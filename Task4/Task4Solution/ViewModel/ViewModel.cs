
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
        private ObservableCollection<Department> _departments;
        public ObservableCollection<Department> Departments
        {
            get
            {
                return _departments;
            }
            set
            {
                _departments = value
            }
        }

        private DepartmentList DepartmentList = new DepartmentList();

        #region Commands
        public Command ShowAddWindowProperty { get; private set; }

        public Command ShowDetailsWindowProperty { get; set; }

        public Command DeleteDepartmentProperty { get; set; }

        public Command RefreshProperty { get; set; }
        public Command ConfirmAddProperty { get; set; }
        public Command ConfirmEditProperty { get; set; }
        #endregion

        public Lazy<IWindow> AddWindow { get; set; }
        public Lazy<IWindow> DetailsWindow { get; set; }

        public Department CurrentDepartment { get; set; }
        public short CurrentID { get; private set; }
        public string CurrentName { get; set; }
        public string CurrentGroupName { get; set; }
        public DateTime CurrentModifiedDate{ get; private set; }

        public ViewModel()
        {
            Model = new Model.Model();
            Departments = new DepartmentList();
            ShowAddWindowProperty = new Command(ShowAddWindow);
            ShowDetailsWindowProperty = new Command(ShowDetailsWindow);
            DeleteDepartmentProperty = new Command(DeleteDepartment);
            RefreshProperty = new Command(Refresh);
            ConfirmAddProperty = new Command(ConfirmAdd);
            ConfirmEditProperty = new Command(ConfirmEdit);
        }

        #region Button actions
        public void ShowAddWindow()
        {
            IWindow window = AddWindow.Value;
            window.SetViewModel(this);
            window.Show();
        } 

        public void DeleteDepartment()
        {
            Model.DeleteDepartment(CurrentDepartment.DepartmentID);
        }

        public void Refresh()
        {
            Console.WriteLine("Przed");
            foreach(Department d in Departments)
            {
                Console.WriteLine(d.Name);
            }
            Departments = new DepartmentList();
            Console.WriteLine("Po");
            foreach (Department d in Departments)
            {
                Console.WriteLine(d.Name);
            }
        }

        public void ShowDetailsWindow()
        {
            if (CurrentDepartment == null)
            {
                return;
            }
            CurrentID = CurrentDepartment.DepartmentID;
            CurrentName = CurrentDepartment.Name;
            CurrentGroupName = CurrentDepartment.GroupName;
            CurrentModifiedDate = CurrentDepartment.ModifiedDate;

            IWindow window = DetailsWindow.Value;
            window.SetViewModel(this);
            window.Show();
        }

        public void ConfirmAdd()
        {
            Console.WriteLine(CurrentName + " " + CurrentGroupName);
            Model.AddDepartment(CurrentName, CurrentGroupName);
        }

        public void ConfirmEdit()
        {
            Console.WriteLine(CurrentName + " " + CurrentGroupName);
            Model.UpdateDepartment(CurrentID, CurrentName, CurrentGroupName);
        }
        #endregion
    }
}
