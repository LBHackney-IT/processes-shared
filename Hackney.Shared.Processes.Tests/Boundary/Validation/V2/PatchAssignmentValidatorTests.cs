using FluentValidation.TestHelper;
using Hackney.Shared.Processes.Boundary.Request.V2.Validation;
using Hackney.Shared.Processes.Domain;
using System;
using Xunit;

namespace Hackney.Shared.Processes.Tests.Boundary.Validation.V2
{
    public class PatchAssignmentValidatorTests
    {
        private readonly PatchAssignmentValidator _classUnderTest;
        private string harmfulString = "<string with tags in it>";

        public PatchAssignmentValidatorTests()
        {
            _classUnderTest = new PatchAssignmentValidator();
        }

        [Fact]
        public void RequestShouldNotErrorWithValidData()
        {
            //Arrange
            var model = new PatchAssignment
            {
                PatchId = Guid.NewGuid(),
                PatchName = "some-patch-name",
                ResponsibleEntityId = Guid.NewGuid(),
                ResponsibleName = "some-name"
            };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldNotHaveAnyValidationErrors();
        }

        [Fact]
        public void RequestShouldErrorWithNullPatchId()
        {
            //Arrange
            var model = new PatchAssignment();
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.PatchId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyPatchId()
        {
            //Arrange
            var model = new PatchAssignment { PatchId = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.PatchId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyPatchName()
        {
            //Arrange
            var model = new PatchAssignment { PatchName = String.Empty };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.PatchName);
        }

        [Fact]
        public void RequestShouldErrorWithHarmfulPatchName()
        {
            //Arrange
            var model = new PatchAssignment { PatchName = harmfulString };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.PatchName);
        }


        [Fact]
        public void RequestShouldErrorWithEmptyResponsibleEntityId()
        {
            //Arrange
            var model = new PatchAssignment { ResponsibleEntityId = Guid.Empty };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibleEntityId);
        }

        [Fact]
        public void RequestShouldErrorWithEmptyResponsibleName()
        {
            //Arrange
            var model = new PatchAssignment { ResponsibleName = String.Empty };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibleName);
        }

        [Fact]
        public void RequestShouldErrorWithHarmfulResponsibleName()
        {
            //Arrange
            var model = new PatchAssignment { ResponsibleName = harmfulString };
            //Act
            var result = _classUnderTest.TestValidate(model);
            //Assert
            result.ShouldHaveValidationErrorFor(x => x.ResponsibleName);
        }
    }
}
