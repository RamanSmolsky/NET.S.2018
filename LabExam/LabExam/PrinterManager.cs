using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LabExam
{
    /// <summary>
    /// Manages list of printers - adding, printing on them
    /// </summary>
    public class PrinterManager
    {
        private static PrinterManager _instance;
        private ILogger _logger;

        protected PrinterManager(ILogger logger)
        {
            _logger = logger;

            Printers = new List<Printer>();
        }

        public List<Printer> Printers { get; private set; }

        public static PrinterManager GetPrinterManager(ILogger logger)
        {
            if (_instance == null)
            {
                _instance = new PrinterManager(logger)
                {
                    Printers = new List<Printer>()
                };

                return _instance;
            }
            else
            {
                return _instance;
            }
        }

        /// <summary>
        /// Adds provided Printer to the list of printers
        /// </summary>
        /// <param name="printer">printer to be added to the list</param>
        /// <exception cref="DuplicatedPrinterException">throws exception if such printer already exists in the list</exception>
        public void Add(Printer printer)
        {
            if (!Printers.Contains(printer) || Printers.Count == 0)
            {
                printer.PrintStarted += LogPrintingInfo;
                printer.PrintCompleted += LogPrintingInfo;
                Printers.Add(printer);
                _logger.Log($"Printer with name: {printer.Name}, model: {printer.Model} added to the list of printers");                
            }
            else
            {
                throw new DuplicatedPrinterException($"printer with name {printer.Name} and model {printer.Model} already exists");
            }
        }

        /// <summary>
        /// Prints selected by the user file on the provided printer (selected by its number in the list of printers)
        /// </summary>
        /// <param name="printerIndex">index of the printer in the list of printers</param>
        public void Print(int printerIndex)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.ShowDialog();

            using (FileStream file = File.OpenRead(fileDialog.FileName))
            {
                Printers[printerIndex].Print(file);
            }
        }

        /// <summary>
        /// Allows user to create printer from console, providing Name and Model, and add it to the list of printers
        /// </summary>
        public void CreatePrinter()
        {
            Console.WriteLine("Enter printer name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter printer model: ");
            string model = Console.ReadLine();

            Add(new UserDefinedPrinter(name, model));
        }

        public void LogPrintingInfo(object sender, PrintEventArgs args)
        {
            string name = ((Printer)sender).Name;
            string model = ((Printer)sender).Model;
            string msg = $"LogPrintingInfo: printer: {name}, model: {model}; message: {args.Message}";
            _logger.Log(msg);            
        }
    }
}