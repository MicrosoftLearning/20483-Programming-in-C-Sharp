using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseConstructors
{
    class Coffee : Beverage
    {
        public Coffee()
        {
            // Use the default constructor to set default values.
            Bean = "Not known";
            Roast = "Medium";
            CountryOfOrigin = "Not known";
        }

        public Coffee(string name, bool isFairTrade, int servingTemp, string bean, string roast, string countryOfOrigin)
            : base(name, isFairTrade, servingTemp)
        {
            Bean = bean;
            Roast = roast;
            CountryOfOrigin = countryOfOrigin;
        }

        public string Bean { get; set; }
        public string Roast { get; set; }
        public string CountryOfOrigin { get; set; }
    }
}
