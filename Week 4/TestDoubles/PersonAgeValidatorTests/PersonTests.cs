using PersonAgeValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonAgeValidatorTests
{
    [TestFixture]
    internal class PersonTests
    {
        [Test]
        public void Ctor_AgeInvalid_ThrowsException()
        {
            // Assert
            IAgeValidator validator = new AgeValidatorTestDouble(false);

            // Act

            // Arrange
            Assert.Throws<Exception>(() => new Person("firstname", "lastname", 40, validator));
        }

        [Test]
        public void Ctor_AgeValid_ReturnsObject()
        {
            // Assert
            IAgeValidator validator = new AgeValidatorTestDouble(true);

            // Act
            Person result = new Person("firstname", "lastname", -100, validator);

            // Arrange
            Assert.That(result, Is.Not.Null);
        }

        // AgeValidatorTestDouble dit is een test double
        // klasse gemaakt om de link van de Person klasse naar AgeValidator doorbreken
        // de bedoeling van de klasse om zelf te kiezen wat er gereturned wordt door de IsAgeValid functie
        // dit doen we hier op lijn 17 en 29

        // de 40 en -100 zijn hier niet meer belangrijk omdat we de return waarde van de age validator vast hebben gekozen
        // wat de age dus ook is gaat de validator false returnen in de eerste test en true in de tweede test
    }
}
