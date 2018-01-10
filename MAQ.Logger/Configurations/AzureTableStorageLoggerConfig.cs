#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Class used to configure values for Azure Logging 
// Change History:
// Name                      Date                       Version       Description
// ---------------------------------------------------------------------------------------------------
// Swapnil M               January 20, 2017           1.0.0.0       Configuration for Azure Logger
// ---------------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// ---------------------------------------------------------------------------------------------------
#endregion

namespace Logger
{
    /// <summary>
    /// Class used to set configurable properties for Azure Logging at run time
    /// </summary>
    public class AzureTableStorageLoggerConfig
    {
        /// <summary>
        /// Gets or sets the Azure connection string
        /// </summary>
        public string AzureConnection { get; set; }

        /// <summary>
        /// Gets or sets the error log table reference
        /// </summary>
        public string ErrorLogTable { get; set; }

        /// <summary>
        /// Constructor used to set configurable properties for Azure Logging at run time
        /// </summary>
        /// <param name="connection">Azure connection string</param>
        /// <param name="logTable">Azure log table name</param>
        public AzureTableStorageLoggerConfig(string connection, string logTable)
        {
            AzureConnection = connection;
            ErrorLogTable = logTable;
        }
    }
}
