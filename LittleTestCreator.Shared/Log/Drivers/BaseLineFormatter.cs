using System;

namespace LittleTestCreator.Shared.Log.Drivers
{
    /// <summary>
    /// Generates lines using message.
    /// </summary>
    public abstract class BaseLineFormatter
    {
        public const string LevelError = "Error";
        public const string LevelWarning = "Warning";
        public const string LevelSuccess = "Success";
        public const string LevelInfo = "Info";

        /// <summary>
        /// Formats the date/time for the line.
        /// </summary>
        protected string DateTimeFormatted
        {
            get => DateTime.Now.ToShortTimeString();
        }

        /// <summary>
        /// Formats the line.
        /// </summary>
        /// <param name="type">Type of message.</param>
        /// <param name="message">Message.</param>
        /// <returns>Message in the format "[Date/time] [Type] Message"</returns>
        protected string FormatLine(string type, string message)
        {
            return $"[{DateTimeFormatted}] [{type}] {message}";
        }
    }
}
