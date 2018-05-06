using System;

namespace LabExam
{
    public class PrintEventArgs : EventArgs
    {
        public PrintEventArgs(string message)
        {
            this.Message = message;
        }

        public string Message { get; private set; }
    }
}