using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TestHangman
{
    [TestClass]
    public class TestHangman
    {
        [TestMethod]
        public void TestWithOneLetterWordCorrectGuess()
        {
            string[] wordsArray = new string[] {"b"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 1);
            using (StreamReader reader = new StreamReader("OneCommandLetter.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("John", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.scoreboard.HighScoreList[0].Value);
        }

        [TestMethod]
        public void TestWithSevenLetterWordThreeIncorrectGuesses()
        {
            string[] wordsArray = new string[] { "hankies" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 1);
            using (StreamReader reader = new StreamReader("TenLetterCommands.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("John", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(3, hangman.scoreboard.HighScoreList[0].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordThreeIncorrectGuessesWithHelp()
        {
            string[] wordsArray = new string[] { "bangables" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 1);
            using (StreamReader reader = new StreamReader("HelpUsed.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual(0, hangman.scoreboard.HighScoreList.Count);
        }

        [TestMethod]
        public void TestWithNineLetterWordTwoGames()
        {
            string[] wordsArray = new string[] { "size", "nightwish" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 2);
            using (StreamReader reader = new StreamReader("TwoGames.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("James", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("John", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(2, hangman.scoreboard.HighScoreList[1].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordFiveGames()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 5);
            using (StreamReader reader = new StreamReader("FiveGames.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Ovidii", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("James", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(3, hangman.scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Matt", hangman.scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(4, hangman.scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("John", hangman.scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(5, hangman.scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Peter", hangman.scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(6, hangman.scoreboard.HighScoreList[4].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordSevenGames()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGames.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Gosho", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.scoreboard.HighScoreList[4].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordSevenGamesWithTopCommand()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesWithTop.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Gosho", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.scoreboard.HighScoreList[4].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordSevenGamesWithRestartCommand()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new", "horse"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 8);
            using (StreamReader reader = new StreamReader("SevenGamesWithRestart.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Dragan", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.scoreboard.HighScoreList[4].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordSevenGamesWithHelpUsed()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new", "horse"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesWithHelp.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Ovidii", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Petkan", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(2, hangman.scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Matt", hangman.scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(4, hangman.scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("John", hangman.scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(5, hangman.scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Peter", hangman.scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(6, hangman.scoreboard.HighScoreList[4].Value);
        }

        [TestMethod]
        public void TestWithNineLetterWordSevenGamesWithInvalidCommands()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new"};
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesWithInvalidCommands.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Gosho", hangman.scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.scoreboard.HighScoreList[4].Value);
        }
    }
}
