using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_2.Solution
{
    public class RandomCharsFileGenerator : RandomFileGenerator
    {
        public RandomCharsFileGenerator()
        {
            //WorkingDirectory = "Files with random chars";
            WorkingDirectory = @"c:\GitHub-RamanSmolsky\NET.S.2018\NET.W.2018.RamanSmolsky.Test\Task2.Solution\temp\";
            //c:\GitHub-RamanSmolsky\NET.S.2018\NET.W.2018.RamanSmolsky.Test\Task2.Solution\temp\
            FileExtension = ".txt";
        }

        public override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private string RandomString(int Size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }
}