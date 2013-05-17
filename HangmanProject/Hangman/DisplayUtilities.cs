//-----------------------------------------------------------------------
// <copyright file="DisplayUtilities.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Hangman
{
    using System;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Collection of methods for abstracting the displaying of 
    /// words or parts of words.
    /// </summary>
    public static class DisplayUtilities
    {
        /// <summary>
        /// Displays the currently revealed part of the word.
        /// </summary>
        /// <param name="secretWord">The full word.</param>
        /// <param name="displayableWord">The characters to be displayed.</param>
        public static void RevealALetter(string secretWord, char[] displayableWord)
        {
            StringBuilder myBuilder = new StringBuilder();
            foreach (var letter in displayableWord)
            {
                myBuilder.Append(letter);
            }

            if (secretWord == myBuilder.ToString())
            {
                throw new ArgumentException("secret word is already revealed");
            }

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

            DisplayMessage(string.Format("OK, I reveal for you the next letter '{0}'.", 
                letterToBeRevealed), true);           
        }

        /// <summary>
        /// Prints the message for invalid entry.
        /// </summary>
        public static void PrintInvalidEntryMessage()
        {
            DisplayMessage("Incorrect guess or command!", true);
        }

        /// <summary>
        /// Prints the displayable part of the word.
        /// </summary>
        /// <param name="displayableWord">The word to be displayed.</param>
        public static void PrintDisplayableWord(char[] displayableWord)
        {
            if (displayableWord.Length < 1)
            {
                throw new ArgumentException("Displayable word can't be an empty array.");
            }

            DisplayMessage("The secret word is:", false);
            foreach (var letter in displayableWord)
            {
                DisplayMessage(string.Format(" {0}", letter), false);
            }

            DisplayMessage(string.Empty, true);
        }

        /// <summary>
        /// Prints the welcoming message for the player.
        /// </summary>
        public static void PrintWelcomeMessage()
        {
            DisplayMessage("Welcome to “Hangman” game. Please try to guess my secret word.", true);
            DisplayMessage("Use 'top' to view the top scoreboard, 'restart' to start a new game, " +
                "'help' to cheat and 'exit' to quit the game.", true);
        }

        /// <summary>
        /// A method that abstracts the printing of a message intended for 
        /// the user.
        /// </summary>
        /// <param name="message">The message to be displayed.</param>
        /// <param name="addNewLine">Whether the message should end
        /// a paragraph.</param>
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
