using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using Hackney.Shared.Processes.Domain;

namespace Hackney.Shared.Processes.Boundary.Request.V2.Validation
{
    public class RelatedEntitiesValidator : AbstractValidator<List<RelatedEntity>>
    {
        public RelatedEntitiesValidator(CreateProcess request)
        {
            var targetTypes = Enum.GetValues(typeof(TargetType)).Cast<TargetType>();

            RuleFor(x => x).NotNull()
                           .NotEmpty()
                           .Must(x => x.Select(x => x.TargetType).Intersect(targetTypes).Count() == targetTypes.Count())
                           .WithMessage($"RelatedEntities must contain all of the following target types: [{String.Join(", ", targetTypes)}].");
            RuleFor(x => x).Must(x => x.Any(x => x.Id == request.TargetId && x.TargetType == request.TargetType))
                           .WithMessage($"RelatedEntities must contain object with targetId: {request.TargetId} and targetType: {request.TargetType}.");

            RuleForEach(x => x).SetValidator(new RelatedEntityValidator());
        }
    }
}