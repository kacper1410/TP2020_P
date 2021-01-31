using Model;
using System;
using System.Collections.Generic;

namespace ViewModelTest
{
    public class TestModel : IModel
    {
        List<Department> Departments;
        short i = 1;

        public TestModel() 
        {
            Departments = new List<Department>();

            Department department = new Department();
            department.DepartmentID = 0;
            department.Name = "Test";
            department.GroupName = "Department";
            department.ModifiedDate = DateTime.Now;

            Departments.Add(department);
        }

        void IModel.AddDepartment(string name, string groupName)
        {
            Department department = new Department();
            department.DepartmentID = i++;
            department.Name = name;
            department.GroupName = groupName;
            department.ModifiedDate = DateTime.Now;

            Departments.Add(department);
        }

        void IModel.DeleteDepartment(int id)
        {
            Departments.RemoveAt(id);
        }

        List<Department> IModel.GetDepartments()
        {
            return Departments;
        }

        void IModel.UpdateDepartment(int id, string name, string groupName)
        {
            Departments[id].Name = name;
            Departments[id].GroupName = groupName;
            Departments[id].ModifiedDate = DateTime.Now;
        }
    }
}
