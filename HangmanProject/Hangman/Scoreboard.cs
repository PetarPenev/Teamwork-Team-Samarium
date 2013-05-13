using System;
using System.Collections.Generic;

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
                if (line.Length == 0)
                {
                    Console.WriteLine("You did not enter a name. Please, try again.");
                }
                else if (line.Length > 40)
                {
                    Console.WriteLine("The name you entered is too long. Please, enter a name up to 40 characters");
                }
                else
                {
                    name = line;
                    inputIsAcceptable = true;
                }
            }

            return name;
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
            Console.WriteLine("Scoreboard:");
            if (highScoreList.Count == 0)
            {
                Console.WriteLine("There are no records in the scoreboard yet.");
            }
            else
            {
                for (int index = 0; index < highScoreList.Count; index++)
                {
                    string name = highScoreList[index].Key;
                    int mistakes = highScoreList[index].Value;
                    Console.WriteLine("{0}. {1} --> {2} mistakes", index + 1, name, mistakes);
                }
            }
        }

    }
}
