using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

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

            var stream = File.Create(path);

            // TODO: 04: Create a SoapFormatter object and serialize the entry object.
            var formatter = new SoapFormatter();
            formatter.Serialize(stream, entry);

            stream.Close();
            stream.Dispose();
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
            var stream = File.OpenRead(path);

            // TODO: 05: Create a SoapFormatter object and deserialize the stream to the entry object.
            var formatter = new SoapFormatter();
            entry = formatter.Deserialize(stream) as ExceptionEntry;

            stream.Close();
            stream.Dispose();

            return entry;
        }
    }
}
