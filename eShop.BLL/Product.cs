using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.Common;

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
            //this.productVendor = new Vendor();
        }

        public Product(int productId, string productName, string description) : this()
        {
            ProductName = productName;
            ProductId = productId;
            Description = description;

            Console.WriteLine("Product instance created, named: " + ProductName);
        }

        private DateTime? availabilityDate;
        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
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

        private Vendor productVendor;
        public Vendor ProductVendor
        {
            get
            {
                if (productVendor == null)
                {
                    productVendor = new Vendor();
                }
                return productVendor;
            }
            set { productVendor = value; }
        }

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New product", this.productName, "sales@abc.com");

            var result = LoggingService.LogAction("Saying Hello");

            return "Hello " + ProductName + " (" + ProductId + ") " + Description + " Available on: " + availabilityDate?.ToShortDateString();
        }
    }
}
