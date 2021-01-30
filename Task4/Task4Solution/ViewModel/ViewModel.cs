
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel
{
	public class ViewModel : ViewModelListener
    {
        public List<Department> Departments { get; private set; }

        private Model.Model Model;

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
            Departments = new List<Department>();
            Model = new Model.Model();
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
            Task.Run(() =>
            {
                Model.DeleteDepartment(CurrentDepartment.DepartmentID);
                Refresh();
            });
            
        }

        public void Refresh()
        {
            Departments = Model.GetDepartments();
            OnPropertyChanged("Departments");
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
            Task.Run(() =>
            {
                Model.AddDepartment(CurrentName, CurrentGroupName);
                Refresh();
            });
            
            AddWindow.Value.Close();
        }

        public void ConfirmEdit()
        {
            Task.Run(() =>
            {
                Model.UpdateDepartment(CurrentID, CurrentName, CurrentGroupName);
                Refresh();
            });
            
            CurrentName = "";
            CurrentGroupName = "";

            DetailsWindow.Value.Close();
        }
        #endregion
    }
}
