using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HangmanTest
{
    [TestClass]
    public class TestWordUtilities
    {
        [TestMethod]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLength5WorkOk()
        {
            int numberOfCharecters = 5;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
            char[] expected = new char[]
            {
                '_','_','_','_','_'
            };
            for (int i = 0; i < numberOfCharecters; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLength3WorkOk()
        {
            int numberOfCharecters = 3;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
            char[] expected = new char[]
            {
                '_','_','_'
            };
            for (int i = 0; i < numberOfCharecters; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        // 50 is largest exceptable value for wordLength
        [TestMethod]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLength50WorkOk()
        {
            int numberOfCharecters = 50;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
            char[] expected = new char[]
            {
                '_','_','_','_','_','_','_','_','_','_',
                '_','_','_','_','_','_','_','_','_','_',
                '_','_','_','_','_','_','_','_','_','_',
                '_','_','_','_','_','_','_','_','_','_',
                '_','_','_','_','_','_','_','_','_','_'
            };
            for (int i = 0; i < numberOfCharecters; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLengthMinus3_throwException()
        {
            int numberOfCharecters = -3;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLength0_throwException()
        {
            int numberOfCharecters = 0;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
        }

        // 51 must throw exceptio because 50 is larges acceptable wordLength
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLength51_throwException()
        {
            int numberOfCharecters = 51;
            char[] actual = Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
        }

        [TestMethod]
        public void SelectRandomWord_FrommyManName()
        {
            string[] myManName = new string[]
        {
            "Siabonga",
            "Nomwete"
        };
            string actual = Hangman.WordUtilities.SelectRandomWord(myManName);
            bool itsWordFromMyManName = (actual == "Siabonga" || actual == "Nomwete");
            Assert.IsTrue(itsWordFromMyManName);
        }

        [TestMethod]
        public void CheckIfWordIsRevealed_A_B_C_IsNotRevealed()
        {
            char[] notRevealedWord = new char[]
            {
                'A','_','B','_','C'
            };
            bool actual = Hangman.WordUtilities.CheckIfWordIsRevealed(notRevealedWord);
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CheckIfWordIsRevealed_bbb_IsRevealed()
        {
            char[] revealedWord = new char[]
        {
            'b','b','b'
        };
            bool actual = Hangman.WordUtilities.CheckIfWordIsRevealed(revealedWord);
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CheckUserGuess_GuessA_Expect2()
        {
            string sugestedLetter = "A";
            string sicretWord = "SIABONGA";
            char[] displayableWord = new char[]
            {
                '_','_','_','_','_','_','_','_'
            };
            int actual = Hangman.WordUtilities.CheckUserGuess(sugestedLetter, sicretWord, displayableWord);
            int expected = 2;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckUserGuess_GuessA_AlreadyRevealed_Expect0()
        {
            string sugestedLetter = "A";
            string sicretWord = "SIABONGA";
            char[] displayableWord = new char[]
            {
                'S','_','A','_','_','_','_','A'
            };
            int actual = Hangman.WordUtilities.CheckUserGuess(sugestedLetter, sicretWord, displayableWord);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CheckUserGuess_GuessZ_NotInThisWord_Expect0()
        {
            string sugestedLetter = "Z";
            string sicretWord = "SIABONGA";
            char[] displayableWord = new char[]
            {
                'S','_','A','_','_','_','_','A'
            };
            int actual = Hangman.WordUtilities.CheckUserGuess(sugestedLetter, sicretWord, displayableWord);
            int expected = 0;
            Assert.AreEqual(expected, actual);
        }
    }
}
