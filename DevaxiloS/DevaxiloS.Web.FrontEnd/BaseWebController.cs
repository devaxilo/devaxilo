using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DevaxiloS.Infras.Messaging;
using DevaxiloS.Services.Configuration;

namespace DevaxiloS.Web.FrontEnd
{
    public interface IBaseWebController
    {
    }

    public class BaseWebController : Controller, IBaseWebController
    {
        protected ICommandBus CommandBus => ServiceLocator.Services.CommandBus;

        protected JsonResult SuccessToClient(string message, string jsonExtra = null)
        {
            return Json(new ResponseViewModel
            {
                IsError = false,
                Message = message,
                JsonExtra = jsonExtra
            });
        }

        protected JsonResult ErrorToClient(string message)
        {
            return Json(new ResponseViewModel
            {
                IsError = true,
                Message = message
            });
        }

        protected JsonResult ErrorModelToClient()
        {
            var validationErrors = new List<ValidationResult>();
            foreach (var key in ModelState.Keys)
            {
                if (ModelState.IsValidField(key)) continue;
                var errorMessage = ModelState[key].Errors[0].ErrorMessage;
                if (string.IsNullOrEmpty(errorMessage))
                {
                    errorMessage = "General Error";
                }

                validationErrors.Add(new ValidationResult(key, errorMessage));
            }

            return Json(new ResponseViewModel
            {
                IsError = true,
                ValidationErrors = validationErrors.AsQueryable().ToDictionary(k => k.Property, v => v.ErrorMessage)
            });
        }
    }

    public class ValidationResult
    {
        public string Property { get; set; }
        public string ErrorMessage { get; set; }
        public ValidationResult(string property, string errorMessage)
        {
            if (string.IsNullOrWhiteSpace(property))
            {
                throw new ArgumentNullException(nameof(Property));
            }

            Property = property;
            ErrorMessage = errorMessage;
        }
    }

    public class ResponseViewModel
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
        public Dictionary<string, string> ValidationErrors { get; set; }
        public string JsonExtra { get; set; }
    }
}