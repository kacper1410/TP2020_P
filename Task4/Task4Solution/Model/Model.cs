using Logic;
using System.Collections.Generic;

namespace Model
{
	public class Model
	{
		private IDataRepository DataRepository;

		public Model()
		{
			DataRepository = new DataRepository();
		}

		public Model(IDataRepository dataRepository)
		{
			DataRepository = dataRepository;
		}

		public void AddDepartment(string name, string groupName)
		{
			DataRepository.AddDepartment(name, groupName);
		}

		public IEnumerable<DepartmentWrapper> GetDepartments()
		{
			return DataRepository.GetDepartments();
		}

		public void UpdateDepartment(int id, string name, string groupName)
		{
			DataRepository.UpdateDepartment(id, name, groupName);
		}

		public void DeleteDepartment(int id)
		{
			DataRepository.RemoveDepartment(id);
		}
	}
}
