namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("AccountLogin")]
    public class AccountLogin
    {
        public int Id { get; set; }

        public int AccId { get; set; }

        [Required]
        [StringLength(100)]
        public string HashLoginCode { get; set; }

        public DateTime ExpiredAt { get; set; }
    }
}
