using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Request
{
    public class RequestCustomerUpdateModel
    {
        public string customerID { get; set; }
        public string customerName { get; set; }
        public string mobile { get; set; }
        public string status { get; set; }

        public class RequestCustomerUpdateModelValidator : AbstractValidator<RequestCustomerUpdateModel>
        {
            public RequestCustomerUpdateModelValidator()
            {
                RuleFor(x => x).Must(ValidInputAtLeast)
                               .WithMessage("Not validate with blank request");

                When(r => !string.IsNullOrEmpty(r.customerID), () =>
                {
                    RuleFor(r => r.customerID)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .MaximumLength(10)
                                  .WithMessage($"Maximum of field customerID is 10 characters");

                    RuleFor(r => r.customerID)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .Must(r => long.TryParse(r, out long o))
                                  .WithMessage("Invalid Customer ID");
                });

                RuleFor(r => r.customerName)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .MaximumLength(20)
                              .WithMessage($"Maximum of field customerName is 20 characters")
                              .NotEmpty()
                              .WithMessage($"Field customerName had required!");

                RuleFor(r => r.mobile)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .MaximumLength(10)
                              .WithMessage($"Maximum of field mobile is 10 characters")
                              .NotEmpty()
                              .WithMessage($"Field mobile had required!");

                RuleFor(r => r.status)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .MaximumLength(10)
                              .WithMessage($"Maximum of field status is 10 characters")
                              .NotEmpty()
                              .WithMessage($"Field status had required!");
            }

            private bool ValidInputAtLeast(RequestCustomerUpdateModel model)
            {
                if (string.IsNullOrEmpty(model.customerID)
                    && string.IsNullOrEmpty(model.customerName)
                    && string.IsNullOrEmpty(model.mobile)
                    && string.IsNullOrEmpty(model.status))
                    return false;
                else
                    return true;
            }
        }
    }
}
