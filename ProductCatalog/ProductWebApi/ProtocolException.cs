using System;
using System.Runtime.Serialization;

namespace ProductWebApi
{
    [Serializable]
    internal class ProtocolException : Exception
    {
        private object hTTPError;
        private string v;

        public enum Reason
        {
            InternalError,
            AuthenticationError,
            HTTPError,
            ConfigurationError
        }
        public ProtocolException()
        {
        }

        public ProtocolException(string message) : base(message)
        {
        }

        public ProtocolException(object hTTPError, string v)
        {
            this.hTTPError = hTTPError;
            this.v = v;
        }

        public ProtocolException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ProtocolException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}