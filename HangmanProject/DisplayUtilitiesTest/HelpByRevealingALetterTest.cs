using System;
using Hangman;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace DisplayUtilitiesTest
{
    [TestClass]
    public class HelpByRevealingALetterTest
    {
        [TestMethod]
        public void TestWithNoRevealedWords()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.HelpByRevealingALetter("dog", new char[] { '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'd'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        [TestMethod]
        public void TestWithSecondWordRevealed()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.HelpByRevealingALetter("compiler", new char[] { '_', 'o', '_', '_', '_', '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'c'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        [TestMethod]
        public void TestWithFirstTwoWordsRevealed()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.HelpByRevealingALetter("compiler", new char[] { 'c', 'o', '_', '_', '_', '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'm'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        [TestMethod]
        [ExpectedException (typeof(ArgumentException))]
        public void TestWithAllWordsRevealed()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.HelpByRevealingALetter("compiler", new char[] { 'c', 'o', 'm', 'p', 'i', 'l', 'e', 'r' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'c'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }
    }
}
