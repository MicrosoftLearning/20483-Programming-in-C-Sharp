using System;
using System.Runtime.Serialization;

namespace FourthCoffee.ExceptionLogger
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.ExceptionLogger.ExceptionEntry" /> class in the object model.
    /// </summary>
    // TODO: 01: Decorate the type with the Serializable attribute.

    public class ExceptionEntry
        // TODO: 02: Implement the ISerializable interface.
     
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

        // TODO: 03: Add a deserialization constructor.



    }
}
