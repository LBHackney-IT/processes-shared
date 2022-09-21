using FluentValidation;

namespace Hackney.Shared.Processes.Boundary.Request.Validation
{
    public class UpdateProcessByIdRequestObjectValidator : AbstractValidator<UpdateProcessByIdRequestObject>
    {
        public UpdateProcessByIdRequestObjectValidator()
        {
            RuleFor(x => x.ProcessData).SetValidator(new ProcessDataValidator());
        }
    }
}
