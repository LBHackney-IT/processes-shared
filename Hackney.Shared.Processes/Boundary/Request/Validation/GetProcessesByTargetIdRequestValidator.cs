// using FluentValidation;
// using System;
//
// namespace Hackney.Shared.Processes.Boundary.Request.Validation
// {
//     public class GetProcessesByTargetIdRequestValidator : AbstractValidator<GetProcessesByTargetIdRequest>
//     {
//         public GetProcessesByTargetIdRequestValidator()
//         {
//             RuleFor(x => x.TargetId).NotNull().NotEqual(Guid.Empty);
//         }
//     }
// }
