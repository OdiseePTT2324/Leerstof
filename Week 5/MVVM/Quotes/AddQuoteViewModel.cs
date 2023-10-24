using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotes.MVVMC
{
    public class AddQuoteViewModel
    {
        private string author;
        private string text;
        private IQuoteRepository quoteRepository;
        private ICoordinator coordinator;
        private ICloseable view;

        public string Author
        {
            get => author;
            set
            {
                author = value;
                // OnPropertyChanged here -> dit venster sluit zich na het toevoegen -> is niet nodig hierdoor
            }
        }
        public string Text
        {
            get => text;
            set
            {
                text = value;
            }
        }

        public ICommand CreateQuoteCommand { get; private set; }

        public AddQuoteViewModel(ICoordinator coordinator, ICloseable view) : this(coordinator, view, new QuoteRepository())
        {
        }

        public AddQuoteViewModel(ICoordinator coordinator, ICloseable view, IQuoteRepository quoteRepository)
        {
            this.coordinator = coordinator;
            this.view = view;
            this.quoteRepository = quoteRepository;
            CreateQuoteCommand = new RelayCommand(CreateQuote);
         }

        private void CreateQuote()
        {
            if (Author != String.Empty && Text != String.Empty)
            {
                Quote quote = new Quote(Text, Author);
                quoteRepository.AddQuote(quote);
                coordinator.ShowMainWindow();

                view.Close();
            }
            else
            {
                coordinator.ShowMessageBox("error");
            }
        }
    }
}
