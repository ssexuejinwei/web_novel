namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.WRITER")]
    public partial class WRITER
    {
        [StringLength(8)]
        public string WRITERID { get; set; }

        [StringLength(100)]
        public string WRITERNAME { get; set; }

        [StringLength(1)]
        public string SEX { get; set; }

        [StringLength(100)]
        public string EMAI { get; set; }

        [StringLength(100)]
        public string PASSWORD { get; set; }

        public decimal? WRITERLEVEL { get; set; }

        public decimal? NUMPRODUCTION { get; set; }

        public decimal? NUMFANS { get; set; }

        public decimal? MONTHTICKET { get; set; }
    }
}
