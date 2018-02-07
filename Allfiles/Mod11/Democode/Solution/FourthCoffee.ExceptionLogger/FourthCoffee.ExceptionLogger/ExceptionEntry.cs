using System;
using System.Runtime.Serialization;

namespace FourthCoffee.ExceptionLogger
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.ExceptionLogger.ExceptionEntry" /> class in the object model.
    /// </summary>
    [Serializable]
    public class ExceptionEntry
        : ISerializable
    {
        /// <summary>
        /// Represents the exception title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Represents the exception details.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// Create an instance of the ExceptionEntry class.
        /// </summary>
        public ExceptionEntry()
        {
        }

        public ExceptionEntry(SerializationInfo info, StreamingContext context)
        {
            this.Title = info.GetString("Title");
            this.Details = info.GetString("Details");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Title", this.Title);
            info.AddValue("Details", this.Details);
        }
    }
}
