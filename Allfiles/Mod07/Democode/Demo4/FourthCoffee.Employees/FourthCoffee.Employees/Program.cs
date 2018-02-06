using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.Employees
{
    class Program
    {

        static FourthCoffeeEntities DBContext = new FourthCoffeeEntities();

        static void Main(string[] args)
        {
            UsingAnonymousTypes();
            GroupingData();
            AggregatingData();
            NavigatingData();
        }

        private static void UsingAnonymousTypes()
        {
            var emps = from e in DBContext.Employees
                       select new { e.FirstName, e.LastName };

            Console.WriteLine("LINQ Query to filter data by column by using anonymous types");
            Console.WriteLine("============================================================");

            foreach (var emp in emps)
            {
                Console.WriteLine("{0} {1}", emp.FirstName, emp.LastName);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void GroupingData()
        {
            var emps = from e in DBContext.Employees
                       group e by e.JobTitle into eGroup
                       select new { Job = eGroup.Key, Names = eGroup };

            Console.WriteLine("LINQ Query to select all employees and group them by their job title id");
            Console.WriteLine("=======================================================================");

            foreach (var emp in emps)
            {
                Console.WriteLine(emp.Job);
                foreach (var name in emp.Names)
                {
                    Console.WriteLine("    {0} {1}", name.FirstName, name.LastName);
                }
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void AggregatingData()
        {
            var jobs = from e in DBContext.Employees
                       group e by e.JobTitle into eGroup
                       select new { Job = eGroup.Key, CountOfEmployees = eGroup.Count() };

            Console.WriteLine("LINQ Query to select all employees, group them by their job title id, and provide count per job title id");
            Console.WriteLine("========================================================================================================");

            foreach (var job in jobs)
            {
                Console.WriteLine("Job: {0}, Count of Employees: {1}", job.Job, job.CountOfEmployees);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
      
        private static void NavigatingData()
        {
            var emps = from e in DBContext.Employees
                       select new
                       {
                           FirstName = e.FirstName,
                           LastName = e.LastName,
                           Job = e.JobTitle1.Job
                       };

            Console.WriteLine("LINQ Query to select all employees and their job titles");
            Console.WriteLine("=======================================================");
            foreach (var emp in emps)
            {
                Console.WriteLine("{0} {1}, {2}", emp.FirstName, emp.LastName, emp.Job);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
