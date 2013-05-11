using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Започнах тези унит тестове защото са по лесни и по разбирам какво става днес до 12.00(11 май) правя каквото правя а после ако искате го променяите
// ако искате триите каквото съм направил. Аз приключвам и почвам да се занимавам с изпита след изпита вечерта на 15 и 16 май целия съм на линия 
// ако трябва ще остана в София , може и да се съберем в телерика  заедно та да не стават конфликти моля ако може тогава да свършим работата ако не ви
// се чака до последния момент разбирам. 

namespace HungmanTest
{
    [TestClass]
    public class TestWordUtilities
    {
        [TestMethod]
        public void GenerateEmptyWordOfUnderscores_ForWordWithLength5WorkOk()
        {
            int numberOfCharecters = 5;
            char[] actual=Hangman.WordUtilities.GenerateEmptyWordOfUnderscores(numberOfCharecters);
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

        [TestMethod]
        public void SelectRandomWord_FrommyManName()
        {
            string[] myManName = new string[]
        {
            "Siabonga",
            "Nomwete"
        };
            string actual=Hangman.WordUtilities.SelectRandomWord(myManName);
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

        // CheckIfLetterIsAlreadyRevealed(string suggestedLetter, char[] displayableWord) is PRIVATE така че не му правя тестове.
    }
}
