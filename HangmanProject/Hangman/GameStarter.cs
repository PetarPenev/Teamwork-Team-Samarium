//-----------------------------------------------------------------------
// <copyright file="GameStarter.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Hangman
{
    using System;
    using System.Linq;

    /// <summary>
    /// The class that starts the game.
    /// </summary>
    internal class GameStarter
    {
        /// <summary>
        /// The method that starts the game.
        /// </summary>
        internal static void Main()
        {
            Hangman hangman = new Hangman(10);
            hangman.Play();
        }
    }
}
