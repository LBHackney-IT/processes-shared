// using FluentValidation;
// using System;
// using Hackney.Shared.Processes.Domain;
//
// namespace Hackney.Shared.Processes.Boundary.Request.Validation
// {
//     public class ProcessDataValidator : AbstractValidator<ProcessData>
//     {
//         public ProcessDataValidator()
//         {
//             RuleForEach(x => x.Documents).NotNull()
//                                          .NotEqual(Guid.Empty);
//         }
//     }
// }
