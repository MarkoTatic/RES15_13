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
    public class RefreshDataProviderTests
    {
        [Test]
        [TestCase("CODE_ANALOG")]
        [TestCase("CODE_CUSTOM")]
        [TestCase("CODE_SINGLENODE")]
        [TestCase("CODE_CONSUMER")]
        public void RefreshReadTest_ValidCode(string code)
        {
            RefreshDataProvider refreshDataProvider = new RefreshDataProvider();
            Assert.Throws<NullReferenceException>(() =>
            {
                refreshDataProvider.RefreshRead(code);
            });
        }
    }
}