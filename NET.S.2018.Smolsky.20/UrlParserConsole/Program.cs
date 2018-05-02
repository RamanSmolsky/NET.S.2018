using System;

namespace Url
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string _tempfileWithAddresses = @"c:\GitHub-RamanSmolsky\NET.S.2018\NET.S.2018.Smolsky.20\_tempAddresses.txt";
            string _filePathTemp = @"c:\GitHub-RamanSmolsky\NET.S.2018\NET.S.2018.Smolsky.20\_temp.xml";

            AddressesManager addrMgr = Parser.ParseFromFile(_tempfileWithAddresses);

            Parser.SerializeFromObjectToXmlFile(addrMgr, _filePathTemp);

            Parser.DeserializeFromXmlFileToObject(_filePathTemp);
        }
    }
}