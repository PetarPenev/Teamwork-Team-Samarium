using System;

namespace Hangman
{
    class Hangman
    {
        // tova go pisah vav vlaka kam pernik i super me cepi glavata, lele kvo imashe v tazi bira????

        private static Scoreboard scoreboard = new Scoreboard();
        private static readonly string[] Words = new string[] 
        { 
            "computer", "programmer", "software", "debugger", "compiler", 
            "developer", "algorithm", "array", "method", "variable"
        };

        private static bool PlayOneGame()
        {
            DisplayUtilities.PrintWelcomeMessage();

            string W = WordUtilities.SelectRandomWord(Words);
            char[] displayableWord = WordUtilities.GenerateEmptyWordOfUnderscores(W.Length);
            int numberOfMistakesMade = 0;

            bool flag = false;
            bool ff = false;
            bool ff2 = false;

            while (!ff)
            {
                DisplayUtilities.PrintDisplayableWord(displayableWord);
                string command = String.Empty;
                string suggestedLetter = GetUserInput(out command);
                if (suggestedLetter != String.Empty)
                {
                    ProcessUserGuess(suggestedLetter, W, displayableWord, ref numberOfMistakesMade);
                }
                else
                {
                    ProcessCommand(command, W, displayableWord, out flag, out ff, out ff2);
                }

                bool gameIsWon = CheckIfGameIsWon(displayableWord, ff2, numberOfMistakesMade);
                if (gameIsWon)
                {
                    ff = true;
                }
            }
            return flag;
        }

        private static bool CheckIfGameIsWon(char[] displayableWord, bool helpIsUsed, int numberOfMistakesMade)
        {
            bool wordIsRevealed = WordUtilities.CheckIfWordIsRevealed(displayableWord);
            if (wordIsRevealed)
            {
                if (helpIsUsed)
                {
                    Console.WriteLine("You won with {0} mistakes but you have cheated. " +
                        "You are not allowed to enter into the scoreboard.", numberOfMistakesMade);
                    DisplayUtilities.PrintDisplayableWord(displayableWord);
                }
                else
                {
                    Console.WriteLine("You won with {0} mistakes.", numberOfMistakesMade);
                    DisplayUtilities.PrintDisplayableWord(displayableWord);
                    scoreboard.TryToSignToScoreboard(numberOfMistakesMade);
                }
            }

            return wordIsRevealed;
        }

        private static void ProcessCommand(string command, string secretWord, char[] displayableWord, out bool endOfAllGames,
            out bool endOfCurrentGame, out bool helpIsUsed)
        {
            endOfCurrentGame = false;
            endOfAllGames = false;
            helpIsUsed = false;
            switch (command)
            {
                case "top":
                    scoreboard.PrintCurrentScoreboard();
                    break;
                case "restart":
                    endOfCurrentGame = true;
                    endOfAllGames = false;
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    endOfCurrentGame = true;
                    endOfAllGames = true;
                    break;
                case "help":
                    DisplayUtilities.HelpByRevealingALetter(secretWord, displayableWord);
                    helpIsUsed = true;
                    break;
                default:
                    break;
            }
        }
        
        private static void ProcessUserGuess(string suggestedLetter, string secretWord, char[] displayableWord,
            ref int numberOfMistakesMade)
        {
            int NumberOfRevealedLetters = WordUtilities.CheckUserGuess(suggestedLetter, secretWord, displayableWord);
            if (NumberOfRevealedLetters > 0)
            {
                bool wordIsRevealed = WordUtilities.CheckIfWordIsRevealed(displayableWord);
                if (!wordIsRevealed)
                {
                    if (NumberOfRevealedLetters == 1)
                    {
                        Console.WriteLine("Good job! You revealed {0} letter.", NumberOfRevealedLetters);
                    }
                    else
                    {
                        Console.WriteLine("Good job! You revealed {0} letters.", NumberOfRevealedLetters);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter[0]);
                numberOfMistakesMade++;
            }
        }

        private static string GetUserInput(out string command)
        {
            string suggestedLetter = String.Empty;
            command = String.Empty;
            bool correctInputIsTaken = false;
            while (!correctInputIsTaken)
            {
                Console.Write("Enter your guess or command: ");
                string inputLine = Console.ReadLine();
                inputLine = inputLine.ToLower();

                if (inputLine.Length == 1)
                {
                    bool isLetter = char.IsLetter(inputLine, 0);
                    if (isLetter)
                    {
                        suggestedLetter = inputLine;
                        correctInputIsTaken = true;
                    }
                    else
                    {
                        DisplayUtilities.PrintInvalidEntryMessage();
                    }
                }
                else if (inputLine.Length == 0)
                {
                    DisplayUtilities.PrintInvalidEntryMessage();
                }
                else if ((inputLine == "top") || (inputLine == "restart") ||
                    (inputLine == "help") || (inputLine == "exit"))
                {
                    command = inputLine;
                    correctInputIsTaken = true;
                }
                else
                {
                    DisplayUtilities.PrintInvalidEntryMessage();
                }
            }
            return suggestedLetter;
        }

        static void Main(string[] args)
        {
            bool gamesAreOver = false;
            while (!gamesAreOver)
            {
                gamesAreOver = PlayOneGame();
                Console.WriteLine();
            }
        }
    }

}