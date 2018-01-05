namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Account")]
    public class Account
    {
        public int Id { get; set; }

        public Guid UUID { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string NickName { get; set; }

        [StringLength(20)]
        public string Phone { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(50)]
        public string HashPassword { get; set; }

        public DateTime CreatedAt { get; set; }

        public byte Status { get; set; }

        public bool EnableTransferAuthen { get; set; }

        [StringLength(50)]
        public string ActivateCode { get; set; }
    }
}
