namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.COLLECT")]
    public partial class COLLECT
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string READERID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string BOOKID { get; set; }
    }
}
