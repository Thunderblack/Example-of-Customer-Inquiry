using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Response
{
    public class ResponseTransactionViewModel
    {
        public long id { get; set; }
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
    }
}
