using NSubstitute;

namespace Guesser.Tests
{
    public class HigherLowerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MakeAGuess_NumberIsCorrect_ReturnsCorrect()
        {
            // Arrange
            var random = Substitute.For<IRandom>();
            random.Next(Arg.Any<int>()).Returns(10);

            HigherLower higherLower = new HigherLower(random);

            // Act
            string result = higherLower.MakeAGuess(10);

            // Assert
            Assert.That(result, Is.EqualTo("Correct"));
        }

        [Test]
        public void MakeAGuess_NumberIsHigher_ReturnsHigher()
        {
            // Arrange
            var random = Substitute.For<IRandom>();
            random.Next(Arg.Any<int>()).Returns(10);

            HigherLower higherLower = new HigherLower(random);

            // Act
            string result = higherLower.MakeAGuess(5);

            // Assert
            Assert.That(result, Is.EqualTo("Higher"));
        }

        [Test]
        public void MakeAGuess_NumberIsLower_ReturnsLower()
        {
            // Arrange
            var random = Substitute.For<IRandom>();
            random.Next(Arg.Any<int>()).Returns(10);

            HigherLower higherLower = new HigherLower(random);

            // Act
            string result = higherLower.MakeAGuess(15);

            // Assert
            Assert.That(result, Is.EqualTo("Lower"));
        }
    }
}