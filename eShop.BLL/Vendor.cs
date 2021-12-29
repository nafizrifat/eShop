using eShop.Common;
using System;

namespace eShop.BLL
{
    /// <summary>
    /// Manages the VENDORS from whom we purchase our inventory.
    /// </summary>
    public class Vendor
    {
        public enum IncludeAddress
        {
            Yes,
            No
        };

        public enum SendCopy
        {
            Yes,No
        };
        public int VendorId { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }



        /// <summary>
        /// Sends a product order to vendor
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quality"></param>
        /// <param name="deliveryBy"></param>
        /// <param name="instructions"></param>
        /// <returns></returns>
        public OperationResult PlaceOrder(Product product, int quality, DateTimeOffset? deliveryBy=null, String instructions="standard delivery")
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));
            if (quality <= 0)
                throw new ArgumentOutOfRangeException(nameof(quality));
            if (deliveryBy <= DateTimeOffset.Now)
                throw new ArgumentOutOfRangeException(nameof(deliveryBy));

            bool success = false;

            var orderText = "Order from eShop" + System.Environment.NewLine +
                            "Product:" + product.ProductCode + System.Environment.NewLine +
                            "Quantity:" + quality;

            if (deliveryBy.HasValue)
            {
                orderText += System.Environment.NewLine + "Deliver By:" + deliveryBy.Value.ToString("d");
            }
            if (!string.IsNullOrWhiteSpace(instructions))
            {
                orderText += System.Environment.NewLine + "Instructions:" + instructions;
            }

            var emailService = new EmailService();
            var confirmation = emailService.SendMessage("New Order", orderText, this.Email);
            if (confirmation.StartsWith("Message Sent"))
            {
                success = true;
            }

            var operationResult = new OperationResult(success, orderText);
            return operationResult;
        }

        /// <summary>
        /// Sends an email to welcome a new vendor.
        /// </summary>
        /// <returns></returns>
        public string SendWelcomeEmail(string message) 
        {
            var emailService = new EmailService();
            var subject = ("Hello " + this.CompanyName).Trim();
            var confirmation = emailService.SendMessage(subject,
                                                        message,
                                                        this.Email);
            return confirmation;
        }

        /// <summary>
        /// Placing the order 
        /// </summary>
        /// <param name="product">Product to order</param>
        /// <param name="quality">Quantity of the product to order</param>
        /// <param name="includeAddress">TRUE when shipping address included</param>
        /// <param name="sendCopy">TRUE when send copy of email</param>
        /// <returns>Success Flag and order text</returns>
        public OperationResult PlaceOrder(Product product, int quality, IncludeAddress includeAddress, SendCopy sendCopy)
        {
            var orderText = "Test";
            if (includeAddress == IncludeAddress.Yes) orderText += " With Address";
            if (sendCopy == SendCopy.Yes) orderText += "With Copy";

            var operationResult = new OperationResult(true, orderText);
            return operationResult;
        }

        public override string ToString()
        {
            string vendorInfo = "Vendor: " + this.CompanyName;
            
            string result;
           
                result = vendorInfo?.ToLower();
                result = vendorInfo?.ToUpper();
                result = vendorInfo?.Replace("Vendor", "Supplier");

                var length = vendorInfo?.Length;
                var index = vendorInfo?.IndexOf(":");
                var begins = vendorInfo?.StartsWith("Vendor");
           

            return vendorInfo;
        }

        public string PrepareDirections()
        {
            var directions = "Insert \r\n to define a new line";
            return directions;
        }

        public string PrepareDirectionsTwoLines()
        {
            var directions = "Insert \r\n to define a new line"+Environment.NewLine+"Then do that";
            return directions;
        }
    }
}