using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Task3;

namespace Task3Tests
{
    [TestClass]
    public class MethodsTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<Product> products = Methods.GetProductsByName("Paint");
            Assert.AreEqual(5, products.Count);
            Assert.AreEqual("Paint - Black", products[0].Name);
            Assert.AreEqual("Paint - Red", products[1].Name);
            Assert.AreEqual("Paint - Silver", products[2].Name);
            Assert.AreEqual("Paint - Blue", products[3].Name);
            Assert.AreEqual("Paint - Yellow", products[4].Name);
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<Product> products = Methods.GetProductsByVendorName("Speed Corporation");
            Assert.AreEqual(9, products.Count);
            Assert.AreEqual("Flat Washer 1", products[0].Name);
            Assert.AreEqual("Flat Washer 6", products[1].Name);
            Assert.AreEqual("Flat Washer 2", products[2].Name);
            Assert.AreEqual("Flat Washer 9", products[3].Name);
            Assert.AreEqual("Flat Washer 4", products[4].Name);
            Assert.AreEqual("Flat Washer 3", products[5].Name);
            Assert.AreEqual("Flat Washer 8", products[6].Name);
            Assert.AreEqual("Flat Washer 5", products[7].Name);
            Assert.AreEqual("Flat Washer 7", products[8].Name);
        }

        [TestMethod]
        public void GetProductNamesByVendorNameTest()
        {
            List<string> productNames = Methods.GetProductNamesByVendorName("Speed Corporation");
            Assert.AreEqual(9, productNames.Count);
            Assert.AreEqual("Flat Washer 1", productNames[0]);
            Assert.AreEqual("Flat Washer 6", productNames[1]);
            Assert.AreEqual("Flat Washer 2", productNames[2]);
            Assert.AreEqual("Flat Washer 9", productNames[3]);
            Assert.AreEqual("Flat Washer 4", productNames[4]);
            Assert.AreEqual("Flat Washer 3", productNames[5]);
            Assert.AreEqual("Flat Washer 8", productNames[6]);
            Assert.AreEqual("Flat Washer 5", productNames[7]);
            Assert.AreEqual("Flat Washer 7", productNames[8]);
        }

        [TestMethod]
        public void GetProductVendorByProductNameTest()
        {
            string vendorName = Methods.GetProductVendorByProductName("Short-Sleeve Classic Jersey, S");
            Assert.AreEqual("Integrated Sport Products", vendorName);
        }

        [TestMethod]
        public void GetProductsWithNRecentReviewsTest()
        {
            List<Product> products = Methods.GetProductsWithNRecentReviews(3);
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0].Name);
            Assert.AreEqual("HL Mountain Pedal", products[1].Name);
        }

        [TestMethod]
        public void GetNRecentlyReviewedProductsTest()
        {
            List<Product> products = Methods.GetNRecentlyReviewedProducts(3);
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0].Name);
            Assert.AreEqual("HL Mountain Pedal", products[1].Name);
            Assert.AreEqual("HL Mountain Pedal", products[2].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<Product> products = Methods.GetNProductsFromCategory("Clothing", 7);
            Assert.AreEqual(7, products.Count);
            Assert.AreEqual("Mountain Bike Socks, M", products[0].Name);
            Assert.AreEqual("Mountain Bike Socks, L", products[1].Name);
            Assert.AreEqual("AWC Logo Cap", products[2].Name);
            Assert.AreEqual("Long-Sleeve Logo Jersey, S", products[3].Name);
            Assert.AreEqual("Long-Sleeve Logo Jersey, M", products[4].Name);
            Assert.AreEqual("Long-Sleeve Logo Jersey, L", products[5].Name);
            Assert.AreEqual("Long-Sleeve Logo Jersey, XL", products[6].Name);
        }

        [TestMethod]
        public void GetProductCategoryByNameTest()
        {

            ProductCategory productCategory = Methods.GetProductCategoryByName("Clothing");
            Assert.IsNotNull(productCategory);
            Assert.AreEqual("Clothing", productCategory.Name);
        }

        [TestMethod]
        public void GetTotalStandardCostByCategoryTest()
        {

            int costs = Queries.GetTotalStandardCostByCategory(Methods.GetProductCategoryByName("Clothing"));
            Assert.AreEqual(868, costs);
        }


    }
}
