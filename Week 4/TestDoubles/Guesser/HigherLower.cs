using System;

namespace Guesser
{
    public class HigherLower
    {
        int number;

        // probleem bij het toevoegen van dependency injection is dat Random geen interfaces heeft
        // oplossing is: schrijf een wrapper klasse
        // Dit is een klasse die gebouwd is rond de Random 

        private IRandom random;

        public HigherLower(IRandom random)
        {
            number = random.Next(100);
        }

        public HigherLower(): this(new RandomWrapper())
        {

        }

        public string MakeAGuess(int guess)
        {
            if (number == guess)
            {
                return "Correct";
            }
            else if (number < guess)
            {
                return "Lower";
            }
            else
            {
                return "Higher";
            }
        }
    }
}
