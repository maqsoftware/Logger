# Logger

Logger library simplifies application execution logging at a target location. The target location can be a Text file, Windows Event Log or Azure Table storage. The library can be integrated in a .NET application.

# How to use

To use the library, add reference to Logger DLL and include Logger namespace in the code. 

The logging methods use custom config objects as a part of the DLL, which make the methods easily configurable. Pass this config object to construct and retrieve Azure table storage, Event Viewer and Text file logging objects.

To log the information, we can call any of the 3 methods based on type of information logged:

1. loggerObject.LogInformation
1. loggerObject.LogWarning
1. loggerObject.LogException

### Dependency

To use Azure Table storage logging, install following NuGet packages:

1. WindowsAzure.Storage version="7.2.1"
1. Microsoft.Azure.KeyVault.Core version="1.0.0"
1. Microsoft.Data.Edm version="5.6.4"
1. Microsoft.Data.OData version="5.6.4"
1. Microsoft.Data.Services.Client version="5.6.4"


# Text Logging

This target allows to write log information into a text file. The log is recorded with timestamp prefixed and type of the information logged (Info, Warning or Exception).
To initialize a text logger, we should specify the text file path along with extension.

```
ILogger loggerDetails = InitializeLogger.GetTextLogger(new TextLoggerConfig("c:/Logger.txt"));
```


# Event Logging

This target allows to log details into Windows Event Log. To Initialize the event logger, an application needs to execute with administrative privileges.

To initialize the event logger, we should specify the event source, event log and event id.

```
ILogger loggerDetails = InitializeLogger.GetEventLogger(new EventLoggerConfig ("Application", "MAQWebServiceError", 101));
```

# Azure Storage Logging

Logs can be added into Azure Table storage. A storage connection string is required to connect with Azure and storage table name where information is to be logged.

To initialize the Azure logger, we should specify the storage connection string and table storage name.

```
ILogger loggerDetails = InitializeLogger.GetAzureLogger(new AzureTableStorageLoggerConfig ("DefaultEndpointsProtocol=https;
AccountName=;AccountKey= ", "table_name")); 
```
