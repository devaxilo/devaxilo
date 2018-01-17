using System;
using System.Data.Entity.Migrations;
using System.Linq;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Services.Commands.Web.Dashboard;
using Quartz;

namespace DevaxiloS.Services.Commands.Web.Trigger
{
    public class LayKetQuaXoSoMienBacJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (var dbContext = new DevaxiloContext())
            {
                var objKetQua = dbContext.KetQuaXoSoMienBacs.OrderByDescending(u => u.Id).Take(1).FirstOrDefault();
                if (objKetQua != null && objKetQua.CreatedDate.Date != DateTime.UtcNow.Date)
                {
                    objKetQua = null;
                }
                /*Lay ket qua*/
                KetQuaUtils fnKetQua = new KetQuaUtils();
                var objKetQuaHt = fnKetQua.AnalysisLotteryFromMinhNgoc(DateTime.UtcNow.Date, objKetQua);
                if (objKetQuaHt != null)
                {
                    dbContext.KetQuaXoSoMienBacs.AddOrUpdate(objKetQuaHt);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}