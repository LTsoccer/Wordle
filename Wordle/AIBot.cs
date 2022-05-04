using System;
using System.Collections.Generic;

namespace Wordle
{
    public class AIBot : IWordleBot
    {
        public AIBot()
        {
        }

        public List<GuessResult> Guesses { get; set; } = new List<GuessResult>();

        public string GenerateGuess()
        {
            Console.WriteLine("Enter a 5-letter guess");
            var guess = Console.ReadLine();
            if (guess.Length != 5)
            {
                Console.WriteLine("Try Again!");
                Console.WriteLine("Enter a 5-letter guess");
                guess = Console.ReadLine();
            }

            return guess;
        }
    }
}

