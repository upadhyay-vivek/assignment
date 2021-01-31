using Assignment.WebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Assignment.WebApp.DTOs
{
    [DataContract(Namespace = "")]
    public class Container
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime shippingDate { get; set; }
        [DataMember]
        public List<Parcel> parcels { get; set; } = new List<Parcel>();
    }

    [CollectionDataContract(Namespace ="")]
    public class ParcelCollection : List<Parcel> { }
}