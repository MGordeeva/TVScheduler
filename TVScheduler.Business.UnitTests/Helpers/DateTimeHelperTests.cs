using TVScheduler.Business.Helpers;

namespace TVScheduler.Business.UnitTests.Helpers
{
    public class DateTimeHelperTests
    {
        [Fact]
        public void TrimMilliseconds_ReturnsDateTimeWithMillisecondsTrimmed()
        {
            // Arrange
            DateTime originalDateTime = new DateTime(2022, 2, 20, 12, 30, 45, 789);

            // Act
            DateTime trimmedDateTime = DateTimeHelper.TrimMilliseconds(originalDateTime);

            // Assert
            Assert.Equal(originalDateTime.Year, trimmedDateTime.Year);
            Assert.Equal(originalDateTime.Month, trimmedDateTime.Month);
            Assert.Equal(originalDateTime.Day, trimmedDateTime.Day);
            Assert.Equal(originalDateTime.Hour, trimmedDateTime.Hour);
            Assert.Equal(originalDateTime.Minute, trimmedDateTime.Minute);
            Assert.Equal(originalDateTime.Second, trimmedDateTime.Second);
            Assert.Equal(0, trimmedDateTime.Millisecond);
        }

        [Fact]
        public void TrimMilliseconds_PreservesDateTimeKind()
        {
            // Arrange
            DateTime originalDateTime = new DateTime(2022, 2, 20, 12, 30, 45, 789, DateTimeKind.Utc);

            // Act
            DateTime trimmedDateTime = DateTimeHelper.TrimMilliseconds(originalDateTime);

            // Assert
            Assert.Equal(originalDateTime.Kind, trimmedDateTime.Kind);
        }
    }
}
