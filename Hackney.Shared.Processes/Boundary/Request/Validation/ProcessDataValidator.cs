using FluentValidation;
using Hackney.Shared.Processes.Domain;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class ProcessDataValidator : AbstractValidator<ProcessData>
    {
        public ProcessDataValidator()
        {
            RuleFor(x => x.FormData).SetValidator(new FormDataValidator());
            RuleForEach(x => x.Documents).NotEqual(Guid.Empty);
        }
    }
}
