#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Factory class implemented to wrap the Logger Interface
// Change History:
// Name                      Date                       Version        Description
// -----------------------------------------------------------------------------------------------------------------------------
// Swapnil M               January 20, 2017           1.0.0.0        Factory class implemented to wrap the Logger Interface
// -----------------------------------------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -----------------------------------------------------------------------------------------------------------------------------
#endregion
/*MIT License

Copyright(c) 2017 MAQ Software

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.*/

namespace Logger
{
    /// <summary>
    /// Wrapper class for Logger
    /// </summary>
    public static class InitializeLogger
    {
        /// <summary>
        /// Gets the data for Azure logger
        /// </summary>
        /// <param name="config">Configuration properties for Azure Logger</param>
        /// <returns>Logs the data/error in Azure table storage</returns>
        /// 
        public static ILogger GetAzureLogger(AzureTableStorageLoggerConfig config)
        {
            return new AzureTableStorageLogger(config);
        }
        /// <summary>
        /// Gets the data for Event logger
        /// </summary>
        /// <param name="config">Configuration properties for Event Logger</param>
        /// <returns>Logs the error in Event logger</returns>
        /// 
        public static ILogger GetEventLogger(EventLoggerConfig config)
        {
            using (EventLogger eventLoggerObj = new EventLogger(config))
            {
                return eventLoggerObj;
            }
        }
        /// <summary>
        /// Gets Data for text Logger Configuration
        /// </summary>
        /// <param name="config">Configuration properties for Text Logger</param>
        /// <returns>Logs the error in text file</returns>
        public static ILogger GetTextLogger(TextLoggerConfig config)
        {
            return new TextLogger(config);
        }
    }
}