using System;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Log
{
    public static class Logger
    {
        public static ILogDriver Driver { get; set; }

        /// <summary>
        /// Sends log message through drivers.
        /// </summary>
        /// <param name="type">Type of message.</param>
        /// <param name="message">Message.</param>
        public static void Log(Type type, string message)
        {
            if (Driver == null)
                return;

            switch (type)
            {
                case Type.Warning:
                    Driver.Warning(message);
                    break;
                case Type.Error:
                    Driver.Error(message);
                    break;
                case Type.Success:
                    Driver.Success(message);
                    break;
                case Type.Info:
                    Driver.Info(message);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        /// <summary>
        /// Close and disposes log drivers.
        /// </summary>
        public static void Close()
        {
            if (Driver is IDisposable logDriverDisposable)
                logDriverDisposable.Dispose();
        }

        public enum Type
        {
            Warning,
            Error,
            Success,
            Info
        }

        
    }
}
