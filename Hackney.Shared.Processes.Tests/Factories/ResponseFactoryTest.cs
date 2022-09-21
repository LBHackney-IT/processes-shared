using AutoFixture;
using FluentAssertions;
using Hackney.Shared.Processes.Domain;
using Hackney.Shared.Processes.Factories;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Factories
{
    public class ResponseFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void CanMapADomainObjectToAResponseObject()
        {
            var domain = _fixture.Create<Process>();
            var response = domain.ToResponse();

            response.Should().BeEquivalentTo(domain, c => c.Excluding(x => x.VersionNumber));
        }
    }
}
