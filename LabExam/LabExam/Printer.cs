using System;
using System.IO;

namespace LabExam
{
    public abstract class Printer : IEquatable<Printer>
    {
        public Printer(string name, string model)
        {
            Name = name;
            Model = model;
        }

        public delegate void PrintEventHandler(object sender, PrintEventArgs eventArgs);

        public event PrintEventHandler PrintStarted;

        public event PrintEventHandler PrintCompleted;

        public string Name { get; private set; }

        public string Model { get; private set; }

        public void Print(Stream fs)
        {
            PrintStarted?.Invoke(this, new PrintEventArgs("printing started"));

            PrintInternal(fs);

            PrintCompleted?.Invoke(this, new PrintEventArgs("printing completed"));
        }

        public bool Equals(Printer other)
        {
            if (other is null)
            {
                return false;
            }

            return Name == other.Name && Model == other.Model;            
        }

        // TODO: is it enough to have possibility of different implementation in next level classes?
        protected virtual void PrintInternal(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                // simulate printing
                Console.WriteLine(stream.ReadByte());
            }
        }
    }
}