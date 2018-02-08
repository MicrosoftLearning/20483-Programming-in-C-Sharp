using System;
using System.Collections.Generic;
using System.Linq;
using FourthCoffee.DataService.Infrastructure;

namespace FourthCoffee.DataService
{
    public class SalesService : ISalesService
    {
        public SalesPerson GetSalesPerson(string emailAddress)
        {
            return this.GetSalesPeople()
                .Where(s => s.EmailAddress.Equals(emailAddress, StringComparison.OrdinalIgnoreCase))
                .FirstOrDefault();
        }

        private IQueryable<SalesPerson> GetSalesPeople()
        {
            return new List<SalesPerson>
            {
                new SalesPerson
                {
                    Area = "snacks",
                    FirstName = "Jesper",
                    Surname = "Herp",
                    EmailAddress = "jesper@fourthcoffee.com"
                },new SalesPerson
                {
                    Area = "snacks",
                    FirstName = "Eran",
                    Surname = "Harel",
                    EmailAddress = "eran@fourthcoffee.com"
                },new SalesPerson
                {
                    Area = "snacks",
                    FirstName = "David",
                    Surname = "Pelton",
                    EmailAddress = "david@fourthcoffee.com"
                },new SalesPerson
                {
                    Area = "snacks",
                    FirstName = "Jan",
                    Surname = "Kotas",
                    EmailAddress = "jan@fourthcoffee.com"
                }
            }.AsQueryable();
        }
    }
}
