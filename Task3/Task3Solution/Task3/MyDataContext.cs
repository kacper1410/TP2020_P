using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class MyDataContext
    {
        public MyDataContext()
        {
            Categories = new List<MyCategory>();
            Products = new List<MyProduct>();
            Vendors = new List<MyVendor>();
            fill();
        }

        public List<MyCategory> Categories { get; set; }
        public List<MyProduct> Products { get; set; }
        public List<MyVendor> Vendors { get; set; }

        private void fill()
        {
            MyCategory category1 = new MyCategory();
            category1.Name = "Clothing";
            MyCategory category2 = new MyCategory();
            category2.Name = "Tools";

            MyVendor vendor1 = new MyVendor();
            vendor1.Name = "Nike"; 
            MyVendor vendor2 = new MyVendor();
            vendor2.Name = "Castorama"; 
            MyVendor vendor3 = new MyVendor();
            vendor3.Name = "Decathlon";

            MyProduct product1 = new MyProduct();
            product1.Name = "Hammer";
            product1.Category = category2;
            product1.Vendor = vendor2;

            MyProduct product2 = new MyProduct();
            product1.Name = "T-shirt";
            product1.Category = category1;
            product1.Vendor = vendor1;

            MyProduct product3 = new MyProduct();
            product1.Name = "Screwdriver";
            product1.Category = category2;
            product1.Vendor = vendor2;

            MyProduct product4 = new MyProduct();
            product1.Name = "Shoes";
            product1.Category = category1;
            product1.Vendor = vendor3;

            MyProduct product5 = new MyProduct();
            product1.Name = "Trousers";
            product1.Category = category1;
            product1.Vendor = vendor2;

            Categories.Add(category1);
            Categories.Add(category2);

            Vendors.Add(vendor1);
            Vendors.Add(vendor2);
            Vendors.Add(vendor3);

            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
            Products.Add(product4);
            Products.Add(product5);
        }
    }
}
