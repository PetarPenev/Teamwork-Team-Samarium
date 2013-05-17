//-----------------------------------------------------------------------
// <copyright file="TestHangman.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace TestHangman
{
    using System;
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testing the Hangman class (via HangmanHelper).
    /// </summary>
    [TestClass]
    public class TestHangman
    {
        /// <summary>
        /// Testing with one-letter word and only correct guesses.
        /// </summary>
        [TestMethod]
        public void TestWithOneLetterWordCorrectGuess()
        {
            string[] wordsArray = new string[] { "b" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 1);
            using (StreamReader reader = new StreamReader("OneCommandLetter.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("John", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.Scoreboard.HighScoreList[0].Value);
        }

        /// <summary>
        /// Testing with one word and three incorrect guesses.
        /// </summary>
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

            Assert.AreEqual("John", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[0].Value);
        }

        /// <summary>
        /// Testing with incorrect guesses and help.
        /// </summary>
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

            Assert.AreEqual(0, hangman.Scoreboard.HighScoreList.Count);
        }

        /// <summary>
        /// Testing with 2 games.
        /// </summary>
        [TestMethod]
        public void TestWithTwoGames()
        {
            string[] wordsArray = new string[] { "size", "nightwish" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 2);
            using (StreamReader reader = new StreamReader("TwoGames.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("John", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(2, hangman.Scoreboard.HighScoreList[1].Value);
        }

        /// <summary>
        /// Testing with 5 games.
        /// </summary>
        [TestMethod]
        public void TestWithFiveGames()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 5);
            using (StreamReader reader = new StreamReader("FiveGames.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Ovidii", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Matt", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(4, hangman.Scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("John", hangman.Scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(5, hangman.Scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Peter", hangman.Scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(6, hangman.Scoreboard.HighScoreList[4].Value);
        }

        /// <summary>
        /// Testing with 7 games and changes in scoreboard.
        /// </summary>
        [TestMethod]
        public void TestWithSevenGames()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGames.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Gosho", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.Scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.Scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.Scoreboard.HighScoreList[4].Value);
        }

        /// <summary>
        /// Testing with the top command.
        /// </summary>
        [TestMethod]
        public void TestWithTopCommand()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesWithTop.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Gosho", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.Scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.Scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.Scoreboard.HighScoreList[4].Value);
        }

        /// <summary>
        /// Testing with the restart command.
        /// </summary>
        [TestMethod]
        public void TestWithRestartCommand()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new", "horse" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 8);
            using (StreamReader reader = new StreamReader("SevenGamesWithRestart.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Dragan", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.Scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.Scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.Scoreboard.HighScoreList[4].Value);
        }

        /// <summary>
        /// Testing with help used.
        /// </summary>
        [TestMethod]
        public void TestWithHelpUsed()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new", "horse" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesWithHelp.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Ovidii", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Petkan", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(2, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Matt", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(4, hangman.Scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("John", hangman.Scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(5, hangman.Scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Peter", hangman.Scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(6, hangman.Scoreboard.HighScoreList[4].Value);
        }

        /// <summary>
        /// Testing with invalid commands.
        /// </summary>
        [TestMethod]
        public void TestWithInvalidCommands()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesWithInvalidCommands.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("Gosho", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(0, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("Ovidii", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(1, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Petkan", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(2, hangman.Scoreboard.HighScoreList[2].Value);

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[3].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[3].Value);

            Assert.AreEqual("Matt", hangman.Scoreboard.HighScoreList[4].Key);
            Assert.AreEqual(4, hangman.Scoreboard.HighScoreList[4].Value);
        }

        /// <summary>
        /// Testing with the exit command.
        /// </summary>
        [TestMethod]
        public void TestWithExit()
        {
            string[] wordsArray = new string[] { "size", "nightwish", "press", 
                "ninja", "streamliner", "create", "new" };
            HangmanHelper hangman = new HangmanHelper(wordsArray, 7);
            using (StreamReader reader = new StreamReader("SevenGamesExit.txt"))
            {
                Console.SetIn(reader);
                hangman.Play();
            }

            Assert.AreEqual("James", hangman.Scoreboard.HighScoreList[0].Key);
            Assert.AreEqual(3, hangman.Scoreboard.HighScoreList[0].Value);

            Assert.AreEqual("John", hangman.Scoreboard.HighScoreList[1].Key);
            Assert.AreEqual(5, hangman.Scoreboard.HighScoreList[1].Value);

            Assert.AreEqual("Peter", hangman.Scoreboard.HighScoreList[2].Key);
            Assert.AreEqual(6, hangman.Scoreboard.HighScoreList[2].Value);
        }
    }
}
