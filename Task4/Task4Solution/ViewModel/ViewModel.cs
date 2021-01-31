
using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ViewModel : ViewModelListener
    {

        private List<Department> _departments;
        private Department _currentDepartment;
        private short _currentID;
        private string _currentName;
        private string _currentGroupName;
        private DateTime _currentModifiedDate;

        private Model.IModel Model;

        #region Commands
        public Command ShowAddWindowProperty { get; private set; }

        public Command ShowDetailsWindowProperty { get; set; }

        public Command DeleteDepartmentProperty { get; set; }

        public Command RefreshProperty { get; set; }
        public Command ConfirmAddProperty { get; set; }
        public Command ConfirmEditProperty { get; set; }
        #endregion

        #region Windows
        public Lazy<IWindow> AddWindow { get; set; }
        public Lazy<IWindow> DetailsWindow { get; set; }
        #endregion

        #region CurrentProperties
        public List<Department> Departments
        {
            get
            {
                return _departments;
            }
            private set
            {
                _departments = value;
                OnPropertyChanged("Departments");
            }
        }

        public Department CurrentDepartment
        {
            get
            {
                return _currentDepartment;
            }
            set
            {
                _currentDepartment = value;
                OnPropertyChanged("CurrentDepartment");
            }
        }

        public short CurrentID
        {
            get
            {
                return _currentID;
            }
            private set
            {
                _currentID = value;
                OnPropertyChanged("CurrentID");
            }
        }

        public string CurrentName
        {
            get
            {
                return _currentName;
            }
            set
            {
                _currentName = value;
                OnPropertyChanged("CurrentName");
            }
        }

        public string CurrentGroupName
        {
            get
            {
                return _currentGroupName;
            }
            set
            {
                _currentGroupName = value;
                OnPropertyChanged("CurrentGroupName");
            }
        }

        public DateTime CurrentModifiedDate
        {
            get
            {
                return _currentModifiedDate;
            }
            private set
            {
                _currentModifiedDate = value;
                OnPropertyChanged("CurrentModifiedDate");
            }
        }
        #endregion

        #region Contructors
        public ViewModel()
        {
            Model = new Model.Model();
            init();
        }

        public ViewModel(IModel model)
        {
            Model = model;
            init();
        }
        private void init()
        {
            Departments = Model.GetDepartments();
            ShowAddWindowProperty = new Command(ShowAddWindow);
            ShowDetailsWindowProperty = new Command(ShowDetailsWindow);
            DeleteDepartmentProperty = new Command(DeleteDepartment);
            RefreshProperty = new Command(Refresh);
            ConfirmAddProperty = new Command(ConfirmAdd);
            ConfirmEditProperty = new Command(ConfirmEdit);
        }
        #endregion

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
                CurrentName = "";
                CurrentGroupName = "";
                Refresh();
            });


            DetailsWindow.Value.Close();
        }
        #endregion
    }
}
