using FluentValidation;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using Hackney.Shared.Processes.Domain;
using System;
using System.Linq;

namespace Hackney.Shared.Processes.Boundary.Request.V2.Validation
{
    public class CreateProcessQueryValidator : AbstractValidator<CreateProcess>
    {
        public CreateProcessQueryValidator()
        {
            var targetTypes = new TargetType[] { TargetType.asset, TargetType.person, TargetType.tenure };

            RuleFor(x => x.TargetId).NotNull()
                                    .NotEqual(Guid.Empty);
            RuleFor(x => x.TargetType).NotNull()
                                      .IsInEnum();

            RuleFor(x => x.RelatedEntities).NotNull()
                                           .NotEmpty()
                                           .Must(x => x?.Select(x => x.TargetType).Intersect(targetTypes).Count() == targetTypes.Count()); // must contain all 3 targetTypes
            RuleFor(x => x).Must(process => process.RelatedEntities?.Any(x => x.TargetType == process.TargetType && x.Id == process.TargetId) ?? true);
            RuleForEach(x => x.RelatedEntities).SetValidator(new RelatedEntityValidator());

            RuleFor(x => x.PatchAssignment).NotNull()
                                           .SetValidator(new PatchAssignmentValidator());
            RuleForEach(x => x.Documents).NotNull()
                                         .NotEqual(Guid.Empty);
        }
    }
}
