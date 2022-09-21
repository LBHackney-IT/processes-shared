using FluentValidation;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class ProcessQueryValidator : AbstractValidator<ProcessQuery>
    {
        public ProcessQueryValidator()
        {
            RuleFor(x => x.Id).NotNull()
                              .NotEqual(Guid.Empty);
        }
    }
}
