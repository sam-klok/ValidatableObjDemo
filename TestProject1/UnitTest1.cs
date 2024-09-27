using System.ComponentModel.DataAnnotations;
using ValidatableObjDemo;

namespace TestProject1
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(10_000)]
        [InlineData(10_000_000)]
        public void WhenInvalidCategory_ReturnsError(int category)
        {
            // Arrange
            var settings = new Settings();
            settings.Category = (Category)category;

            var validationContext = new ValidationContext(settings);

            // Act
            var validationResults = settings.Validate(validationContext);

            // Assert
            Assert.NotNull(validationResults);
            Assert.Equal(1, validationResults.Count());
        }
    }
}