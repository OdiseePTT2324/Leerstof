using Les1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Tests
{
    [TestFixture]
    internal class CustomerTests
    {
        Store s = new Store(); // Als je dit hier doet, hergebruik je de store doorheen de testen
        Product p;
        Customer c;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            // Dit gebeurt slechts 1 keer (voor alle testen)
        }

        [SetUp]
        public void Setup()
        {
            // Dit wordt elke test opnieuw uitgevoerd
            s = new Store();
            s.AddInventory(Product.Bread, 5);
            p = Product.Shampoo;
            c = new Customer();
        }

        //Omgekeerde van de setup
        //[TearDown]
        //[OneTimeTearDown]


        [Test]
        public void Purchase_15ShampooAvailable_ReturnsTrue10ShampooBasketStoreInventory5()
        {
            // Arrange
            s.AddInventory(Product.Shampoo, 15);

            // Act
            bool result = c.Purchase(s, p, 10);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(c.Basket[p], Is.EqualTo(10));
            Assert.That(s.GetInventory(p), Is.EqualTo(5));
        }


        /*
        [Test]
        public void Purchase_NoShampooAvailable_KeyNotFoundExceptionThrown()
        {
            // Arrange
            Store s = new Store();
            s.AddInventory(Product.Bread, 5);
            Customer c = new Customer();
            Product p = Product.Shampoo;

            // Test faalt omdat er een exception opgeworpen wordt (geen Shampoos aanwezig)
            // Act
            //bool result = c.Purchase(s, p, 10);

            // Assert
            //Assert.That(result, Is.False);

            // Dit checkt of de exception opgeworpen wordt
            Assert.Throws<KeyNotFoundException>(() => c.Purchase(s, p, 10));
        }


        [Test]
        public void Purchase_5ShampooAvailable_ReturnsFalseBasketEmpty()
        {
            // Arrange
            Store s = new Store();
            s.AddInventory(Product.Bread, 5);
            s.AddInventory(Product.Shampoo, 5);
            Customer c = new Customer();
            Product p = Product.Shampoo;

            // Act
            bool result = c.Purchase(s, p, 10);

            // Assert
            Assert.That(result, Is.False);
            Assert.That(c.Basket.Count, Is.EqualTo(0));
        }

        [Test]
        public void Purchase_15ShampooAvailable_ReturnsTrue10ShampooBasketStoreInventory5()
        {
            // Arrange
            Store s = new Store();
            s.AddInventory(Product.Bread, 5);
            s.AddInventory(Product.Shampoo, 15);
            Customer c = new Customer();
            Product p = Product.Shampoo;

            // Act
            bool result = c.Purchase(s, p, 10);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(c.Basket[p], Is.EqualTo(10));
            Assert.That(s.GetInventory(p), Is.EqualTo(5));
        }
        */
    }
}
