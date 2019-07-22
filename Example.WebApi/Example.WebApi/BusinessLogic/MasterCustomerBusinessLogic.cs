using Example.WebApi.DataAccess.Common;
using Example.WebApi.DataAccess.Model.Database.Master;
using Example.WebApi.DataAccess.UnitOfWork;
using Example.WebApi.Models.Request;
using Example.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.BusinessLogic
{
    public class MasterCustomerBusinessLogic
    {
        private readonly UnitOfWork _unit;
        public MasterCustomerBusinessLogic(UnitOfWork unit)
        {
            this._unit = unit;
        }

        public ResponseCustomerInquiryModel InquiryTransaction(RequestCustomerInquiryModel model)
        {
            var result = new ResponseCustomerInquiryModel();
            var customer = new Customers();

            try
            {
                // Parse string to Long Variable
                long.TryParse(model.customerID, out long c_id);

                // Find customer by ID, Email
                customer = _unit.MasterCustomerRepository.FindOneOfCustomer(c_id, model.email);

                // Check Customer != Null, If we found null that thrown exception
                if (customer == null) throw new Exception("Customer Not found");
                else
                {
                    result = result.ConvertDbModelToResponseModel(customer);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception on {DateTime.Now} with Message {ex.Message}");
            }

            return result;
        }

        public void CreateCustomer(RequestCustomerCreateModel model)
        {
            try
            {
                long.TryParse(model.customerID, out long customerID);
                var cModel = new Customers
                {
                    customerID = customerID,
                    customerName = model.customerName,
                    email = model.email,
                    mobile = model.mobile,
                    status = model.status,
                };
                _unit.MasterCustomerRepository.Create(cModel);

                _unit.SaveTransactionScope();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception on {DateTime.Now} with Message {ex.Message}");
            }
        }

        public void UpdateCustomer(RequestCustomerUpdateModel model)
        {
            try
            {
                long.TryParse(model.customerID, out long customerID);
                var findOne = _unit.MasterCustomerRepository.FindOneOfCustomer(customerID, string.Empty);
                if (findOne != null)
                {
                    findOne.customerName = model.customerName;
                    findOne.mobile = model.mobile;
                    findOne.status = model.status;

                    _unit.MasterCustomerRepository.Update(findOne);

                    _unit.SaveTransactionScope();
                }
                else
                {
                    throw new Exception("Not Found");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception on {DateTime.Now} with Message {ex.Message}");
            }
        }
    }
}
