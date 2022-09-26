using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation
{
    public class CreateProcessQueryValidatorTests
    {
        private readonly CreateProcessQueryValidator _classUnderTest;

        public CreateProcessQueryValidatorTests()
        {
            _classUnderTest = new CreateProcessQueryValidator();
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
            var query = new CreateProcess() { TargetId = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.TargetId);
        }

        [Fact]
        public void RequestShouldErrorWithNullRelatedEntity()
        {
            //Arrange
            var query = new CreateProcess() { };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.RelatedEntities);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyDocumentIDs()
        {
            //Arrange
            var model = new CreateProcess() { Documents = new List<Guid> { Guid.Empty } };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Documents);
        }
        [Fact]
        public void RequestShouldNotErrorWithValidDocumentIDs()
        {
            //Arrange
            var model = new CreateProcess() { Documents = new List<Guid> { Guid.NewGuid() } };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Documents);
        }
    }
}
