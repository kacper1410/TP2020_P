using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;

namespace Task3
{
    public class Class1
    {
        public void method()
        {

            DataClasses1DataContext dataClasses1 = new DataClasses1DataContext();
            //IEnumerable<string> names = from product in dataClasses1.Products
            //                            where product.ProductNumber == "112"
            //                            select product.Name;

            IEnumerable<string> names = dataClasses1.Products.Where(p => p.ProductNumber == "112").Select(p => p.Name);

            Product product1 = new Product();
            product1.Name = "xd";
            product1.ProductNumber = "112";
            product1.ModifiedDate = DateTime.Now;
            product1.SellStartDate = DateTime.Now;
            product1.SellEndDate = DateTime.Now;
            product1.DiscontinuedDate = DateTime.Now;
            product1.SafetyStockLevel = 156;
            product1.ReorderPoint = 12;

            dataClasses1.Products.InsertOnSubmit(product1);

            dataClasses1.SubmitChanges();

            File.WriteAllText("names", String.Join("\n", names.ToArray()));

        }
    }
}
