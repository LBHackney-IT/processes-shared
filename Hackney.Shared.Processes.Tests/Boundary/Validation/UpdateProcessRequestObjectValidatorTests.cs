using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation
{
    public class UpdateProcessRequestObjectValidatorTests
    {
        private readonly UpdateProcessRequestObjectValidator _classUnderTest;

        public UpdateProcessRequestObjectValidatorTests()
        {
            _classUnderTest = new UpdateProcessRequestObjectValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullFormData()
        {
            //Arrange
            var model = new UpdateProcessRequestObject
            {
                FormData = null,
                Documents = new List<Guid>()
            };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.FormData);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidFormData()
        {
            //Arrange
            var model = new UpdateProcessRequestObject
            {
                FormData = new Dictionary<string, object>(),
                Documents = new List<Guid>()
            };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.FormData);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyDocumentIDs()
        {
            //Arrange
            var model = new UpdateProcessRequestObject
            {
                FormData = null,
                Documents = new List<Guid> { Guid.Empty }
            };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Documents);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidDocumentIDs()
        {
            //Arrange
            var model = new UpdateProcessRequestObject
            {
                FormData = null,
                Documents = new List<Guid> { Guid.NewGuid() }
            };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Documents);
        }

    }
}
