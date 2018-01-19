namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("LotteryTransaction")]
    public class LotteryTransaction
    {
        public int Id { get; set; }

        public Guid UUID { get; set; }

        public int UserId { get; set; }

        public int? ParentId { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }

        public int LotteryNumber { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? FinishedAt { get; set; }

        public byte LotteryType { get; set; }
        public byte WalletType { get; set; }
        public byte TransactionType { get; set; }
        public byte Status { get; set; }
    }
}
