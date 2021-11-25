using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
        
        public const double InchesPerMeter = 39.37;
        public readonly decimal MinimumPrice;


        public Product()
        {
            Console.WriteLine("Product Created");
            //this.productVendor = new Vendor();
            this.MinimumPrice = .96m;
            this.Catagory = "Tools";
        }

        public Product(int productId, string productName, string description) : this()
        {
            ProductName = productName;
            ProductId = productId;
            Description = description;
            if (productName.StartsWith("Bulk"))
            {
                this.MinimumPrice = 9.99m;
            }

            Console.WriteLine("Product instance created, named: " + ProductName);
        }

        private DateTime? availabilityDate;
        public DateTime? AvailabilityDate
        {
            get { return availabilityDate; }
            set { availabilityDate = value; }
        }

        public decimal Cost { get; set; }

        private string productName;
        public string ProductName
        {
            get
            {
                var formattedName = productName?.Trim();
                return formattedName;
            }
            set
            {
                if (value.Length < 3)
                {
                    ValidationMessage = "Product Name must be at least 3 characters";
                }

                else if (value.Length >20)
                {
                    ValidationMessage = "Product Name cannot be more than 20 characters";
                }
                else
                {
                    productName = value;
                }
            }
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

        internal string Catagory { get;  set; }
        public int SequenceNumber { get; set; } = 1;
        //public string ProductCode => this.Catagory +"-"+ SequenceNumber;
        //public string ProductCode => string.Format("{0}-{1}", Catagory, SequenceNumber);
        public string ProductCode => $"{Catagory}-{SequenceNumber}";
        public string ValidationMessage { get; private set; }

        //public decimal CalculateSuggestedPrice(decimal markupPercent)
        //{
        //    return this.Cost + (this.Cost * markupPercent / 100);
        //}


        public decimal CalculateSuggestedPrice(decimal markupPercent)=>this.Cost + (this.Cost * markupPercent / 100);
        

        public string SayHello()
        {
            //var vendor = new Vendor();
            //vendor.SendWelcomeEmail("Message from Product");

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New product", this.productName, "sales@abc.com");

            var result = LoggingService.LogAction("Saying Hello");

            return "Hello " + ProductName + " (" + ProductId + ") " + Description + " Available on: " + availabilityDate?.ToShortDateString();
        }

        public override string ToString()
        {
            return this.productName + "(" + this.productId + ")";
        }
    }
}
