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
			FillList();
		}

		public DepartmentList(Model model) : base()
		{
			Model = model;
			FillList();
		}

		public void AddDepartment(string name, string groupName)
		{
			Model.AddDepartment(name, groupName);
			FillList();
		}

		public void DeleteDepartment(int id)
		{
			Model.DeleteDepartment(id);
			FillList();
		}

		public void UpdateDepartment(int id, string name, string groupName)
		{
			Model.UpdateDepartment(id, name, groupName);
			FillList();
		}

		private void FillList()
		{
			Clear();
			foreach (DepartmentWrapper department in Model.GetDepartments())
			{
				Add(new Department(department));
			}
		}
	}
}
