using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Example.WebApi.DataAccess.Model.Database.Master
{
    [Table("TransactionsStatus")]
    public class TransactionsStatus
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        [StringLength(1)]
        public string code { get; set; }

        [Required]
        [StringLength(20)]
        public string description { get; set; }
    }
}
