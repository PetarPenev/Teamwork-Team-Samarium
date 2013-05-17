//-----------------------------------------------------------------------
// <copyright file="HangmanHelper.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace TestHangman
{
    using System;

    public class HangmanHelper : Hangman.Hangman
    {
        private string[] wordsArray;

        private int currentWord;

        /// <summary>
        /// Initializes a new instance of the <see cref="HangmanHelper"/> class.
        /// </summary>
        /// <param name="arrayOfWords">The array of words to be passed.</param>
        /// <param name="numberOfGames">The number of Hangman games to be played.</param>
        public HangmanHelper(string[] arrayOfWords, int numberOfGames)
            : base(numberOfGames)
        {
            this.WordsArray = arrayOfWords;
            this.currentWord = 0;
        }

        public string[] WordsArray
        {
            get
            {
                return this.wordsArray;
            }

            set
            {
                if ((value == null) || (value.Length == 0))
                {
                    throw new ArgumentException("The array of words must not be empty.");
                }

                this.wordsArray = value;
            }
        }

        protected override string GetWord()
        {
            string word = this.wordsArray[this.currentWord];
            this.currentWord++;
            return word;
        }
    }
}
