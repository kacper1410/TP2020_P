using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
	public class DataRepository: IDataRepository
	{
		private DepartmentsDataContext Context;

		public DataRepository()
		{
			Context = new DepartmentsDataContext();
		}

		public void AddDepartment(string name, string groupName)
	{
			Department department = new Department();

			department.Name = name;
			department.GroupName = groupName;
			department.ModifiedDate = DateTime.Now;

			using (Context)
			{
				Context.Departments.InsertOnSubmit(department);
				Context.SubmitChanges();
			}
		}

		public IEnumerable<DepartmentWrapper> GetDepartments()
		{
			List<DepartmentWrapper> departments = new List<DepartmentWrapper>();
			using (Context)
			{
				Context.Departments.ToList().ForEach(d => departments.Add(new DepartmentWrapper(d)));
			}

			return departments;
		}

		public void RemoveDepartment(int id)
		{
			using (Context)
			{
				Department department = Context.Departments
									.Where(d => d.DepartmentID == id)
									.FirstOrDefault();

				Context.Departments.DeleteOnSubmit(department);

				Context.SubmitChanges();
			}
		}

		public void UpdateDepartment(int id, string name, string groupName)
		{
			using (Context)
			{
				Department department = Context.Departments.Single(x => x.DepartmentID == id);

				department.Name = name;
				department.GroupName = groupName;
				department.ModifiedDate = DateTime.Now;

				Context.SubmitChanges();
			}

		}
	}
}
