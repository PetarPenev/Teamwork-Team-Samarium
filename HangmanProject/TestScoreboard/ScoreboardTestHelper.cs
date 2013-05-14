//-----------------------------------------------------------------------
// <copyright file="ScoreboardTestHelper.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace TestScoreboard
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// A helper class for testing the scoreboard.
    /// </summary>
    public class ScoreboardTestHelper : Hangman.Scoreboard
    {
        /// <summary>
        /// The list of inputs for player names.
        /// </summary>
        private string[] inputs = new string[] { "Player1", "Player2", "Player3",
            "Player4", "Player5", "Player6", "Player7", "Player8" };

        /// <summary>
        /// The current member of the input we are passing as a name.
        /// </summary>
        private int currentInput = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ScoreboardTestHelper"/> class.
        /// </summary>
        public ScoreboardTestHelper()
        {
            this.HighScoreList = new List<KeyValuePair<string, int>>();
        }

        /// <summary>
        /// Gets or sets the names of the players.
        /// </summary>
        public string[] Inputs
        {
            get { return this.inputs; }
            set { this.inputs = value; }
        }

        /// <summary>
        /// Overriding of a method to get a name so that we can use the names specified.
        /// </summary>
        /// <returns>A string of the player's name.</returns>
        protected override string GetName()
        {
            this.currentInput++;
            if (this.currentInput >= this.inputs.Length)
            {
                this.currentInput = this.currentInput % this.inputs.Length;
            }
         
            return this.inputs[this.currentInput];
        }
    }
}
