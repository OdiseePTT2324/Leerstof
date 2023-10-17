using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesStart
{
    // Interfaces: naam begint met altijd met hoofdletter i (I)
    internal interface IPaymentMethod
    {
        // in een interface is alles public
        void OpenPaymentScreen();
        bool PaymentSucceeded { get; }

        string PaymentFailedMessage { get; }
        string PaymentSucceededMessage { get; }
    }
}
