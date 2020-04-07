using System;
using TestCreator.Interfaces;

namespace TestCreator.Log.Drivers
{
    internal class ConsoleDriver : BaseLineFormatter, ILogDriver
    {
        public void Warning(string message)
        {
            var line = FormatLine(LevelWarning, message);
            Console.WriteLine(line);
        }

        public void Info(string message)
        {
            var line = FormatLine(LevelInfo, message);
            Console.WriteLine(line);
        }

        public void Success(string message)
        {
            var line = FormatLine(LevelSuccess, message);
            Console.WriteLine(line);
        }

        public void Error(string message)
        {
            var line = FormatLine(LevelError, message);
            Console.WriteLine(line);
        }
    }
}
