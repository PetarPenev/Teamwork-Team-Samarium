using System;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DisplayUtilitiesTest
{
    [TestClass]
    public class PrintDisplayableWordTest
    {
        [TestMethod]
        public void TestWithThreeLetters()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.PrintDisplayableWord(new char[] { '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "The secret word is: _ _ _" + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestWithEmtyArray()
        {
            DisplayUtilities.PrintDisplayableWord(new char[] { });
        }
    }
}
