using Example.WebApi.DataAccess.Common;
using Example.WebApi.DataAccess.Model.Database.Master;
using Example.WebApi.DataAccess.Model.Database.Operation;
using Example.WebApi.DataAccess.UnitOfWork;
using Example.WebApi.Models.Request;
using Example.WebApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.BusinessLogic
{
    public class TransactionBusinessLogic
    {
        private readonly UnitOfWork _unit;
        public TransactionBusinessLogic(UnitOfWork unit)
        {
            this._unit = unit;
        }

        public ResponseTransactionInquiryModel InquiryTransaction(RequestTransactionInquiryModel model)
        {
            var result = new ResponseTransactionInquiryModel();
            var transactions = new List<Transactions>();
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
                    transactions = _unit.TransactionRepository.FindRecentlyTransaction(customer.customerID)
                                        .OrderBy(x => x.id)
                                        .Select(x => x)
                                        .ToList();

                    // Check Transaction != Null, If we found null that thrown exception
                    if (transactions == null) throw new Exception("Transaction Not found");

                    result = result.ConvertToResponseModel(customer, transactions);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception on {DateTime.Now} with Message {ex.Message}");
            }

            return result;
        }

        public void CreateTransaction(RequestTransactionCreateModel model)
        {
            try
            {
                // Convert Customer ID to Long Type
                long.TryParse(model.customerID, out long customerID);

                var cModel = new Transactions
                {
                    date = model.date,
                    customerID = customerID,
                    amount = model.amount,
                    currency = model.currency,
                    status = model.status,
                };
                _unit.TransactionRepository.Create(cModel);

                _unit.SaveTransactionScope();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception on {DateTime.Now} with Message {ex.Message}");
            }
        }

        public void UpdateTransaction(RequestTransactionUpdateModel model)
        {
            try
            {
                var findOne = _unit.TransactionRepository.FindTransaction(model.id);
                if (findOne != null)
                {
                    findOne.date = model.date;
                    findOne.amount = model.amount;
                    findOne.currency = model.currency;
                    findOne.status = model.status;

                    _unit.TransactionRepository.Update(findOne);

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
