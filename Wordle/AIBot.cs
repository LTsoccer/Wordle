using System;
using System.Collections.Generic;
using System.Linq;

namespace Wordle
{
    public class AIBot : IWordleBot
    {
        public AIBot()
        {
            Words = new List<string>();
            GuessWords = new List<string>();
            foreach (string line in System.IO.File.ReadLines(@"../../../data/english_words_full.txt"))
            {
                if(line.Length == 5)
                {
                    GuessWords.Add(line);
                }
            }
            Words = GuessWords;
        }

        private List<string> Words { get; set; }

        private List<string> GuessWords { get; set; }
        public List<GuessResult> Guesses { get; set; } = new List<GuessResult>();

        private string goodGuess { get; set; } = "";

        public string GenerateGuess()
        {
            Words = GuessWords;
            goodGuess = "";
            var guess = "";
            if (Guesses.Count == 0)
            {
                guess = "adieu";
                Words.Remove(guess);
            }
            else
            {
                foreach (LetterGuess letter in Guesses[Guesses.Count - 1].Guess)
                {
                    goodGuess += letter.Letter;
                }
                int counting = 0;
                Console.WriteLine(Words.Count);
                foreach (LetterGuess letter in Guesses[Guesses.Count - 1].Guess)
                {
                    EliminateWords(letter, counting);
                    counting += 1;
                }

                Random randomNumber = new Random();
                int wordIndex = randomNumber.Next(0, Words.Count - 1);
                guess = Words[wordIndex];
                Console.WriteLine(guess);


                while (!IsValidWord(guess))
                {
                    wordIndex = randomNumber.Next(0, Words.Count - 1);
                    guess = Words[wordIndex];
                }
            }

            return guess;
        }

        private void EliminateWords(LetterGuess letter, int counting)
        {
            int count = 0;
            foreach (char character in goodGuess) 
            {
                if (character == letter.Letter)
                {
                    count += 1;
                }
            }
            if ((letter.LetterResult == LetterResult.Incorrect) && (count != 1))
            {
                for (int i = Words.Count - 1; i >= 0; i--)
                {
                    string word1 = Words[i];
                
                    if (word1[counting].Equals(Guesses[Guesses.Count - 1].Guess[counting].Letter))
                    {
                        Words.Remove(word1);
                    }

                }
            }
            else if ((letter.LetterResult == LetterResult.Incorrect) && (count == 1))
            {
                for (int i = Words.Count - 1; i >= 0; i--)
                {
                    string word1 = Words[i];
                    if (word1.Contains(letter.Letter))
                    {
                        Words.Remove(word1);
                    }
                }
            }
            else if (letter.LetterResult == LetterResult.Correct)
            {
                for (int i = Words.Count - 1; i >= 0; i--)
                {
                    string word1 = Words[i];
                    if (!word1[counting].Equals(Guesses[Guesses.Count - 1].Guess[counting].Letter))
                    {
                        Words.Remove(word1);
                    }
                }
            }
            else if (letter.LetterResult == LetterResult.Misplaced)
            {
                for (int i = Words.Count - 1; i >= 0; i--)
                {
                    string word1 = Words[i];
                    if (!word1.Contains(letter.Letter))
                    {
                        Words.Remove(word1);
                    }
                    if (word1[counting].Equals(Guesses[Guesses.Count - 1].Guess[counting].Letter))
                    {
                        Words.Remove(word1);
                    }
                }
            }
        }

        public bool IsValidWord(string word)
        {
            if (GuessWords.Contains(word))
            {
                return true;
            }
            return false;
        }
    }
}

