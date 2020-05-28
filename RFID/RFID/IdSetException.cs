using System;
using System.Runtime.Serialization;

namespace RFID
{
    [Serializable]
    internal class IdSetException : Exception
    {
        private ulong id;
        public ulong Id
        {
            get
            {
                return id;
            }
        }

        public IdSetException()
        {
        }

        public IdSetException(ulong id)
        {
            this.id = id;
        }

        public IdSetException(string message) : base(message)
        {
        }

        public IdSetException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdSetException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}