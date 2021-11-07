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
                {ProductId = 1, ProductName = "Milk - Whole 1G", Description = "1 gallon Whole Milk with Vitamin D"};

            var expected = "Hello Milk - Whole 1G (1) 1 gallon Whole Milk with Vitamin D"+ " Available on: ";

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

    }
}