using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Assignment.WebApp.Models
{
    [DataContract(Namespace = "")]
    [XmlType(TypeName = "Company")]
    public class Sender
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Address Address { get; set; }
    }
}