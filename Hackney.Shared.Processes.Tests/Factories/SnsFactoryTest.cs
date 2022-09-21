using System;
using AutoFixture;
using FluentAssertions;
using Hackney.Core.JWT;
using Hackney.Core.Sns;
using Hackney.Shared.Processes.Domain;
using Hackney.Shared.Processes.Factories;
using Hackney.Shared.Processes.Sns;
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
        }

        [Fact]
        public void CanCreateProcessStartedEvent()
        {
            var process = _fixture.Create<Process>();
            var message = process.CreateProcessStartedEvent(_token);

            ValidateMessageData(message, process.Id, EventConstants.PROCESS_STARTED_EVENT);
            message.EventData.NewData.Should().Be(process);

            message.User.Name.Should().Be(_token.Name);
            message.User.Email.Should().Be(_token.Email);
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

            message.User.Name.Should().Be(_token.Name);
            message.User.Email.Should().Be(_token.Email);
        }
    }
}
