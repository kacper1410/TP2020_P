using System;
using System.Collections.Generic;

namespace LogicTest
{
	public class DepartmentsContext
    {
        public List<Department> Departments { get; set; }

        public DepartmentsContext()
        {
            Departments = new List<Department>();
            Departments.Add(new Department(1, "Name1", "Group1", DateTime.Now));
            Departments.Add(new Department(2, "Name2", "Group2", DateTime.Now));
            Departments.Add(new Department(3, "Name3", "Group3", DateTime.Now));
            Departments.Add(new Department(4, "Name4", "Group4", DateTime.Now));
            Departments.Add(new Department(5, "Name5", "Group5", DateTime.Now));
        }
    }
}
