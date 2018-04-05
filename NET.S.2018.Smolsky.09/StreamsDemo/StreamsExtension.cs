using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

#region source of initial project structure
// https://github.com/EPM-RD-NETLAB/.NET-Framework-modules/blob/master/M13.%20Streams%20and%20IO/M13.Streams.Task.7z
#endregion source of initial project structure

namespace StreamsDemo
{
    // C# 6.0 in a Nutshell. Joseph Albahari, Ben Albahari. O'Reilly Media. 2015
    // Chapter 15: Streams and I/O
    // Chapter 6: Framework Fundamentals - Text Encodings and Unicode
    // https://msdn.microsoft.com/ru-ru/library/system.text.encoding(v=vs.110).aspx
    public static class StreamsExtension
    {
        #region Public members

        #region Implement by byte copy logic using class FileStream as a backing store stream.

        public static int ByByteCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} and {nameof(destinationPath)} should be both not null and not empty");
            }

            Stream source = null;
            Stream destination = null;
            int bytesCounter = 0;

            try
            {
                source = new FileStream(sourcePath, FileMode.Open);
                destination = new FileStream(destinationPath, FileMode.Create);

                if (!source.CanRead || !destination.CanWrite)
                {
                    throw new IOException($"either {nameof(sourcePath)} could not be opened for reading or {nameof(destinationPath)} could not be opened for writing");
                }

                int byteFromSource = source.ReadByte();

                // TODO: ? use this: reader.Peek() != -1)
                while (byteFromSource != -1)
                {
                    destination.WriteByte((byte)byteFromSource);
                    bytesCounter++;
                    byteFromSource = source.ReadByte();
                }

                destination.Flush();
                return bytesCounter;
            }
            catch (Exception ex)
            {
                throw new Exception($"error while processing {nameof(sourcePath)} or {nameof(destinationPath)}", ex);
            }
            finally
            {
                source.Dispose();
                destination.Dispose();
            }
        }

        #endregion

        #region Implement by byte copy logic using class MemoryStream as a backing store stream.

        public static int InMemoryByByteCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} and {nameof(destinationPath)} should be both not null and not empty");
            }

            string content = null;
            StreamReader sr = null;
            StreamWriter swr = null;
            MemoryStream ms = null;
            byte[] contentAsBytes = null;
            byte[] contentAsBytesAgain = null;
            char[] contentAsChars = null;

            // step 1. Use StreamReader to read entire file in string
            try
            {
                using (sr = new StreamReader(sourcePath))
                {
                    content = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                throw new StreamsExtensionException("Could not read content of the file", ex);
            }

            try
            {
                // step 2. Create byte array on base string content - use  System.Text.Encoding class
                contentAsBytes = Encoding.UTF8.GetBytes(content);
            }
            catch (Exception ex)
            {
                throw new StreamsExtensionException("could not get UTF8 encoding of the content", ex);
            }

            // step 3. Use MemoryStream instance to read from byte array (from step 2)
            if (contentAsBytes == null)
            {
                throw new StreamsExtensionException($"{contentAsBytes} is null, nothing to proceed with");
            }

            // step 4. Use MemoryStream instance (from step 3) to write it content in new byte array
            ms = new MemoryStream(contentAsBytes);
            contentAsBytesAgain = ms.ToArray();

            try
            {
                // step 5. Use Encoding class instance (from step 2) to create char array on byte array content
                contentAsChars = Encoding.UTF8.GetChars(contentAsBytesAgain);
            }
            catch (Exception ex)
            {
                throw new StreamsExtensionException("could not get char array with UTF8 encoding of the content", ex);
            }

            // step 6. Use StreamWriter here to write char array content in new file
            try
            {
                using (swr = new StreamWriter(destinationPath))
                {
                    swr.Write(contentAsChars);
                    swr.Flush();
                }
            }
            catch (Exception ex)
            {
                throw new StreamsExtensionException("Error while writing the content to the file", ex);
            }

            return contentAsChars.Length;
        }

        #endregion

        #region TODO: Implement by block copy logic using FileStream buffer.

        public static int ByBlockCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} and {nameof(destinationPath)} should be both not null and not empty");
            }

            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using MemoryStream.

        public static int InMemoryByBlockCopy(string sourcePath, string destinationPath)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(destinationPath))
            {
                throw new ArgumentException($"{nameof(sourcePath)} and {nameof(destinationPath)} should be both not null and not empty");
            }

            // TODO: Use InMemoryByByteCopy method's approach
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by block copy logic using class-decorator BufferedStream.

        public static int BufferedCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region TODO: Implement by line copy logic using FileStream and classes text-adapters StreamReader/StreamWriter

        public static int ByLineCopy(string sourcePath, string destinationPath)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region content comparison logic of two files 

        public static bool IsContentEquals(string sourcePath1, string sourcePath2)
        {
            if (string.IsNullOrEmpty(sourcePath1) || string.IsNullOrEmpty(sourcePath2))
            {
                throw new ArgumentException($"{nameof(sourcePath1)} and {nameof(sourcePath2)} should be both not null and not empty");
            }

            string content1 = null;
            string content2 = null;
            StreamReader sr1 = null;
            StreamReader sr2 = null;

            try
            {
                using (sr1 = new StreamReader(sourcePath1))
                {
                    content1 = sr1.ReadToEnd();
                }

                using (sr2 = new StreamReader(sourcePath2))
                {
                    content2 = sr2.ReadToEnd();
                }

                return content1 == content2;
            }
            catch (Exception ex)
            {
                throw new StreamsExtensionException("Could not read content of the files", ex);
            }
            finally
            {
                sr1.Dispose();
                sr2.Dispose();
            }
        }

        #endregion

        #endregion

        #region Private members

        #region TODO: Implement validation logic

        private static void InputValidation(string sourcePath, string destinationPath)
        {
        }

        #endregion

        #endregion
    }
}