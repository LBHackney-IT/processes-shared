using FluentValidation;
using Hackney.Shared.Processes.Domain;
using System;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class RelatedEntityValidator : AbstractValidator<RelatedEntity>
    {
        public RelatedEntityValidator()
        {
            RuleFor(x => x.Id).NotNull().NotEqual(Guid.Empty);
            RuleFor(x => x.TargetType).NotNull();
        }
    }
}
