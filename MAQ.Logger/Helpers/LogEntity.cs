#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Class used to add an extra field for Azure Logging
// Change History:
// Name                      Date                       Version        Description
// -------------------------------------------------------------------------------------------------------
// Swapnil M               January 20, 2017           1.0.0.0        Azure Logging for Error Message
// -------------------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------------------------------
#endregion

namespace Logger
{
    #region using
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    #endregion
    /// <summary>
    /// Wrapper class for log messages
    /// </summary>
    [CLSCompliant(false)]

    public class LogEntity : TableEntity
    {
        /// <summary>
        /// Gets or sets the log message.
        /// </summary>
        /// <value>
        /// The log message.
        /// </value>
        public string LogMessage { get; set; }
    }
}
