using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Request
{
    public class RequestCustomerInquiryModel
    {
        public string customerID { get; set; }
        public string email { get; set; }

        public class RequestCustomerInquiryModelValidator : AbstractValidator<RequestCustomerInquiryModel>
        {
            public RequestCustomerInquiryModelValidator()
            {
                RuleFor(x => x).Must(ValidInputAtLeast)
                              .WithMessage("No inquiry criteria");

                When(r => !string.IsNullOrEmpty(r.customerID), () =>
                {
                    RuleFor(r => r.customerID)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .MaximumLength(10)
                                  .WithMessage("Invalid Customer ID");

                    RuleFor(r => r.customerID)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .Must(r => long.TryParse(r, out long o))
                                  .WithMessage("Invalid Customer ID");
                });

                When(r => !string.IsNullOrEmpty(r.email), () =>
                {
                    RuleFor(r => r.email)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .MaximumLength(25)
                                  .WithMessage("Invalid Email");

                    RuleFor(r => r.email)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .EmailAddress()
                                  .WithMessage("Invalid Email");
                });
            }

            private bool ValidInputAtLeast(RequestCustomerInquiryModel model)
            {
                if (string.IsNullOrEmpty(model.customerID) && string.IsNullOrEmpty(model.email))
                    return false;
                else
                    return true;
            }
        }
    }
}
