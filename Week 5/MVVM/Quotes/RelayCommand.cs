using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Quotes
{
    // Dit kan je kopieren voor je project
    internal class RelayCommand : ICommand
    {
        //Dit is een delegate / functie
        // Dit is de actie die moet gebeuren door dit commando
        private Action action;

        public RelayCommand(Action action)
        {
            this.action = action;
        }

        // niet nodig voor dit vak
        public event EventHandler CanExecuteChanged;

        // niet nodig voor dit vak
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            // voer de functie in action uit
            action();
        }
    }
}
