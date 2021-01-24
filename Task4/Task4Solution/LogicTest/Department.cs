using System;

namespace LogicTest
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

        public Department(short id, string name, string groupName, DateTime modifiedDate)
        {
            DepartmentID = id;
            Name = name;
            GroupName = groupName;
            ModifiedDate = modifiedDate;
        }
    }
}
