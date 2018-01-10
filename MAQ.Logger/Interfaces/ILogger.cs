#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Interface created for Logger
// Change History:
// Name                      Date                       Version        Description
// ---------------------------------------------------------------------------------------------------------------------------------
// Swapnil M               January 20, 2017           1.0.0.0        Class used to log all the errors occurred during runtime
// ---------------------------------------------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// ---------------------------------------------------------------------------------------------------------------------------------
#endregion
namespace Logger
{

    #region using
    using System;
    #endregion
    /// <summary>
    /// Interface containing declaration of Logging methods
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Writes the log message for specified exception
        /// </summary>
        /// <param name="exception">Exception object</param>
        void LogException(Exception exception);
        /// <summary>
        /// Logs the specified exception.
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void LogInformation(string message);
        /// <summary>
        /// Logs the specified information
        /// </summary>
        /// <param name="message">Message to be logged</param>
        void LogWarning(string message);
    }
}
