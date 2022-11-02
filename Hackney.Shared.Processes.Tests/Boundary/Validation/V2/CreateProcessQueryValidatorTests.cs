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
    public class CreateProcessQueryValidatorTests
    {
        private readonly CreateProcessQueryValidator _classUnderTest;
        private Fixture _fixture;

        public CreateProcessQueryValidatorTests()
        {
            _classUnderTest = new CreateProcessQueryValidator();
            _fixture = new Fixture();
        }

        [Fact]
        public void RequestShouldErrorWithNullTargetId()
        {
            //Arrange
            var query = new CreateProcess();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TargetId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyTargetId()
        {
            //Arrange
            var query = new CreateProcess { TargetId = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TargetId);
        }

        [Fact]
        public void RequestShouldErrorWithNullRelatedEntities()
        {
            //Arrange
            var query = new CreateProcess();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RelatedEntities);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyRelatedEntities()
        {
            //Arrange
            var query = new CreateProcess
            {
                RelatedEntities = new List<RelatedEntity>()
            };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RelatedEntities);
        }

        [Fact]
        public void RequestShouldErrorWithRelatedEntitiesThatDoesNotContainAllTargetTypes()
        {
            //Arrange
            var query = new CreateProcess
            {
                RelatedEntities = new List<RelatedEntity>
                {
                    _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.asset).Create(),
                    _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.tenure).Create(),
                }
            };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RelatedEntities);
        }

        [Fact]
        public void RequestShouldErrorWithRelatedEntitiesThatDoesNotContainTargetId()
        {
            //Arrange
            var query = new CreateProcess
            {
                TargetId = Guid.NewGuid(),
                TargetType = TargetType.person,
                RelatedEntities = new List<RelatedEntity>
                {
                    _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.asset).Create(),
                    _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.tenure).Create(),
                    _fixture.Build<RelatedEntity>().With(x => x.TargetType, TargetType.person).With(x => x.Id, Guid.NewGuid()).Create(),
                }
            };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RelatedEntities);
        }

        [Fact]
        public void RequestShouldErrorWithNullPatchAssignment()
        {
            //Arrange
            var query = new CreateProcess();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.PatchAssignment);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyDocumentIDs()
        {
            //Arrange
            var model = new CreateProcess { Documents = new List<Guid> { Guid.Empty } };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Documents);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidDocumentIDs()
        {
            //Arrange
            var model = new CreateProcess { Documents = new List<Guid> { Guid.NewGuid() } };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Documents);
        }
    }
}
