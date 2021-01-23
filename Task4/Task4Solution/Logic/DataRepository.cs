﻿using Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
	public class DataRepository
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

		public IEnumerable<Department> GetDepartments()
		{
			List<Department> departments;
			using (Context)
			{
				departments = Context.Departments.ToList();
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

				Context.SubmitChanges();
			}

		}
	}
}
