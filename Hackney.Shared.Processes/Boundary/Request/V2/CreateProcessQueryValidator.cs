using System;
using System.Linq;
using FluentValidation;

namespace Hackney.Shared.Processes.Boundary.Request.V2.Validation
{
    public class CreateProcessQueryValidator : AbstractValidator<CreateProcess>
    {
        public CreateProcessQueryValidator()
        {
            RuleFor(x => x.TargetId).NotNull()
                                    .NotEqual(Guid.Empty);
            RuleFor(x => x.TargetType).NotNull()
                                      .IsInEnum();
            RuleFor(x => x.RelatedEntities).SetValidator(x => new RelatedEntitiesValidator(x));
            RuleFor(x => x.PatchAssignment).NotNull()
                                           .SetValidator(new PatchAssignmentValidator());
            RuleForEach(x => x.Documents).NotNull()
                                         .NotEqual(Guid.Empty);
        }
    }
}
