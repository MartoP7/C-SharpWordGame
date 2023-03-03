using System;
using System.Collections.Generic;
using System.Linq;

namespace wordGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // INPUT

            //difficulty
            byte lives = 0;

            Console.Write("Select difficulty - free, easy, normal, hard, hardcore:\n- ");
            string difficulty = Console.ReadLine().ToLower();
            switch (difficulty)
            {
                case "free": lives = 255; break;
                case "easy": lives = 10; break;
                case "normal": lives = 5; break;
                case "hard": lives = 3; break;
                case "hardcore": lives = 1; break;
                default: Console.WriteLine("Err: No difficulty"); return;
            }
            
            //word input
            Console.Write("Player 1: Enter word that Player 2 have to guess:\n- ");
            string word = Console.ReadLine().ToLower();

            Console.Clear();

            Console.WriteLine("Player 2: Take a guess! Enter one letter!");
            Console.WriteLine($"You have {lives} lives!\n");

            // lists init
            List<char> wordInput = word.ToCharArray().ToList();
            List<char> wordSplit = new List<char>();

            // EXECUTE METHODS

            PrintEmpty(wordInput, wordSplit);

            GuessWord(wordInput, wordSplit, word, lives);

        }
        private static void PrintEmpty(List<char> wordInput, List<char> wordSplit)
        {
            //empty space print
            Console.Write("  ");
            for (int i = 0; i < wordInput.Count; i++)
            {

                if (wordInput[i] != ' ')
                {
                    wordSplit.Add('-');
                }
                else
                {
                    wordSplit.Add(' ');
                }
            }
            Console.WriteLine(string.Join(" ", wordSplit));
        }
        private static void GuessWord(List<char> wordInput, List<char> wordSplit, string word, byte lives)
        {
            //current word
            string currentWord = String.Concat(wordSplit);

            //word guess loop
            while (currentWord != word)
            {

                if (lives > 0)
                {

                    char letter = char.Parse(Console.ReadLine());
                    int index = 0;

                    if (wordInput.Contains(letter))
                    {
                        index = wordInput.IndexOf(letter);

                        wordSplit.RemoveAt(index);
                        wordSplit.Insert(index, letter);

                        wordInput.RemoveAt(index);
                        wordInput.Insert(index, '-');
                        Console.Clear();
                        Console.WriteLine("Player 2: Take a guess! Enter one letter!");
                        Console.WriteLine($"You have {lives} lives!\n");
                        Console.Write("  ");
                        Console.WriteLine(string.Join(" ", wordSplit));
                        currentWord = String.Concat(wordSplit);

                    }
                    else
                    {
                        lives--;
                        Console.Clear();
                        Console.WriteLine("Player 2: Take a guess! Enter one letter!");
                        Console.WriteLine($"You have {lives} lives!\n");
                        Console.Write("  ");
                        Console.WriteLine(string.Join(" ", wordSplit));
                    }

                }
                else
                {
                    Console.WriteLine("\nGAME OVER!");
                    Console.WriteLine($"Player 1 wins!\n");
                    return;
                }
            }
            //player 2 wins
            if (currentWord == word)
            {
                Console.WriteLine("\nPlayer 2 wins!\n");
            }
        }
    }
}
