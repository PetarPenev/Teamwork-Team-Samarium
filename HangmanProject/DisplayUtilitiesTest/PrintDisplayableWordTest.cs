//-----------------------------------------------------------------------
// <copyright file="PrintDisplayableWordTest.cs" company="Samarium">
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
    /// Test the PrintDisplayableWord method.
    /// </summary>
    [TestClass]
    public class PrintDisplayableWordTest
    {
        /// <summary>
        /// Test the method with three-letter word.
        /// </summary>
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

        /// <summary>
        /// Test with an argument exception.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWithEmtyArray()
        {
            DisplayUtilities.PrintDisplayableWord(new char[] { });
        }
    }
}
