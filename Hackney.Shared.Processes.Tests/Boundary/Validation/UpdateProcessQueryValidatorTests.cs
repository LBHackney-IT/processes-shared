using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using System;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation
{
    public class UpdateProcessQueryValidatorTests
    {
        private readonly UpdateProcessQueryValidator _classUnderTest;
        private const string ValueWithTags = "sdfsdf<sometag>";


        public UpdateProcessQueryValidatorTests()
        {
            _classUnderTest = new UpdateProcessQueryValidator();
        }

        [Fact]
        public void RequestShouldErrorWithNullId()
        {
            //Arrange
            var query = new UpdateProcessQuery();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            //Arrange
            var query = new UpdateProcessQuery { Id = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithNullProcessTrigger()
        {
            //Arrange
            var model = new UpdateProcessQuery { ProcessTrigger = null };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ProcessTrigger);
        }

        [Fact]
        public void RequestShouldErrorWithHarmfulProcessTrigger()
        {
            //Arrange
            var model = new UpdateProcessQuery { ProcessTrigger = "<string with tags>" };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ProcessTrigger);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidProcessTrigger()
        {
            //Arrange
            string processTrigger = "some-trigger";
            var model = new UpdateProcessQuery { ProcessTrigger = processTrigger };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.ProcessTrigger);
        }
    }
}
