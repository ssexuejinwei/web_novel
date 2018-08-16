namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    [Table("DBTA.READER")]
    public partial class READER
    {
        //[Required(ErrorMessage ="")]
        [Required(ErrorMessage ="±ØÌî")]
        [StringLength(8)]
        public string READERID { get; set; }

        [StringLength(100)]
        public string READERNAME { get; set; }

        [StringLength(1)]
        public string SEX { get; set; }

        [StringLength(100)]
        public string EMAIL { get; set; }

        [StringLength(100)]
        public string PASSWORD { get; set; }

        public decimal? VIPREST { get; set; }

        public decimal? BALANCE { get; set; }

        public decimal? NUMCOLLECTBOOK { get; set; }

        public decimal? MONTHTICKET { get; set; }
    }

   
}
