#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Class for logging in Azure table
// Change History:
// Name                      Date                       Version        Description
// --------------------------------------------------------------------------------------------------
// Swapnil M               January 20, 2017           1.0.0.0        Class to log in Azure table
// --------------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// --------------------------------------------------------------------------------------------------
#endregion
namespace Logger
{
    #region using
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Table;
    using System;
    using System.Globalization;
    #endregion
    /// <summary>
    /// Class used for Azure Logging 
    /// </summary>
    public class AzureTableStorageLogger : ILogger
    {
        private readonly string azureConnectionString;
        private CloudStorageAccount storageAccount;
        private CloudTableClient client;
        private readonly CloudTable table;
        private readonly TimeZoneInfo timeZone;
        private readonly DateTime dateTime;
        /// <summary>
        /// Constructor to initialize configurable properties
        /// </summary>
        /// <param name="config">Configuration details</param>
        public AzureTableStorageLogger(AzureTableStorageLoggerConfig config)
        {
            if (null != config)
            {
                azureConnectionString = config.AzureConnection;
                storageAccount = CloudStorageAccount.Parse(azureConnectionString);
                client = storageAccount.CreateCloudTableClient();
                table = client.GetTableReference(config.ErrorLogTable);
                timeZone = TimeZoneInfo.FindSystemTimeZoneById(TimeZone.CurrentTimeZone.StandardName);
                dateTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, timeZone);
            }
        }
        /// <summary>
        /// Logs the specified exception type error
        /// </summary>
        /// <param name="exception">Exception received to log an error</param>
        public void LogException(Exception exception)
        {
            LoggerTypeException(LoggingDetails.GetFormattedExceptionString(exception), Constants.LOG_LEVEL_ERROR);
        }
        /// <summary>
        /// Logs the specified information type error
        /// </summary>
        /// <param name="message">Message received to log an error</param> 
        public void LogInformation(string message)
        {
            LoggerTypeException(message, Constants.LOG_LEVEL_INFO);
        }
        /// <summary>
        /// Logs the specified warning type error
        /// </summary>
        /// <param name="message">Message received to log an error</param>
        public void LogWarning(string message)
        {
            LoggerTypeException(message, Constants.LOG_LEVEL_WARNING);
        }
        /// <summary>
        /// Method logs error message to table or event viewer
        /// </summary>
        /// <param name="errorMessage">Error message to be logged</param>
        /// <param name="type">Event type of an Error</param>
        private void LoggerTypeException(string errorMessage, string type)
        {
            try
            {
                table.CreateIfNotExists();
                LogEntity tableEntityObj = new LogEntity();
                tableEntityObj.PartitionKey = type;
                string guid = Convert.ToString(Guid.NewGuid(), CultureInfo.InvariantCulture);
                guid = guid.Substring(0, 5);
                tableEntityObj.RowKey = string.Format(CultureInfo.InvariantCulture, Constants.PLACE_HOLDER, dateTime.ToString(Constants.AZURE_ROW_DATE_KEY_FORMAT, CultureInfo.InvariantCulture), guid);
                tableEntityObj.LogMessage = errorMessage;
                TableOperation insertOp = TableOperation.Insert(tableEntityObj);
                table.Execute(insertOp);
            }
            catch
            {
                throw;
                // Do nothing here. Throw to parent
                // Justification = Cannot Log exception for a Logger file
            }
            finally
            {
                // Garbage collector
                storageAccount = null;
                client = null;
            }
        }
    }
}