using System;

namespace TNBase.External.DataImport
{
    [Serializable]
    public class InvalidImportDataException : Exception
    {
        public InvalidImportDataException() { }
        public InvalidImportDataException(string message) : base(message) { }
        public InvalidImportDataException(string message, Exception inner) : base(message, inner) { }
        protected InvalidImportDataException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
