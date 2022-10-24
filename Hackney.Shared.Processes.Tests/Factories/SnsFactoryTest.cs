using System;
using System.Collections.Generic;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.JWT;
using Hackney.Core.Sns;
using Hackney.Shared.Processes.Domain;
using Hackney.Shared.Processes.Factories;
using Hackney.Shared.Processes.Infrastructure;
using Hackney.Shared.Processes.Sns;
using Stateless;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Factories
{
    public class SnsFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();
        private readonly Token _token;

        public SnsFactoryTest()
        {
            _token = _fixture.Create<Token>();
        }

        private void ValidateMessageData(EntityEventSns message, Guid entityId, string eventType)
        {
            message.DateTime.Should().BeCloseTo(DateTime.UtcNow);
            message.EntityId.Should().Be(entityId);
            message.EventType.Should().Be(eventType);
            message.Version.Should().Be(EventConstants.V1_VERSION);
            message.SourceDomain.Should().Be(EventConstants.SOURCE_DOMAIN);
            message.SourceSystem.Should().Be(EventConstants.SOURCE_SYSTEM);

            message.User.Name.Should().Be(_token.Name);
            message.User.Email.Should().Be(_token.Email);
        }

        [Fact]
        public void CanCreateProcessStartedEvent()
        {
            var process = _fixture.Create<Process>();
            var message = process.CreateProcessStartedEvent(_token);

            ValidateMessageData(message, process.Id, EventConstants.PROCESS_STARTED_EVENT);
            message.EventData.NewData.Should().Be(process);
        }

        [Theory]
        [InlineData(EventConstants.PROCESS_STARTED_AGAINST_PERSON_EVENT)]
        [InlineData(EventConstants.PROCESS_STARTED_AGAINST_TENURE_EVENT)]
        public void CanCreateProcessStartedAgainstEntityEvent(string eventType)
        {
            var process = _fixture.Create<Process>();
            var message = process.CreateProcessStartedAgainstEntityEvent(_token, eventType);

            ValidateMessageData(message, process.TargetId, eventType);

            var newData = (message.EventData.NewData as ProcessStartedAgainstEntityData);
            newData.Id.Should().Be(process.Id);
            newData.ProcessName.Should().Be(process.ProcessName);
        }

        [Fact]
        public void CanCreateProcessUpdatedEvent()
        {
            var processId = Guid.NewGuid();
            var processUpdatedResult = _fixture.Create<UpdateEntityResult<ProcessState>>();

            var message = processUpdatedResult.CreateProcessUpdatedEvent(processId, _token);

            ValidateMessageData(message, processId, EventConstants.PROCESS_UPDATED_EVENT);
            message.EventData.NewData.Should().Be(processUpdatedResult.NewValues);
        }

        [Fact]
        public void CanCreateCreateProcessStateUpdatedEvent()
        {
            var trigger = _fixture.Create<ProcessTrigger>();
            var stateData = _fixture.Create<Dictionary<string, object>>();
            var stateCreatedAt = DateTime.UtcNow;
            var eventType = "SOME_EVENT_TYPE";
            var transition = new StateMachine<string, string>.Transition("some-initial-state",
                                                                         "some-destination-state",
                                                                         "some-trigger",
                                                                         new object[] { trigger });

            var message = transition.CreateProcessStateUpdatedEvent(stateCreatedAt, stateData, eventType, _token);

            ValidateMessageData(message, trigger.Id, eventType);

            (message.EventData.OldData as ProcessStateChangeData).State.Should().Be(transition.Source);
            var newData = message.EventData.NewData as ProcessStateChangeData;
            newData.State.Should().Be(transition.Destination);
            newData.StateData.Should().BeEquivalentTo(stateData);
        }
    }
}
