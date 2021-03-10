using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static WoWs_Randomizer.utils.enums.LogLevels;

namespace WoWs_Randomizer.utils
{
    class LogHandler
    {
        private string name = "";
        private LogLevel level = LogLevel.WARNING;
        private List<LogEntry> logEntries = new List<LogEntry>();
        private List<LogEntry> flushedEntries = new List<LogEntry>();
        private bool autoDeleteOnFirstFlush = true;

        public LogHandler(string LogName)
        {
            this.name = LogName;
        }

        public override string ToString()
        {
            return "LogHandler: " + this.name + " (" + base.ToString() + ") @ " + this.level.ToString();
        }

        public void SetAutoDeleteOnFirstFlush(bool state)
        {
            this.autoDeleteOnFirstFlush = state;
        }
        public bool GetAutoDeleteOnFirstFlushState() { return this.autoDeleteOnFirstFlush; }

        public void DeleteLogFromDisk()
        {
            string fileName = Commons.GetLogFileName("txt");
            if ( File.Exists(fileName))
            {
                this.Debug("Deleted '" + fileName + "'");
                File.Delete(fileName);
            } else
            {
                this.Debug("File not found: '" + fileName + "'");
            }
        }

        public void Flush(bool complete = false)
        {
            _ = WriteToDisk(!this.autoDeleteOnFirstFlush);
            this.autoDeleteOnFirstFlush = false;
            flushedEntries.AddRange(logEntries);
            logEntries.Clear();
            if ( complete )
            {
                string fileName = Commons.GetLogFileName();
                BinarySerialize.WriteToBinaryFile<List<LogEntry>>(fileName, flushedEntries);
            }
        }

        private async Task WriteToDisk(bool append)
        {
            string fileName = Commons.GetLogFileName("txt");
            string log = "";
            bool isFirst = true;
            foreach(LogEntry entry in this.logEntries)
            {
                if ( !isFirst ) { log += "\n"; }
                log += entry.ToString();
                isFirst = false;
            }
            using (StreamWriter file = new StreamWriter(fileName, append: append))
            {
                await file.WriteLineAsync(log);
            }
        }

        public void Log(LogEntry log)
        {
            this.logEntries.Add(log);
        }

        public void Log(string text)
        {
            LogEntry entry = new LogEntry(text, this.level);
            this.logEntries.Add(entry);
        }

        public void Log(string text, LogLevel logLevel)
        {
            LogEntry entry = new LogEntry(text, logLevel);
            this.logEntries.Add(entry);
        }

        public void Debug(string text)
        {
            LogEntry entry = new LogEntry(text, LogLevel.DEBUG);
            AddEntry(entry);
        }

        public void Info(string text)
        {
            LogEntry entry = new LogEntry(text, LogLevel.INFO);
            AddEntry(entry);
        }

        public void Warning(string text)
        {
            LogEntry entry = new LogEntry(text, LogLevel.WARNING);
            AddEntry(entry);
        }

        public void Warning(string text, Exception e)
        {
            LogEntry entry = new LogEntry(text, LogLevel.WARNING, e);
            AddEntry(entry);
        }

        public void Error(string text)
        {
            LogEntry entry = new LogEntry(text, LogLevel.ERROR);
            AddEntry(entry);
        }
        public void Error(string text, Exception e)
        {
            LogEntry entry = new LogEntry(text, LogLevel.ERROR, e);
            AddEntry(entry);
        }

        public void SetLogLevel(LogLevel loggingLevel)
        {
            this.level = loggingLevel;
        }

        public LogLevel GetLogLevel() { return this.level; }

        private void AddEntry(LogEntry entry)
        {
            if ( (int)this.level == 99 || (int)this.level <= (int)entry.GetLogLevel())
            {
                this.logEntries.Add(entry);
            }
        }
    }
}
