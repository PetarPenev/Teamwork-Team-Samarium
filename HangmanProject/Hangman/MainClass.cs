using System;
using System.Linq;

namespace Hangman
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Hangman hangman = Hangman.GetHangman();
            while (!hangman.IsCurrentGameOver)
            {
                hangman.IsCurrentGameOver = hangman.PlayOneGame();
                Console.WriteLine();
            }
        }
    }
}
