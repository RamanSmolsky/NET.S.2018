using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2.Solution;

namespace Task2.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomCharsFileGenerator ch = new RandomCharsFileGenerator();

            ch.GenerateFiles(3, 5);

            RandomBytesFileGenerator bt = new RandomBytesFileGenerator();
            bt.GenerateFiles(2, 7);
        }
    }
}