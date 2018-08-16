namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.REVIEW")]
    public partial class REVIEW
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string COMMENTID { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal FLOORNUMBER { get; set; }

        [StringLength(20)]
        public string BOOKID { get; set; }

        [StringLength(20)]
        public string CHAPTERID { get; set; }

        [StringLength(20)]
        public string ID { get; set; }

        [StringLength(300)]
        public string CONTENT { get; set; }

        [StringLength(30)]
        public string REVIEWDATE { get; set; }
    }
}
