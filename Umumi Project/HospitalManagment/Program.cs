using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment
{
    class Program
    {
        static HumanResourceManager humanResourceManager = new HumanResourceManager();
        static void Main(string[] args)
        {
            

            do
            {
                Console.WriteLine("-------------");
                Console.WriteLine("Etmek Istediyiniz Emeliyyati Secin:");
                Console.WriteLine("-------------");
                Console.WriteLine("1.1 Departameantlerin siyahisini gostermek");
                Console.WriteLine("-------------");
                Console.WriteLine("1.2 Departamenet yaratmaq");
                Console.WriteLine("-------------");
                Console.WriteLine("1.3 Departmanetde deyisiklik etmek");
                Console.WriteLine("-------------");
                Console.WriteLine("2.1 Iscilerin siyahisini gostermek");
                Console.WriteLine("-------------");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("-------------");
                Console.WriteLine("2.3 Isci elave etmek");
                Console.WriteLine("-------------");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik etmek");
                Console.WriteLine("-------------");
                Console.WriteLine("2.5 Departamentden isci silinmesi");

                string cavab = Console.ReadLine();
                switch (cavab)
                {

                    case "1.1":
                        Getdepartament();
                        break;
                    case "1.2":
                        AddDepartament(humanResourceManager);
                        break;
                    case "1.3":
                        EditDepartament();
                        break;
                    case "2.1":
                        ShowEmployees(humanResourceManager);
                        break;
                    case "2.2":
                        ShowEmployeeDepartaments(humanResourceManager);
                        break;
                    case "2.3":
                        AddEmployee(humanResourceManager);
                        break;
                    case "2.4":
                        EditEmployee();
                        break;
                    case "2.5":
                        RemoveEmployee(humanResourceManager);
                        break;
                    default:
                        break;
                }


            } while (true);
        }


         public static void Getdepartament()
        {
            if (humanResourceManager.Departments != null) 
            {
                foreach (var department in humanResourceManager.Departments)
                {
                    Console.WriteLine($"Name of department: {department.Name},Number of employees: {department.Employees.Count}, Average salary: {department.CalcSalaryAverage()}");
                }
            }
        }

        public static void AddDepartament(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Enter the name");
            string fullname = Console.ReadLine();
            Console.WriteLine("Enter the workerlimit");
            int worklimit = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the salary");
            double salarylimit = Convert.ToDouble(Console.ReadLine());
            humanResourceManager.AdDepartment(fullname, worklimit, salarylimit);
        }

        public static void EditDepartament()
        {
            string onedepname = "";
            string newdepname = "";
            int newwroklimit = 0;
            double newsalarylimit = 0;
            bool loop1 = true;
            bool loop2 = true;
            bool loop3 = true;

            Console.WriteLine("Enter the name of the department you want to change");
            onedepname = Console.ReadLine();
            //while (true)
            {

                try
                {
                    
                    Department department = humanResourceManager.Departments.Find(u => u.Name == onedepname);

                    if (department != null)
                    {
                        Console.WriteLine($"{department.Name},{department.WorkerLimit},{department.SalaryLimit}");
                    }

                    while (loop1)
                    {
                        try
                        {
                            Console.WriteLine("Enter the new name");
                            newdepname = Console.ReadLine();

                            if (string.IsNullOrEmpty(newdepname) == false && newdepname.Length > 2)
                            {
                                department.Name = newdepname;
                                loop1 = false;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter the correct name:");
                        }
                    }


                    while (loop2)
                    {
                        try
                        {
                            Console.WriteLine("Ente new work limit");
                            newwroklimit = Convert.ToInt32(Console.ReadLine());

                            if (newwroklimit >= 2)
                            {
                                department.WorkerLimit = newwroklimit;
                                loop2 = false;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter the correct worker limit:");
                        }
                    }


                    while (loop3)
                    {
                        try
                        {
                            Console.WriteLine("Enter new salary limit");
                            newsalarylimit = Convert.ToDouble(Console.ReadLine());
                            if (newsalarylimit >= 250)
                            {
                                department.SalaryLimit = newsalarylimit;
                                loop3 = false;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Enter the correct salary limit:");
                        }
                    }


                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public static void ShowEmployees(HumanResourceManager humanResourceManager)
        {
            foreach (var department in humanResourceManager.Departments)
            {
                foreach (var employee in department.Employees)
                {
                    Console.WriteLine(employee.ID);
                    Console.WriteLine(employee.FullName);
                    Console.WriteLine(employee.DepartmentName);
                    Console.WriteLine(employee.Salary);
                }
            }
        }

        public static void ShowEmployeeDepartaments(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Isci siyahisini gostermek ucun departament adini daxil edin:");
            string departamentname = Console.ReadLine();

            Department department = humanResourceManager.Departments.Find(u => u.Name == departamentname);
            foreach (Employee employee in department.Employees)
            {
                Console.WriteLine(employee.ID);
                Console.WriteLine(employee.FullName);
                Console.WriteLine(employee.Position);
                Console.WriteLine(employee.Salary);
            }
        }

        public static void AddEmployee(HumanResourceManager humanResourceManager)
        {
            Console.WriteLine("Yeni iscinin adini elave edin:");
            string newemployename = Console.ReadLine();
            Console.WriteLine("Yeni iscinin soyadini elave edin:");
            string newemployesurname = Console.ReadLine();
            string newposition = "";
            double newemployeesalary = 0;
            string newemployedepname = "";
            bool positionloop = true;
            bool deploop = true;
            bool salaryloop = true;
            Console.WriteLine("Yeni iscinin vezifesini daxil edin:");

            while (positionloop)
            {
                try
                {
                    newposition = Console.ReadLine();
                    if (string.IsNullOrEmpty(newposition) == false && newposition.Length >= 2)
                    {
                        positionloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun yeni iscinin vezifesini daxil edin:");
                }
                Console.WriteLine("Yeni iscinin maasini elave edin:");

                try
                {
                    newemployeesalary = Convert.ToDouble(Console.ReadLine());
                    if (newemployeesalary >= 250)
                    {
                        salaryloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun maas daxil edin");
                }

                Console.WriteLine("Yeni iscinin departament adini daxil edin:");

                while (deploop)
                {
                    try
                    {
                        newemployedepname = Console.ReadLine();
                        if (string.IsNullOrEmpty(newemployename) == false && newemployedepname.Length >= 2)
                        {
                            deploop = false;
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Duzgun yeni departament adini daxil edin");
                    }


                    Department department = humanResourceManager.Departments.Find(u => u.Name == newemployedepname);
                    Employee employee = new Employee(newemployename, newposition, newemployeesalary, newemployedepname);

                    department.Employees.Add(employee);
                }
            }
        }

        public static void EditEmployee()
        {
            bool noollop = true;
            bool editsalary = true;
            bool newsalaryloop = true;
            bool positionloopnew = false;
            string deyisik = "";
            double newsalary = 0;
            string newposition = "";

            Console.WriteLine("Deyismek istediyiniz iscinin nomresini daxil edin:");

            while (noollop)
            {
                try
                {
                    deyisik = Console.ReadLine();

                    foreach (Department dep in humanResourceManager.Departments)
                    {
                        Employee newemployee = dep.Employees.Find(u => u.ID == deyisik);

                        if (newemployee != null)
                        {


                            Console.WriteLine("Iscinin maasini elave edin:");

                            while (editsalary)
                            {
                                try
                                {
                                    newsalary = Convert.ToDouble(Console.ReadLine());
                                    if (newsalary >= 250)
                                    {
                                        newemployee.Salary = newsalary;
                                        newsalaryloop = false;
                                    }

                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Duzgun maas daxil edin");
                                }

                                Console.WriteLine("Iscinin yeni vezifesini daxil edin:");

                                while (positionloopnew)
                                {
                                    try
                                    {
                                        newposition = Console.ReadLine();

                                        if (string.IsNullOrEmpty(newposition) != false && newposition.Length >= 2)
                                        {
                                            newemployee.Position = newposition;
                                            positionloopnew = false;
                                        }
                                        else
                                        {
                                            throw new Exception();
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Iscinin yeni vezifesini daxil edin:");
                                    }

                                }
                                editsalary = false;
                            }
                        }
                        else
                        {
                            noollop = false;
                        }

                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Iscinin nomresini duzgun daxil edin:");
                }
                
            }
            noollop = false;
            
        }

        public static void RemoveEmployee(HumanResourceManager humanResourceManager)
        {
            string depname = "";
            string empid = "";
            bool nameloop = true;
            bool idloop = true;

            Console.WriteLine("Departamentin adini daxil edin:");

            while (nameloop)
            {
                try
                {
                    depname = Console.ReadLine();
                    if (string.IsNullOrEmpty(depname)==false&&depname.Length>=2)
                    {
                        Department removedepname = humanResourceManager.Departments.Find(u => u.Name == depname);

                        while (idloop)
                        {
                            try
                            {
                                empid = Console.ReadLine();

                                foreach (Department dep in humanResourceManager.Departments)
                                {
                                    Employee removeemp = dep.Employees.Find(u => u.ID == empid);

                                    if (removeemp!=null)
                                    {
                                        removedepname.Employees.Remove(removeemp);

                                        idloop = false;
                                    }
                                    else
                                    {
                                        throw new Exception();
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Isci nomresini duzgun daxil edin ");
                            }
                        }
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Departamemnt adini duzugn daxil edin");
                }
            }
        }
    }
}






