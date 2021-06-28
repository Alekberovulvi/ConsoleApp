using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment
{
    interface IHumanResourceManager
    {
        void AdDepartment(string name, int workerlimit, double salarylimit);
        void GetDepartment(string name, string newname);
        void AddEmployee(string fullname, string position, double salary, string departmentName);
        void RemoveEmployee(string id, string departmanetname, Employee employee, List<Employee> employees);
        void EditEmploye(string id, string fullName, int salary, double position);

    }
}
