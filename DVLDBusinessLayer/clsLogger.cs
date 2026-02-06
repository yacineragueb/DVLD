using System;
using System.Diagnostics;

namespace DVLDBusinessLayer
{
    public class clsLogger
    {
        private static readonly string SourceName = "DVLD";

        public static void Initialize()
        {
            if (!EventLog.SourceExists(SourceName))
            {
                EventLog.CreateEventSource(SourceName, "Application");
            }
        }

        public static void LogError(Exception ex, string context = "")
        {
            EventLog.WriteEntry(
                SourceName,
                $"{context}\n{ex}",
                EventLogEntryType.Error);
        }
    }
}
