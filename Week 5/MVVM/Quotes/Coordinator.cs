using Quotes.MVVMC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Quotes
{

    public interface ICoordinator
    {
        void ShowMainWindow();
        void ShowAddQuoteWindow();

        // Gebruik de parameters in de functie om data door te geven van het ene window naar het andere window
        void ShowEditQuoteWindow(Quote quote);

        void ShowMessageBox(String message);

    }
    public class Coordinator : ICoordinator
    {
        public void ShowAddQuoteWindow()
        {
            AddQuoteWindow window = new AddQuoteWindow();
            AddQuoteViewModel viewModel = new AddQuoteViewModel(this, window);

            window.DataContext = viewModel;
            window.Show();
        }

        public void ShowEditQuoteWindow(Quote quote)
        {
            throw new NotImplementedException();
        }

        public void ShowMainWindow()
        {
            MainWindow window = new MainWindow();
            QuoteViewModel viewModel = new QuoteViewModel(this, window);
            window.DataContext = viewModel;

            window.Show();
        }

        public void ShowMessageBox(string message)
        {
            MessageBox.Show(message);
        }
    }
}
