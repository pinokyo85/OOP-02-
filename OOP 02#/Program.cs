using System;

namespace Demo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Employee[] Emparray = new Employee[3];
            Emparray[0] = new Employee(101, "Mazen Fady", SecurityPrivilege.DBA, 12000, new HiringDate(7, 17, 2025), 'M');
            Emparray[1] = new Employee(102, "Bassent Ahmed", SecurityPrivilege.Guest, 15000, new HiringDate(1, 1, 2011), 'F');
            Emparray[2] = new Employee(103, "Mohamed Fady", SecurityPrivilege.SecurityOfficer, 9000, new HiringDate(2, 5, 1999), 'M');

            foreach (var emp in Emparray)
            {
                Console.WriteLine(emp.ToString());
                Console.WriteLine("----------------------");
            }
        } 

        public class Employee
        {
            private int id;
            private string name;
            private SecurityPrivilege securityLevel;
            private decimal salary;
            private HiringDate hireDate;
            private char gender;

            public int ID
            {
                get { return id; }
                set { id = value > 0 ? value : 1; }
            }

            public string Name
            {
                get { return name; }
                set { this.name = value; }
            }

            public SecurityPrivilege Securitylevel
            {
                get { return securityLevel; }
                set { securityLevel = value; }
            }

            public decimal Salary
            {
                get { return salary; }
                set { salary = value >= 0 ? value : 0; }
            }

            public HiringDate HireDate
            {
                get { return hireDate; }
                set { hireDate = value; }
            }

            public char Gender
            {
                get { return gender; }
                set { gender = (value == 'M' || value == 'F') ? value : 'M'; }
            }

            public Employee()
            {
                ID = 123;
                Name = "Mazen";
                Securitylevel = SecurityPrivilege.Guest;
                Salary = 12000;
                HireDate = new HiringDate();
                Gender = 'M';
            }

            public override string ToString()
            {
                return string.Format("Employee ID: {0}\nName: {1}\nSecurity Level: {2}\nSalary: {3:C}\nHire Date: {4}\nGender: {5}",
                    ID, Name, Securitylevel, Salary, HireDate, Gender);
            }

            public Employee(int id, string name, SecurityPrivilege securityLevel, decimal salary, HiringDate hireDate, char gender)
            {
                ID = id;
                Name = name;
                Securitylevel = securityLevel;
                Salary = salary;
                HireDate = hireDate;
                Gender = gender;
            }
        }

        public enum SecurityPrivilege
        {
            Guest, Developer, Secretary, DBA, SecurityOfficer
        }

        public class HiringDate
        {
            private int day;
            private int month;
            private int year;

            public int Day
            {
                get { return day; }
                set { day = (value <= 31 && value >= 1) ? value : 1; }
            }

            public int Month
            {
                get { return month; }
                set { month = (value <= 12 && value >= 1) ? value : 1; }
            }

            public int Year
            {
                get { return year; }
                set { year = (value <= DateTime.Now.Year && value >= 1970) ? value : DateTime.Now.Year; }
            }

            public HiringDate(int day, int month, int year)
            {
                Day = day;
                Month = month;
                Year = year;
            }

            public HiringDate() : this(1, 1, DateTime.Now.Year) { }

            public override string ToString()
            {
                return $"{Day}/{Month}/{Year}";
            }
        }
    }
}