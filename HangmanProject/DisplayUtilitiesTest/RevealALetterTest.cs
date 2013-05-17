//-----------------------------------------------------------------------
// <copyright file="RevealALetterTest.cs" company="Samarium">
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
    /// Testing the RevealALetter method.
    /// </summary>
    [TestClass]
    public class RevealALetterTest
    {
        /// <summary>
        /// Test the method with no revealed characters.
        /// </summary>
        [TestMethod]
        public void TestWithNoRevealedCharacters()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.RevealALetter("dog", new char[] { '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'd'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        /// <summary>
        /// Testing the method with the second character revealed.
        /// </summary>
        [TestMethod]
        public void TestWithSecondCharacterRevealed()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.RevealALetter("compiler", new char[] { '_', 'o', '_', '_', '_', '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'c'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        /// <summary>
        /// Testing the method with two characters revealed.
        /// </summary>
        [TestMethod]
        public void TestWithFirstTwoWordsRevealed()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.RevealALetter("compiler", new char[] { 'c', 'o', '_', '_', '_', '_', '_', '_' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'm'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }

        /// <summary>
        /// Testing the method when there are no characters to be revealed.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithAllCharactersRevealed()
        {
            string actual;
            var originalConsoleOut = Console.Out;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                DisplayUtilities.RevealALetter("compiler", new char[] { 'c', 'o', 'm', 'p', 'i', 'l', 'e', 'r' });
                writer.Flush();
                actual = writer.GetStringBuilder().ToString();
            }

            Console.SetOut(originalConsoleOut);
            string expectedOutput = "OK, I reveal for you the next letter 'c'." + Environment.NewLine;
            Assert.AreEqual(expectedOutput, actual);
        }
    }
}
