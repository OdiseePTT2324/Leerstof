using CodeLes1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeLes1Tests
{
    //Dit is een testklasse
    [TestFixture]
    internal class CalculatorTests
    {
        //Dit is een unit test
        // Let op de naamgeving van de test
        // SUT _ Input _ Output
        // Functienaam _ parameters _ return/wat je wil testen
        [Test]
        public void Sum_X10Y20_Returns30()
        {
            // Arrange -- alles klaartzetten
            Calculator c = new Calculator();
            int x = 10;
            int y = 20;

            // Act -- 1 actie uitvoeren (SUT) (best altijd 1 lijn)
            int result = c.Sum(x, y);

            // Assert -- controleer het gewenste effect

            // oudere manier
            Assert.AreEqual(result, 30);

            // nieuwere manier
            Assert.That(result, Is.EqualTo(30));
        }

        [Test]
        public void Divide_X8Y3_Returns3()
        {
            // Arrange -- alles klaartzetten
            Calculator c = new Calculator();
            int x = 8;
            int y = 3;

            // Act -- 1 actie uitvoeren (SUT) (best altijd 1 lijn)
            int result = c.Divide(x, y);

            // Assert -- controleer het gewenste effect
            Assert.That(result, Is.EqualTo(3));
        }
    }
}
