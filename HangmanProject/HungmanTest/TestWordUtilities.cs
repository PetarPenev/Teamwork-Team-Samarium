//-----------------------------------------------------------------------
// <copyright file="TestWordUtilities.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace HangmanTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Tests the word utilities class.
    /// </summary>
    [TestClass]
    public class TestWordUtilities
    {
        /// <summary>
        /// Tests the GenerateEmptyUnderscores method with 5-letter word.
        /// </summary>
        [TestMethod]
        public void GenerateEmptyWordOfUnderscoresForLengthFive()
        {
            int numberOfCharecters = 5;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
            char[] expected = new char[]
            {
                '_', '_', '_', '_', '_'
            };
            for (int i = 0; i < numberOfCharecters; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Tests the GenerateEmptyUnderscores method with 3-letter word.
        /// </summary>
        [TestMethod]
        public void GenerateEmptyWordOfUnderscoresForLengthThree()
        {
            int numberOfCharecters = 3;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
            char[] expected = new char[]
            {
                '_', '_', '_'
            };
            for (int i = 0; i < numberOfCharecters; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Tests the method with the limit value of 50.
        /// </summary>
        [TestMethod]
        public void GenerateEmptyWordOfUnderscoresForLimitValue()
        {
            int numberOfCharecters = 50;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
            char[] expected = new char[]
            {
                '_', '_', '_', '_', '_', '_', '_', '_', '_', '_',
                '_', '_', '_', '_', '_', '_', '_', '_', '_', '_',
                '_', '_', '_', '_', '_', '_', '_', '_', '_', '_',
                '_', '_', '_', '_', '_', '_', '_', '_', '_', '_',
                '_', '_', '_', '_', '_', '_', '_', '_', '_', '_'
            };                                          
            for (int i = 0; i < numberOfCharecters; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        /// <summary>
        /// Tests the method with a negative length for the word.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateEmptyWordOfUnderscoresForNegativeLength()
        {
            int numberOfCharecters = -3;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
        }

        /// <summary>
        /// Tests the method with length 0.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateEmptyWordOfUnderscoresForLengthZero()
        {
            int numberOfCharecters = 0;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
        }

        /// <summary>
        /// Tests the method with a length longer than the acceptable max length.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateEmptyWordOfUnderscoresForLengthFiftyOne()
        {
            int numberOfCharecters = 51;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
        }

        /// <summary>
        /// Tests with an array of a random name.
        /// </summary>
        [TestMethod]
        public void SelectRandomWordRandomName()
        {
            string[] myManName = new string[]
        {
            "Siabonga",
            "Nomwete"
        };
            string actual = Hangman.WordUtilities.SelectRandomWord(myManName);
            bool itsWordFromMyManName = actual == "Siabonga" || actual == "Nomwete";
            Assert.IsTrue(itsWordFromMyManName);
        }

        /// <summary>
        /// Checks the method with a partially revealed word.
        /// </summary>
        [TestMethod]
        public void CheckIfWordIsRevealedNotRevealedWord()
        {
            char[] notRevealedWord = new char[]
            {
                'A',  '_', 'B',  '_', 'C'
            };
            bool actual = Hangman.WordUtilities.CheckIfWordIsRevealed(notRevealedWord);
            Assert.IsFalse(actual);
        }

        /// <summary>
        /// Checks the method with a revealed word.
        /// </summary>
        [TestMethod]
        public void CheckIfWordIsRevealedWithRevealedWord()
        {
            char[] revealedWord = new char[]
        {
            'b', 'b', 'b'
        };
            bool actual = Hangman.WordUtilities.CheckIfWordIsRevealed(revealedWord);
            Assert.IsTrue(actual);
        }

        /// <summary>
        /// Checks the user guess in case of a present unrevealed letter.
        /// </summary>
        [TestMethod]
        public void CheckUserGuessPresentUnrevealedLetterAllCaps()
        {
            string sugestedLetter = "A";
            string secretWord = "SIABONGA";
            char[] displayableWord = new char[]
            {
                '_', '_', '_', '_', '_', '_', '_', '_'
            };
            int actual = Hangman.WordUtilities.CheckUserGuess(sugestedLetter, secretWord, displayableWord);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the user guess in case of already revealed letter.
        /// </summary>
        [TestMethod]
        public void CheckUserGuessAlreadyRevealedLetter()
        {
            string sugestedLetter = "A";
            string secretWord = "SIABONGA";
            char[] displayableWord = new char[]
            {
                'S', '_', 'A', '_', '_', '_', '_', 'A'
            };
            int actual = Hangman.WordUtilities.CheckUserGuess(sugestedLetter, secretWord, displayableWord);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Checks the user guess in case of a non-present letter.
        /// </summary>
        [TestMethod]
        public void CheckUserGuessNotPresentLetter()
        {
            string sugestedLetter = "Z";
            string sicretWord = "SIABONGA";
            char[] displayableWord = new char[]
            {
                'S', '_', 'A', '_', '_', '_', '_', 'A'
            };
            int actual = Hangman.WordUtilities.CheckUserGuess(sugestedLetter, sicretWord, displayableWord);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
