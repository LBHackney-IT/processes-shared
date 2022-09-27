using AutoFixture;
using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation
{
    public class FormDataValidatorTests
    {
        private readonly FormDataValidator _classUnderTest;
        private string harmfulString = "<string with tags in it>";
        private Fixture _fixture;

        public FormDataValidatorTests()
        {
            _classUnderTest = new FormDataValidator();
            _fixture = new Fixture();
        }

        [Fact]
        public void RequestShouldErrorWithHarmfulValueInKeys()
        {
            //Arrange
            var query = _fixture.Create<Dictionary<string, object>>();
            query.Add(harmfulString, "some-value");
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Keys);
        }

        [Fact]
        public void RequestShouldErrorWithHarmfulValueInValues()
        {
            //Arrange
            var query = _fixture.Create<Dictionary<string, object>>();
            query.Add("some-key", harmfulString);
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Values);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidTargetId()
        {
            //Arrange
            var query = _fixture.Create<Dictionary<string, object>>();
            //Act
            var result = _classUnderTest.TestValidate(query);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
