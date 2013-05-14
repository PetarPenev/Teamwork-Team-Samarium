//-----------------------------------------------------------------------
// <copyright file="Scoreboard.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//-----------------------------------------------------------------------
namespace Hangman
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

    /// <summary>
    /// A class representing a scoreboard for a game.
    /// </summary>
    public class Scoreboard
    {
        /// <summary>
        /// Specifies the number of entries in the board.
        /// </summary>
        private const int MaxNumberOfHighScoreEntries = 5; 

        /// <summary>
        /// The list containing the players and the number of their mistakes.
        /// </summary>
        private List<KeyValuePair<string, int>> highScoreList;              

        /// <summary>
        /// Initializes a new instance of the <see cref="Scoreboard" /> class.
        /// </summary>
        public Scoreboard()
        {
            this.HighScoreList = new List<KeyValuePair<string, int>>();
        }

        /// <summary>
        /// Gets or sets the list of high scores.
        /// </summary>
        public List<KeyValuePair<string, int>> HighScoreList
        {
            get
            {
                return new List<KeyValuePair<string, int>>(this.highScoreList);
            }

            protected set
            {
                this.highScoreList = value;
            }
        }

        /// <summary>
        /// A method that signs a particular result to the scoreboard.
        /// </summary>
        /// <param name="numberOfMistakesMade">The number of mistakes made by the player.</param>
        public void TryToSignToScoreboard(int numberOfMistakesMade)
        {
            bool scoreQualifiesForHighScoreList = this.CheckIfScoreQualifiesForHighScoreList(numberOfMistakesMade);
            if (scoreQualifiesForHighScoreList)
            {
                this.AddNewRecord(numberOfMistakesMade);
                this.PrintCurrentScoreboard();
            }
        }

        /// <summary>
        /// A method that prints the current scoreboard.
        /// </summary>
        public void PrintCurrentScoreboard()
        {
            DisplayUtilities.DisplayMessage(this.ToString(), true);
        }

        /// <summary>
        /// An overriding of the ToString method for the scoreboard.
        /// </summary>
        /// <returns>A string representation of the records in the board.</returns>
        public override string ToString()
        {
            StringBuilder scoreboardText = new StringBuilder("Scoreboard:" + Environment.NewLine);
            if (this.highScoreList.Count == 0)
            {
                scoreboardText.Append("There are no records in the scoreboard yet.");
            }
            else
            {
                for (int index = 0; index < this.highScoreList.Count; index++)
                {
                    string name = this.highScoreList[index].Key;
                    int mistakes = this.highScoreList[index].Value;
                    scoreboardText.AppendLine(string.Format("{0}. {1} --> {2} mistakes", index + 1, name, mistakes));
                }
            }

            var stringOfScoreboard = scoreboardText.ToString().TrimEnd('\r', '\n');

            return stringOfScoreboard;
        }

        /// <summary>
        /// A method that gets the name of the player to be added to the list from the user.
        /// </summary>
        /// <returns>A string of the player's name that is received from the user.</returns>
        protected string AskForPlayerName()
        {
            string name = string.Empty;
            bool inputIsAcceptable = false;
            while (!inputIsAcceptable)
            {
                DisplayUtilities.DisplayMessage("Please enter your name for the top scoreboard: ", false);
                string line = this.GetName();
                if (line == null)
                {
                    throw new ArgumentNullException("The name was not initialized before passing.");
                }

                if (line.Length == 0)
                {
                    DisplayUtilities.DisplayMessage("You did not enter a name. Please, try again.", true);
                }
                else if (line.Length > 40)
                {
                    DisplayUtilities.DisplayMessage("The name you entered is too long. Please, enter a name up to 40 characters", true);
                }
                else if (!this.NameInList(line))
                {
                    name = line;
                    inputIsAcceptable = true;
                }
                else
                {
                    DisplayUtilities.DisplayMessage("The name is already taken. Please choose a different one.", true);
                }
            }

            return name;
        }

        /// <summary>
        /// A method that gets the name from the user. Used to abstract the logic of getting a name.
        /// </summary>
        /// <returns>A string of the name of the user.</returns>
        protected virtual string GetName()
        {
            return Console.ReadLine();
        }

        /// /// <summary>
        /// A comparison method used for sorting the list.
        /// </summary>
        /// <param name="pairA">First item to be compared.</param>
        /// <param name="pairB">Second item to be compared.</param>
        /// <returns>An integer value: 0 if the pairs are equal, positive if the second is bigger than
        /// the first and negative in all other cases.</returns>
        private static int CompareByValue(KeyValuePair<string, int> pairA, KeyValuePair<string, int> pairB)
        {
            return pairA.Value.CompareTo(pairB.Value);
        }

        /// <summary>
        /// A method that adds a record to the scoreboard.
        /// </summary>
        /// <param name="numberOfMistakesMade">The number of mistakes made by the player.</param>
        private void AddNewRecord(int numberOfMistakesMade)
        {
            if (this.highScoreList.Count == MaxNumberOfHighScoreEntries)
            {
                this.DeleteTheWorstRecord();
            }

            string playerName = this.AskForPlayerName();
            KeyValuePair<string, int> newRecord = new KeyValuePair<string, int>(playerName, numberOfMistakesMade);
            this.highScoreList.Add(newRecord);
            this.SortRecordsAscendingByScore();
        }

        /// <summary>
        /// A helper method that checks if a certain result is good enough to be added to the board.
        /// </summary>
        /// <param name="numberOfMistakesMade">The result to be checked.</param>
        /// <returns>A <typeparamref name="bool"/> value indicating whether the result is good enough.</returns>
        private bool CheckIfScoreQualifiesForHighScoreList(int numberOfMistakesMade)
        {
            bool scoreQualifiesForTopFive = false;
            if (this.highScoreList.Count < MaxNumberOfHighScoreEntries)
            {
                scoreQualifiesForTopFive = true;
            }
            else
            {
                int worstScoreInTopFive = this.highScoreList[MaxNumberOfHighScoreEntries - 1].Value;
                if (numberOfMistakesMade < worstScoreInTopFive)
                {
                    scoreQualifiesForTopFive = true;
                }
            }

            return scoreQualifiesForTopFive;
        }

        /// <summary>
        /// A helper method that checks whether a name is already in the board.
        /// </summary>
        /// <param name="name">The name to be checked.</param>
        /// <returns>A <typeparamref name="bool"/> value indicating whether the board contains the name.</returns>
        private bool NameInList(string name)
        {
            Debug.Assert(!string.IsNullOrEmpty(name), "Passed name should be valid at this point.");
            foreach (var position in this.highScoreList)
            {
                if (position.Key == name)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// A helper method that removes the lowest result from the board.
        /// </summary>
        private void DeleteTheWorstRecord()
        {
            this.highScoreList.RemoveAt(this.highScoreList.Count - 1);
        }

        /// <summary>
        /// A helper method that sorts the board.
        /// </summary>
        private void SortRecordsAscendingByScore()
        {
            this.highScoreList.Sort(CompareByValue);
        }
    }
}
