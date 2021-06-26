using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment
{
    class Program
    {
        static void Main(string[] args)
        {
            HumanResourceManager humanResourceManager = new HumanResourceManager();

            do
            {
                Console.WriteLine("Etmek Istediyiniz Emeliyyati Secin:");
                Console.WriteLine("-------------");
                Console.WriteLine("1.1 Departameantlerin siyahisini gostermek");
                Console.WriteLine("1.2 Departamenet yaratmaq");
                Console.WriteLine("1.3 Departmanetde deyisiklik etmek");
                Console.WriteLine("2.1 Iscilerin siyahisini gostermek");
                Console.WriteLine("2.2 Departamentdeki iscilerin siyahisini gostermrek");
                Console.WriteLine("2.3 Isci elave etmek");
                Console.WriteLine("2.4 Isci uzerinde deyisiklik etmek");
                Console.WriteLine("2.5 Departamentden isci silinmesi");

                string cavab = Console.ReadLine();
                switch (cavab)
                {
                    
                    case "1.1": 
                        if(humanResourceManager.Departments != null)
                        {
                            foreach (var department in humanResourceManager.Departments)
                            {
                                Console.WriteLine($"{department.Name} {department.Employees.Count} {department.CalcSalaryAverage(department.Employees)}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("list is empty");
                        }
                        
                        break;
                    case "1.2":
                        Console.WriteLine("Enter the name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter the workerlimit");
                        int worklimit = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter the salary");
                        double salarylimit = Convert.ToDouble(Console.ReadLine());                       
                        humanResourceManager.AdDepartment(name, worklimit, salarylimit);
                        break;
                    case "1.3":

                        break;

                    default:
                        break;
                }


            } while (true);
        }
    }
}
