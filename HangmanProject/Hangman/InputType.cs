//-----------------------------------------------------------------------
// <copyright file="InputType.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace Hangman
{
    using System;
    using System.Linq;

    /// <summary>
    /// The types of commands that the player can pass.
    /// </summary>
    public enum InputType
    {
        /// <summary>
        /// A letter - guess for the word.
        /// </summary>
        Letter,

        /// <summary>
        /// A command to be executed.
        /// </summary>
        Command,

        /// <summary>
        /// Invalid command.
        /// </summary>
        Invalid
    }
}
