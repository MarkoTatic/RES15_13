using Writer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Common;
using Server;

namespace Writer.Tests
{
    [TestFixture]
    public class AddRemoveWorkerTests
    {
        Mock<ITurnOnOffWorker> mockOnOff = new Mock<ITurnOnOffWorker>();

        [Test]
        public void AddWorkerTest_ValidAdd()
        {
            AddRemoveWorker addRemoveWorker = new AddRemoveWorker();
            addRemoveWorker.ConnectToSetWorker();
            mockOnOff.Setup(m => m.StartNewWorker()).Returns(true);

            bool expected = addRemoveWorker.AddWorker();
            Assert.AreEqual(expected, true);
        }

        [Test]
        public void RemoveWorkerTest_ValidRemove()
        {
            AddRemoveWorker addRemoveWorker = new AddRemoveWorker();
            addRemoveWorker.ConnectToSetWorker();
            mockOnOff.Setup(m => m.RemoveWorker()).Returns(true);

            bool expected = addRemoveWorker.RemoveWorker();
            Assert.AreEqual(expected, true);
        }


        [Test]
        public void ReturnNumberOfWorkersTest_ValidCall()
        {
            AddRemoveWorker addRemoveWorker = new AddRemoveWorker();
            addRemoveWorker.ConnectToSetWorker();
            mockOnOff.Setup(m => m.vratiListuWorkeraOdnosnoBrojWorkera()).Returns(0);

            int expected = addRemoveWorker.ReturnNumberOfWorkers();
            Assert.AreEqual(expected, 0);
        }


        [OneTimeSetUp]
        public void SetUp()
        {
            ConnectionWriter connectionWriter = new ConnectionWriter();
            connectionWriter.Start();

        }
    }
}