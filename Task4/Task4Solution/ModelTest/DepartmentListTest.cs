using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;

namespace ModelTest
{
	[TestClass]
	public class DepartmentListTest
	{
		private DepartmentList DepartmentList = new DepartmentList();

		[TestMethod]
		public void TestMethod1()
		{
			DepartmentList.AddDepartment("test", "test_group");
		}
	}
}
