//-----------------------------------------------------------------------
// <copyright file="TestConstructor.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace TestScoreboard
{
    using System;
    using Hangman;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// A class that tests the constructor of the scoreboard.
    /// </summary>
    [TestClass]
    public class TestConstructor
    {
        /// <summary>
        /// Testing the constructor of the scoreboard.
        /// </summary>
        [TestMethod]
        public void TestConstructorOfScoreboard()
        {
            Scoreboard board = new Scoreboard(5);
            Assert.AreEqual(board.HighScoreList.Count, 0);
        }
    }
}
