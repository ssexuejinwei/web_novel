namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.CHAPTER")]
    public partial class CHAPTER
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string BOOKID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string CHAPTERID { get; set; }

        [StringLength(200)]
        public string CHAPTERNAME { get; set; }

        [StringLength(200)]
        public string CHAPTERCONTENT { get; set; }
    }
}
