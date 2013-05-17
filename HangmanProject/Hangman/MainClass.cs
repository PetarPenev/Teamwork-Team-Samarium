using System;
using System.Linq;

namespace Hangman
{
    internal class MainClass
    {
        static void Main(string[] args)
        {
            Hangman hangman = new Hangman(10);
            hangman.Play();
        }
    }
}
