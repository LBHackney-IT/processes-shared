using AutoFixture;
using FluentAssertions;
using Hackney.Shared.Processes.Domain;
using Hackney.Shared.Processes.Factories;
using Hackney.Shared.Processes.Infrastructure;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Factories
{
    public class EntityFactoryTest
    {
        private readonly Fixture _fixture = new Fixture();

        [Fact]
        public void CanMapADatabaseEntityToADomainObject()
        {

            var databaseEntity = _fixture.Create<ProcessesDb>();
            var domain = databaseEntity.ToDomain();

            domain.Should().BeEquivalentTo(databaseEntity);
        }

        [Fact]
        public void CanMapADomainEntityToADatabaseObject()
        {

            var domain = _fixture.Create<Process>();
            var databaseEntity = domain.ToDatabase();

            databaseEntity.Should().BeEquivalentTo(domain);
        }
    }
}
