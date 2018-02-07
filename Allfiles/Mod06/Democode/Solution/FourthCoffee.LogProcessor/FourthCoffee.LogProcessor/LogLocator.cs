using System.Collections.Generic;
using System.IO;

namespace FourthCoffee.LogProcessor
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.LogProcessor.LogLocator" /> class in the object model.
    /// </summary>
    public class LogLocator
    {
        string _logDirectoryPath;

        /// <summary>
        /// Create an instance of the LogLocator class.
        /// </summary>
        /// <param name="logDirectoryRoot">The root log file directory path.</param>
        public LogLocator(string logDirectoryRoot)
        {
            // TODO: 01: Ensure log file directory exists.
            if (!Directory.Exists(logDirectoryRoot))
                throw new DirectoryNotFoundException();

            this._logDirectoryPath = logDirectoryRoot;
        }

        /// <summary>
        /// Returns a collection of log file paths for a given directory.
        /// </summary>
        public IEnumerable<string> GetLogFilePaths()
        {
            // TODO: 02: Get all log file paths.
            return Directory.GetFiles(
                this._logDirectoryPath,
                "*.txt");
        }
    }
}
