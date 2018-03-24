using System;
using ClassLibraryDemo;

namespace ConsoleApplicationDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Title1", "Author1");
            Console.WriteLine(book.ToString());
            Console.ReadKey();
        }
    }
}
