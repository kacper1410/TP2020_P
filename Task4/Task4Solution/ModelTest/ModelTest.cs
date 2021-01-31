using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ModelTest
{
    [TestClass]
    public class ModelTest
    {
        private Model.Model Model;

        public ModelTest()
        {
            Model = new Model.Model(new DataRepository());
        }

		[TestMethod]
		public void AddDepartmentTest()
		{

			Assert.AreEqual(5, Model.GetDepartments().ToList().Count);
			Model.AddDepartment("22263334447", "Grupa321");
			Assert.AreEqual(6, Model.GetDepartments().ToList().Count);
		}

		[TestMethod]
		public void GetDepartmentsTest()
		{
			Assert.AreEqual(5, Model.GetDepartments().ToList().Count);
		}

		[TestMethod]
		public void DeleteDepartmentTest()
		{
			Assert.AreEqual(5, Model.GetDepartments().ToList().Count);
			Model.DeleteDepartment(5);
			Assert.AreEqual(4, Model.GetDepartments().ToList().Count);
		}

		[TestMethod]
		public void UpdateDepartmentTest()
		{
			Model.UpdateDepartment(5, "NewName", "NewGroup");
			Assert.AreEqual("NewName", Model.GetDepartments().ToList()[4].Name);
			Assert.AreEqual("NewGroup", Model.GetDepartments().ToList()[4].GroupName);
		}
	}
}