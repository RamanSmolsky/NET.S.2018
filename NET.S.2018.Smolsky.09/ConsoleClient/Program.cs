using System;
using System.Configuration;
using static StreamsDemo.StreamsExtension;

#region source of initial project structure
//https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/blob/master/M13.%20Streams%20and%20IO/M13.Streams.Task.7z
#endregion source of initial project structure

namespace ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var source = ConfigurationManager.AppSettings["sourceFilePath"];

            var destination = ConfigurationManager.AppSettings["destinationFiePath"];

            Console.WriteLine($"ByteCopy() done. Total bytes: {ByByteCopy(source, destination)}");

            Console.WriteLine($"InMemoryByteCopy() done. Total bytes: {InMemoryByByteCopy(source, destination)}");

            Console.WriteLine(IsContentEquals(source, destination));

            //etc
        }
    }
}