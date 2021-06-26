using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment
{
    public class Employee
    {
        public string ID;
        private static int _count;
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string DepartmentName { get; set; }
        public string Position { get; set; }
        public double Salary { get; set; }

        //Asagidaki constructor-da ilk olaraq field-lere value set edirik. Daha sonra ise her bir isciye unikal ID teyin edirik.
        //Her defesinde Countu artiriq. En sonda ise Unikal Countu Departament adinin ilk 2 herfiyle birlesdirib unikal ID-ye set edirik.
        public Employee(string fullname, string position, double salary, string departmentname)
        {
            Position = position;
            Salary = salary;
            DepartmentName = departmentname;
            FullName = fullname;
            _count++;
            ID = DepartmentName.Trim().ToUpper().Substring(0, 2) + _count.ToString();
        }
        //Field-lere set olunmus deyerleri asagidaki method vasitesiyle program classin-da olan Employee classindan instance alib,initialize olan obyekte otururuk.
        public override string ToString()
        {
            return $"{ID},{FullName},{Position},{Salary},{DepartmentName}";
        }
    }
}
