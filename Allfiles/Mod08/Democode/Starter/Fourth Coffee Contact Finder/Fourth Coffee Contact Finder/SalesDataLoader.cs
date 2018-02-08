using System;
using System.IO;
using System.Text;
using FourthCoffee.DataService.Infrastructure;
// TODO: 01: Bring the System.Net namespace into scope.


namespace Fourth_Coffee_Contact_Finder
{
    public class SalesDataLoader
    {
        Uri _serviceUri;
        // TODO: 02: Declare a global object to encapsulate an HTTP request.
  

        public SalesDataLoader(Uri serviceUri)
        {
            if(serviceUri ==null)
                 throw new NullReferenceException("serviceUri");

            this._serviceUri = serviceUri;
        }


        public SalesPerson GetPersonByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return null;

            this.InitializeRequest();

            var rawData = Encoding.Default.GetBytes(
                "{\"emailAddress\":\"" + email.Trim() + "\"}");

            // TODO: 04: Configure the request to send JSON data.
          

            this.WriteDataToRequestStream(rawData);

            return this.ReadDataFromResponseStream();
        }

        private void InitializeRequest()
        {
            // TODO: 03: Instantiate the _request object.
         

            if (this._request == null)
                throw new NullReferenceException("_request");
        }

        private void WriteDataToRequestStream(byte[] data)
        {
            // TODO: 05: Write data to the request stream.
           
        }

        private SalesPerson ReadDataFromResponseStream()
        {
            // TODO: 06: Create an HttpWebResponse object.
            

            // TODO: 07: Check to see if the response contains any data.
            

            // TODO: 08: Read and process the response data.
          

            return result;
        }
    }
}
