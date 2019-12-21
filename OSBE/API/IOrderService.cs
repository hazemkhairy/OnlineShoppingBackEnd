using OSBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace OSBE.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IOrderService" in both code and config file together.
    [ServiceContract]
    public interface IOrderService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "Place",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string PlaceOrder(OrderDTO order);

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "All/{userID}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        List<OrderDTO> GetAll(string userID);

        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "GetOrder/{orderID}",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        OrderDTO GetOrder(string orderID);
    }
}
