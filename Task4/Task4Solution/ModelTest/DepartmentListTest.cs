using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;

namespace ModelTest
{
	[TestClass]
	public class DepartmentListTest
	{
		private DepartmentList DepartmentList;

		public DepartmentListTest()
		{
			Model.Model Model = new Model.Model(new DataRepository());
			DepartmentList = new DepartmentList(Model);
		}

		[TestMethod]
		public void AddDepartmentTest()
		{
			Assert.AreEqual(5, DepartmentList.Count);
			DepartmentList.AddDepartment("22263334447", "Grupa321");
			Assert.AreEqual(6, DepartmentList.Count);
		}

		[TestMethod]
		public void DeleteDepartmentTest()
		{
			Assert.AreEqual(5, DepartmentList.Count);
			DepartmentList.DeleteDepartment(5);
			Assert.AreEqual(4, DepartmentList.Count);
		}

		[TestMethod]
		public void UpdateDepartmentTest()
		{
			DepartmentList.UpdateDepartment(5, "NewName", "NewGroup");
			Assert.AreEqual("NewName", DepartmentList[4].Name);
			Assert.AreEqual("NewGroup", DepartmentList[4].GroupName);
		}
	}
}
