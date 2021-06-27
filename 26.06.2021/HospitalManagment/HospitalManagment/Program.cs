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
                        if (humanResourceManager.Departments!=null)
                        {
                            foreach (var departament in humanResourceManager.Departments)
                            {
                                Console.WriteLine($"{departament.Name},{departament.Employees.Count},{departament.CalcSalaryAverage(departament.Employees)}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("List is empty");
                        }
                        
                        break;
                    case "1.2":
                        AddDepartament(humanResourceManager);
                        break;
                    case "1.3":
                        EditDepartament(humanResourceManager);
                        break;
                    case "2.1":
                        break;
                    case "2.2":
                        break;
                    case "2.3":
                        break;
                    case "2.4":
                        break;
                    case "2.5":
                        break;
                    default:
                        break;
                }


            } while (true);
        }

        public static void AddDepartament(HumanResourceManager humanResourceManager)
        {
            bool nameloop = true;
            bool workerlimitloop = true;
            bool salarylimitloop = true;
            string depname = "";
            int depworklimit = 0;
            double depsalarylimit = 0;


            Console.WriteLine("Departamentin adini daxil edin:");
            while (nameloop)
            {
                try
                {
                    depname = Console.ReadLine();
                    if (string.IsNullOrEmpty(depname) == false && depname.Length >= 2)
                    {
                        nameloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun ad daxil edin:");
                }


            }

            Console.WriteLine("Departamentin workerlimitini daxil edin:");
            while (workerlimitloop)
            {
                try
                {
                    depworklimit = Convert.ToInt32(Console.ReadLine());
                    if (depworklimit >= 1)
                    {
                        workerlimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun wroker limitini daxil edin:");
                    throw;
                }
            }

            Console.WriteLine("Departamentin SalaryLimiti daxil edin");
            while (salarylimitloop)
            {
                try
                {
                    depsalarylimit = Convert.ToDouble(Console.ReadLine());
                    if (depsalarylimit >= 250)
                    {
                        salarylimitloop = false;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Duzgun salarylimitini daxil edin:");
                }
            }
        }

        public static void EditDepartament(HumanResourceManager humanResourceManager)
        {
            string onedepname = "";
            string newdepname = "";
            int newwroklimit = 0;
            double newsalarylimit = 0;
            bool oneloop = true;
            bool loop1 = true;
            bool loop2 = true;
            bool loop3 = true;

            Console.WriteLine("Deyisiklik etmek istediyiniz departamentin adini daxil edin");

            while (true)
            {

                try
                {
                    onedepname = Console.ReadLine();
                    Department department = humanResourceManager.Departments.Find(u => u.Name == onedepname);

                    if (department != null)
                    {
                        Console.WriteLine($"{department.Name},{department.WorkerLimit},{department.SalaryLimit}");
                    }

                    while (loop1)
                    {
                        try
                        {
                            newdepname = Console.ReadLine();

                            if (string.IsNullOrEmpty(newdepname) == false && newdepname.Length >= 2)
                            {
                                department.Name = newdepname;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Duzgun ad daxil edin:");
                        }
                    }

                    Console.WriteLine("Departamentin worker limitini daxil edin:");

                    while (loop2)
                    {
                        try
                        {
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
                            Console.WriteLine("Duzgun worker limit daxil edin:");
                        }
                    }

                    Console.WriteLine("Yeni salary limit daxil edin:");

                    while (loop3)
                    {
                        try
                        {
                            newsalarylimit = Convert.ToDouble(Console.ReadLine());
                            if (newsalarylimit >= 250)
                            {
                                department.SalaryLimit = newsalarylimit;
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Duzgun salary limit daxil edin:");
                        }
                    }

                   
                             }
                }
        }







