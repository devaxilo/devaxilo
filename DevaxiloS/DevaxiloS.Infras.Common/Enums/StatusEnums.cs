using System.ComponentModel;

namespace DevaxiloS.Infras.Common.Enums
{
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
