using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Request
{
    public class RequestCustomerCreateModel
    {
        public string customerID { get; set; }
        public string email { get; set; }
        public string customerName { get; set; }
        public string mobile { get; set; }
        public string status { get; set; }

        public class RequestCustomerCreateModelValidator : AbstractValidator<RequestCustomerCreateModel>
        {
            public RequestCustomerCreateModelValidator()
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

                When(r => !string.IsNullOrEmpty(r.email), () =>
                {
                    RuleFor(r => r.email)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .MaximumLength(25)
                                  .WithMessage($"Maximum of field email is 25 characters");

                    RuleFor(r => r.email)
                                  .Cascade(CascadeMode.StopOnFirstFailure)
                                  .EmailAddress()
                                  .WithMessage("Invalid Email");
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

            private bool ValidInputAtLeast(RequestCustomerCreateModel model)
            {
                if (string.IsNullOrEmpty(model.customerID) 
                    && string.IsNullOrEmpty(model.email)
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
