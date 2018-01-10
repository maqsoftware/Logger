#region PageSummary
// *****************************************************************
// Project:        Logger
// Solution:       Logger
//
// Author:  MAQ Software
// Date:    January 20, 2017
// Description: Class used to configure values for Text Logging
// Change History:
// Name                      Date                       Version      Description
// -------------------------------------------------------------------------------------------------
// Swapnil M               January 20, 2017           1.0.0.0      Configuration for Text Logger
// -------------------------------------------------------------------------------------------------
// Copyright (C) MAQ Software
// -------------------------------------------------------------------------------------------------
#endregion
namespace Logger
{
    /// <summary>
    /// Class used to set configurable properties for Event Logging at run time
    /// </summary>
    public class TextLoggerConfig
    {
        /// <summary>
        /// Gets or sets the file path
        /// </summary>
        public string FilePath { get; set; }
        /// <summary>
        /// Constructor used to set configurable properties for Event Logging at run time
        /// </summary>
        /// <param name="filePath">Specify where log file needs to be saved</param>
        public TextLoggerConfig(string filePath)
        {
            FilePath = filePath;
        }
    }
}
