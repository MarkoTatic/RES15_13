using Common;
using DataBase;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataBase.Tests
{


    [TestFixture]
    public class SqlDataAccessTests
    {
        //const string lcms2Path = "C:\\SQLite.Interop.dll";
        //[DllImport(@lcms2Path)]
        //public static extern IntPtr cmsReadTag(IntPtr hProfile, uint cmsTagSignature);

        Mock<IWorkerModel> mockWorkerModel = new Mock<IWorkerModel>();
        Mock<IDbConnection> dbConnection = new Mock<IDbConnection>();

        [Test]
        public void SaveData1Test_ValidCall()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            string connectionString = "Test";

            mockWorkerModel.SetupGet(m => m.Code).Returns("CODE_ANALOG");
            mockWorkerModel.SetupGet(m => m.Id).Returns(1);
            mockWorkerModel.SetupGet(m => m.Value).Returns(20);
            mockWorkerModel.SetupGet(m => m.TimeStamp).Returns("6/1/2019 5:14:00 PM");

            Assert.Throws<NullReferenceException>(() =>
            {
                sqlDataAccess.SaveData1(mockWorkerModel.Object, connectionString, "DataSet1");
            });
        }

        [Test]
        public void LoadLastData1Test_ValidInput()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            string connectionString = "Test";

            //string expected = sqlDataAccess.LoadLastData1("CODE_ANALOG", connectionString, "DataSet1");

            //Assert.AreEqual(expected, 5);
            Assert.Throws<NullReferenceException>(() =>
            {
                sqlDataAccess.LoadLastData1("CODE_ANALOG", connectionString, "DataSet1");
            });
        }

        [Test]
        public void LoadDataFromInterval1Test_ValidInput()
        {
            SqlDataAccess sqlDataAccess = new SqlDataAccess();
            string connectionString = "Test";

            //string expected = sqlDataAccess.LoadLastData1("CODE_ANALOG", connectionString, "DataSet1");

            //Assert.AreEqual(expected, 5);

            Assert.Throws<NullReferenceException>(() =>
            {
                sqlDataAccess.LoadDataFromInterval1(DateTime.Now, DateTime.Now, "CODE_ANALOG", connectionString, "DataSet1");
            });

        }
    }
}