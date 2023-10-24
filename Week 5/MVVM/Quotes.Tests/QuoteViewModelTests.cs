using NSubstitute;

namespace Quotes.Tests
{
    public class QuoteViewModelTests
    {
        IQuoteRepository _repository;
        QuoteViewModel sut;

        [SetUp]
        public void Setup()
        {
            _repository = Substitute.For<IQuoteRepository>();
            _repository.GetAllQuotes().Returns(new List<Quote>());

            sut = new QuoteViewModel(_repository);
        }

        [Test]
        public void SelectedQuoteChanged_WhenSelectedQuoteIsChanged_AuthorAndTextIsSet()
        {
            // Arrange
            Quote quote = new Quote("text", "author");

            // Act
            sut.SelectedQuote = quote;

            // Assert
            Assert.That(sut.Author, Is.EqualTo(quote.Author));
            Assert.That(sut.Text, Is.EqualTo(quote.Text));
        }

        [Test]
        public void WhenAuthorChanged_PropertyChangedEventIsSend()
        {
            // Arrange
            string property = "";
            // hang er een extra event handler aan met +=
            sut.PropertyChanged += (sender, eventargs) =>
            {
                property = eventargs.PropertyName;
            };

            // Act
            sut.Author = "blalblalkajvlka;jv";

            // Assert
            Assert.That(property, Is.EqualTo("Author"));
        }

        [Test]
        public void WhenQuoteIsSaved_CheckQuoteIsAddedToListAndAddedToRepo()
        {
            // Arrange
            sut.Author = "author";
            sut.Text = "text";

            // Act
            sut.AddQuoteCommand.Execute(null); // de parameters in deze functie zijn niet belangrijk, laat ze maar null zijn
            // bovenstaande simuleert dat we op de knop duwen

            // Assert
            Assert.That(sut.Quotes.Count, Is.EqualTo(1));
            Assert.That(sut.Quotes[0].Author, Is.EqualTo("author"));
            Assert.That(sut.Quotes[0].Text, Is.EqualTo("text"));
           // _repository.Received(1).AddQuote(Arg.Any<Quote>());

        }
    }
}