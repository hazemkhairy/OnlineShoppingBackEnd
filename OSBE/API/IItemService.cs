using OSBE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Script.Services;

namespace OSBE.API
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IItemService" in both code and config file together.
    [ServiceContract]
    public interface IItemService
    {
        [OperationContract]
        [WebInvoke(Method = "POST",
            UriTemplate = "Add",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Add(ItemDTO item);
        [OperationContract]
        [WebInvoke(Method = "GET",
           UriTemplate = "GetItem/{id}",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        ItemDTO GetItem(string id);
        [OperationContract]
        [WebInvoke(Method = "GET",
           UriTemplate = "GetItems/{categoryId}",
           BodyStyle = WebMessageBodyStyle.WrappedRequest,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json)]
        List<ItemDTO> GetItems(string categoryId);
        [OperationContract]
        [WebInvoke(Method = "DELETE",
            UriTemplate = "Delete",
            BodyStyle = WebMessageBodyStyle.WrappedRequest,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        string Delete(string itemId);
    }
}
