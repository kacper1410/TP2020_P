using Model;
using System.Collections.Generic;

namespace ViewModel
{
	public class ViewModel
    {
        public IEnumerable<Department> Departments;
        public DepartmentList DepartmentList = new DepartmentList();
        
        public ViewModel()
        {
            Departments = new DepartmentList();
        }

        public void ShowAddWindow()
        {

        } 

        public void DeleteDepartment()
        {

        }

        public void Refresh()
        {

        }

        public void ShowDetailsWindow()
        {

        }
    }
}
