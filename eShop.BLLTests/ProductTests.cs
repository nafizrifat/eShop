using Microsoft.VisualStudio.TestTools.UnitTesting;
using eShop.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Tests
{
    [TestClass()]
    public class ProductTests
    {
        [TestMethod()]
        public void SayHelloTest()
        {
            //Arrange
            //setting properties 
            var currentProduct = new Product();
            currentProduct.ProductName = "Milk - Whole 1G";
            currentProduct.ProductId = 1;
            currentProduct.Description = "1 gallon Whole Milk with Vitamin D";
            currentProduct.ProductVendor.CompanyName = "ABC";

            var expected = "Hello Milk - Whole 1G (1) 1 gallon Whole Milk with Vitamin D" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloTest_ParameterizedConstructor()
        {
            //Arrange
            //parameterized constructor 
            var currentProduct = new Product(1, "Milk - Whole 1G", "1 gallon Whole Milk with Vitamin D");

            var expected = "Hello Milk - Whole 1G (1) 1 gallon Whole Milk with Vitamin D" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void SayHelloTest_ObjectInitializer()
        {
            //Arrange
            //object initializer
            var currentProduct = new Product()
            { ProductId = 1, ProductName = "Milk - Whole 1G", Description = "1 gallon Whole Milk with Vitamin D" };

            var expected = "Hello Milk - Whole 1G (1) 1 gallon Whole Milk with Vitamin D" + " Available on: ";

            //Act
            var actual = currentProduct.SayHello();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void Product_Null()
        {
            //Arrange
            Product currentProduct = null;
            var companyName = currentProduct?.ProductVendor?.CompanyName;

            string expected = null;
            //Act
            var actual = companyName;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ConvertMetersToInchesTest()
        {
            //Arrange
            var expected = 78.74;

            //Act
            var actual = 2 * Product.InchesPerMeter;

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void MinimumPriceTest_Default()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = .96m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void MinimumPriceTest_Bulk()
        {
            //Arrange
            var currentProduct = new Product(1, "Bulk Product", "");
            var expected = 9.99m;

            //Act
            var actual = currentProduct.MinimumPrice;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductName_Format()
        {
            //Arrange
            var currentProduct = new Product(1, " Steel Hammer ", "");
            var expected = "Steel Hammer";

            //Act
            var actual = currentProduct.ProductName;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Validation_TooShort()
        {
            //Arrange
            var currentProduct = new Product(1, "aw", "");
            string expected = null;
            var expectedMessage = "Product Name must be at least 3 characters";
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void Validation_TooLong()
        {
            //Arrange
            var currentProduct = new Product(1, "Milk with 2percent of fat almost fat free", "");
            string expected = null;
            var expectedMessage = "Product Name cannot be more than 20 characters";
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void Validation_JustRight()
        {
            //Arrange
            var currentProduct = new Product(1, "Milk with 2%", "");
            var expected = "Milk with 2%";
            string expectedMessage = null;
            //Act
            var actual = currentProduct.ProductName;
            var actualMessage = currentProduct.ValidationMessage;

            //Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod()]
        public void Category_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools";

            //Act
            var actual = currentProduct.Catagory;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Category_NewValue()
        {
            //Arrange
            var currentProduct = new Product();
            currentProduct.Catagory = "Electronic";
            var expected = "Electronic";

            //Act
            var actual = currentProduct.Catagory;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sequence_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = 1;

            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Sequence_NewValue()
        {//Arrange
            var currentProduct = new Product();
            currentProduct.SequenceNumber = 5;
            var expected = 5;

            //Act
            var actual = currentProduct.SequenceNumber;

            //Assert
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void ProductCode_DefaultValue()
        {
            //Arrange
            var currentProduct = new Product();
            var expected = "Tools-1";

            //Act
            var actual = currentProduct.ProductCode;

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }

}