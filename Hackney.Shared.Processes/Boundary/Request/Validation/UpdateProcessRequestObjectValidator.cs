using FluentValidation;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class UpdateProcessRequestObjectValidator : AbstractValidator<UpdateProcessRequestObject>
    {
        public UpdateProcessRequestObjectValidator()
        {
            RuleFor(x => x.FormData).NotNull();
            RuleFor(x => x.FormData).SetValidator(new FormDataValidator());
            RuleForEach(x => x.Documents).NotEqual(Guid.Empty);
        }
    }
}
