using DevaxiloS.Infras.Common.Enums;

namespace DevaxiloS.Services.DomainModels.Lottery
{
    public class SetLotteryRequest : BaseWebRequest
    {
        public byte[] Numbers { get; set; }
        public decimal Amount { get; set; }
        public LotteryType LotteryType { get; set; }
        public WalletType WalletType { get; set; }
    }
}
