namespace FrisdrankAutomaat.Tests
{
    public class VendingMachineTests
    {
        Vendingmachine v;
        Drink cola = new Drink("cola", 2.0);

        [SetUp]
        public void Setup()
        {

            v = new Vendingmachine();
            v.AddDrink(cola, 0, 0);
            v.AddDrink(cola, 0, 1);
            v.AddDrink(cola, 0, 0);
            v.AddDrink(cola, 0, 0);
        }

        [Test]
        public void buy_RowTooLarge_ThrowsIndexOutOfRangeException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => v.buy(20, 4));
        }

        [Test]
        public void buy_ColumnTooLarge_ThrowsIndexOutOfRangeException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<IndexOutOfRangeException>(() => v.buy(9, 14));
        }


        [Test]
        public void buy_NoDrinkAtSpot_ThrowsNoInventoryException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<NoInventoryException>(() => v.buy(2, 2));
        }


        [Test]
        public void buy_NotEnoughMoney_ThrowsNotEnoughMoneyException()
        {
            // Arrange

            // Act

            // Assert
            Assert.Throws<NotEnougMoneyException>(() => v.buy(0, 1));
        }


        [Test]
        public void buy_EnoughMoney_DrinkReturnedAndRefundAvailable()
        {
            // Arrange
            v.InsertCoins(Coins.TWOEURO);
            v.InsertCoins(Coins.FIFTYCENTS);

            // Act
            Drink result = v.buy(0, 1);

            // Assert
            Assert.That(result, Is.EqualTo(cola));
            Assert.That(v.Budget, Is.EqualTo(0.5));
            Assert.That(v.Inventory[(0, 1)], Is.Null);
        }
    }
}