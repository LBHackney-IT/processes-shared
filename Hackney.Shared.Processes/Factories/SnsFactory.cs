using Hackney.Core.JWT;
using Hackney.Core.Sns;
using Hackney.Shared.Processes.Domain;
using Hackney.Shared.Processes.Infrastructure;
using Hackney.Shared.Processes.Sns;
using System;
using System.Collections.Generic;

namespace Hackney.Shared.Processes.Factories
{
    public static class SnsFactory
    {
        public static EntityEventSns CreateProcessStartedEvent(this Process process, Token token)
        {
            return new EntityEventSns
            {
                CorrelationId = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                EntityId = process.Id,
                Id = Guid.NewGuid(),
                EventType = EventConstants.PROCESS_STARTED_EVENT,
                Version = EventConstants.V1_VERSION,
                SourceDomain = EventConstants.SOURCE_DOMAIN,
                SourceSystem = EventConstants.SOURCE_SYSTEM,
                EventData = new EventData
                {
                    NewData = process
                },
                User = new User { Name = token.Name, Email = token.Email }
            };
        }

        public static EntityEventSns CreateProcessStartedAgainstEntityEvent(this Process process, Token token, string eventType)
        {
            return new EntityEventSns
            {
                CorrelationId = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                EntityId = process.TargetId,
                Id = Guid.NewGuid(),
                EventType = eventType,
                Version = EventConstants.V1_VERSION,
                SourceDomain = EventConstants.SOURCE_DOMAIN,
                SourceSystem = EventConstants.SOURCE_SYSTEM,
                EventData = new EventData
                {
                    NewData = new ProcessStartedAgainstEntityData
                    {
                        Id = process.Id,
                        ProcessName = process.ProcessName
                    }
                },
                User = new User { Name = token.Name, Email = token.Email }
            };
        }

        public static EntityEventSns ProcessUpdated(this UpdateEntityResult<ProcessState> updateResult, Guid id, Token token)
        {
            return new EntityEventSns
            {
                CorrelationId = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                EntityId = id,
                Id = Guid.NewGuid(),
                EventType = EventConstants.PROCESS_UPDATED_EVENT,
                Version = EventConstants.V1_VERSION,
                SourceDomain = EventConstants.SOURCE_DOMAIN,
                SourceSystem = EventConstants.SOURCE_SYSTEM,
                EventData = new EventData
                {
                    OldData = updateResult.OldValues,
                    NewData = updateResult.NewValues
                },
                User = new User
                {
                    Name = token.Name,
                    Email = token.Email
                }
            };
        }

        public static EntityEventSns ProcessStateUpdated(this Stateless.StateMachine<string, string>.Transition transition,
                                                         Dictionary<string, object> stateData,
                                                         Token token,
                                                         string eventType)
        {
            var triggerData = transition.Parameters[0] as ProcessTrigger;

            return new EntityEventSns
            {
                CorrelationId = Guid.NewGuid(),
                DateTime = DateTime.UtcNow,
                EntityId = triggerData.Id,
                Id = Guid.NewGuid(),
                EventType = eventType,
                Version = EventConstants.V1_VERSION,
                SourceDomain = EventConstants.SOURCE_DOMAIN,
                SourceSystem = EventConstants.SOURCE_SYSTEM,
                EventData = new EventData
                {
                    OldData = new ProcessStateChangeData
                    {
                        State = transition.Source
                    },
                    NewData = new ProcessStateChangeData
                    {
                        State = transition.Destination,
                        StateData = stateData
                    }
                },
                User = new User
                {
                    Name = token.Name,
                    Email = token.Email
                }
            };
        }
    }
}
