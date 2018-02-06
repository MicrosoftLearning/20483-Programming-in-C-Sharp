using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConstructors
{
    class Program
    {
        static void Main(string[] args)
        {
            Coffee coffee1 = new Coffee();
            Coffee coffee2 = new Coffee("Fourth Espresso", true, 170, "Arabica", "Dark", "Columbia");

            Console.WriteLine("*** Coffee 1 ***");
            Console.WriteLine("Name: {0}", coffee1.Name);
            Console.WriteLine("Fair Trade: {0}", coffee1.IsFairTrade);
            Console.WriteLine("Serving Temperature: {0}", coffee1.GetServingTemperature());
            Console.WriteLine("Bean Type: {0}", coffee1.Bean);
            Console.WriteLine("Roast Type: {0}", coffee1.Roast);
            Console.WriteLine("Country of Origin: {0}", coffee1.CountryOfOrigin);
            Console.WriteLine();

            Console.WriteLine("*** Coffee 2 ***");
            Console.WriteLine("Name: {0}", coffee2.Name);
            Console.WriteLine("Fair Trade: {0}", coffee2.IsFairTrade);
            Console.WriteLine("Serving Temperature: {0}", coffee2.GetServingTemperature());
            Console.WriteLine("Bean Type: {0}", coffee2.Bean);
            Console.WriteLine("Roast Type: {0}", coffee2.Roast);
            Console.WriteLine("Country of Origin: {0}", coffee2.CountryOfOrigin);
            Console.WriteLine();

            Console.WriteLine("Press Enter to continue");
            Console.ReadLine();
        }
    }
}
