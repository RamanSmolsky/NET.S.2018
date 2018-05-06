using System.IO;

namespace LabExam
{
    /// <summary>
    /// Logger to log printing events messages (not the content to be printed) to the file
    /// </summary>
    public class LogToFile : ILogger
    {
        /// <summary>
        /// Logs provided message to the predefined file
        /// </summary>
        /// <param name="message"></param>
        public void Log(string message)
        {
            using (StreamWriter streamWriter = File.AppendText("log.txt"))
            {
                streamWriter.WriteLine(message);
                streamWriter.Flush();
                streamWriter.Close();
            }
        }
    }
}