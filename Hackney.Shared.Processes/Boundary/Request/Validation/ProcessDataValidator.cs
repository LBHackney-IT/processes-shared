using FluentValidation;
using Hackney.Shared.Processes.Domain;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class ProcessDataValidator : AbstractValidator<ProcessData>
    {
        public ProcessDataValidator()
        {
            RuleForEach(x => x.Documents).NotNull()
                                         .NotEqual(Guid.Empty);
        }
    }
}
