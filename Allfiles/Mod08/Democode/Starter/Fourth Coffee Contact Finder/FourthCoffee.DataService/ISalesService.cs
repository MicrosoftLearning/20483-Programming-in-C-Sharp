using System.ServiceModel;
using System.ServiceModel.Web;
using FourthCoffee.DataService.Infrastructure;

namespace FourthCoffee.DataService
{
    [ServiceContract]
    public interface ISalesService
    {
        [OperationContract]
        [WebInvoke(
            Method = "POST",
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.WrappedRequest)]
        SalesPerson GetSalesPerson(string emailAddress);
    }
}
