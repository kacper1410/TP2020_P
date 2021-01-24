using Logic;
using System.Collections.ObjectModel;

namespace Model
{
	public class DepartmentList : ObservableCollection<Department>
	{
		private Model Model;

		public DepartmentList() : base()
		{
			Model = new Model();
			RefreshList();
		}

		public DepartmentList(Model model) : base()
		{
			Model = model;
			RefreshList();
		}

		public void AddDepartment(string name, string groupName)
		{
			Model.AddDepartment(name, groupName);
			RefreshList();
		}

		public void DeleteDepartment(int id)
		{
			Model.DeleteDepartment(id);
			RefreshList();
		}

		public void UpdateDepartment(int id, string name, string groupName)
		{
			Model.UpdateDepartment(id, name, groupName);
			RefreshList();
		}

		public void RefreshList()
		{
			Clear();
			foreach (DepartmentWrapper department in Model.GetDepartments())
			{
				Add(new Department(department));
			}
		}
	}
}
