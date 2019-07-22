using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Example.WebApi.DataAccess.Model.Database
{
    public class LogTimeStamp
    {
        [Required]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}
