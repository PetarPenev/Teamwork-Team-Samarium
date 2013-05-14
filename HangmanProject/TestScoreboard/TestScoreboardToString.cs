using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hangman;
using System.Text;

namespace TestScoreboard
{
    [TestClass]
    public class TestScoreboardToString
    {
        [TestMethod]
        public void TestEmptyScoreboard()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();

            string scoreboardContent = scoreboard.ToString();
            string expectedContent = "Scoreboard:" + Environment.NewLine + 
                "There are no records in the scoreboard yet.";

            Assert.AreEqual(expectedContent, scoreboardContent);
        }

        [TestMethod]
        public void TestOneMember()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player 0", "Player 1", "Player 2", "Player 3" };

            scoreboard.TryToSignToScoreboard(4);

            string scoreboardContent = scoreboard.ToString();
            string expectedContent = "Scoreboard:" + Environment.NewLine +
                "1. Player 1 --> 4 mistakes";

            Assert.AreEqual(expectedContent, scoreboardContent);
        }

        [TestMethod]
        public void TestFullScoreboard()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player 0", "Player 1", "Player 2", 
                "Player 3", "Player 4", "Player 5" };

            scoreboard.TryToSignToScoreboard(4);
            scoreboard.TryToSignToScoreboard(3);
            scoreboard.TryToSignToScoreboard(5);
            scoreboard.TryToSignToScoreboard(9);
            scoreboard.TryToSignToScoreboard(7);

            string scoreboardContent = scoreboard.ToString();

            StringBuilder expectedString = new StringBuilder();
            expectedString.AppendLine("Scoreboard:");
            expectedString.AppendLine("1. Player 2 --> 3 mistakes");
            expectedString.AppendLine("2. Player 1 --> 4 mistakes");
            expectedString.AppendLine("3. Player 3 --> 5 mistakes");
            expectedString.AppendLine("4. Player 5 --> 7 mistakes");
            expectedString.Append("5. Player 4 --> 9 mistakes");

            string expectedContent = expectedString.ToString();

            Assert.AreEqual(expectedContent, scoreboardContent);
        }

        [TestMethod]
        public void TestFullScoreboardWithOverflow()
        {
            ScoreboardTestHelper scoreboard = new ScoreboardTestHelper();
            scoreboard.Inputs = new string[] { "Player 0", "Player 1", "Player 2", 
                "Player 3", "Player 4", "Player 5", "Player 6", "Player 7" };

            scoreboard.TryToSignToScoreboard(4);
            scoreboard.TryToSignToScoreboard(3);
            scoreboard.TryToSignToScoreboard(5);
            scoreboard.TryToSignToScoreboard(9);
            scoreboard.TryToSignToScoreboard(7);
            scoreboard.TryToSignToScoreboard(1);
            scoreboard.TryToSignToScoreboard(0);

            string scoreboardContent = scoreboard.ToString();

            StringBuilder expectedString = new StringBuilder();
            expectedString.AppendLine("Scoreboard:");
            expectedString.AppendLine("1. Player 7 --> 0 mistakes");
            expectedString.AppendLine("2. Player 6 --> 1 mistakes");
            expectedString.AppendLine("3. Player 2 --> 3 mistakes");
            expectedString.AppendLine("4. Player 1 --> 4 mistakes");
            expectedString.Append("5. Player 3 --> 5 mistakes");

            string expectedContent = expectedString.ToString();

            Assert.AreEqual(expectedContent, scoreboardContent);
        }
    }
}
