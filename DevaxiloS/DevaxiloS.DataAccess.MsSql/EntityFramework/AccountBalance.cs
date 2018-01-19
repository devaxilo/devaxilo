using System.ComponentModel.DataAnnotations.Schema;

namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{
    [Table("AccountBalance")]
    public class AccountBalance
    {
        public int Id { get; set; }

        public int AccId { get; set; }

        [Column(TypeName = "money")]
        public decimal Balance { get; set; }

        [Column(TypeName = "money")]
        public decimal HoldBalance { get; set; }

        public byte Status { get; set; }
    }
}
