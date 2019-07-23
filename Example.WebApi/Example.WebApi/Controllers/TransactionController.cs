using Example.WebApi.BusinessLogic;
using Example.WebApi.DataAccess;
using Example.WebApi.DataAccess.UnitOfWork;
using Example.WebApi.Models.Request;
using Example.WebApi.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Controllers
{
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unit;
        public TransactionBusinessLogic _transactionBusinessLogic;

        public TransactionController()
        {
            this._context = new ApplicationDbContext();
            this._unit = new UnitOfWork(this._context);
            this._transactionBusinessLogic = new TransactionBusinessLogic(this._unit);
        }

        [HttpPost]
        [Route("api/transaction/inquiry")]
        public IActionResult InquiryTransaction([FromBody] RequestTransactionInquiryModel Models)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    var result = _transactionBusinessLogic.InquiryTransaction(Models);

                    if (result.customerID > 0)
                    {
                        return Ok(result);
                    }
                    else return Ok(DataAccess.Common.AppConstants.NotFoundMessage);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState.ValidationState);
            }
        }

        [HttpPost]
        [Route("api/transaction/create")]
        public IActionResult CreateTransaction([FromBody] RequestTransactionCreateModel Models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _transactionBusinessLogic.CreateTransaction(Models);
                    return Ok(Models);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState.ValidationState);
            }
        }

        [HttpPost]
        [Route("api/transaction/update")]
        public IActionResult UpdateTransaction([FromBody] RequestTransactionUpdateModel Models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _transactionBusinessLogic.UpdateTransaction(Models);
                    return Ok(Models);
                }
                catch
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest(ModelState.ValidationState);
            }
        }
    }
}
