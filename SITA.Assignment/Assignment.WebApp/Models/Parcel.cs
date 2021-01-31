using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Assignment.WebApp.Models
{
    [DataContract(Namespace="")]
    public class Parcel
    {
        [DataMember]
        public Sender Sender { get; set; }
        [DataMember]
        public Receipient Receipient { get; set; }
        [DataMember]
        public decimal Weight { get; set; }
        [DataMember]
        public decimal Value { get; set; }
    }
}