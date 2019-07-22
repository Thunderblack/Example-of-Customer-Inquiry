using Example.WebApi.DataAccess.Model.Database.Operation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Example.WebApi.DataAccess.Model.Database.Master
{
    [Table("Customers")]
    public class Customers : LogTimeStamp
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public long customerID { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(25)]
        public string email { get; set; }

        [Required]
        [Column(Order = 3)]
        [StringLength(20)]
        public string customerName { get; set; }

        [Required]
        [Column(Order = 4)]
        [StringLength(10)]
        public string mobile { get; set; }

        [Required]
        [Column(Order = 5)]
        [StringLength(1)]
        public string status { get; set; }

        public ICollection<Transactions> transactions { get; set; }
    }
}
