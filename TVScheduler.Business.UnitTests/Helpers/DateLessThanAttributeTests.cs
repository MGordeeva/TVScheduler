using System.ComponentModel.DataAnnotations;
using TVScheduler.Business.Helpers;

namespace TVScheduler.Business.UnitTests.Helpers
{
    public class DateLessThanAttributeTests
    {
        const string proreptyToCompare = nameof(TestModel.LaterTime);

        private class TestModel
        {
            [DateLessThan(nameof(LaterTime))]
            public DateTime FisrtTime { get; set; }

            public DateTime LaterTime { get; set; }
        }

        [Fact]
        public void IsValid_FirstTimeLessThanComparisonTime_ShouldReturnSuccess()
        {
            // Arrange
            var attribute = new DateLessThanAttribute(proreptyToCompare);
            var model = new TestModel { FisrtTime = DateTime.Now, LaterTime = DateTime.Now.AddDays(1) };

            // Act
            var result = attribute.GetValidationResult(model.FisrtTime, new ValidationContext(model));

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void IsValid_FirstTimeEqualToComparisonTime_ShouldReturnSuccess()
        {
            // Arrange
            var attribute = new DateLessThanAttribute(proreptyToCompare);
            var model = new TestModel { FisrtTime = DateTime.Now, LaterTime = DateTime.Now };

            // Act
            var result = attribute.GetValidationResult(model.FisrtTime, new ValidationContext(model));

            // Assert
            Assert.Equal(ValidationResult.Success, result);
        }

        [Fact]
        public void IsValid_InvalidPropertyName_ShouldThrowArgumentException()
        {
            // Arrange
            var attribute = new DateLessThanAttribute("InvalidPropertyName");
            var model = new TestModel { FisrtTime = DateTime.Now, LaterTime = DateTime.Now.AddDays(1) };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => attribute.GetValidationResult(model.FisrtTime, new ValidationContext(model)));
        }
    }
}