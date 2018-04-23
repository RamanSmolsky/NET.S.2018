using System;
using System.IO;

namespace Task_2.Solution
{
    public class RandomBytesFileGenerator: RandomFileGenerator
    {
        public RandomBytesFileGenerator()
        {
            //WorkingDirectory = "Files with random bytes";
            WorkingDirectory = @"c:\GitHub-RamanSmolsky\NET.S.2018\NET.W.2018.RamanSmolsky.Test\Task2.Solution\temp\";
            FileExtension = ".bytes";
        }

        public override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}