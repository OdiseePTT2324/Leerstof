using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Data.Entity.Infrastructure;

namespace Quotes
{
    public class QuoteViewModel: INotifyPropertyChanged
    {
        private IQuoteRepository quoteRepository;
        private ICoordinator coordinator;
        private ICloseable view;

        public ObservableCollection<Quote> Quotes { get; set; }

        private string author;
        public string Author { get => author; set {
                author = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Author")); // Zeg tegen het view dat de author aangepast is
                OnPropertyChanged();                                            // gelijk aan de vorige lijn maar automatisch wordt de naam ingevuld
            } 
        }
        private string text;
        public string Text { get => text; set
            {
                text = value;
                //PropertyChanged(this, new PropertyChangedEventArgs("Text"));
                OnPropertyChanged();   
            }
        }

        private Quote quote;

        public event PropertyChangedEventHandler PropertyChanged;

        public Quote SelectedQuote { get => quote; set
            {
                quote = value;
                SelectedQuoteChanged();
            } 
        }

        public ICommand AddQuoteCommand { get; private set; }

        public QuoteViewModel(ICoordinator coordinator, ICloseable view) : this(coordinator, view, new QuoteRepository())
        {
        }

        public QuoteViewModel(ICoordinator coordinator, ICloseable view, IQuoteRepository quoteRepository)
       {
            this.coordinator = coordinator;
            this.view = view;
            this.quoteRepository = quoteRepository;
            Quotes = new ObservableCollection<Quote>(quoteRepository.GetAllQuotes());

            AddQuoteCommand = new RelayCommand(AddQuote);

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //CallerMemberName -- dit gaat ingevuld worden met de naam van de property die het oproept
            if (PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void AddQuote()
        {
           if (Author != String.Empty && Text != String.Empty)
            {
                coordinator.ShowAddQuoteWindow();
                view.Close();

            }
            else
            {
                coordinator.ShowMessageBox("Vul een author en text in");
            }
        }


        public void SelectedQuoteChanged()
        {
            if (quote != null)
            {
                Author = quote.Author;
                Text = quote.Text;
            }
            else
            {
                Author = "";
                Text = "";
            }
        }
    }
}
