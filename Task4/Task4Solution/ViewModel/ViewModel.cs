
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ViewModel
{
	public class ViewModel
    {
        public DepartmentList DepartmentList { get; private set; }

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
            DepartmentList = new DepartmentList();
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
            DepartmentList.DeleteDepartment(CurrentDepartment.DepartmentID);
        }

        public void Refresh()
        {
            DepartmentList.RefreshList();
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
            DepartmentList.AddDepartment(CurrentName, CurrentGroupName);

            AddWindow.Value.Close();
        }

        public void ConfirmEdit()
        {
            DepartmentList.UpdateDepartment(CurrentID, CurrentName, CurrentGroupName);

            CurrentName = "";
            CurrentGroupName = "";

            DetailsWindow.Value.Close();
        }
        #endregion
    }
}
