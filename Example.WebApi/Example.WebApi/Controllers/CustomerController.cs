using Example.WebApi.BusinessLogic;
using Example.WebApi.DataAccess;
using Example.WebApi.DataAccess.UnitOfWork;
using Example.WebApi.Models.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unit;
        public MasterCustomerBusinessLogic _masterCustomerBusinessLogic;

        public CustomerController()
        {
            this._context = new ApplicationDbContext();
            this._unit = new UnitOfWork(this._context);
            this._masterCustomerBusinessLogic = new MasterCustomerBusinessLogic(this._unit);
        }

        [HttpPost]
        [Route("api/customer/inquiry")]
        public IActionResult InquiryCustomer([FromBody] RequestCustomerInquiryModel Models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _masterCustomerBusinessLogic.InquiryTransaction(Models);

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
        [Route("api/customer/create")]
        public IActionResult CreateCustomer([FromBody] RequestCustomerCreateModel Models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _masterCustomerBusinessLogic.CreateCustomer(Models);
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
        [Route("api/customer/update")]
        public IActionResult UpdateCustomer([FromBody] RequestCustomerUpdateModel Models)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _masterCustomerBusinessLogic.UpdateCustomer(Models);
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
