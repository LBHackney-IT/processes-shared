using System;
using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Processes.Boundary.Constants;
using Hackney.Shared.Processes.Domain;

namespace Hackney.Shared.Processes.Boundary.Request.V2.Validation
{
    public class PatchAssignmentValidator : AbstractValidator<PatchAssignment>
    {
        public PatchAssignmentValidator()
        {
            RuleFor(x => x.PatchId).NotNull().NotEqual(Guid.Empty);
            RuleFor(x => x.PatchName).NotNull()
                                     .NotEmpty();
            RuleFor(x => x.PatchName).NotXssString()
                                     .WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleFor(x => x.ResponsibleEntityId).NotNull().NotEqual(Guid.Empty);
            RuleFor(x => x.ResponsibleName).NotNull().NotEmpty();
            RuleFor(x => x.ResponsibleName).NotXssString()
                                     .WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}