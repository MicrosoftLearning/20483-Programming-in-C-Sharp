using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace FourthCoffee.DataService.Infrastructure
{
    [DataContract()]
    public class SalesPerson
    {
        [DataMember()]
        public string FirstName { get; set; }

        [DataMember()]
        public string Surname { get; set; }

        [DataMember()]
        public string Area { get; set; }

        [DataMember()]
        public string EmailAddress { get; set; }

        public static SalesPerson FromJson(Stream json)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(SalesPerson));

            return jsonSerializer.ReadObject(json) as SalesPerson;
        }
    }
}