using Data;
using System.Collections.Generic;

namespace Logic
{
	interface IDataRepository
	{
		IEnumerable<DepartmentWrapper> GetDepartments();
		void RemoveDepartment(int id);
		void AddDepartment(string name, string groupName);
		void UpdateDepartment(int id, string name, string groupName);
	}
}
