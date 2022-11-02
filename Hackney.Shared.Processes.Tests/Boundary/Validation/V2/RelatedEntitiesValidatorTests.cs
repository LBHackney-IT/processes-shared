using AutoFixture;
using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request.V2;
using Hackney.Shared.Processes.Boundary.Request.V2.Validation;
using Hackney.Shared.Processes.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation.V2
{
    public class RelatedEntitiesValidatorTests
    {
        private readonly RelatedEntitiesValidator _classUnderTest;
        private Fixture _fixture;
        private readonly CreateProcess _request;

        public RelatedEntitiesValidatorTests()
        {
            _fixture = new Fixture();
            _request = _fixture.Create<CreateProcess>();
            _classUnderTest = new RelatedEntitiesValidator(_request);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyRelatedEntities()
        {
            //Arrange
            var relatedEntities = new List<RelatedEntity>();
            //Act
            var result = _classUnderTest.TestValidate(relatedEntities);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x);
        }

        [Fact]
        public void RequestShouldErrorWithRelatedEntitiesThatDoesNotContainAllTargetTypes()
        {
            //Arrange
            var relatedEntities = new List<RelatedEntity>
            {
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.asset).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.tenure).Create()
            };
            //Act
            var result = _classUnderTest.TestValidate(relatedEntities);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x);
        }

        [Fact]
        public void RequestShouldErrorWithRelatedEntitiesThatDoesNotContainTargetId()
        {
            //Arrange
            var relatedEntities = new List<RelatedEntity>
            {
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.asset).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.tenure).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.person).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, _request.TargetType).With(x => x.Id, Guid.NewGuid()).Create()
            };
            //Act
            var result = _classUnderTest.TestValidate(relatedEntities);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidRelatedEntities()
        {
            //Arrange
            var relatedEntities = new List<RelatedEntity>
            {
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.asset).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.tenure).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.person).Create(),
                _fixture.Build<RelatedEntity>().With(x => x.TargetType, _request.TargetType).With(x => x.Id, _request.TargetId).Create()
            };
            //Act
            var result = _classUnderTest.TestValidate(relatedEntities);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
