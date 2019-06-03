using NUnit.Framework;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server.Tests
{
    [TestFixture]
    public class ReadDataProviderTests
    {
        [Test]
        [TestCase("CODE_ANALOG")]
        [TestCase("CODE_CUSTOM")]
        [TestCase("CODE_LIMITSET")]
        [TestCase("CODE_SINGLENODE")]
        [TestCase("CODE_MULTIPLENODE")]
        [TestCase("CODE_CONSUMER")]
        [TestCase("CODE_SOURCE")]
        public void ReadLastValueTest_ValidCodes(string tempCode)
        {
            ReadDataProvider readDataProvider = new ReadDataProvider();

           // string expected = "test";
            //string actual = readDataProvider.ReadLastValue(tempCode);

            Assert.Throws<NullReferenceException>(() =>
            {
                readDataProvider.ReadLastValue(tempCode);
            });
        }


        [Test]
        [TestCase("CODE_ANALOG")]
        [TestCase("CODE_CUSTOM")]
        [TestCase("CODE_SINGLENODE")]
        [TestCase("CODE_CONSUMER")]
        public void ReadValueFromTimeIntervalTest_ValidCodes(string code)
        {
            ReadDataProvider readDataProvider = new ReadDataProvider();

            Assert.Throws<NullReferenceException>(() =>
            {
                readDataProvider.ReadValueFromTimeInterval(DateTime.Now, DateTime.Now, code) ;
            });
        }

    }
}