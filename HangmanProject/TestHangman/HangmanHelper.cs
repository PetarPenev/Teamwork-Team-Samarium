using System;

namespace TestHangman
{
    public class HangmanHelper : Hangman.Hangman
    {
        private string[] wordsArray;

        private int currentWord;

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
            string word = this.wordsArray[this.currentWord];
            currentWord++;
            return word;
        }

        public HangmanHelper(string[] arrayOfWords, int numberOfGames) : base(numberOfGames)
        {
            this.WordsArray = arrayOfWords;
            this.currentWord = 0;
        }
    }
}
