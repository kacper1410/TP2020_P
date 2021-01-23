using Logic;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Model
{
	public class DepartmentList : INotifyCollectionChanged
	{
		private List<DepartmentWrapper> Departments;
		private Model Model;
		public event NotifyCollectionChangedEventHandler CollectionChanged;

		public DepartmentList()
		{
			Model = new Model();
			Departments = (List<DepartmentWrapper>)Model.GetDepartments();
		}

		public void AddDepartment(string name, string groupName)
		{
			Model.AddDepartment(name, groupName);
			Departments = (List<DepartmentWrapper>)Model.GetDepartments();
		}
	}
}
