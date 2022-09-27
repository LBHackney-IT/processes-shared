using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Processes.Boundary.Constants;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class UpdateProcessQueryValidator : AbstractValidator<UpdateProcessQuery>
    {
        public UpdateProcessQueryValidator()
        {
            RuleFor(x => x.ProcessName).IsInEnum();
            RuleFor(x => x.Id).NotNull()
                              .NotEqual(Guid.Empty);
            RuleFor(x => x.ProcessTrigger).NotNull().NotEmpty();
            RuleFor(x => x.ProcessTrigger).NotXssString().WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}
