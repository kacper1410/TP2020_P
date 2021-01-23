
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
	public class ViewModel
    {
        private Model.Model Model;
        public IEnumerable<Department> Departments { get; set; }
        private DepartmentList DepartmentList = new DepartmentList();
        public Command ShowAddWindowProperty { get; private set; }

        public Command ShowDetailsWindowProperty { get; set; }

        public Command DeleteDepartmentProperty { get; set; }

        public Command RefreshProperty { get; set; }

        public Lazy<IWindow> AddWindow { get; set; }
        public Lazy<IWindow> DetailsWindow { get; set; }

        public Department CurrentDepartment { get; set; }

        public ViewModel()
        {
            Model = new Model.Model();
            Departments = new DepartmentList();
            ShowAddWindowProperty = new Command(ShowAddWindow);
            ShowDetailsWindowProperty = new Command(ShowDetailsWindow);
            DeleteDepartmentProperty = new Command(DeleteDepartment);
            RefreshProperty = new Command(Refresh);
        }

        public void ShowAddWindow()
        {
            IWindow window = AddWindow.Value;
            window.Show();
        } 

        public void DeleteDepartment()
        {
            Model.DeleteDepartment(CurrentDepartment.DepartmentID);
        }

        public void Refresh()
        {
            Departments = new DepartmentList();
        }

        public void ShowDetailsWindow()
        {
            IWindow window = DetailsWindow.Value;
            window.Show();
        }
    }
}
