using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Threading.Tasks;

namespace ViewModelTest
{
    [TestClass]
    public class ViewModelTest
    {
        IModel Model;
        ViewModel.ViewModel ViewModel;

        public ViewModelTest()
        {
            Model = new TestModel();
            ViewModel = new ViewModel.ViewModel(Model);
        }

        [TestMethod]
        public void GetDepartmentsTest()
        {
            Assert.AreEqual(1, ViewModel.Departments.Count);
        }

        [TestMethod]
        public void AddDepartmentTest()
        {
            ViewModel.AddWindow = new Lazy<ViewModel.IWindow>(() => new TestWindow());
            Assert.AreEqual(1, ViewModel.Departments.Count);
            ViewModel.CurrentName = "AddTest";
            ViewModel.CurrentGroupName = "AddGroupName";
            ViewModel.ConfirmAdd();
            System.Threading.Thread.Sleep(200);
            Assert.AreEqual(2, ViewModel.Departments.Count);
        }

        [TestMethod]
        public void DeleteDepartmentTest()
        {
            Assert.AreEqual(1, ViewModel.Departments.Count);
            ViewModel.CurrentDepartment = ViewModel.Departments[0];
            ViewModel.DeleteDepartment();
            System.Threading.Thread.Sleep(200);
            Assert.AreEqual(0, ViewModel.Departments.Count);
        }

        [TestMethod]
        public void UpdateDepartmentTest()
        {
            ViewModel.DetailsWindow = new Lazy<ViewModel.IWindow>(() => new TestWindow());
            Assert.AreEqual(1, ViewModel.Departments.Count);
            ViewModel.CurrentName = "Update";
            ViewModel.CurrentGroupName = "UpdateGroup";
            ViewModel.ConfirmEdit();
            System.Threading.Thread.Sleep(200);
            Assert.AreEqual(1, ViewModel.Departments.Count);
            Assert.AreEqual("Update", ViewModel.Departments[0].Name);
            Assert.AreEqual("UpdateGroup", ViewModel.Departments[0].GroupName);
        }
    }
}
