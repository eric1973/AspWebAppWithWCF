using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceLayer.DataContract
{
    [DataContract]
    public class Person
    {
        public Person()
        {
            PersonOrders = new HashSet<PersonOrder>();
        }

        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public ICollection<PersonOrder> PersonOrders { get; set; }
    }
}