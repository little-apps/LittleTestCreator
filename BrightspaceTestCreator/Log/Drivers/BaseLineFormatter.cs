using System;

namespace BrightspaceTestCreator.Log.Drivers
{
    public abstract class BaseLineFormatter
    {
        public const string LevelError = "Error";
        public const string LevelWarning = "Warning";
        public const string LevelSuccess = "Success";
        public const string LevelInfo = "Info";

        protected string DateTimeFormatted
        {
            get => DateTime.Now.ToShortTimeString();
        }

        protected string FormatLine(string type, string message)
        {
            return $"[{DateTimeFormatted}] [{type}] {message}";
        }
    }
}
