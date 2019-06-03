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
    public class LoadBalancerTests
    {
        [Test]
        [TestCase("CODE_ANALOG")]
        [TestCase("CODE_DIGITAL")]
        public void CheckDataSetTest_ValidDataSet(string code)
        {
            LoadBalancer loadBalancer = new LoadBalancer();

            int actual = loadBalancer.CheckDataSet(code);
            Assert.AreEqual(1, actual);
        }

        [Test]
        [TestCase("CODE_CUSTOM")]
        [TestCase("CODE_LIMITSET")]
        public void CheckDataSetTest_ValidDataSet2(string code)
        {
            LoadBalancer loadBalancer = new LoadBalancer();

            int actual = loadBalancer.CheckDataSet(code);
            Assert.AreEqual(2, actual);
        }

        [Test]
        [TestCase("CODE_SINGLENODE")]
        [TestCase("CODE_MULTIPLENODE")]
        public void CheckDataSetTest_ValidDataSet3(string code)
        {
            LoadBalancer loadBalancer = new LoadBalancer();

            int actual = loadBalancer.CheckDataSet(code);
            Assert.AreEqual(3, actual);
        }

        [Test]
        [TestCase("CODE_CONSUMER")]
        [TestCase("CODE_SOURCE")]
        public void CheckDataSetTest_ValidDataSet4(string code)
        {
            LoadBalancer loadBalancer = new LoadBalancer();

            int actual = loadBalancer.CheckDataSet(code);
            Assert.AreEqual(4, actual);
        }

        [Test]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        public void CheckDescriptionTest_ValidDataSet(int tempDataSet)
        {
            Item item = new Item();
            LoadBalancer loadBalancer = new LoadBalancer();

            bool actual = loadBalancer.CheckDescription(tempDataSet, item);
            Assert.AreEqual(true, actual);
        }

        [Test]
        [TestCase(51)]
        public void CheckDescriptionTest_InvalidDataSet(int tempDataSet)
        {
            Item item = new Item();
            LoadBalancer loadBalancer = new LoadBalancer();

            bool actual = loadBalancer.CheckDescription(tempDataSet, item);
            Assert.AreEqual(false, actual);
        }

        [OneTimeSetUp]
        public void Connections()
        {
            ConnectionNoW connectionNoW = new ConnectionNoW();
            connectionNoW.Start();
            ConnectionReader connectionReader = new ConnectionReader();
            connectionReader.Start();
            ConnectionRefresh connectionRefresh = new ConnectionRefresh();
            connectionRefresh.Start();
            LoadBOpenConnection loadBOpenConnection = new LoadBOpenConnection();
            loadBOpenConnection.Start();
        }
    }
}