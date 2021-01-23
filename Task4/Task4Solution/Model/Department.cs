using Logic;

namespace Model
{
	public class Department
	{
		public short DepartmentID 
		{
			get
			{
				return DepartmentID;
			}

			set
			{
				DepartmentID = value;
			}
		}
		private string Name
		{
			get
			{
				return Name;
			}

			set
			{
				Name = value;
			}
		}

		private string GroupName
		{
			get
			{
				return GroupName;
			}

			set
			{
				GroupName = value;
			}
		}

		private System.DateTime ModifiedDate
		{
			get
			{
				return ModifiedDate;
			}

			set
			{
				ModifiedDate = value;
			}
		}

		public Department(DepartmentWrapper department)
		{
			DepartmentID = department.DepartmentID;
			Name = department.Name;
			GroupName = department.GroupName;
			ModifiedDate = department.ModifiedDate;
		}
	}
}
