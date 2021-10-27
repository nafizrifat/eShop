using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShop.BLL;

namespace eShop.Wpf.ViewModels
{
    public class VendorDetailViewModel
    {
        public Vendor currentVendor { get; set; }

        VendorRepository vendorRepository = new VendorRepository();

        public VendorDetailViewModel()
        {
            LoadData();
        }

        public void LoadData()
        {
            currentVendor = vendorRepository.Retrieve(1);
        }

        //public void SaveButton_Click()
        //{

        //}
    }
}
