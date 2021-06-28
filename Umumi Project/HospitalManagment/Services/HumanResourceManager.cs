using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment
{
    class HumanResourceManager:IHumanResourceManager
    {
        public List<Department> Departments { get; set; }
        public HumanResourceManager()
        {
            Departments = new List<Department>();
        }

        //Asagidaki methodda bize gelen parametrlerle bizde olan departamentleri yoxluyuruq sert odenirse siyahiya elave edirik.

        public void AdDepartment(string fullname,int workerlimit ,double salarylimit)
        {
            Department department = new Department(fullname, workerlimit, salarylimit);
            Departments.Add(department);

        }
        //Asagidaki methodda bize gelen paramterlerle employeleri yoxlyuruq, sert odenirse yeni bir Employee obyekti siyahiya elave olunur.

        public void AddEmployee(string fullname,string position,double salary,string departmentName)
        {
            Employee employee = new Employee(fullname,position,salary,departmentName);
            var department = Departments.Find(s => s.Name == departmentName);
            department.Employees.Add(employee);

        }

        //Asagidaki method departementin adinin deyisillib deyisilmediyini yoxluyur sert odenmediyi teqdirde departamment adi yeni ada set olunur.

        public void EditDepartaments(string name, string newName)
        {
            var department = Departments.Find(u => u.Name == name);
            if (department == null)
                throw new ArgumentNullException("There is such department");
            department.Name = newName;
        }

        //Asagidaki method bize gelen paramtrlerin listde olub olmadigini yoxluyur, listde oldugu teqdirde bizim Employye listindeki enployyee obyektine set olunur.
        
        public void EditEmploye(string id,string fullName,double salary,string position,List<Employee> employees)
        {
            foreach (Employee item in employees)
            {
                if (item.ID!=null&&item.FullName!=fullName&&item.Salary!=salary&&item.Position!=position)
                {
                    item.ID = id;
                    item.FullName = fullName;
                    item.Position = position;
                }
            }
        }

        //Asagidaki method Departments listini bize qaytarir.

        public List<Department> GetDepartments()
        {
            return Departments.ToList();
        }

        // Adagidaki method eyer daxil edilen paramterler bizdeki parmaterlere beraberdise bu halda teyin olunmus employye-ni siyahidan cixaracaq.

        public void RemoveEmployee(string id,string departmentName,Employee employee,List<Employee> employees)
        {
            if (employees.Any(u => u.ID == id && u.DepartmentName == departmentName)) 
            {
                employees.Remove(employee);
            }
        }

        public void GetDepartment(string name, string newname)
        {
            throw new NotImplementedException();
        }

        public void EditEmploye(string id, string fullName, int salary, double position)
        {
            throw new NotImplementedException();
        }

        public List<Employee> Employees()
        {
            throw new NotImplementedException();
        }
    }
}
