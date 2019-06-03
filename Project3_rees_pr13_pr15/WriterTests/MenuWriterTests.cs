using Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Server;
using System.IO;
using Moq;
using Common;

namespace Writer.Tests
{
    [TestFixture]
    public class MenuWriterTests
    {

        Mock<IAddRemoveWorker> mockAddRemoveWorker = new Mock<IAddRemoveWorker>();

        [Test]
        [TestCase("+")]
        public void ActivateDeActivateWorkerTest_ValidYes(string request)
        {
            MenuWriter mw = new MenuWriter();

            mockAddRemoveWorker.Setup(m => m.AddWorker()).Returns(true);
            bool actual = mw.ActivateDeActivateWorker(request);

            Assert.AreEqual(true, actual);
        }

        [Test]
        [TestCase("-")]
        public void ActivateDeActivateWorkerTest_ValidNo(string request)
        {
            MenuWriter mw = new MenuWriter();

            mockAddRemoveWorker.Setup(m => m.RemoveWorker()).Returns(false);
            bool actual = mw.ActivateDeActivateWorker(request);

            Assert.AreEqual(false, actual);
        }

        [Test]
        [TestCase(".")]
        public void ActivateDeActivateWorkerTest_ValidDot(string request)
        {
            MenuWriter mw = new MenuWriter();

            mockAddRemoveWorker.Setup(m => m.ReturnNumberOfWorkers()).Returns(0);
            bool actual = mw.ActivateDeActivateWorker(request);

            Assert.AreEqual(true, actual);
        }

        [Test]
        [TestCase("x")]
        public void ActivateDeActivateWorkerTest_ValidX(string request)
        {
            MenuWriter mw = new MenuWriter();

            bool actual = mw.ActivateDeActivateWorker(request);

            Assert.AreEqual(true, actual);
        }

        [Test]
        [TestCase("   ")]
        [TestCase("  y ")]
        [TestCase("sadsasad")]
        public void ActivateDeActivateWorkerTest_InvalidInput(string request)
        {
            MenuWriter mw = new MenuWriter();

            Assert.Throws<ArgumentException>(() =>
            {
                mw.ActivateDeActivateWorker(request);
            });
        }

        [Test]
        [TestCase("+", "-", "2")]
        public void MenuWriter_ValidInputTest(string s1, string s2, string s3)
        {
            MenuWriter mw = new MenuWriter();
            mw.StartServer = s1;
            mw.StatusWorker = s2;
            mw.PreuzmiOdKlijenta = s3;

            Assert.AreEqual(mw.StartServer, s1);
            Assert.AreEqual(mw.StatusWorker, s2);
            Assert.AreEqual(mw.PreuzmiOdKlijenta, s3);
        }

        [Test]
        [TestCase("y")]
        [TestCase("Y")]
        public void CheckWriterInputRequestTest_ValidParameterYES(string yesOrNo)
        {
            MenuWriter mw = new MenuWriter();
            bool expected = true;
            bool actual = mw.CheckWriterInputRequest(yesOrNo);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("n")]
        [TestCase("N")]
        public void CheckWriterInputRequestTest_ValidParameterNO(string yesOrNo)
        {
            MenuWriter mw = new MenuWriter();
            bool expected = false;
            bool actual = mw.CheckWriterInputRequest(yesOrNo);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase("_")]
        [TestCase("")]
        [TestCase("dasasasd")]
        public void CheckWriterInputRequestTest_InvalidParameter(string yesOrNo)
        {
            MenuWriter mw = new MenuWriter();
            Assert.Throws<ArgumentException>(() =>
            {
                mw.CheckWriterInputRequest(yesOrNo);
            });
        }

        [Test]
        [TestCase("Y")]
        [TestCase("y")]
        public void RequestStartServerTest_ValidYES(string yes)
        {
            MenuWriter mw = new MenuWriter();
            bool expected = true;
            bool actual = mw.RequestStartServer(yes.ToUpper());
            Assert.AreEqual(expected, actual);
        }
        [Test]
        [TestCase("N")]
        [TestCase("n")]
        public void RequestStartServerTest_ValidNO(string no)
        {
            MenuWriter mw = new MenuWriter();
            bool expected = false;
            bool actual = mw.RequestStartServer(no.ToUpper());
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCase(" N")]
        [TestCase("")]
        [TestCase("234567")]
        [TestCase("Yes")]
        public void RequestStartServerTest_Invalid(string fail)
        {
            MenuWriter mw = new MenuWriter();
            Assert.Throws<ArgumentException>(() =>
            {
                mw.RequestStartServer(fail);
            });
        }

        [Test]
        public void StartServerMenuTest_Valid()
        {
            MenuWriter mw = new MenuWriter();
            var output = new StringWriter();
            Console.SetOut(output);


            var input = new StringReader("Y");
            Console.SetIn(input);
            mw.StartServerMenu();


            Assert.That(output.ToString() + "Y", Is.EqualTo(("1. Start sending data to Server[Y/N]" + Environment.NewLine + "Y")));
        }

       [Test]
       public void PrintMenuTest_Valid()
        {
            MenuWriter mw = new MenuWriter();
            var output = new StringWriter();
            Console.SetOut(output);

            var input = new StringReader("+");
            Console.SetIn(input);
            mw.PrintMenu();

            Assert.That(output.ToString() + "+", Is.EqualTo((@"
            Enter Command: + for add worker
                           - for delete worker
                           . for number of active workers
                           x for application exit" + Environment.NewLine + "+")));
        }
    }
}