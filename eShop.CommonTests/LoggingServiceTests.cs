using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using eShop.Common;

namespace eShop.CommonTests
{
    [TestClass]
    public class LoggingServiceTests
    {
        [TestMethod]
        public void LogAction_success()
        {
            //arrange
            var expected = "Action: Test Action";

            //act
            var actual = LoggingService.LogAction("Test Action");

            //Assert
            Assert.AreEqual(expected,actual);
        }
    }
}
