using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using eShop.BLL;
using eShop.Common;

namespace eShop.BLLTests
{
    [TestClass]
    public class VendorTests
    {
        [TestMethod]
        public void  SendWelcomeEmail_NullCompany_Success()
        {
            //Arrange
            var vendor = new Vendor();
            vendor.CompanyName = null;
            var expected = "Message Sent: Hello";
            
            //Act
            var actual = vendor.SendWelcomeEmail("Test Message");

            //Assert
            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void PlaceOrderTest()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Milk", "");
            var expected = new OperationResult(true, "Order from eShop\r\nProduct:Tools-1\r\nQuantity:10\r\nInstructions:standard delivery");

            //Act
            var actual = vendor.PlaceOrder(product,10);
            

            //Assert
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Success, actual.Success);
        }
        [TestMethod]
        public void PlaceOrderTest_3Parameters()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Milk", "");
            var expected = new OperationResult(true, "Order from eShop\r\nProduct:Tools-1\r\nQuantity:10\r\nDeliver By:10/25/2022\r\nInstructions:standard delivery");

            //Act
            var actual = vendor.PlaceOrder(product, 10, new DateTimeOffset(2022, 10,25,0,0,0 ,new TimeSpan(-6,0,0)));


            //Assert
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Success, actual.Success);
        }

        [TestMethod]
        public void PlaceOrder_NoDeliveryDate()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Milk", "");
            var expected = new OperationResult(true, "Order from eShop\r\nProduct:Tools-1\r\nQuantity:10\r\nInstructions:Express delivery");

            //Act
            var actual = vendor.PlaceOrder(product, 10, instructions: "Express delivery");


            //Assert
            Assert.AreEqual(expected.Message, actual.Message);
            Assert.AreEqual(expected.Success, actual.Success);
        }

        [TestMethod]
        public void PlaceOrderTest_WithAddress()
        {
            //Arrange
            var vendor = new Vendor();
            var product = new Product(1, "Milk","");
            var expected = new OperationResult(true, "Test With Address");
           //Act
            var actual = vendor.PlaceOrder(product,12,Vendor.IncludeAddress.Yes,Vendor.SendCopy.No);

            //Assert
           Assert.AreEqual(expected.Success,actual.Success);
           Assert.AreEqual(expected.Message,actual.Message);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Product_NullProduct_Exception()
        {
            //Arrange
            var vendor = new Vendor();
            //Act
            var actual = vendor.PlaceOrder(null, 10);

            //Assert
            //Expected Exception
        }

        [TestMethod]
        public void ToStringTest()
        {
            //Arrange
            var vendor = new Vendor();
            vendor.VendorId=1;
            vendor.CompanyName = "XYZ Corp";
            var expected = "Vendor: XYZ Corp";
            //Act
            var actual = vendor.ToString();

            //Assert
            Assert.AreEqual(expected,actual);
        }

        [TestMethod]
        public void PrepareDirectionsTest()
        {
            //Arrange
            var vendor = new Vendor();
            
            var expected = "Insert \r\n to define a new line";
            //Act
            var actual = vendor.PrepareDirections();
            Console.WriteLine(actual);
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
