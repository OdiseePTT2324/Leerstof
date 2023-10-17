using PersonAgeValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidatorTests
{
    [TestFixture]
    internal class AgeValidatorTests
    {

        [Test]
        [TestCase(10)]
        [TestCase(17)]
        [TestCase(72)]
        public void IsValidAge_AgeInvalid_ReturnsFalse(int age)
        {
            // Assert
            AgeValidator validator = new AgeValidator();

            // Act
            bool result = validator.IsValidAge(age);

            // Arrange
            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(18)]
        [TestCase(40)]
        [TestCase(71)]
        public void IsValidAge_AgeValid_ReturnsTrue(int age)
        {
            // Assert
            AgeValidator validator = new AgeValidator();

            // Act
            bool result = validator.IsValidAge(age);

            // Arrange
            Assert.IsTrue(result);
        }
    }
}
