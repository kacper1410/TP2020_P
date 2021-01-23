using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Linq;

namespace ModelTest
{
	[TestClass]
	public class DepartmentListTest
	{
		private DepartmentList DepartmentList = new DepartmentList();
		private Model.Model Model = new Model.Model();

		[TestMethod]
		public void TestMethod1()
		{
			DepartmentList departments = new DepartmentList();

			Assert.AreEqual(22, departments.Count);
			departments.AddDepartment("22263334447", "Grupa321");
			Assert.AreEqual(23, departments.Count);
			Department department = departments.Where(d => d.Name.Equals("22263334447")).FirstOrDefault();
			departments.DeleteDepartment(department.DepartmentID);
			Assert.AreEqual(22, departments.Count);
		}
	}
}
