using System.Xml;
using System.Xml.Serialization;

namespace Url
{
    public class Parameter
    {
        private string key;

        private string value;

        public Parameter()
        {
        }

        public Parameter(string value, string key)
        {
            Value = value;
            Key = key;
        }

        [XmlAttribute("value")]
        public string Value { get => value; set => this.value = value; }

        [XmlAttribute("key")]
        public string Key { get => key; set => key = value; }
    }
}