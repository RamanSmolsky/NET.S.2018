using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task_2.Solution
{
    public abstract class RandomFileGenerator
    {
        public string WorkingDirectory { get; set; }

        public string FileExtension { get; set; }

        public virtual void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{FileExtension}";

                WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        public abstract byte[] GenerateFileContent(int contentLength);

        protected void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }        
    }
}