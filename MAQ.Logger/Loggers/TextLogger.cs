#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Class for logging in text file
// Change History:
// Name                      Date                       Version        Description
// -----------------------------------------------------------------------------------------------
// Sonal Singh               January 20, 2017           1.0.0.0        Class to log in text file
// Swapnil M                 February 10, 2017          1.0.0.1        Fix issue with logging error if file is missing
// -----------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -----------------------------------------------------------------------------------------------
#endregion

namespace Logger
{
    #region using
    using System;
    using System.Globalization;
    using System.IO;
    #endregion

    /// <summary>
    /// Class for logging in text file
    /// </summary> 
    public class TextLogger : ILogger
    {
        readonly string filePath;
        /// <summary>
        /// Constructor to initialize configurable properties
        /// </summary>
        /// <param name="config">Configuration details</param>
        public TextLogger(TextLoggerConfig config)
        {
            if (null != config)
            {
                filePath = config.FilePath;
            }
        }
        /// <summary>
        /// Logs the specified exception type error
        /// </summary>
        /// <param name="exception">Generated exception to log</param>
        public void LogException(Exception exception)
        {
            WriteText(LoggingDetails.GetFormattedExceptionString(exception));
        }
        /// <summary>
        /// Logs the specified information type error
        /// </summary>
        /// <param name="message">Message received to log an error</param>
        public void LogInformation(string message)
        {
            WriteText(string.Concat(CultureInfo.InvariantCulture, Constants.LOG_LEVEL_INFO,Constants.SPACE, message));
        }
        /// <summary>
        /// Logs the specified warning type error
        /// </summary>
        /// <param name="message">Message received to log an error</param>
        public void LogWarning(string message)
        {
            WriteText(string.Concat(CultureInfo.InvariantCulture, Constants.LOG_LEVEL_WARNING, Constants.SPACE, message));
        }
        /// <summary>
        /// Function is used to add the message to a log file
        /// </summary>
        /// <param name="errorMessage">String error message</param>        
        private void WriteText(string errorMessage)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    using (StreamWriter outputFile = new StreamWriter(filePath, true))
                    {
                        outputFile.WriteLine(string.Concat(Constants.OPENING_SQUARE_BRACKET, DateTime.Now, Constants.CLOSING_SQUARE_BRACKET, Constants.COLON, errorMessage));
                        outputFile.Flush();
                    }
                }
            }
            catch(Exception)
            {
                throw; //throw to parent function
            }
        }
    }
}
