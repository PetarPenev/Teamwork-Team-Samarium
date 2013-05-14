﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Hangman
{
    public class Scoreboard
    {
        private const int MaxNumberOfHighScoreEntries = 5;

        protected List<KeyValuePair<String, int>> highScoreList;

        public List<KeyValuePair<String, int>> HighScoreList
        {
            get 
            {
                return new List<KeyValuePair<String, int>>(this.highScoreList);
            }

            private set
            { 
                highScoreList = value;
            }
        }

        public Scoreboard()
        {
            this.HighScoreList = new List<KeyValuePair<String, int>>();
        }

        public void TryToSignToScoreboard(int numberOfMistakesMade)
        {
            bool scoreQualifiesForHighScoreList = CheckIfScoreQualifiesForHighScoreList(numberOfMistakesMade);
            if (scoreQualifiesForHighScoreList)
            {
                AddNewRecord(numberOfMistakesMade);
                PrintCurrentScoreboard();
            }
        }

        private bool CheckIfScoreQualifiesForHighScoreList(int numberOfMistakesMade)
        {
            bool scoreQualifiesForTopFive = false;
            if (highScoreList.Count < MaxNumberOfHighScoreEntries)
            {
                scoreQualifiesForTopFive = true;
            }
            else
            {
                int worstScoreInTopFive = highScoreList[MaxNumberOfHighScoreEntries - 1].Value;
                if (numberOfMistakesMade < worstScoreInTopFive)
                {
                    scoreQualifiesForTopFive = true;
                }
            }

            return scoreQualifiesForTopFive;
        }

        protected void AddNewRecord(int numberOfMistakesMade)
        {
            if (highScoreList.Count == MaxNumberOfHighScoreEntries)
            {
                DeleteTheWorstRecord();
            }

            string playerName = AskForPlayerName();
            KeyValuePair<string, int> newRecord = new KeyValuePair<string, int>(playerName, numberOfMistakesMade);
            highScoreList.Add(newRecord);
            SortRecordsAscendingByScore();
        }

        protected string AskForPlayerName()
        {
            string name = String.Empty;
            bool inputIsAcceptable = false;
            while (!inputIsAcceptable)
            {
                Console.Write("Please enter your name for the top scoreboard: ");
                string line = GetName();
                if (line == null)
                {
                    throw new ArgumentNullException("The name was not initialized before passing.");
                }

                if (line.Length == 0)
                {
                    Console.WriteLine("You did not enter a name. Please, try again.");
                }
                else if (line.Length > 40)
                {
                    Console.WriteLine("The name you entered is too long. Please, enter a name up to 40 characters");
                }
                else if (!NameInList(line))
                {
                    name = line;
                    inputIsAcceptable = true;
                }
                else
                {
                    Console.WriteLine("The name is already taken. Please choose a different one.");
                }
            }

            return name;
        }

        private bool NameInList(string name)
        {
            Debug.Assert(!string.IsNullOrEmpty(name));
            foreach (var position in this.highScoreList)
            {
                if (position.Key == name)
                {
                    return true;
                }
            }

            return false;
        }

        protected virtual string GetName()
        {
            return Console.ReadLine();
        }

        private void DeleteTheWorstRecord()
        {
            this.highScoreList.RemoveAt(highScoreList.Count - 1);
        }

        private void SortRecordsAscendingByScore()
        {
            highScoreList.Sort(CompareByValue);
        }

        private static int CompareByValue(KeyValuePair<string, int> pairA, KeyValuePair<string, int> pairB)
        {
            return pairA.Value.CompareTo(pairB.Value);
        }

        public void PrintCurrentScoreboard()
        {
            DisplayUtilities.DisplayMessage(this.ToString(), true);
        }

        public override string ToString()
        {
            StringBuilder scoreboardText = new StringBuilder("Scoreboard:" + Environment.NewLine);
            if (highScoreList.Count == 0)
            {
                scoreboardText.Append("There are no records in the scoreboard yet.");
            }
            else
            {
                for (int index = 0; index < highScoreList.Count; index++)
                {
                    string name = highScoreList[index].Key;
                    int mistakes = highScoreList[index].Value;
                    scoreboardText.AppendLine(string.Format("{0}. {1} --> {2} mistakes", index + 1, name, mistakes));
                }
            }

            var stringOfScoreboard = scoreboardText.ToString().TrimEnd('\r', '\n');
            
            return stringOfScoreboard;
        }

    }
}
