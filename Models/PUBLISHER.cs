namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DBTA.PUBLISHER")]
    public partial class PUBLISHER
    {
        [Key]
        [StringLength(100)]
        public string PUBLISHERNAME { get; set; }

        [StringLength(100)]
        public string PUBLISHERLINK { get; set; }
    }
}
