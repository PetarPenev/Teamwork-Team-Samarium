using System;

namespace Hangman
{
    class Hangman
    {
        private readonly Scoreboard scoreboard = new Scoreboard();
        private readonly string[] words = new string[] 
        { 
            "computer", "programmer", "software", "debugger", "compiler", 
            "developer", "algorithm", "array", "method", "variable"
        };

        private bool isGameWon = false;
        private bool isWholeGameOver = false;
        private bool isHelpUsed = false;
        private bool isCurrentGameOver = false;

        public bool IsCurrentGameOver
        {
            get
            {
                return this.isCurrentGameOver;
            }

            set
            {
                this.isCurrentGameOver = value;
            }
        }

        private bool PlayOneGame()
        {
            DisplayUtilities.PrintWelcomeMessage();

            string randomWord = WordUtilities.SelectRandomWord(this.words);
            char[] displayableWord = WordUtilities.GenerateEmptyWordOfUnderscores(randomWord.Length);
            int numberOfMistakesMade = 0;

            this.isGameWon = false;
            this.isHelpUsed = false;

            while (!this.isGameWon)
            {
                DisplayUtilities.PrintDisplayableWord(displayableWord);
                string command = String.Empty;
                string suggestedLetter = this.GetUserInput(out command);
                if (suggestedLetter != String.Empty)
                {
                    this.ProcessUserGuess(suggestedLetter, randomWord, displayableWord, ref numberOfMistakesMade);
                }
                else
                {
                    this.ProcessCommand(command, randomWord, displayableWord);
                }

                if (!this.isGameWon)
                {
                    this.isGameWon = this.CheckIfGameIsWon(displayableWord, this.isHelpUsed, numberOfMistakesMade);
                }
            }

            return this.isWholeGameOver;
        }

        private bool CheckIfGameIsWon(char[] displayableWord, bool helpIsUsed, int numberOfMistakesMade)
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
                    this.scoreboard.TryToSignToScoreboard(numberOfMistakesMade);
                }
            }

            return wordIsRevealed;
        }

        private void ProcessCommand(string command, string secretWord, char[] displayableWord)
        {
            switch (command)
            {
                case "top":
                    this.scoreboard.PrintCurrentScoreboard();
                    break;
                case "restart":
                    this.isGameWon = true;
                    this.isWholeGameOver = false;
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    this.isGameWon = true;
                    this.isWholeGameOver = true;
                    break;
                case "help":
                    DisplayUtilities.HelpByRevealingALetter(secretWord, displayableWord);
                    this.isHelpUsed = true;
                    break;
                default:
                    break;
            }
        }
        
        private void ProcessUserGuess(string suggestedLetter, string secretWord, char[] displayableWord, ref int numberOfMistakesMade)
        {
            int numberOfRevealedLetters = WordUtilities.CheckUserGuess(suggestedLetter, secretWord, displayableWord);
            if (numberOfRevealedLetters > 0)
            {
                bool wordIsRevealed = WordUtilities.CheckIfWordIsRevealed(displayableWord);
                if (!wordIsRevealed)
                {
                    if (numberOfRevealedLetters == 1)
                    {
                        Console.WriteLine("Good job! You revealed {0} letter.", numberOfRevealedLetters);
                    }
                    else
                    {
                        Console.WriteLine("Good job! You revealed {0} letters.", numberOfRevealedLetters);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter[0]);
                numberOfMistakesMade++;
            }
        }

        private string GetUserInput(out string command)
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
            Hangman hangman = new Hangman();
            while (!hangman.IsCurrentGameOver)
            {
                hangman.IsCurrentGameOver = hangman.PlayOneGame();
                Console.WriteLine();
            }
        }
    }
}