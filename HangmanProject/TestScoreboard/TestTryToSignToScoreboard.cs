using System;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestScoreboard
{
    [TestClass]
    public class TestTryToSignToScoreboard
    {
        [TestMethod]
        public void TestScoreboardSigning()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.TryToSignToScoreboard(5);

            Assert.AreEqual(1, scoreboard.HighScoreList.Count);
        }

        [TestMethod]
        public void TestScoreboardSigningWithoutRemoval()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.TryToSignToScoreboard(5);
            scoreboard.TryToSignToScoreboard(3);
            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(1);

            Assert.AreEqual(5, scoreboard.HighScoreList.Count);
        }

        [TestMethod]
        public void TestScoreboardSigningWithOneRemoval()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.TryToSignToScoreboard(5);
            scoreboard.TryToSignToScoreboard(3);
            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(1);
            scoreboard.TryToSignToScoreboard(4);

            Assert.AreEqual(5, scoreboard.HighScoreList.Count);
        }

        [TestMethod]
        public void TestScoreboardSigningWithThreeRemovals()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.TryToSignToScoreboard(7);
            scoreboard.TryToSignToScoreboard(6);
            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(1);
            scoreboard.TryToSignToScoreboard(5);
            scoreboard.TryToSignToScoreboard(3);
            scoreboard.TryToSignToScoreboard(4);

            Assert.AreEqual(5, scoreboard.HighScoreList.Count);
        }

        [TestMethod]
        public void TestScoreboardSigningWithEmptyName()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player", "", "Player2" };
            scoreboard.TryToSignToScoreboard(7);
            scoreboard.TryToSignToScoreboard(6);            

            Assert.AreEqual(2, scoreboard.HighScoreList.Count);

            Assert.AreEqual("Player", scoreboard.HighScoreList[0].Key);
            Assert.AreEqual("Player2", scoreboard.HighScoreList[1].Key);

            Assert.AreEqual(6, scoreboard.HighScoreList[0].Value);
            Assert.AreEqual(7, scoreboard.HighScoreList[1].Value);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestScoreboardSigningWithNull()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player", null, "Player2" };
            scoreboard.TryToSignToScoreboard(7);
            scoreboard.TryToSignToScoreboard(6);

            Assert.AreEqual(2, scoreboard.HighScoreList.Count);

            Assert.AreEqual("Player", scoreboard.HighScoreList[0].Key);
            Assert.AreEqual("Player2", scoreboard.HighScoreList[1].Key);

            Assert.AreEqual(6, scoreboard.HighScoreList[0].Value);
            Assert.AreEqual(7, scoreboard.HighScoreList[1].Value);
        }

        [TestMethod]
        public void TestScoreboardSigningWithTooLongName()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player", "TooLongANameToBePassedAsAnArgumentSoTheNextOneWillBe", 
                "Player2" };
            scoreboard.TryToSignToScoreboard(7);
            scoreboard.TryToSignToScoreboard(6);

            Assert.AreEqual(2, scoreboard.HighScoreList.Count);

            Assert.AreEqual("Player", scoreboard.HighScoreList[0].Key);
            Assert.AreEqual("Player2", scoreboard.HighScoreList[1].Key);

            Assert.AreEqual(6, scoreboard.HighScoreList[0].Value);
            Assert.AreEqual(7, scoreboard.HighScoreList[1].Value);
        }

        [TestMethod]
        public void TestScoreboardSigningWithoutQualifing()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player 0", "Player 1", "Player 2", "Player 3",
                "Player 4", "Player 5", "Player 6", "Player 7", "Player 8" };

            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(3);
            scoreboard.TryToSignToScoreboard(5);
            scoreboard.TryToSignToScoreboard(4);
            scoreboard.TryToSignToScoreboard(6);
            scoreboard.TryToSignToScoreboard(9);
            scoreboard.TryToSignToScoreboard(11);


            Assert.AreEqual(5, scoreboard.HighScoreList.Count);

            Assert.AreEqual("Player 1", scoreboard.HighScoreList[0].Key);
            Assert.AreEqual("Player 2", scoreboard.HighScoreList[1].Key);
            Assert.AreEqual("Player 4", scoreboard.HighScoreList[2].Key);
            Assert.AreEqual("Player 3", scoreboard.HighScoreList[3].Key);
            Assert.AreEqual("Player 5", scoreboard.HighScoreList[4].Key);

            Assert.AreEqual(2, scoreboard.HighScoreList[0].Value);
            Assert.AreEqual(3, scoreboard.HighScoreList[1].Value);
            Assert.AreEqual(4, scoreboard.HighScoreList[2].Value);
            Assert.AreEqual(5, scoreboard.HighScoreList[3].Value);
            Assert.AreEqual(6, scoreboard.HighScoreList[4].Value);
        }

        [TestMethod]
        public void TestScoreboardSigningWithDuplicateNames()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player 0", "Duplicate", "Duplicate", "Player 1" };

            scoreboard.TryToSignToScoreboard(2);
            scoreboard.TryToSignToScoreboard(3);
            
            Assert.AreEqual(2, scoreboard.HighScoreList.Count);

            Assert.AreEqual("Duplicate", scoreboard.HighScoreList[0].Key);
            Assert.AreEqual("Player 1", scoreboard.HighScoreList[1].Key);

            Assert.AreEqual(2, scoreboard.HighScoreList[0].Value);
            Assert.AreEqual(3, scoreboard.HighScoreList[1].Value);
        }
    }
}
