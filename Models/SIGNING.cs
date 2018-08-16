namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.SIGNING")]
    public partial class SIGNING
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string WRITERID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(100)]
        public string NAME { get; set; }

        [StringLength(20)]
        public string STARTTIME { get; set; }

        [StringLength(20)]
        public string ENDTIME { get; set; }
    }
}
