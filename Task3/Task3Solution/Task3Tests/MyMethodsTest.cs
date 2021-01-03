using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task3;

namespace Task3Tests
{
	[TestClass]
    public class MyMethodsTest
    {
        [TestMethod]
        public void GetProductsByNameTest()
        {
            List<MyProduct> products = MyMethods.GetProductsByName("");
            Assert.AreEqual(5, products.Count);
            Assert.AreEqual("Hammer", products[0].Name);
            Assert.AreEqual("T-shirt", products[1].Name);
            Assert.AreEqual("Screwdriver", products[2].Name);
            Assert.AreEqual("Shoes", products[3].Name);
            Assert.AreEqual("Trousers", products[4].Name);
        }

        [TestMethod]
        public void GetProductsByVendorNameTest()
        {
            List<MyProduct> products = MyMethods.GetProductsByVendorName("Castorama");
            Assert.AreEqual(3, products.Count);
            Assert.AreEqual("Hammer", products[0].Name);
            Assert.AreEqual("Screwdriver", products[1].Name);
            Assert.AreEqual("Trousers", products[2].Name);
        }

        [TestMethod]
        public void GetNProductsFromCategoryTest()
        {
            List<MyProduct> products = MyMethods.GetNProductsFromCategory("Clothing", 2);
            Assert.AreEqual(2, products.Count);
            Assert.AreEqual("Shoes", products[0].Name);
            Assert.AreEqual("Trousers", products[1].Name);
        }
    }
}
