using System;
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
        }
    }
}
