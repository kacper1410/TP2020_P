using Logic;
using System;
using System.Collections.Generic;

namespace ModelTest
{
	class DataRepository : IDataRepository
	{
		private List<DepartmentWrapper> Departments;
		private short i = 6;

		public DataRepository()
		{
			Departments = new List<DepartmentWrapper>();
			Departments.Add(new DepartmentWrapper(1, "Name1", "Group1", DateTime.Now));
			Departments.Add(new DepartmentWrapper(2, "Name2", "Group2", DateTime.Now));
			Departments.Add(new DepartmentWrapper(3, "Name3", "Group3", DateTime.Now));
			Departments.Add(new DepartmentWrapper(4, "Name4", "Group4", DateTime.Now));
			Departments.Add(new DepartmentWrapper(5, "Name5", "Group5", DateTime.Now));
		}
		public void AddDepartment(string name, string groupName)
		{
			Departments.Add(new DepartmentWrapper(i++, name, groupName, DateTime.Now));
		}

		public IEnumerable<DepartmentWrapper> GetDepartments()
		{
			return Departments;
		}

		public void RemoveDepartment(int id)
		{
			Departments.RemoveAt(id - 1);
		}

		public void UpdateDepartment(int id, string name, string groupName)
		{
			Departments[id - 1].Name = name;
			Departments[id - 1].GroupName = groupName;
			Departments[id - 1].ModifiedDate = DateTime.Now;
		}
	}
}
