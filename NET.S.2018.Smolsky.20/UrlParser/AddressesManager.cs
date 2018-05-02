using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Url
{
    // TODO: fix - classes structure design was 'for' serializing, try to develop it if there is no serializing
    [XmlRoot(ElementName = "urlAddresses")]
    public class AddressesManager
    {
        private List<Address> addresses;

        public AddressesManager()
        {
            Addresses = new List<Address>();
        }

        [XmlElement(ElementName = "urlAddress")]
        public List<Address> Addresses { get => addresses; set => addresses = value; }
    }
}