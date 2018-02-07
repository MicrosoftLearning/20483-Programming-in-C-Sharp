using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locking
{  
    class Program
    {
        static void Main(string[] args)
        {
            // Create a Coffee instance with enough stock to make 1000 coffees.
            Coffee coffee = new Coffee(1000);
            Random r = new Random();
            
            // Create 100 iterations of a parallel for loop.
            Parallel.For(0, 100, index =>
                {
                    // Place an order for a random number of coffees.
                    coffee.MakeCoffees(r.Next(1, 100));
                });
            Console.ReadLine();
        }
    }
}
