using System;
using System.IO;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Log.Drivers;

namespace LittleTestCreator.Console.LogDrivers
{
    public class FileDriver : BaseLineFormatter, ILogDriver, IDisposable
    {
        private readonly TextWriter _textWriter;

        public FileDriver(string logFile)
        {
            _textWriter = new StreamWriter(logFile, true);
        }

        public void Warning(string message)
        {
            var line = FormatLine(LevelWarning, message);
            _textWriter.WriteLine(line);
        }

        public void Info(string message)
        {
            var line = FormatLine(LevelInfo, message);
            _textWriter.WriteLine(line);
        }

        public void Success(string message)
        {
            var line = FormatLine(LevelSuccess, message);
            _textWriter.WriteLine(line);
        }

        public void Error(string message)
        {
            var line = FormatLine(LevelError, message);
            _textWriter.WriteLine(line);
        }

        public void Dispose()
        {
            _textWriter?.Dispose();
        }
    }
}
