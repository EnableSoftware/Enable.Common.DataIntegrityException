using System;
using System.Runtime.Serialization;

namespace Enable.Common
{
    /// <summary>
    /// Represents an attempt that has been made to compromise the integrity of the application data.
    /// </summary>
    [Serializable]
    public class DataIntegrityException : Exception
    {
        public DataIntegrityException()
            : base()
        {
        }

        public DataIntegrityException(string message)
            : base(message)
        {
        }

        public DataIntegrityException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected DataIntegrityException(SerializationInfo serializationInfo, StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}
