using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
// TODO 01: Add Using for Newtonsoft.Json

namespace FourthCoffee.ExceptionLogger
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.ExceptionLogger.ExceptionSerializer" /> class in the object model.
    /// </summary>
    public static class ExceptionSerializer
    {
        /// <summary>
        /// Serializes an exception.
        /// </summary>
        /// <param name="entry">The exception entry to serialize.</param>
        /// <param name="path">The file path.</param>
        public static void Serialize(ExceptionEntry entry, string path)
        {
            if (entry == null)
                throw new NullReferenceException("entry");

            // TODO 02: Convert object to JSON string
        }

        /// <summary>
        /// Deserializes an exception.
        /// </summary>
        /// <param name="path">The file path.</param>
        /// 
        public static ExceptionEntry Deserialize(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();

            var entry = default(ExceptionEntry);
            var jsonAsStriong = File.ReadAllText(path);

            // TODO: 03: Convert JSON string to an object 
            
            return entry;
        }
    }
}
