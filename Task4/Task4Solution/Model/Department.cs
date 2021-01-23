using Logic;
using System;

namespace Model
{
	public class Department
	{
		private short _departmentID;
		private string _name;
		private string _groupName;
		private DateTime _modifiedDate;
		public short DepartmentID 
		{
			get
			{
				return _departmentID;
			}

            set
            {
				_departmentID = value;
			}

		}


		public string Name
		{
			get
			{
				return _name;
			}

			set
			{
				_name = value;
			}
		}

		public string GroupName
		{
			get
			{
				return _groupName;
			}

			set
			{
				_groupName = value;
			}
		}

		public DateTime ModifiedDate
		{
			get
			{
				return _modifiedDate;
			}

			set
			{
				_modifiedDate = value;
			}
		}

		public Department(DepartmentWrapper department)
		{
			DepartmentID = department.DepartmentID;
			Name = department.Name;
			GroupName = department.GroupName;
			ModifiedDate = department.ModifiedDate;
		}

		public Department()
		{
		}
	}
}
