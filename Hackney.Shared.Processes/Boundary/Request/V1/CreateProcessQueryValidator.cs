using FluentValidation;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.V1.Validation
{
    public class CreateProcessQueryValidator : AbstractValidator<CreateProcess>
    {
        public CreateProcessQueryValidator()
        {
            RuleFor(x => x.TargetId).NotNull()
                                    .NotEqual(Guid.Empty);
            RuleFor(x => x.TargetType).NotNull().IsInEnum();
            RuleFor(x => x.RelatedEntities).NotNull();
            RuleForEach(x => x.RelatedEntities).SetValidator(new RelatedEntityValidator());
            RuleForEach(x => x.Documents).NotNull()
                                         .NotEqual(Guid.Empty);
        }
    }
}
