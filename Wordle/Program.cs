using System;
using System.IO;

namespace Wordle
{
    class Program
    {
        static void Main(string[] args)
        {
            //var guessResult = new GuessResult("arise");

            //Console.WriteLine(guessResult);

            //string filePath = "../../../data/english_words_full.txt";

            int totalGuesses = 0;

            var secretWords = new string[] { "crane", "trash", "about" };

            foreach (var secretWord in secretWords ) {
                var bot = new AIBot();

                Console.WriteLine("New Game!");
                var game = new WordleGame(secretWord);

                int guesses = game.Play(bot);
                Console.WriteLine("Gameover.");
                Console.WriteLine($"Num Guesses: {guesses}");
                Console.WriteLine();

                totalGuesses += guesses;

            }
            double averageGuesses = (double)totalGuesses / secretWords.Length;
            Console.WriteLine();
            Console.WriteLine($"Average Guesses: {averageGuesses}");
            
        }
    }
}

