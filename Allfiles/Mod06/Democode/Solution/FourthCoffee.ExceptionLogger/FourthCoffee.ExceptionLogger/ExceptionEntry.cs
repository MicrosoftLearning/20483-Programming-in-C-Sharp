using System;
using System.Runtime.Serialization;

namespace FourthCoffee.ExceptionLogger
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.ExceptionLogger.ExceptionEntry" /> class in the object model.
    /// </summary>
  
    public class ExceptionEntry
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

        public ExceptionEntry(string title, string details)
        {
            Title = title;
            Details = details;
        }
      


    }
}
