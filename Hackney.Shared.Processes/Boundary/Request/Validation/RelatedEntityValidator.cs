using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Processes.Boundary.Constants;
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
            RuleFor(x => x.Description).NotXssString()
                                       .WithErrorCode(ErrorCodes.XssCheckFailure)
                                       .When(x => !String.IsNullOrEmpty(x.Description));
        }
    }
}
