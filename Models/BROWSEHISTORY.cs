namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.BROWSEHISTORY")]
    public partial class BROWSEHISTORY
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string READERID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string BOOKID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string CHAPTERID { get; set; }

        [StringLength(100)]
        public string TIME { get; set; }
    }
}
