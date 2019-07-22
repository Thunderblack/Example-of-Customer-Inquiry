using Example.WebApi.DataAccess.Model.Database.Master;
using Example.WebApi.DataAccess.Model.Database.Operation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Response
{
    public class ResponseTransactionInquiryModel
    {
        public long customerID { get; set; }
        public string email { get; set; }
        public string customerName { get; set; }
        public string mobile { get; set; }
        public string status { get; set; }

        public List<ResponseTransactionViewModel> transactions { get; set; }

        public ResponseTransactionInquiryModel ConvertToResponseModel(Customers customer, List<Transactions> transactions)
        {
            return new ResponseTransactionInquiryModel
            {
                customerID = customer.customerID,
                customerName = customer?.customerName,
                email = customer?.email,
                mobile = customer?.mobile,
                status = customer?.status,
                transactions = JsonConvert.DeserializeObject<List<ResponseTransactionViewModel>>(JsonConvert.SerializeObject(transactions))
        };
        }
    }
}
