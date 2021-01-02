﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}