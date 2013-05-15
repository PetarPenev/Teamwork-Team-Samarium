using System;
using System.IO;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DisplayUtilitiesTest
{
    [TestClass]
    public class PrintInvalidEntryMessageTest
    {
        [TestMethod]
        public void PrintInvalidEntryMessage()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.PrintInvalidEntryMessage();
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "Incorrect guess or command!" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }
    }
}
