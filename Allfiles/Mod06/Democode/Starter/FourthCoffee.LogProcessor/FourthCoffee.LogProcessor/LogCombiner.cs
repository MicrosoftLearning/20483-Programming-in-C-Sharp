using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FourthCoffee.LogProcessor
{
    /// <summary>
    /// Represents the <see cref="FourthCoffee.LogProcessor.LogCombiner" /> class in the object model.
    /// </summary>
    public class LogCombiner
    {
        LogLocator _locator;

        /// <summary>
        /// Create an instance of the LogCombiner class.
        /// </summary>
        /// <param name="locator">The LogLocator object.</param>
        public LogCombiner(LogLocator locator)
        {
            if (locator == null)
                throw new NullReferenceException("locator");

            this._locator = locator;
        }

        /// <summary>
        /// Combines one or more logfiles into a single log file.
        /// </summary>
        /// <param name="combinedLogPath">The output file path for the combined log file.</param>
        public void CombineLogs(string combinedLogPath)
        {
            // TODO: 03: Check for existing combined log file and delete if it already exists.
            

            var logFiles = this._locator.GetLogFilePaths();

            if (logFiles.Count() == 0)
            {
                File.WriteAllText(combinedLogPath, "No log files to combine.");
            }
            else
            {
                this.WriteFileHeading(combinedLogPath);

                foreach (var logFile in logFiles)
                    this.WriteLog(combinedLogPath, logFile);
            }
        }

        private void WriteFileHeading(string combinedLogPath)
        {
            var heading = new List<string>();
            heading.Add("########################################");
            heading.Add("######### Combined Log File ############");
            heading.Add("########################################");

            // TODO: 04: Write the heading to the combined log file.
            
        }

        private void WriteLog(string combinedLogPath, string logPath)
        {
            // TODO: 05: Get the log file name without the file extension.
         

            if (logName.Equals("combinedlog"))
                return;

            var logText = this.GetLogFileText(logPath);

            var logContent = new List<string>();
            logContent.Add("");
            logContent.Add(string.Format("######### [{0}]", logName));
            logContent.Add(logText);
            logContent.Add("");

            // TODO: 07: Write the log file contents to the combined log file.
            
        }

        private string GetLogFileText(string logPath)
        {
            // TODO: 06: Read the contents of the existing log file.
            

            if (string.IsNullOrEmpty(logText))
            {
                logText = "No entries";
            }

            return logText;
        }
    }
}
