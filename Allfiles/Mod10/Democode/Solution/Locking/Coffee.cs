using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locking
{
    class Coffee
    {
        private object coffeeLock = new object();
        int stock;

        public Coffee(int initialStock)
        {
            stock = initialStock;
        }

        public bool MakeCoffees(int coffeesRequired)
        {
            // This condition will never be true unless you comment out the lock statement.
            if (stock < 0)
            {
                throw new Exception("Stock cannot be negative!");
            }

            //lock (coffeeLock)
            {
                // Check that there is sufficient stock to fulfil the order.
                if (stock >= coffeesRequired)
                {
                    // Introduce a delay to make thread contention more likely.
                    Thread.Sleep(500);

                    Console.WriteLine(String.Format("Stock level before making coffee: {0}", stock));
                    Console.WriteLine("Making coffee...");
                    stock = stock - coffeesRequired;
                    Console.WriteLine(String.Format("Stock level after making coffee: {0}", stock));
                    return true;
                }
                else
                {
                    Console.WriteLine("Insufficient stock to make coffee");
                    return false;
                }
            }
        }
    }
}
