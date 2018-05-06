using System;

namespace LabExam
{
    public class DuplicatedPrinterException : Exception
    {
        public DuplicatedPrinterException(string message) : base(message)
        {
        }
    }
}