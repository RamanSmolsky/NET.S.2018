using System;

namespace LabExam
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            LogToFile logToFile = new LogToFile();
            PrinterManager pm = PrinterManager.GetPrinterManager(logToFile);

            AddKnownPrinters(pm);

            ProcessPrinting(pm);
        }

        private static void AddKnownPrinters(PrinterManager pm)
        {
            pm.Add(new CanonPrinter());
            pm.Add(new EpsonPrinter());
        }

        private static void ProcessPrinting(PrinterManager pm)
        {
            while (true)
            {
                Console.WriteLine("Select your choice:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Add new printer");

                ShowListOfPrinters(pm);

                var key = Console.ReadKey();

                if (key.Key == ConsoleKey.D0)
                {
                    break;
                }

                if (key.Key == ConsoleKey.D1)
                {
                    Console.WriteLine();

                    try
                    {
                        pm.CreatePrinter();
                    }
                    catch (DuplicatedPrinterException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    continue;
                }

                if (key.Key >= ConsoleKey.D2 && key.Key <= ConsoleKey.D9)
                {
                    pm.Print((int)key.Key - 50);
                }

                Console.WriteLine();
            }
        }

        private static void ShowListOfPrinters(PrinterManager pm)
        {
            if (pm == null)
            {
                Console.WriteLine($"PrinterManager {nameof(pm)} is null - nothing to show");
            }

            if (pm.Printers == null)
            {
                Console.WriteLine($"PrinterManager {nameof(pm)} has empty list of printers - nothing to show");
            }

            if (pm.Printers.Count > 8)
            {
                Console.WriteLine($"PrinterManager {nameof(pm)} has more than 8 printers - only 8 will be shown");
            }

            int i = 2;

            foreach (var printer in pm.Printers)
            {
                Console.WriteLine($"{i}: Print on {printer.Name}, model {printer.Model}");
                i++;
            }
        }
    }
}