using DevaxiloS.DataAccess.MsSql.EntityFramework;
using DevaxiloS.Infras.Common.Utils;
using Newtonsoft.Json;

namespace DevaxiloS.DataAccess.MsSql.CustomModels
{
    public class ManageWalletInfoResult
    {
        public int Id { get; set; }
        public string HashInfo { get; set; }
        public int DataType { get; set; }
        public WalletInfo WalletInfo { set; get; }

        public void FromWalletInfo(ManageWalletInfo objInfo)
        {
            Id = objInfo.Id;
            DataType = objInfo.DataType;
            HashInfo = objInfo.HashInfo;
            string jsonObject = "";
            /*Giai ma chuoi duoc Hash*/
            jsonObject = CryptoUtils.Decrypt("WalletDoge", HashInfo, false);
            /*Parse json to object*/
            WalletInfo = JsonConvert.DeserializeObject<WalletInfo>(jsonObject);
        }

        public void HashWalletInfo()
        {
            string jsonObject = "";
            jsonObject = JsonConvert.SerializeObject(WalletInfo);
            HashInfo = CryptoUtils.Encrypt("WalletDoge", jsonObject, false);
        }
    }

    public class WalletInfo
    {
        public string APIKey { get; set; }
        public string LabelKey { get; set; }
        public string AddressKey { get; set; }
    }
}
