using System;

namespace TestHangman
{
    public class HangmanHelper : Hangman.Hangman
    {
        private string[] wordsArray;

        public string[] WordsArray
        {
            get { 
                return wordsArray;
            }

            set {
                if ((value == null) || (value.Length==0))
                {
                    throw new ArgumentException("The array of words must not be empty.");
                }

                wordsArray = value;
            }
        }

        protected override string GetWord()
        {
            return Hangman.WordUtilities.SelectRandomWord(this.wordsArray);
        }

        public HangmanHelper(string[] arrayOfWords)
        {
            this.WordsArray = arrayOfWords;
        }
    }
}
