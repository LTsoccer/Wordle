using System;
using System.Collections.Generic;

namespace Wordle
{
	public class HumanBot: IWordleBot
	{
		public HumanBot()
		{
            Words = new List<string>();
            foreach (string line in System.IO.File.ReadLines(@"../../../data/english_words_full.txt"))
            {
                Words.Add(line);
            }
            GuessWords = Words;
        }

        private List<string> Words { get; set; }

        private List<string> GuessWords { get; set; }
        public List<GuessResult> Guesses { get; set; } = new List<GuessResult>();

        public string GenerateGuess()
        {
            Console.WriteLine("Enter a 5-letter guess");
            var guess = Console.ReadLine();
            while (guess.Length != 5 || !IsValidWord(guess))
            {
                Console.WriteLine("Try Again!");
                Console.WriteLine("Enter a 5-letter guess");
                guess = Console.ReadLine();
            }

            return guess;
        }
        public bool IsValidWord(string word)
        {
            if (Words.Contains(word))
            {
             return true;
            }
            return false;
        }
    }
}

