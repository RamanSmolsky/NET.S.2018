using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace StreamsDemo
{
    [Serializable]
    internal class StreamsExtensionException : Exception
    {
        public StreamsExtensionException()
        {
        }

        public StreamsExtensionException(string message) : base(message)
        {
        }

        public StreamsExtensionException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected StreamsExtensionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}