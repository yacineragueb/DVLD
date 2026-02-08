using System;
using System.Diagnostics;

namespace DVLDAccessLayer
{
    internal class Logger
    {
        private static readonly string SourceName = "DVLD";

        public static void LogError(Exception ex, string context = "")
        {
            EventLog.WriteEntry(
                SourceName,
                $"{context}\n{ex}",
                EventLogEntryType.Error);
        }
    }
}
