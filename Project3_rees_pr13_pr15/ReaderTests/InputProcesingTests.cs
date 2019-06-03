using NUnit.Framework;
using Reader;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Tests
{
    [TestFixture]
    public class InputProcesingTests
    {
        [Test]
        [TestCase("R")]
        [TestCase("r")]
        public void ChoiseRefreshTest_ValidOk(string input)
        {
            InputProcesing inputProcesing = new InputProcesing();

            bool expected = true;
            bool actual = inputProcesing.ChoiseRefresh(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("F")]
        [TestCase("tr")]
        public void ChoiseRefreshTest_ValidNOk(string input)
        {
            InputProcesing inputProcesing = new InputProcesing();

            bool expected = false;
            bool actual = inputProcesing.ChoiseRefresh(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("6/1/2019 3:15:15 PM")]
        public void CheckDateTimeTest_ValideOk(DateTime input)
        {
            InputProcesing inputProcesing = new InputProcesing();

            bool expected = true;
            bool actual = inputProcesing.CheckDateTime(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("6/2/2019 3:14:55 PM", "6/3/2019 2:18:44 PM")]
        public void CheckCorectDateTimeTest_ValideOk(DateTime input1, DateTime input2)
        {
            InputProcesing inputProcesing = new InputProcesing();

            bool expected = true;
            bool actual = inputProcesing.CheckCorectDateTime(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("6/3/2019 2:18:44 PM", "6/2/2019 3:14:55 PM")]
        [TestCase("6/2/2019 3:14:55 PM", "6/2/2019 3:14:55 PM")]
        public void CheckCorectDateTimeTest_ValideNOk(DateTime input1, DateTime input2)
        {
            InputProcesing inputProcesing = new InputProcesing();

            bool expected = false;
            bool actual = inputProcesing.CheckCorectDateTime(input1, input2);

            Assert.AreEqual(expected, actual);
        }

        /*[Test]
        [TestCase("18","35","2019", "3","85","15", "PM")]
        //[TestCase("18/35/2019 3:55:99 PM")]
        //[Microsoft.VisualStudio.TestTools.UnitTesting.ExpectedException(typeof(ArgumentNullException))]
        public void CheckDateTimeTest_ValideNOk(string a, string b, string c, string d, string e, string f, string g)
         {

            int aa = Int32.Parse(a);
            int bb = Int32.Parse(b);
            int cc = Int32.Parse(c);
            int dd = Int32.Parse(d);
            int ee = Int32.Parse(e);
            int ff = Int32.Parse(f);

            InputProcesing inputProcesing = new InputProcesing();

            //DateTime input = new DateTime(cc, bb, aa, dd, ee, ff);

            /*bool expected = false;
            bool actual = inputProcesing.CheckDateTime(input);

            Assert.AreEqual(expected, actual);*/

        /*Assert.Throws<ArgumentException>(() =>
        {
            DateTime input = new DateTime(cc, bb, aa, dd, ee, ff);
        }
        );
    }*/
    }
}