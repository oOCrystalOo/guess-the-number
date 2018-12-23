using System;

namespace guess_the_number
{
    class Program
    {
        private int number;
        private int count;

        static void Main(string[] args)
        {
            Program p = new Program();
            p.StartGame();
        }

        private void StartGame()
        {
            Random rnd = new Random();
            number = rnd.Next(1, 100);
            count = 0;
            Console.WriteLine("New number selected.");
            PromptInput();
        }
        private void PromptInput()
        {
            Console.WriteLine("Enter a number to guess.");
            String input = Console.ReadLine();
            int guess;
            if (Int32.TryParse(input, out guess))
            {
                if (guess < 1 || guess > 100)
                {
                    Console.WriteLine("Not a valid input.");
                    PromptInput();
                } else
                {
                    count++;
                    CheckInput(guess);
                }
            } else
            {
                Console.WriteLine("Not a valid input.");
                PromptInput();
            }
        }

        private void CheckInput (int guess)
        {
            if (guess == number)
            {
                string word = "try";
                if (count > 1)
                {
                    word = "tries";
                }
                Console.WriteLine("You guessed correctly! It took you {0} {1} to guess the correct number.", count, word);
                Console.WriteLine("Guess a new number? Y/N");
                string s = Console.ReadLine();
                if (s.ToLower() == "y")
                {
                    StartGame();
                }
            } else
            {
                if (guess < number)
                {
                    Console.WriteLine("The number is Higher.");
                    PromptInput();
                } else
                {
                    Console.WriteLine("The number is Lower.");
                    PromptInput();
                }
            }
        }
    }
}
