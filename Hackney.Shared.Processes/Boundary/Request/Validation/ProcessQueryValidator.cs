// using FluentValidation;
// using System;
// using Hackney.Shared.Processes.Boundary.Request;
//
// namespace Hackney.Shared.Processes.Boundary.Request.Validation
// {
//     public class ProcessQueryValidator : AbstractValidator<ProcessQuery>
//     {
//         public ProcessQueryValidator()
//         {
//             RuleFor(x => x.Id).NotNull()
//                               .NotEqual(Guid.Empty);
//         }
//     }
// }
