//-----------------------------------------------------------------------
// <copyright file="PrintInvalidEntryMessageTest.cs" company="Samarium">
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
    /// Testing the PrintingInvalidEntryMessage method.
    /// </summary>
    [TestClass]
    public class PrintInvalidEntryMessageTest
    {
        /// <summary>
        /// Actual test of the method.
        /// </summary>
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
