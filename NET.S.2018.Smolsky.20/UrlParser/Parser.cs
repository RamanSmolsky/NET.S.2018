using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Url
{
    // TODO: redesign to add flexibility in terms of new variants of sources (not just text file)
    public static class Parser
    {
        public static AddressesManager ParseFromFile(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} should not be null");
            }

            string[] res = null;

            try
            {
                res = File.ReadAllLines(filePath);
            }
            catch (Exception)
            {
                throw new ApplicationException($"error while reading {filePath} file");
            }
            
            AddressesManager addrMngr = new AddressesManager();

            foreach (var line in res)
            {
                Address addr = GetAddressFromString(line);
                addrMngr.Addresses.Add(addr);
            }

            return addrMngr;
        }

        public static void SerializeFromObjectToXmlFile(AddressesManager addressesManager, string filePath)
        {
            // TODO: fix - empty <parameters> tag added to the result file if there are no parameters
            // TODO: fix - empty <segments> tag added to the result file if there are no segments
            Encoding encoding = Encoding.GetEncoding("UTF-8");

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(string.Empty, string.Empty);

            XmlSerializer x = new XmlSerializer(typeof(AddressesManager));

            XmlWriterSettings xs = new XmlWriterSettings
            {
                Encoding = Encoding.GetEncoding("UTF-8"),
                Indent = true,
                IndentChars = "\t",
                NewLineChars = Environment.NewLine,
                ConformanceLevel = ConformanceLevel.Document
            };

            using (Stream s = File.OpenWrite(filePath))
            {
                // TODO: try to workaround the problem with empty tag written in short form
                // https://www.experts-exchange.com/questions/27641357/XmlWriter-Create-Empty-Tag-tag-tag.html
                // https://bytes.com/topic/net/answers/178893-force-xmlserializer-use-explicit-closing-tags-zero-length-strings
                // to force writing expanded empty tag
                x.Serialize(XmlWriter.Create(s, xs), addressesManager, ns);
            }
        }

        public static AddressesManager DeserializeFromXmlFileToObject(string filePath)
        {
            XmlSerializer x = new XmlSerializer(typeof(AddressesManager));

            AddressesManager res = null;

            using (Stream s = File.OpenRead(filePath))
            {
                res = (AddressesManager)x.Deserialize(s);
            }

            return res;
        }

        private static Address GetAddressFromString(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException($"{nameof(url)} should not be null or empty");
            }

            string temp = url.ToUpper();
            string hostTemp = string.Empty;

            if (temp.StartsWith("HTTP://") || temp.StartsWith("HTTPS://"))
            {
                if (temp.StartsWith("HTTP://"))
                {
                    hostTemp = url.Substring(0, 4);
                    url = url.Substring(7);
                }
                else
                {
                    hostTemp = url.Substring(0, 5);
                    url = url.Substring(8);
                }
            }
            else
            {
                throw new ArgumentNullException($"{nameof(url)} does not start with valid scheme (http or https)");
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentOutOfRangeException($"{nameof(url)} contains only scheme (http or https) - no host");
            }

            int indexOfFirstForwardSlash = url.IndexOf("/");

            string host = null;

            if (indexOfFirstForwardSlash == -1)
            {
                host = url; // remained part of the url is host
            }
            else
            {
                host = url.Substring(0, indexOfFirstForwardSlash);
            }

            string temptail = url.Substring(indexOfFirstForwardSlash + 1);

            // are there any parameters?
            int indexOfQuestionMark = temptail.IndexOf("?");
            string middle = null;
            string finalTail = null;
            string[] segments = null;
            string[] tempParameters = null;

            if (indexOfQuestionMark != -1)
            {
                middle = temptail.Substring(0, indexOfQuestionMark);
                finalTail = temptail.Substring(indexOfQuestionMark + 1);
               
                tempParameters = finalTail.Split('?');
            }
            else
            {
                middle = temptail;
            }

            segments = middle.Split('/');

            List<Parameter> paramRes = new List<Parameter>();

            if (tempParameters != null)
            {
                foreach (var parameterPair in tempParameters)
                {
                    int index = parameterPair.IndexOf("=");

                    if (index == -1)
                    {
                        // log exception, as parameter pair should contain '=' symbol, stop further processing of this line
                    }

                    string value = parameterPair.Substring(0, index);
                    string key = parameterPair.Substring(index + 1);

                    paramRes.Add(new Parameter(value, key));
                }
            }

            Address res = new Address(host);
            res.Host.UrlParts = segments?.ToList();
            res.Host.Parameters = paramRes;

            return res;
        }
    }
}