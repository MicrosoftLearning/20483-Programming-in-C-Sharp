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
            QueryingData();
            FilteringDataByRow();
            FilteringDataByColumn();
        }

        private static void QueryingData()
        {
            IQueryable<Employee> emps = from e in DBContext.Employees
                                        orderby e.LastName
                                        select e;

            Console.WriteLine("Basic LINQ Query to select all employees");
            Console.WriteLine("========================================");
            foreach (var emp in emps)
            {
                Console.WriteLine("{0} {1} {2}", emp.FirstName, emp.LastName, DateTime.Parse(emp.DateOfBirth.ToString()).ToShortDateString());
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static void FilteringDataByRow()
        {
            string _LastName = "Prescott";
            IQueryable<Employee> emps = (from e in DBContext.Employees
                                         where e.LastName == _LastName
                                         select e);

            Console.WriteLine("LINQ Query to select all employees with a last name of Prescott");
            Console.WriteLine("===============================================================");
            foreach (var emp in emps)
            {
                Console.WriteLine("{0} {1}", emp.FirstName, emp.LastName);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private class FullName
        {
            public string Forename { get; set; }
            public string Surname { get; set; }
        }

        private static void FilteringDataByColumn()
        {
            IQueryable<FullName> names = from e in DBContext.Employees
                                         select new FullName { Forename = e.FirstName, Surname = e.LastName };

            Console.WriteLine("LINQ Query to select only the first name and last name of all employees");
            Console.WriteLine("=======================================================================");

            foreach (var name in names)
            {
                Console.WriteLine("{0} {1}", name.Forename, name.Surname);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
