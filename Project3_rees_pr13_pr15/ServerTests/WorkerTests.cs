using Common;
using DataBase;
using Moq;
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
    public class WorkerTests
    {
        [Test]
        [TestCase(true, 1, true, "1/6/2019 2:11:00 PM")]

        public void WorkerTest_ValidConstructor(bool isworking, int idworkera, bool requested, DateTime time)
        {
            Worker w1 = new Worker();
            w1.IdWorkera = idworkera;
            w1.IsWorking = isworking;
            w1.ReaderRequested = requested;
            w1.TimeStamp = time;


            Assert.AreEqual(w1.IdWorkera, idworkera);
            Assert.AreEqual(w1.ReaderRequested, requested);
            Assert.AreEqual(w1.IsWorking, isworking);
            Assert.AreEqual(w1.TimeStamp, time);
        }

        [Test]
        [TestCase(100, 99)]
        [TestCase(79, 80)]
        public void CheckDataSetTest_ValidParametersFalse(int tempValue, int value)
        {
            Worker worker = new Worker();
            bool actual = worker.CheckDataSet(tempValue, value);
            Assert.AreEqual(false, actual);
        }

        [Test]
        [TestCase(22, 99)]
        [TestCase(1, 80)]
        public void CheckDataSetTest_ValidParametersTrue(int tempValue, int value)
        {
            Worker worker = new Worker();
            bool actual = worker.CheckDataSet(tempValue, value);
            Assert.AreEqual(true, actual);
        }


        Mock<IWorkerModel> mockWorkerModel = new Mock<IWorkerModel>();

        [Test]
        public void CheckCodeTest_Valid_CodeDigital()
        {
            string code = "CODE_DIGITAL";
            int value = 1;
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            Worker worker = new Worker();

            bool actual = worker.CheckCode(code, value, sqlDataAccess);

            Assert.AreEqual(true, actual);

        }

        [Test]
        [TestCase("CODE_ANALOG")]
        [TestCase("CODE_CUSTOM")]
        [TestCase("CODE_LIMITSET")]
        [TestCase("CODE_SINGLENODE")]
        [TestCase("CODE_MULTIPLENODE")]
        [TestCase("CODE_CONSUMER")]
        [TestCase("CODE_SOURCE")]
        public void CheckCodeTest_Valid_CodeAnalog(string code)
        {
            //string code = "CODE_ANALOG";
            int value = 1;
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            Worker worker = new Worker();

            bool actual = worker.CheckCode(code, value, sqlDataAccess);
            Assert.AreEqual(true, actual);

        }

        Mock<ISqlDataAccess> mockSQL = new Mock<ISqlDataAccess>();

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void AddDataToTableTest_ValidDataSet(int dataSet)
        {
            Worker worker = new Worker();

            bool actual = worker.AddDataToTable(mockWorkerModel.Object, dataSet, mockSQL.Object);

            Assert.AreEqual(true, actual);
        }

        [Test]
        [TestCase(53)]
        public void AddDataToTableTest_InvalidDataSet(int dataSet)
        {
            Worker worker = new Worker();

            bool actual = worker.AddDataToTable(mockWorkerModel.Object, dataSet, mockSQL.Object);

            Assert.AreEqual(false, actual);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void RepackDataTest_ValidDataSet(int desc)
        {
            Worker worker = new Worker();
            Description description = new Description();//struct
            Item item1 = new Item();//struct
            description.dataSet = desc;
            description.id = 1;
            description.items = new List<Item>();
            description.items.Add(item1);
            description.items.Add(item1);
            WorkerProperty workerProperty = new WorkerProperty();//struct
            workerProperty.code = "CODE_ANALOG";
            workerProperty.workerValue = 10;

            bool actual = worker.RepackData(description, workerProperty);

            Assert.AreEqual(true, actual);
        }

        [Test]
        [TestCase(5)]
        public void RepackDataTest_InvalidDataSet(int desc)
        {
            Worker worker = new Worker();
            Description description = new Description();//struct
            Item item1 = new Item();//struct
            description.dataSet = desc;
            description.id = 1;
            description.items = new List<Item>();
            description.items.Add(item1);
            description.items.Add(item1);
            WorkerProperty workerProperty = new WorkerProperty();//struct
            workerProperty.code = "CODE_ANALOG";
            workerProperty.workerValue = 10;

            bool actual = worker.RepackData(description, workerProperty);

            Assert.AreEqual(false, actual);
        }

        [Test]
        public void ProcessDataTest()
        {
            Worker worker = new Worker();
            Description description = new Description();

            //bool expected = worker.ProcessData(description);

            Assert.Throws<NullReferenceException>(() =>
            {
                worker.ProcessData(description);
            });
        }



        //[Test]
        //public void CreateEntityTest_ValidInput()
        //{
        //    Worker worker = new Worker();
        //    CollectionDescription collectionDescription = new CollectionDescription();
        //    WorkerProperty wp = new WorkerProperty();
        //    HistoricalCollection historicalCollection = new HistoricalCollection();
        //    List<WorkerProperty> list = new List<WorkerProperty>();

        //    collectionDescription.dataSet = 1;
        //    collectionDescription.id = 1;
        //    wp.code = "CODE_ANALOG";
        //    wp.workerValue = 20;
        //    list.Add(wp);
        //    historicalCollection.items = list;
        //    collectionDescription.listaItema = historicalCollection;

        //    mockWorkerModel.SetupGet(m => m.Code).Equals("CODE_ANALOG");
        //    mockWorkerModel.SetupGet(m => m.Value).Equals(20);
        //    //mockWorkerModel.SetupGet(m => m.Code).Equals("CODE_ANALOG");

        //    IWorkerModel actual = worker.CreateEntity(collectionDescription);

        //    Assert.AreEqual(mockWorkerModel.Object, actual);

        //}

        //[TestFixture]
        //public class SqlDataAccessTests
        //{
        //    Mock<IWorkerModel> mockWorkerModel = new Mock<IWorkerModel>();

        //    [Test]
        //    public void SaveData1Test_ValidCall()
        //    {
        //        SqlDataAccess sqlDataAccess = new SqlDataAccess();
        //        string connectionString = "Test";

        //        mockWorkerModel.SetupGet(m => m.Code).Returns("CODE_ANALOG");
        //        mockWorkerModel.SetupGet(m => m.Id).Returns(1);
        //        mockWorkerModel.SetupGet(m => m.Value).Returns(20);
        //        mockWorkerModel.SetupGet(m => m.TimeStamp).Returns("6/1/2019 5:14:00 PM");

        //        //Assert.Throws<NullReferenceException>(() =>
        //        //{
        //        //    sqlDataAccess.SaveData1(mockWorkerModel.Object, connectionString);
        //        //});

        //        bool expected = sqlDataAccess.SaveData1(mockWorkerModel.Object, connectionString);

        //        Assert.AreEqual(true, expected);
        //    }
        //}
    }
}