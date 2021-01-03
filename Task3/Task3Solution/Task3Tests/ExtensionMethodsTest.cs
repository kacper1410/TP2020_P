using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Task3;

namespace Task3Tests
{
	[TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void GetProductsWithoutCategoryQueryTest()
        {
            List<Product> products = Queries.GetProductsByVendorName("Litware, Inc.").GetProductsWithoutCategoryQuery();
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("Adjustable Race", products[0].Name);
        }

        [TestMethod]
        public void GetProductsWithoutCategoryMethodTest()
        {
            List<Product> products = Queries.GetProductsByVendorName("Litware, Inc.").GetProductsWithoutCategoryMethod();
            Assert.AreEqual(1, products.Count);
            Assert.AreEqual("Adjustable Race", products[0].Name);
        }

        [TestMethod]
        public void GetProductPageWithSizeTest()
        {
            List<Product> products =  Queries.GetProductsByName("").GetProductPageWithSize(10, 2);
            Assert.AreEqual(10, products.Count);
            Assert.AreEqual("Chainring", products[0].Name);
            Assert.AreEqual("Crown Race", products[1].Name);
            Assert.AreEqual("Chain Stays", products[2].Name);
            Assert.AreEqual("Decal 1", products[3].Name);
            Assert.AreEqual("Decal 2", products[4].Name);
            Assert.AreEqual("Down Tube", products[5].Name);
            Assert.AreEqual("Mountain End Caps", products[6].Name);
            Assert.AreEqual("Road End Caps", products[7].Name);
            Assert.AreEqual("Touring End Caps", products[8].Name);
            Assert.AreEqual("Fork End", products[9].Name);
        }

        [TestMethod]
        public void GetProductNamesWithVendorNameQueryTest()
        {
            string str = Queries.GetProductsByName("").GetProductNamesWithVendorNameQuery();
            Assert.AreEqual(460, str.Split('\n').Length);
            Assert.AreEqual("Adjustable Race - Litware, Inc.", str.Split('\n')[0]);
            Assert.AreEqual("Hex Nut 1 - Norstan Bike Hut", str.Split('\n')[122]);
            Assert.AreEqual("Chain - Varsity Sport Co.", str.Split('\n')[459]);
        }

        [TestMethod]
        public void GetProductNamesWithVendorNammMethodTest()
        {
            string str = Queries.GetProductsByName("").GetProductNamesWithVendorNameMethod();
            Assert.AreEqual(460, str.Split('\n').Length);
            Assert.AreEqual("Adjustable Race - Litware, Inc.", str.Split('\n')[0]);
            Assert.AreEqual("Hex Nut 1 - Norstan Bike Hut", str.Split('\n')[122]);
            Assert.AreEqual("Chain - Varsity Sport Co.", str.Split('\n')[459]);
        }
    }
}
