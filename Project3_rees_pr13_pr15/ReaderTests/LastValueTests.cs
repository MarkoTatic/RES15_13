using Common;
using Moq;
using NUnit.Framework;
using Reader;
using Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reader.Tests
{
    [TestFixture]
    public class LastValueTests
    {


        //[OneTimeSetUp]
        //public void Connections()
        //{

        //}

        [Test]
        public void Teest()
        {
            ConnectionReader connectionNoW = new ConnectionReader();
            connectionNoW.Start();


            ConnectionNoW connectionNoW2 = new ConnectionNoW();
            connectionNoW2.Start();

            NumberWorkers numberWorkers = new NumberWorkers();
            numberWorkers.Number();

            ValuesFromInterval valuesFromInterval = new ValuesFromInterval();
            Refreshing refreshing = new Refreshing();
            LastValue lastValue = new LastValue();

           
        }
        /*Mock<IReadData> mockLastValues = new Mock<IReadData>();
        //[OneTimeSetUp]
        //public void ConnectionsTest()
       // {
            
            //ValuesFromInterval valuesFromInterval = new ValuesFromInterval();
       // }
        

        [Test]
        public void ReadLastValueTest()
        {
            ConnectionReader connectionReader = new ConnectionReader();
            connectionReader.Start();

            LastValue lastValue = new LastValue();
            //mockValuesFromInterval.Setup(m=> m.ReadValuesFromInterval)
            //string expected = "test";
            //string actual = lastValue.ReadLastValue("CODE_ANALOG");

            mockLastValues.Setup(m => m.ReadLastValue("CODE_ANALOG")).Returns("test");
            //string actual = lastValue.ReadLastValue("CODE_ANALOG");

            //Assert.AreEqual("test", actual);
            Assert.Throws<Exception>(() =>
            {
                lastValue.ReadLastValue("CODE_ANALOG");
            });
        }*/
    }
}