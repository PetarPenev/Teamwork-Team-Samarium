using System;
using System.IO;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisplayUtilitiesTest
{
    [TestClass]
    public class PrintWelcomeMessageTest
    {
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
