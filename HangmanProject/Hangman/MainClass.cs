using System;
using System.Linq;

namespace Hangman
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Hangman hangman = Hangman.GetHangman();
            hangman.Play();
        }
    }
}
