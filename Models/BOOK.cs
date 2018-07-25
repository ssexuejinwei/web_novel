namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.BOOK")]
    public partial class BOOK
    {
        [StringLength(20)]
        public string BOOKID { get; set; }

        [StringLength(100)]
        public string BOOKNAME { get; set; }

        [StringLength(20)]
        public string WRITERID { get; set; }

        [StringLength(30)]
        public string STARTTIME { get; set; }

        [StringLength(30)]
        public string UPDATETIME { get; set; }

        public decimal? DOWNLOADNUM { get; set; }

        public decimal? COLLECTNUM { get; set; }

        public decimal? IFEND { get; set; }

        [StringLength(100)]
        public string DOWNLOADLINK { get; set; }

        public decimal? PRICEPERCHAPTER { get; set; }
    }
}
