using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Log.Drivers;
using SystemConsole = System.Console;

namespace LittleTestCreator.Console.LogDrivers
{
    public class ConsoleDriver : BaseLineFormatter, ILogDriver
    {
        public void Warning(string message)
        {
            var line = FormatLine(LevelWarning, message);
            SystemConsole.WriteLine(line);
        }

        public void Info(string message)
        {
            var line = FormatLine(LevelInfo, message);
            SystemConsole.WriteLine(line);
        }

        public void Success(string message)
        {
            var line = FormatLine(LevelSuccess, message);
            SystemConsole.WriteLine(line);
        }

        public void Error(string message)
        {
            var line = FormatLine(LevelError, message);
            SystemConsole.WriteLine(line);
        }
    }
}
