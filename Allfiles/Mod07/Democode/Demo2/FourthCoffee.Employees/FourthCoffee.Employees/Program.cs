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
            PrintEmployeesList();

            var emp = DBContext.Employees.First(e => e.LastName == "Prescott");
            if (emp != null)
            {
                emp.LastName = "Forsyth";
            }

            PrintEmployeesList();
        }

        private static void PrintEmployeesList()
        {
            foreach (FourthCoffee.Employees.Employee emp in DBContext.Employees)
            {
                Console.WriteLine("{0} {1}", emp.FirstName, emp.LastName);
            }
            Console.ReadLine();
        }
    }
}
