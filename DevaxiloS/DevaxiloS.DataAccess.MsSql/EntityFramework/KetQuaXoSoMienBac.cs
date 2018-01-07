using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevaxiloS.DataAccess.MsSql.EntityFramework
{
    [Table("KetQuaXoSoMienBac")]
    public class KetQuaXoSoMienBac
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        [StringLength(10)]
        public string G0 { get; set; }
        [StringLength(10)]
        public string G1 { get; set; }
        [StringLength(10)]
        public string G21 { get; set; }
        [StringLength(10)]
        public string G22 { get; set; }
        [StringLength(10)]
        public string G31 { get; set; }
        [StringLength(10)]
        public string G32 { get; set; }
        [StringLength(10)]
        public string G33 { get; set; }
        [StringLength(10)]
        public string G34 { get; set; }
        [StringLength(10)]
        public string G35 { get; set; }
        [StringLength(10)]
        public string G36 { get; set; }
        [StringLength(10)]
        public string G41 { get; set; }
        [StringLength(10)]
        public string G42 { get; set; }
        [StringLength(10)]
        public string G43 { get; set; }
        [StringLength(10)]
        public string G44 { get; set; }
        [StringLength(10)]
        public string G51 { get; set; }
        [StringLength(10)]
        public string G52 { get; set; }
        [StringLength(10)]
        public string G53 { get; set; }
        [StringLength(10)]
        public string G54 { get; set; }
        [StringLength(10)]
        public string G55 { get; set; }
        [StringLength(10)]
        public string G56 { get; set; }
        [StringLength(10)]
        public string G61 { get; set; }
        [StringLength(10)]
        public string G62 { get; set; }
        [StringLength(10)]
        public string G63 { get; set; }
        [StringLength(10)]
        public string G71 { get; set; }
        [StringLength(10)]
        public string G72 { get; set; }
        [StringLength(10)]
        public string G73 { get; set; }
        [StringLength(10)]
        public string G74 { get; set; }
        [StringLength(100)]
        public string LoCuoi { get; set; }
        [StringLength(10)]
        public string De { get; set; }
    }
}