using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfServiceLayer.DataContract;

namespace WcfServiceLayer
{
    [ServiceContract]
    public interface IPersonService
    {
        [OperationContract]
        [WebInvoke(Method = "GET", 
                   RequestFormat = WebMessageFormat.Json, 
                   ResponseFormat = WebMessageFormat.Json, 
                   UriTemplate = "Data/{value}")]
        string GetData(string value);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "DataUsingDataContract/")]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        // TODO: Add your service operations here

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "Persons/")]
        List<Person> GetAllPersons();

        [OperationContract]
        [WebInvoke(Method = "GET",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "Person/{id}")]
        Person GetPersonById(string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "AddPerson/{id}")]
        Person AddNewPerson(Person person, string id);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "UpdatePerson/{id}")]
        bool UpdateAPerson(Person person, string id);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                   RequestFormat = WebMessageFormat.Json,
                   ResponseFormat = WebMessageFormat.Json,
                   UriTemplate = "DeletePerson/{id}")]
        bool DeleteAPerson(string id);
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
