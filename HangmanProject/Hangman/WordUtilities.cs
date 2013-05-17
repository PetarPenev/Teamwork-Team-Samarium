//-----------------------------------------------------------------------
// <copyright file="WordUtilities.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class for manipulation and operations with words contained in string arrays.
    /// </summary>
    public static class WordUtilities
    {
        /// <summary>
        /// Selects a random word from the passed array.
        /// </summary>
        /// <param name="words">The array of words.</param>
        /// <returns>The randomly selected word.</returns>
        public static string SelectRandomWord(string[] words)
        {
            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(0, words.Length);
            string randomWord = words[randomIndex];
            return randomWord;
        }

        /// <summary>
        /// Generating a char array of empty underscores with a particular length.
        /// </summary>
        /// <param name="wordLength">The length of the word to be 
        /// visualized with empty underscores.</param>
        /// <returns>The char array of empty underscores.</returns>
        public static char[] GenerateEmptyWordOfUnderscores(int wordLength)
        {
            if (wordLength <= 0)
            {
                throw new ArgumentOutOfRangeException("WordLength must be a positive number!");
            }
            else if (wordLength > 50)
            {
                throw new ArgumentOutOfRangeException("There are no such long word(over 50 digits!)");
            }
            else
            {
                char[] wordOfUnderscores = new char[wordLength];
                for (int index = 0; index < wordLength; index++)
                {
                    wordOfUnderscores[index] = '_';
                }

                return wordOfUnderscores;
            }
        }

        /// <summary>
        /// Checks whether all the letters of the word have been guessed.
        /// </summary>
        /// <param name="displayableWord">The array with word characters.</param>
        /// <returns>A boolean value indicating whether the word is revealed.</returns>
        public static bool CheckIfWordIsRevealed(char[] displayableWord)
        {
            bool wordIsRevealed = true;
            for (int index = 0; index < displayableWord.Length; index++)
            {
                if (displayableWord[index] == '_')
                {
                    wordIsRevealed = false;
                    break;
                }
            }

            return wordIsRevealed;
        }

        /// <summary>
        /// A method that checks whether a letter is contained in a word in a non-revealed position.
        /// </summary>
        /// <param name="suggestedLetter">The letter to be checked.</param>
        /// <param name="secretWord">The word that is being guessed.</param>
        /// <param name="displayableWord">The array of revealed and non-revealed characters.</param>
        /// <returns>The number of occurrences of the letter.</returns>
        public static int CheckUserGuess(string suggestedLetter, string secretWord, char[] displayableWord)
        {
            int numberOfRevealedLetters = 0;
            bool letterIsAlreadyRevealed = CheckIfLetterIsAlreadyRevealed(suggestedLetter, displayableWord);
            if (!letterIsAlreadyRevealed)
            {
                for (int index = 0; index < secretWord.Length; index++)
                {
                    if (suggestedLetter[0] == secretWord[index])
                    {
                        displayableWord[index] = suggestedLetter[0];
                        numberOfRevealedLetters++;
                    }
                }
            }

            return numberOfRevealedLetters;
        }

        /// <summary>
        /// Checks whether the letter is already revealed.
        /// </summary>
        /// <param name="suggestedLetter">The letter to be checked.</param>
        /// <param name="displayableWord">The array of revealed and non-revealed characters.</param>
        /// <returns>A boolean value indicating whether the letter is already revealed.</returns>
        private static bool CheckIfLetterIsAlreadyRevealed(string suggestedLetter, char[] displayableWord)
        {
            bool letterIsAlreadyRevealed = false;
            for (int index = 0; index < displayableWord.Length; index++)
            {
                if (displayableWord[index] == suggestedLetter[0])
                {
                    letterIsAlreadyRevealed = true;
                }
            }

            return letterIsAlreadyRevealed;
        }
    }
}
