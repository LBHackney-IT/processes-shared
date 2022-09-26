using System.Collections.Generic;
using FluentValidation;
using Hackney.Core.Validation;
using Hackney.Shared.Processes.Boundary.Constants;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class FormDataValidator : AbstractValidator<Dictionary<string, object>>
    {
        public FormDataValidator()
        {
            RuleForEach(x => x.Keys).NotXssString().WithErrorCode(ErrorCodes.XssCheckFailure);
            RuleForEach(x => x.Values).NotXssString().WithErrorCode(ErrorCodes.XssCheckFailure);
        }
    }
}