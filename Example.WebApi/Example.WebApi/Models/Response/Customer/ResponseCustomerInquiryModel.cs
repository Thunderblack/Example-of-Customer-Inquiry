using Example.WebApi.DataAccess.Model.Database.Master;
using Example.WebApi.DataAccess.Model.Database.Operation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Response
{
    public class ResponseCustomerInquiryModel
    {
        public long customerID { get; set; }
        public string email { get; set; }
        public string customerName { get; set; }
        public string mobile { get; set; }
        public string status { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDate { get; set; }
        public string updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }

        public ResponseCustomerInquiryModel ConvertDbModelToResponseModel(Customers customer)
        {
            return new ResponseCustomerInquiryModel
            {
                customerID = customer.customerID,
                email = customer.email,
                customerName = customer.customerName,
                mobile = customer.mobile,
                status = customer.status,
                createdBy = customer.CreatedBy,
                createdDate = customer.CreatedDate,
                updatedBy = customer.UpdatedBy,
                updatedDate = customer.UpdatedDate
            };
        }
    }
}
