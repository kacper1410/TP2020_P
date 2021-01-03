using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Task3
{
	public static class MyMethods
    {
        private static MyDataContext context = new MyDataContext();

        public static List<MyProduct> GetProductsByName(string namePart)
        {
            Debug.Write(context.Products);
            List<MyProduct> products = context.Products
                .Where(product => product.Name.Contains(namePart))
                .ToList();

            return products;
        }
        public static List<MyProduct> GetProductsByVendorName(string vendorName)
        {
            List<MyProduct> products = context.Products
                .Where(product => product.Vendor.Name.Equals(vendorName))
                .ToList();

            return products;
        }

        public static List<MyProduct> GetNProductsFromCategory(string categoryName, int n)
        {
            List<MyProduct> products = context.Products
                .Where(product => product.Category.Name.Equals(categoryName))
                .OrderBy(product => product.Name)
                .Take(n)
                .ToList();

            return products;
        }
    }
}
