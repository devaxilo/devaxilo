using System.ComponentModel;

namespace DevaxiloS.Infras.Common.Enums
{
    public enum LotteryTransactionType : byte
    {
        [Description("Set")]
        Set = 1,

        [Description("Bid")]
        Bid = 2
    }

    public enum LotteryTransactionStatus : byte
    {
        [Description("Processing")]
        Processing = 1,

        [Description("Finish")]
        Finish = 5,
    }


    public enum LotteryType : byte
    {
        [Description("Lotto")]
        Lotto = 1,

        [Description("Lottery")]
        Lottery = 2,
    }

    public enum WalletType : byte
    {
        [Description("Doge Coin")]
        DogeCoin = 1
    }

    public enum SysStatus : byte
    {
        [Description("New")]
        New = 1,

        [Description("Activated")]
        Activated = 5,

        [Description("Archived")]
        Deleted = 6,
    }
}
