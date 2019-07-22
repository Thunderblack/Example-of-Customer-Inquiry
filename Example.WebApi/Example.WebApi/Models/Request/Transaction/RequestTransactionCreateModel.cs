using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.WebApi.Models.Request
{
    public class RequestTransactionCreateModel
    {
        public DateTime date { get; set; }
        public decimal amount { get; set; }
        public string currency { get; set; }
        public string status { get; set; }
        public string customerID { get; set; }

        public class RequestTransactionCreateModelValidator : AbstractValidator<RequestTransactionCreateModel>
        {
            public RequestTransactionCreateModelValidator()
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

                RuleFor(r => r.date)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .Must(r => !r.Equals(default(DateTime)))
                              .WithMessage($"Invalid Date")
                              .NotEmpty()
                              .WithMessage($"Field date had required!");

                RuleFor(r => r.amount)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .ScalePrecision(15,2)
                              .WithMessage($"Invalid Amount")
                              .NotEmpty()
                              .WithMessage($"Field amount had required!");

                RuleFor(r => r.currency)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .MaximumLength(3)
                              .WithMessage($"Maximum of field currency is 3 characters")
                              .NotEmpty()
                              .WithMessage($"Field currency had required!");

                RuleFor(r => r.status)
                              .Cascade(CascadeMode.StopOnFirstFailure)
                              .MaximumLength(10)
                              .WithMessage($"Maximum of field status is 10 characters")
                              .NotEmpty()
                              .WithMessage($"Field status had required!");
            }

            private bool ValidInputAtLeast(RequestTransactionCreateModel model)
            {
                if (model.date != default(DateTime)
                    && model.amount != default(decimal)
                    && string.IsNullOrEmpty(model.currency)
                    && string.IsNullOrEmpty(model.customerID)
                    && string.IsNullOrEmpty(model.status))
                    return false;
                else
                    return true;
            }
        }
    }
}
