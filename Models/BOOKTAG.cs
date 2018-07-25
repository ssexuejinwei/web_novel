namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.BOOKTAG")]
    public partial class BOOKTAG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(8)]
        public string BOOKID { get; set; }

        [Key]
        [Column("BOOKTAG", Order = 1)]
        [StringLength(100)]
        public string BOOKTAG1 { get; set; }
    }
}
