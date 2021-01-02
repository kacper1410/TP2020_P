using System;
using System.Collections.Generic;
using System.Linq;

namespace Task3
{
	public class Queries
    {
        private static ProductionDataContext context = new ProductionDataContext();


        public static List<Product> GetProductsByName(string namePart)
        {
            IEnumerable<Product> products = from product in context.Products
                                            where product.Name.Contains(namePart)
                                            select product;

            return new List<Product>(products.ToArray());
        }

        public static List<Product> GetProductsByVendorName(string vendorName)
        {
            IEnumerable<Product> products = from productVendor in context.ProductVendors
                                            where productVendor.Vendor.Name.Equals(vendorName)
                                            select productVendor.Product;

            return new List<Product>(products.ToArray());
        }

        public static List<string> GetProductNamesByVendorName(string vendorName)
        {
            IEnumerable<string> productNames = from productVendor in context.ProductVendors
                                               where productVendor.Vendor.Name.Equals(vendorName)
                                               select productVendor.Product.Name;

            return new List<string>(productNames.ToArray());
        }

        public static string GetProductVendorByProductName(string productName)
        {
            IEnumerable<string> vendor = from productVendor in context.ProductVendors
                                         where productVendor.Product.Name.Equals(productName)
                                         select productVendor.Vendor.Name;

            return vendor.First();
        }

		public static List<Product> GetProductsWithNRecentReviews(int howManyReviews)
		{
            IEnumerable<Product> products = from productReview in context.ProductReviews
                                            orderby productReview.ReviewDate
                                            select productReview.Product;

            return new List<Product>(products.Take(howManyReviews).Distinct().ToArray());
        }

		public static List<Product> GetNRecentlyReviewedProducts(int howManyProducts)
		{
            IEnumerable<Product> products = from productReview in context.ProductReviews
                                            orderby productReview.ReviewDate
                                            select productReview.Product;

            return new List<Product>(products.ToArray().Take(howManyProducts));
        }

		public static List<Product> GetNProductsFromCategory(string categoryName, int n)
        {
            IEnumerable<Product> products = from product in context.Products
                                            where product.ProductSubcategory.ProductCategory.Name.Equals(categoryName)
                                            select product;

            return new List<Product>(products.ToArray().Take(n));
        }

        public static int GetTotalStandardCostByCategory(ProductCategory category)
        {
            IEnumerable<decimal> costs = from product in context.Products
                                         where product.ProductSubcategory.ProductCategory.ProductCategoryID == category.ProductCategoryID
                                         select product.StandardCost;

            return Decimal.ToInt32(costs.Sum());
        }

        public static ProductCategory GetProductCategoryByName(string name)
        {
            IEnumerable<ProductCategory> categories = from category in context.ProductCategories
                                                      where category.Name.Equals(name)
                                                      select category;
            return categories.First();
        }
    }
}
