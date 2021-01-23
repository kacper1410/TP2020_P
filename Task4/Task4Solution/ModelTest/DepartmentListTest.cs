using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System.Diagnostics;

namespace ModelTest
{
	[TestClass]
	public class DepartmentListTest
	{
		private DepartmentList DepartmentList = new DepartmentList();

		[TestMethod]
		public void TestMethod1()
		{
			foreach (Department d in DepartmentList)
			{
				Debug.Write(d);
			}
		}
	}
}
