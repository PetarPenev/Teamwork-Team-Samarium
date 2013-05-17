//-----------------------------------------------------------------------
// <copyright file="PrintWelcomeMessageTest.cs" company="Samarium">
//     All rights reserved © Telerik Academy 2012-2013
// </copyright>
//----------------------------------------------------------------------
namespace DisplayUtilitiesTest
{
    using System;
    using System.IO;
    using Hangman;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Testing the PrintWelcomeMessage method.
    /// </summary>
    [TestClass]
    public class PrintWelcomeMessageTest
    {
        /// <summary>
        /// Actual test of the method.
        /// </summary>
        [TestMethod]
        public void PrintWelcomeMessage()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.PrintWelcomeMessage();
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput =
                "Welcome to “Hangman” game. Please try to guess my secret word." + Environment.NewLine +
                "Use 'top' to view the top scoreboard, 'restart' to start a new game, " + 
                "'help' to cheat and 'exit' to quit the game." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }
    }
}
