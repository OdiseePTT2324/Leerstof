using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Quotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, ICloseable
    {
        // 1: Maak QuoteViewModel aan, maak het hier aan in de constructor en stel het in als datacontext
        // 2: Maak public properties aan voor de nodige data velden (listbox -> list) en Textbox -> string
        // 3: Zorg in de .xaml file voor data binding: listbox -> ItemsSource="{Binding Quotes}" en voor Textbox -> Text
                // Verschillende modes om in verschillende richtingen te schrijven
                // One Time -> lees 1-maal de data uit na constructie
                // OneWay -> Lees continue de data uit
                // OneWayToSource -> Schrijf de data naar het viewmodel
                // TwoWay default -> lees en schrijf naar de property in het viewmodel
        // 4: Alle dataklassen moet leesbaar kunnen maken
                // Methode 1: Om een ToString methode te gebruiken
                // Methode 2: Door gebruik te maken van een ListBox.ItemTemplate. Dit is voor de geavanceerdere zaken
        // 5: Activeren van events door te werken met commando's ipv events. Deze kunnen nagebootst worden om user inputs na te bootsen
                // Maak de RelayCommand aan, implementeer de ICommand interface (kan overgenomen worden voor het project)
                // Maak een public property aan per commando dat uitgevoerd moet worden, maak in de constructor het relay command aan met de juiste functieoproep
                // Bind het commando aan een knop in de .xaml file
                // implementeer de functie die uitgevoerd wordt
        // 6: ListBox wordt nog niet geupdated
                // Vervang List door ObservableCollection
                // Let op dat je deze collectie niet overschrijft door een andere collectie (met new) anders werkt het niet meer
        // 7: Pas de textboxen aan als je op een Quote klikt
                // Bind de selectedItem met een property
                // Pas de set aan zodat een functie opgeroepen wordt als de waarde aangepast wordt om de waarde van de in te vullen tekstvelden geupdated wordt
                // Deze aanpassing van properties moet nog teruggestuurd worden naar het view als notificatie
                // Laat je viewmodel de interface INotifyPropertyChanged implementeren
                // Kopieer de onpropertychanged functie en roep deze op in de sets van de publieke properties
        // 8: Nu kan je alles testen
        // Alles hierboven werkt goed, zolang je 1 scherm hebt, messagebox tonen of nieuwe schermen open kan niet rechtstreeks vanuit de view models
        // 9: Roep een coordinator in het leven roepen, deze gaat alle UI-code bevatten
                // De interface bevat functies voor alle schermen die je hebt te openen. Maak een object van het window aan en bijhorende viewmodel, koppel het elkaar en toon het window
        // 10: Ga naar de app.xaml - verwijder de startupURI (we gaan zelf bepalen hoe er gestart moet worden)
        // 11: Ga naar de app.xaml.cs - maak de coordinator aan in een constructor en toon het gewenste scherm
        // 12: Maak nu je tweede scherm met viewmodel (addquotewindow)
        // 13: Als je de knop duwt in je mainwindow, open nu je tweede scherm ipv de quote toe te voegen
        // 14: Als je een venster wilt sluiten, dan ga je interface toevoegen aan de windows, bvb ICloseable
                // De close functie moet niet geimplementeerd worden, want die is deel van de Window
        // 15: Geef de windows nu ook mee met de constructor van het viewmodel, hiermee kan een viewmodel zijn bijhorende view afsluiten

        public MainWindow() 
        {
            InitializeComponent();
        }
    }
}
