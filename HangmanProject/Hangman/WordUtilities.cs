using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public static class WordUtilities
    {
        public static string SelectRandomWord(string[] Words)
        {
            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(0, Words.Length);
            string randomWord = Words[randomIndex];
            return randomWord;
        }

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
