using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagment
{
    public class Department
    {
        public string Name { get; set; }
        public int WorkerLimit { get; set; }
        public double SalaryLimit { get; set; }
        public List<Employee> Employees { get; set; }

        //List yaraderken onu initialize etmeyimiz mecburidir, eks halda reference etdiyi list uzunlugu null olur.

        //Asagida mutleq listi imitialize etmeliyik ki daha sonra instance alib obyekt yaradanda bu liste reference etsin,eks halda null reference olur, runtime error cixir.

        public Department(string name, int workerlimit, double salarylimit)
        {
            Employees = new List<Employee>();
            Name = name;
            WorkerLimit = workerlimit;
            SalaryLimit = salarylimit;
        }
        //Asagida Employee tipinden olan Employees listinde olan iscilerin ortalamna maasini tapmaq lazimdir.
        public double CalcSalaryAverage()
        {
            double average = 0;
            double sum = 0;
            foreach (var item in Employees)
            {
                sum += item.Salary;
            }
            if (Employees.Count != 0)

            {
                average = sum / Employees.Count;
                return average;
            }
            else
            {
                return 0;
            }
        }
    }
}
    