using NUnit.Framework;
using Reader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Tests
{

    [TestFixture]
    public class MenuTests
    {

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void ChoiseReadTest_ValidInputOk(int input)
        {
            Menu menu = new Menu();
            bool expected = true;
            bool actual = menu.ChoiseRead(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(4)]
        public void ChoiseReadTest_ValidInputNOk(int input)
        {
            Menu menu = new Menu();
            bool expected = false;
            bool actual = menu.ChoiseRead(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        public void ChoiseCodeTest_ValidInputYes(int input)
        {
            Menu menu = new Menu();
            bool expected = true;
            bool actual = menu.ChoiseCode(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(0)]
        [TestCase(9)]

        public void ChoiseCodeTest_ValidInputNOk(int input)
        {
            Menu menu = new Menu();
            bool expected = false;
            bool actual = menu.ChoiseCode(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(1, "CODE_ANALOG")]
        public void MenuTest(int value, string code)
        {
            Menu menu = new Menu(value, code);

            Assert.AreEqual(code, menu.Code);
            Assert.AreEqual(value, menu.Read);

        }

        [Test]
        public void PrintReadTest_Valid()
        {
            Menu menu = new Menu();
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("1");
            Console.SetIn(input);
            menu.PrintRead();

            Assert.That(output.ToString() + "1", Is.EqualTo("1.   Reading the last value arrived at the database" + Environment.NewLine + "2.   Read the values ​​from the selected time interval" + Environment.NewLine + "3.   Number of active Workers" + Environment.NewLine + "1"));
        }

        [Test]
        public void PrintCodeTest_Valid()
        {
            Menu menu = new Menu();
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("1");
            Console.SetIn(input);
            menu.PrintCode();

            Assert.That(output.ToString() + "1", Is.EqualTo("Please select CODE: " + Environment.NewLine + "1.   CODE_ANALOG" + Environment.NewLine +"2.   CODE_DIGITAL" + Environment.NewLine +"3.   CODE_CUSTOM" + Environment.NewLine +"4.   CODE_LIMITSET" + Environment.NewLine +"5.   CODE_SINGLENODE" + Environment.NewLine +"6.   CODE_MULTIPLENODE" + Environment.NewLine +"7.   CODE_CONSUMER" + Environment.NewLine +"8.   CODE_SOURCE" + Environment.NewLine +  "1"));
        }
    }
}