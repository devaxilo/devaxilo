using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{

    [Table("ManageWalletInfo")]
    public class ManageWalletInfo
    {
        public int Id { get; set; }
        [StringLength(500)]
        public string HashInfo { get; set; }
        public int DataType { get; set; }
    }
}
