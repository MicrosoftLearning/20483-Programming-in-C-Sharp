using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FourthCoffee.MethodTestHarness
{
    public class Utilities
    {
        public Utilities() 
        {
            // TODO: 02: Invoke the Initialize method.
        
        }

        // TODO: 01: Define the Initialize method.
        


        #region Helper methods

        string GetApplicationPath()
        {
            return Assembly.GetExecutingAssembly().Location;
        }

        #endregion
    }
}
