using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;

namespace TestScoreboard
{
    [TestClass]
    public class TestConstructor
    {
        [TestMethod]
        public void TestConstructorOfScoreboard()
        {
            Scoreboard board = new Scoreboard();
            Assert.AreEqual(board.HighScoreList.Count, 0);
        }
    }
}
