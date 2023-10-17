using InterfacesStart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        public MainWindow(List<IPaymentMethod> paymentMethods)
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            List<StockItem> stockItems = new List<StockItem>()
            {
                new StockItem("Brood", 2.5),
                new StockItem("Hesp", 3),
                new StockItem("Kaas", 2.10),
                new StockItem("Wijn", 7.85),
                new StockItem("Melk", 2)
            };

            stockListBox.ItemsSource = stockItems;
        }


        private void stockListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stockListBox.SelectedItem != null)
            {
                var item = (StockItem)stockListBox.SelectedItem;
                List<StockItem> items = (List<StockItem>)stockListBox.ItemsSource;
                items.Remove(item);
                stockListBox.ItemsSource = null;
                stockListBox.ItemsSource = items;
                orderListBox.Items.Add(item);
                SetTotalAmount();
            }
        }

        private void SetTotalAmount()
        {
            double totalAmount = 0;
            foreach (StockItem item in orderListBox.Items)
            {
                totalAmount += item.Price;
            }

            totalAmountLabel.Content = totalAmount;
        }

        private void payButton_Click(object sender, RoutedEventArgs e)
        {
            // Implementeer deze knop zodanig dat het juiste scherm getoond wordt.
            // open het correcte scherm (paypol, bancontact of visa)
            // Toon in message box of het gelukt is.
            
            /*
            // Eerste oplossing
            if (visaRadioButton.IsChecked == true)
            {
                Visa visaPayment = new Visa();
                visaPayment.ShowDialog();
                if (visaPayment.PaymentSucceeded)
                {
                    MessageBox.Show("Visa Paymment Succeeded");
                } else
                {
                    MessageBox.Show("Visa Payment failed");
                }
            }
            if (bancontactRadioButton.IsChecked == true)
            {
                Bancontact banccontactPayment = new Bancontact();
                banccontactPayment.ShowDialog();
                if (banccontactPayment.PaymentSucceeded)
                {
                    MessageBox.Show("Bancontact Paymment Succeeded");
                }
                else
                {
                    MessageBox.Show("Bancontact Payment failed");
                }
            }
            if (paypalRadioButton.IsChecked == true)
            {
                Paypal paypalPayment = new Paypal();
                paypalPayment.ShowDialog();
                if (paypalPayment.PaymentSucceeded)
                {
                    MessageBox.Show("Paypal Paymment Succeeded");
                }
                else
                {
                    MessageBox.Show("Paypal Payment failed");
                }
            }*/

            // Nadelen: Heel wat repititief werk
            // showDialog, PaymentSucceeded en SucceededMessage en FailedMessage

            IPaymentMethod paymentMethod = null;
            if(visaRadioButton.IsChecked == true)
            {
                paymentMethod = new Visa();
            } else if(paypalRadioButton.IsChecked == true)
            {
                paymentMethod = new Paypal();
            } else if(bancontactRadioButton.IsChecked == true)
            {
                paymentMethod = new Bancontact();
            }

            paymentMethod.OpenPaymentScreen();
            if(paymentMethod.PaymentSucceeded == true)
            {
                MessageBox.Show(paymentMethod.PaymentSucceededMessage);
            } else
            {
                MessageBox.Show(paymentMethod.PaymentFailedMessage);
            }
        }
    }
}
