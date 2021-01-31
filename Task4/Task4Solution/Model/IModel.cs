using System.Collections.Generic;

namespace Model
{
    public interface IModel
    {
        void AddDepartment(string name, string groupName);

        List<Department> GetDepartments();

        void UpdateDepartment(int id, string name, string groupName);

        void DeleteDepartment(int id);
    }
}
