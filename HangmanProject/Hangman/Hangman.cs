﻿using System;

namespace Hangman
{
    public class Hangman
    {
        private static readonly object syncRoot = new Object();
        public readonly Scoreboard scoreboard = new Scoreboard();
        private int numberOfGames;
        private int maxNumberOfGames;
        private readonly string[] words = new string[] 
        { 
            "computer", "programmer", "software", "debugger", "compiler", 
            "developer", "algorithm", "array", "method", "variable"
        };

        private bool isGameWon = false;
        private bool isWholeGameOver = false;
        private bool isHelpUsed = false;
        private bool isCurrentGameOver = false;

        public Hangman(int maxNumberOfGames)
        {
            this.numberOfGames = 0;
            this.maxNumberOfGames = maxNumberOfGames;
        }

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


        /// <summary>
        /// Starts new game until user enter exit command
        /// </summary>
        public void Play()
        {
            while (!this.IsCurrentGameOver)
            {
                this.IsCurrentGameOver = this.NewGame();
                Console.WriteLine();
                if (this.numberOfGames == this.maxNumberOfGames)
                {
                    this.IsCurrentGameOver = true;
                }
            }
        }

        /// <summary>
        /// Starts one game
        /// </summary>
        /// <returns>True if user entered exit command.False if user wants to keep playing</returns>
        private bool NewGame()
        {
            DisplayUtilities.PrintWelcomeMessage();

            string randomWord = this.GetWord();
            char[] displayableWord = WordUtilities.GenerateEmptyWordOfUnderscores(randomWord.Length);
            int numberOfMistakesMade = 0;

            this.isGameWon = false;
            this.isHelpUsed = false;

            while (!this.isGameWon)
            {
                DisplayUtilities.PrintDisplayableWord(displayableWord);
                string userInput = this.GetUserInput();
                InputType inputType = GetInputType(userInput);
                if (inputType == InputType.Letter)
                {
                    this.ProcessUserGuess(userInput, randomWord, displayableWord, ref numberOfMistakesMade);
                }
                else
                {
                    this.ProcessCommand(userInput, randomWord, displayableWord);
                }

                if (!this.isGameWon)
                {
                    this.isGameWon = this.CheckIfGameIsWon(displayableWord, this.isHelpUsed, numberOfMistakesMade);
                }
            }

            this.numberOfGames++;
            return this.isWholeGameOver;
        }

        /// <summary>
        /// Returns a word that is to be guessed by the player.
        /// </summary>
        /// <returns>The word to be guessed.</returns>
        protected virtual string GetWord()
        {
            return WordUtilities.SelectRandomWord(this.words);
        }

        /// <summary>
        /// Checks if current game is won
        /// </summary>
        /// <param name="displayableWord">contains unrevealed word</param>
        /// <param name="helpIsUsed">indicates if help is used in the current game</param>
        /// <param name="numberOfMistakesMade">total number of mistakes in current game</param>
        /// <returns>True if current game is won.False if current game isn't won</returns>
        private bool CheckIfGameIsWon(char[] displayableWord, bool helpIsUsed, int numberOfMistakesMade)
        {
            bool isWon = WordUtilities.CheckIfWordIsRevealed(displayableWord);
            if (isWon)
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

            return isWon;
        }

        /// <summary>
        /// Processes different game commands
        /// </summary>
        /// <param name="command">command entered by the user</param>
        /// <param name="secretWord">contains word that is generated by the game</param>
        /// <param name="displayableWord">contains unrevealed word</param>
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

        /// <summary>
        /// Reveals suggested letter if it is in the hidden word
        /// </summary>
        /// <param name="suggestedLetter">contains letter suggested by the user</param>
        /// <param name="secretWord">contains word that is generated by the game</param>
        /// <param name="displayableWord">contains unrevealed word</param>
        /// <param name="numberOfMistakesMade">total number of mistakes in current game</param>
        private void ProcessUserGuess(string suggestedLetter, string secretWord, char[] displayableWord, ref int numberOfMistakesMade)
        {
            int numberOfRevealedLetters = WordUtilities.CheckUserGuess(suggestedLetter, secretWord, displayableWord);
            if (numberOfRevealedLetters > 0)
            {
                bool wordIsRevealed = WordUtilities.CheckIfWordIsRevealed(displayableWord);
                if (!wordIsRevealed)
                {
                    Console.WriteLine("Good job! You revealed {0} letters.", numberOfRevealedLetters);
                }
            }
            else
            {
                Console.WriteLine("Sorry! There are no unrevealed letters \"{0}\".", suggestedLetter[0]);
                numberOfMistakesMade++;
            }
        }

        /// <summary>
        /// Asks user for input until correct command is entered
        /// </summary>
        /// <returns>Correct user input</returns>
        private string GetUserInput()
        {
            string userInput = String.Empty;
            bool correctInputIsTaken = false;
            while (!correctInputIsTaken)
            {
                Console.Write("Enter your guess or command: ");
                string inputLine = Console.ReadLine();
                inputLine = inputLine.ToLower();
                InputType inputType = GetInputType(inputLine);
                if (inputType == InputType.Letter || inputType == InputType.Command)
                {
                    userInput = inputLine;
                    correctInputIsTaken = true;
                }
                else
                {
                    DisplayUtilities.PrintInvalidEntryMessage();
                }
            }

            return userInput;
        }

        /// <summary>
        /// Checks if the input is letter, command or invalid input.
        /// </summary>
        /// <param name="input">user input</param>
        /// <returns>Type of the input as InputType</returns>
        private InputType GetInputType(string input)
        {
            InputType type = InputType.Invalid;
            bool isValidCommand = (input == "top") || (input == "restart") || (input == "help") || (input == "exit");

            if (input.Length == 1)
            {
                bool isLetter = char.IsLetter(input, 0);
                if (isLetter)
                {
                    type = InputType.Letter;
                }
            }
            else if (isValidCommand)
            {
                type = InputType.Command;
            }

            return type;
        }
    }
}