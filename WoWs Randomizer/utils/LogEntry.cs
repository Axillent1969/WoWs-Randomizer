using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WoWs_Randomizer.utils.enums.LogLevels;

namespace WoWs_Randomizer.utils
{
    [Serializable]
    public class LogEntry
    {
        private DateTime timestamp = DateTime.Now;
        private string logtext = "";
        private LogLevel logLevel = LogLevel.INFO;
        private Exception ex = null;

        public LogEntry() { }
        public LogEntry(string text)
        {
            this.logtext = text;
        }
        public LogEntry(string text, LogLevel logLevel)
        {
            this.logtext = text;
            this.logLevel = logLevel;
        }

        public LogEntry(string text, LogLevel logLevel, Exception e)
        {
            this.logtext = text;
            this.logLevel = logLevel;
            this.ex = e;
        }

        public void SetLogLevel(LogLevel logLevel) { this.logLevel = logLevel; }
        public void SetText(string text) { this.logtext = text; }
        public void SetException(Exception ex) { this.ex = ex; }
        public string GetLogText() { return this.logtext; }
        public LogLevel GetLogLevel() { return this.logLevel; }
        public DateTime GetTimestamp() { return this.timestamp; }
        public Exception GetException() { return this.ex; }

        public override string ToString()
        {
            string dt = "[" + this.timestamp.ToString("o", CultureInfo.CreateSpecificCulture("sv-SE")) + "] "; 
            string lvl = this.logLevel.ToString();
            if ( this.ex != null)
            {
                return dt + lvl + " " + this.logtext + " (" + ex.Message + ")";
            }
            return dt + lvl + " " + this.logtext;
        }

    }
}
