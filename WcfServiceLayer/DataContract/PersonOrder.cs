using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WcfServiceLayer.DataContract
{
    [DataContract]
    public class PersonOrder
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public int personId { get; set; }

        [DataMember]
        public string description { get; set; }

        [DataMember]
        public int amount { get; set; }

        [DataMember]
        public string notes { get; set; }
    }
}