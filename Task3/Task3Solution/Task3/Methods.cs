using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task3
{
	public class Methods
	{
        private static ProductionDataContext context = new ProductionDataContext();


        public static List<Product> GetProductsByName(string namePart)
        {
            List<Product> products = context.Products
                .Where(product => product.Name.Contains(namePart))
                .ToList();

            return products;
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            List<Product> products = context.ProductVendors
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product)
                .ToList();

            return products;
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            List<string> productNames = context.ProductVendors
                .Where(productVendor => productVendor.Vendor.Name.Equals(vendorName))
                .Select(productVendor => productVendor.Product.Name)
                .ToList();

            return productNames;
        }

        public static string GetProductVendorByProductName(string productName)
        {
            string vendor = context.ProductVendors
                .Where(productVendor => productVendor.Product.Name.Equals(productName))
                .Select(productVendor => productVendor.Vendor.Name)
                .FirstOrDefault();

            return vendor;
        }

        public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
        {
            List<Product> products = context.ProductReviews
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyReviews)
                .Distinct()
                .ToList();

            return products;
        }

        public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> products = context.ProductReviews
                .OrderBy(productReview => productReview.ReviewDate)
                .Select(productReview => productReview.Product)
                .Take(howManyProducts)
                .ToList();

            return products;
        }

        public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            List<Product> products = context.Products
                .Where(product => product.ProductSubcategory.ProductCategory.Name.Equals(categoryName))
                .Take(n)
                .ToList();

            File.WriteAllText("names", String.Join("\n", products.Select(p => p.Name).ToArray()));

            return products;
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            decimal costs = context.Products
                .Where(product => product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID)
                .Select(product => product.StandardCost)
                .Sum();

            return Decimal.ToInt32(costs);
        }

        public static ProductCategory GetProductCategoryByName(string name)
        {
            ProductCategory category = context.ProductCategories
                .Where(productCategory => productCategory.Name.Equals(name))
                .FirstOrDefault();

            return category;
        }
    }
}
