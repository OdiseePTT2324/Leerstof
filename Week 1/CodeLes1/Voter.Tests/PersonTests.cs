namespace Voter.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(17, "Test")]
        [TestCase(16, "Test")]
        [TestCase(15, "Test")]
        [TestCase(14, "Test")]
        public void CanVote_Age17_ReturnsFalse(int age, String tekst)
        {
            // OPGELET parameter in de functie voor de parameter

            // Arrange
            Person p = new Person(age);

            // Act
            bool result = p.CanVote();

            // Assert
            Assert.That(result, Is.False);

            //Met pass gaat de test altijd slagen
            //Assert.Pass();
        }


        [Test]
        [TestCase(19, ExpectedResult = true)]
        [TestCase(18, ExpectedResult = true)]
        [TestCase(17, ExpectedResult =false)]
        [TestCase(16, ExpectedResult = false)]
        [TestCase(15, ExpectedResult = false)]
        [TestCase(14, ExpectedResult = false)]
        public bool CanVote_DifferentAges_ReturnsTrueIfAgeGreaterOrEquals18(int age)
        {

            // Arrange
            Person p = new Person(age);

            // Act
            return p.CanVote();
        }
    }
}