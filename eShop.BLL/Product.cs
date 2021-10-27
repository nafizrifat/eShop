using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL
{
    /// <summary>
    /// Manages the product for the inventory
    /// </summary>
    public class Product
    {
        public Product()
        {
            Console.WriteLine("Product Created");
        }

        public Product(int productId, string productName, string description):this()
        {
            ProductName = productName;
            ProductId = productId;
            Description = description;

            Console.WriteLine("Product instance created, named: "+ ProductName);
        }

        private string productName;
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private int productId;
        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public string SayHello()
        {
            return "Hello " + ProductName + " (" + ProductId + ") " + Description;
        }
    }
}
