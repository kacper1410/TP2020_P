using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Task3
{
    public static class ExtensionMethods
    {
        private static ProductionDataContext context = new ProductionDataContext();

        public static List<Product> GetProductsWithoutCategoryQuery(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutCategory = from product in products
                                                           where product.ProductSubcategory == null
                                                           select product;

            return productsWithoutCategory.ToList();
        }

        public static List<Product> GetProductsWithoutCategoryMethod(this List<Product> products)
        {
            IEnumerable<Product> productsWithoutCategoty = products.Where(product => product.ProductSubcategory == null);

            return productsWithoutCategoty.ToList();
        }

        public static List<Product> GetProductPageWithSize(this List<Product> products, int size, int pageNumber)
        {
            List<Product> _products = products.Skip((pageNumber - 1) * size).Take(size).ToList();

            return _products;
        }

        public static string GetProductNamesWithVendorNameQuery(this List<Product> products)
		{
            var productWithVendor = from product in products
                                    from productVendor in context.ProductVendors
                                    where productVendor.ProductID == product.ProductID
                                    select new { ProductName = productVendor.Product.Name, VendorName = productVendor.Vendor.Name  };

            IEnumerable<string> lines = productWithVendor.Select(p => p.ProductName + " - " + p.VendorName);

            return String.Join("\n", lines.ToArray());
		}

		public static string GetProductNamesWithVendorNameMethod(this List<Product> products)
		{
			var productWithVendor = products.Join(
                context.ProductVendors,
                product => product.ProductID, 
                productVendor => productVendor.ProductID,
                (product, productVendor) => new { ProductName = product.Name, VendorName = productVendor.Vendor.Name });

            IEnumerable<string> lines = productWithVendor.Select(p => p.ProductName + " - " + p.VendorName);

            return String.Join("\n", lines.ToArray());
        }
	}
}
