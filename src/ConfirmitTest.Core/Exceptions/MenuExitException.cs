using System;
using System.Runtime.Serialization;

namespace ConfirmitTest.Core.Exceptions
{
    [Serializable]
    public class MenuExitException : ApplicationException
    {
        public MenuExitException()
        {
        }

        public MenuExitException(string message) : base(message)
        {
        }

        public MenuExitException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected MenuExitException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}