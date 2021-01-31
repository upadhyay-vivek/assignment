using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Assignment.WebApp.Models
{
    [DataContract(Namespace ="")]
    public class Address
    {
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string HouseNumber { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
        [DataMember]
        public string City { get; set; }
    }
}