using Les1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Webshop.Tests
{
    [TestFixture]
    internal class StoreTests
    {
        [Test]
        public void AddInventory_EmptyInventoryAdd5Shampoo_5ShampooAdded()
        {
            // Arrange
            Store sut = new Store();

            // Act
            sut.AddInventory(Product.Shampoo, 5);

            // Assert
            Assert.That(sut.GetInventory(Product.Shampoo), Is.EqualTo(5));
        }


        [Test]
        public void AddInventory_Already5InInventory5Added_10InInventory()
        {
            // Arrange
            Store sut = new Store();
            sut.AddInventory(Product.Shampoo, 5);

            // Act
            sut.AddInventory(Product.Shampoo, 5);

            // Assert
            Assert.That(sut.GetInventory(Product.Shampoo), Is.EqualTo(10));
        }
    }
}
