using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task3.Solution;

namespace Task3.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Stock s = new Stock();
            Bank b = new Bank("MyBank", s);
            Broker br = new Broker("MyBroker", s);
            s.Market();
            s.Market();
        }
    }
}