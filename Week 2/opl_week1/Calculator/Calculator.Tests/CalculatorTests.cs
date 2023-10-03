using NUnit.Framework;
using System;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {

        [Test]
        [TestCase(0, ExpectedResult =false)]
        [TestCase(1, ExpectedResult =false)]
        [TestCase(2, ExpectedResult =true)]
        [TestCase(3, ExpectedResult =true)]
        [TestCase(4, ExpectedResult =false)]
        [TestCase(17, ExpectedResult = true)]
        public bool IsPrime_OnlyReturnsTrueIfIsPrime(int number)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            return sut.IsPrime(number);

            // Assert
        }



        [Test]
        [TestCase(0, ExpectedResult = "")]
        [TestCase(1, ExpectedResult = "1")]
        [TestCase(2, ExpectedResult = "10")]
        [TestCase(3, ExpectedResult = "11")]
        [TestCase(4, ExpectedResult = "100")]
        [TestCase(17, ExpectedResult = "10001")]
        public String ConvertToBinary_DoesCorrectConversion(int number)
        {
            // Arrange
            Calculator sut = new Calculator();

            // Act
            return sut.ConvertToBinary(number);

            // Assert
        }

        [Test]
        [TestCase(19)]
        [TestCase(274)]
        public void ConvertToInt_OriginalNumberCorrectlyConverted(int number)
        {
            // Arrange
            Calculator sut =new Calculator();
            String binary = sut.ConvertToBinary(number);

            // Act
            int result = sut.ConvertToInt(binary);

            // Assert
            Assert.That(result, Is.EqualTo(number));
        }
    }
}
