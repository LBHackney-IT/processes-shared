using Hackney.Shared.Processes.Domain;
using Hackney.Shared.Processes.Infrastructure;

namespace Hackney.Shared.Processes.Factories
{
    public static class EntityFactory
    {
        public static Process ToDomain(this ProcessesDb entity)
        {
            return new Process
            {
                Id = entity.Id,
                TargetId = entity.TargetId,
                TargetType = entity.TargetType,
                RelatedEntities = entity.RelatedEntities,
                ProcessName = entity.ProcessName,
                CurrentState = entity.CurrentState,
                PreviousStates = entity.PreviousStates,
                VersionNumber = entity.VersionNumber
            };
        }

        public static ProcessesDb ToDatabase(this Process entity)
        {
            return new ProcessesDb
            {
                Id = entity.Id,
                TargetId = entity.TargetId,
                TargetType = entity.TargetType,
                RelatedEntities = entity.RelatedEntities,
                ProcessName = entity.ProcessName,
                CurrentState = entity.CurrentState,
                PreviousStates = entity.PreviousStates,
                VersionNumber = entity.VersionNumber
            };
        }


    }
}
