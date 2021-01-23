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

			foreach (DepartmentWrapper department in Model.GetDepartments())
			{
				Add(new Department(department));
			}
		}
	}
}
