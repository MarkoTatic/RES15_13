using System;
using Common;
using NUnit.Framework;

namespace WriterTests
{
    [TestFixture]
    public class LoggerTests
    {
        [Test]
        [TestCase("", @"C:\Users\ASUS\Desktop\MarkoTaticProjekatRES\Project3_rees_pr13_pr15\logger.txt")]
        public void WriteToLogFileTest_ValidCase(string text, string path)
        {
            string expected = Logger.WriteToLogFile(text, path);

            Assert.AreEqual(expected, "\r\n");

        }

        //[Test]
        //[TestCase("", @"dasdasasdasdasdaer.txt")]
        //public void WriteToLogFileTest_InValidCase(string text, string path)
        //{
        //    //string expected = 

        //    Assert.Throws<NullReferenceException>(() =>
        //    {
        //        Logger.WriteToLogFile(text, path);
        //    });

        //}
    }
}
