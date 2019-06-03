using DataBase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tests
{
    [TestFixture]
    public class WorkerModelTests
    {
        [Test]
        [TestCase("1", "CODE_ANALOG", "20", "6/1/2019 5:14:00 PM")]
        public void WorkerModelTest_ValidInput(string id, string code, string value, string timeStamp)
        {
            WorkerModel workerModel = new WorkerModel();
            workerModel.Id = Int32.Parse(id);
            workerModel.Code = code;
            workerModel.Value = Int32.Parse(value);
            workerModel.TimeStamp = timeStamp;

            Assert.AreEqual(workerModel.Id.ToString(), id);
            Assert.AreEqual(workerModel.Value.ToString(), value);
            Assert.AreEqual(workerModel.Code, code);
            Assert.AreEqual(workerModel.TimeStamp, timeStamp);
        }

        [Test]
        [TestCase("1", "CODE_ANALOG", "20", "6/1/2019 5:14:00 PM")]
        public void WorkerModelParametersTest_ValidInput(string id, string code, string value, string timeStamp)
        {
            WorkerModel workerModel = new WorkerModel(Int32.Parse(id), Int32.Parse(value), code, timeStamp);

            Assert.AreEqual(workerModel.Id.ToString(), id);
            Assert.AreEqual(workerModel.Value.ToString(), value);
            Assert.AreEqual(workerModel.Code, code);
            Assert.AreEqual(workerModel.TimeStamp, timeStamp);
        }

    }
}