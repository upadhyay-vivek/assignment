using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Assignment.WebApp.Models
{
    [DataContract(Namespace ="")]
    public class Receipient
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Address Address { get; set; }
    }
}