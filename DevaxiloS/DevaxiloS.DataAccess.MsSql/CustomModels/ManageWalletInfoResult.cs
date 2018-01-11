using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevaxiloS.DataAccess.MsSql.CustomModels
{
    public class ManageWalletInfoResult
    {
        public int Id { get; set; }
        public string HashInfo { get; set; }
        public int DataType { get; set; }
        public WalletInfo WalletInfo { set; get; }
    }

    public class WalletInfo
    {
        public string APIKey { get; set; }
        public string LabelKey { get; set; }
        public string AddressKey { get; set; }
    }
}
