using Data;
using System;

namespace Logic
{
	public class DepartmentWrapper
	{
		private Department Department;

		public DepartmentWrapper(Department department)
		{
			Department = department;
		}

		public short DepartmentID
		{
			get
			{
				return Department.DepartmentID;
			}
		}

		public string Name
        {
			get
            {
				return Department.Name;
            }

			set
            {
				Department.Name = value;
            }
        }

		public string GroupName
		{
			get
			{
				return Department.GroupName;
			}

			set
			{
				Department.GroupName = value;
			}
		}

		public DateTime ModifiedDate
        {
			get
            {
				return Department.ModifiedDate;
            }
        }
	}
}
