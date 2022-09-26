using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request.Validation;
using Hackney.Shared.Processes.Domain;
using System;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation
{
    public class RelatedEntityValidatorTests
    {
        private readonly RelatedEntityValidator _classUnderTest;
        private string harmfulString = "<string with tags in it>";

        public RelatedEntityValidatorTests()
        {
            _classUnderTest = new RelatedEntityValidator();
        }

        [Fact]
        public void RequestShouldErrorWithEmptyId()
        {
            //Arrange
            var model = new RelatedEntity { Id = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldNotErrorWithValidId()
        {
            //Arrange
            var model = new RelatedEntity { Id = Guid.NewGuid() };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Id);
        }

        [Fact]
        public void RequestShouldErrorWithHarmfulDescription()
        {
            //Arrange
            var model = new RelatedEntity { Description = harmfulString };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.Description);
        }

        [Fact]
        public void RequestShouldNotErrorWithValiDescription()
        {
            //Arrange
            var model = new RelatedEntity { Description = "some-description" };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Description);
        }
    }
}
