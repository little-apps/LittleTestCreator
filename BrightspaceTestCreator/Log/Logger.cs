using System;
using System.Collections.Generic;
using BrightspaceTestCreator.Interfaces;

namespace BrightspaceTestCreator.Log
{
    internal static class Logger
    {
        private static readonly List<ILogDriver> _logDrivers = new List<ILogDriver>();

        public static void AddDriver(ILogDriver driver)
        {
            _logDrivers.Add(driver);
        }

        public static void Log(Type type, string message)
        {
            foreach (var logDriver in _logDrivers)
            {
                switch (type)
                {
                    case Type.Warning:
                        logDriver.Warning(message);
                        break;
                    case Type.Error:
                        logDriver.Error(message);
                        break;
                    case Type.Success:
                        logDriver.Success(message);
                        break;
                    case Type.Info:
                        logDriver.Info(message);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(type), type, null);
                }
            }
        }

        public static void Close()
        {
            foreach (var logDriver in _logDrivers)
            {
                if (logDriver is IDisposable logDriverDisposable)
                    logDriverDisposable.Dispose();
            }
        }

        internal enum Type
        {
            Warning,
            Error,
            Success,
            Info
        }

        
    }
}
