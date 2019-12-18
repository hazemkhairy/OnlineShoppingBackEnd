using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using OSBE.DTOs;
namespace OSBE.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IExampleService" in both code and config file together.
    [ServiceContract]
    public interface IExampleService
    {
        [OperationContract]
        [WebInvoke(Method = "GET",
            UriTemplate = "GetExample",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string GetExample();

        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "POSTExample",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string PostExample(ExampleClientDTO client);
    }
}
