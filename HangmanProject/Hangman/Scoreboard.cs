using System;
using System.Collections.Generic;

class Scoreboard
{
    private const int MAX_NUMBER_OF_HIGH_SCORE_ENTRIES = 5;

    private List<KeyValuePair<String, int>> highScoreList;

    public Scoreboard()
    {
        this.highScoreList = new List<KeyValuePair<String, int>>();
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
        if (highScoreList.Count < MAX_NUMBER_OF_HIGH_SCORE_ENTRIES)
        {
            scoreQualifiesForTopFive = true;
        }
        else
        {
            int worstScoreInTopFive = highScoreList[MAX_NUMBER_OF_HIGH_SCORE_ENTRIES - 1].Value;
            if (numberOfMistakesMade < worstScoreInTopFive)
            {
                scoreQualifiesForTopFive = true;
            }
        }

        return scoreQualifiesForTopFive;
    }

    private void AddNewRecord(int numberOfMistakesMade)
    {
        if (highScoreList.Count == MAX_NUMBER_OF_HIGH_SCORE_ENTRIES)
        {
            DeleteTheWorstRecord();
        }

        string playerName = AskForPlayerName();
        KeyValuePair<string, int> newRecord = new KeyValuePair<string, int>(playerName, numberOfMistakesMade);
        highScoreList.Add(newRecord);
        SortRecordsAscendingByScore();
    }

    private string AskForPlayerName()
    {
        string name = String.Empty;
        bool inputIsAcceptable = false;
        while (!inputIsAcceptable)
        {
            Console.Write("Please enter your name for the top scoreboard: ");
            string line = Console.ReadLine();
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

