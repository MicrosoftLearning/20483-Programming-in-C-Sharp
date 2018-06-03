using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.LogProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO 09: Replace [Repository Root] with your folder path 
            var logLocator = new LogLocator(@"[Repository Root]\Mod06\Democode\Data\Logs\");
            var logCombiner = new LogCombiner(logLocator);

            logCombiner.CombineLogs(@"[Repository Root]\Mod06\Democode\Data\Logs\CombinedLog.txt");

        }
    }
}
