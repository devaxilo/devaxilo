using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using DevaxiloS.DataAccess.MsSql.CustomModels;
using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Commands;
using DevaxiloS.Infras.Common.Utils;
using DevaxiloS.Infras.Messaging;
using Newtonsoft.Json;

namespace DevaxiloS.Services.Commands.Web.Admin
{
    public class ManageWalletInfoCommand : Command
    {
        public CommandResponse<IEnumerable<ManageWalletInfoResult>> Response { get; set; }

        public ManageWalletInfoCommand(int id) : base(id)
        {

        }
    }

    public class ManageWalletInfoCommandHandler : ICommandHandler<ManageWalletInfoCommand>
    {
        public async Task Execute(ManageWalletInfoCommand command)
        {
            using (var dbContext = new DevaxiloContext())
            {
                List<ManageWalletInfo> lstInfs = await dbContext.ManageWalletInfos.ToListAsync();
                List<ManageWalletInfoResult> lstInfoResults = new List<ManageWalletInfoResult>();
                var intId = await dbContext.SaveChangesAsync();
                if (lstInfs.Count > 0)
                {
                    
                    foreach (var item in lstInfs)
                    {
                        ManageWalletInfoResult objInfoResult = new ManageWalletInfoResult();
                       
                        lstInfoResults.Add(objInfoResult);
                    }
                }

                command.Response = new CommandResponse<IEnumerable<ManageWalletInfoResult>>(lstInfoResults, true, "Info Wallet Doge");

            }
        }
    }
}
