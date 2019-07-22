using Example.WebApi.DataAccess.Model.Database.Master;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Example.WebApi.DataAccess.Model.Database.Operation
{
    [Table("Transactions")]
    public class Transactions : LogTimeStamp
    {
        [ForeignKey("CustomerRefID")]
        public Customers customers { get; set; }

        [Key]
        [Required]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        [Required]
        [Column(Order = 2)]
        public DateTime date { get; set; }

        [Required]
        [Column(TypeName = "numeric(15,2)", Order = 3)]
        public decimal amount { get; set; }

        [Required]
        [Column(Order = 4)]
        [StringLength(3)]
        public string currency { get; set; }

        [Required]
        [Column(Order = 5)]
        public long customerID { get; set; }

        [Required]
        [Column(Order = 6)]
        [StringLength(1)]
        public string status { get; set; }
    }
}
