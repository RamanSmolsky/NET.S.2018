using System.Xml;
using System.Xml.Serialization;

namespace Url
{
    [XmlInclude(typeof(Host))] // TODO: type with only one member - could it be just that member?
    public class Address
    {
        public Address()
        {
        }

        public Address(string host)
        {
            Host = new Host(host);
        }

        [XmlElement(elementName: "host")]
        public Host Host { get; set; }
    }
}