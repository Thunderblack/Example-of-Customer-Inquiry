using Example.WebApi.DataAccess.Model.Database.Operation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace Example.WebApi.DataAccess.Model.Database.Master
{
    [Table("Customers")]
    public class Customers : LogTimeStamp
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long customerID { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(25)]
        public string email { get; set; }

        [Required]
        [Column(Order = 3)]
        [StringLength(30)]
        public string customerName { get; set; }

        [Required]
        [Column(Order = 4)]
        [StringLength(10)]
        public string mobile { get; set; }

        [Required]
        [Column(Order = 5)]
        [StringLength(10)]
        public string status { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public ICollection<Transactions> transactions { get; set; }
    }
}
