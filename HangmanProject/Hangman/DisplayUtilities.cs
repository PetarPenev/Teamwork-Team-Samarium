using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public static class DisplayUtilities
    {
        public static void HelpByRevealingALetter(string secretWord, char[] displayableWord)
        {
            int nextUnrevealedLetterIndex = 0;
            for (int index = 0; index < displayableWord.Length; index++)
            {
                if (displayableWord[index] == '_')
                {
                    nextUnrevealedLetterIndex = index;
                    break;
                }
            }
            char letterToBeRevealed = secretWord[nextUnrevealedLetterIndex];
            for (int index = 0; index < secretWord.Length; index++)
            {
                if (letterToBeRevealed == secretWord[index])
                {
                    displayableWord[index] = letterToBeRevealed;
                }
            }
            DisplayMessage(String.Format("OK, I reveal for you the next letter '{0}'.", letterToBeRevealed), true);
        }

        public static void PrintInvalidEntryMessage()
        {
            DisplayMessage("Incorrect guess or command!", true);
        }

        public static void PrintDisplayableWord(char[] displayableWord)
        {
            DisplayMessage("The secret word is:", false);
            foreach (var letter in displayableWord)
            {
                DisplayMessage(String.Format(" {0}", letter), false);
            }
            DisplayMessage(String.Empty, true);
        }

        public static void PrintWelcomeMessage()
        {
            DisplayMessage("Welcome to “Hangman” game. Please try to guess my secret word.", true);
            DisplayMessage("Use 'top' to view the top scoreboard, 'restart' to start a new game, " +
                "'help' to cheat and 'exit' to quit the game.", true);
        }

        public static void DisplayMessage(string message, bool addNewLine)
        {
            if (addNewLine)
            {
                Console.WriteLine(message);
            }
            else
            {
                Console.Write(message);
            }
        }
    }
}
