using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace Url
{
    [XmlType(TypeName = "host")]
    public class Host
    {
        private List<string> urlParts;

        private List<Parameter> parameters;

        public Host()
        {
        }

        public Host(string host)
        {
            Name = host;
        }

        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlArray("url")]
        [XmlArrayItem(elementName: "segment")]
        public List<string> UrlParts { get => urlParts; set => urlParts = value; }

        [XmlArray("parameters")]
        [XmlArrayItem(elementName: "parameter")]
        public List<Parameter> Parameters { get => parameters; set => parameters = value; }
    }
}