using FluentValidation;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class UpdateProcessQueryValidator : AbstractValidator<UpdateProcessQuery>
    {
        public UpdateProcessQueryValidator()
        {
            RuleFor(x => x.Id).NotNull()
                              .NotEqual(Guid.Empty);
            RuleFor(x => x.ProcessTrigger).NotNull().NotEmpty();
        }
    }
}
