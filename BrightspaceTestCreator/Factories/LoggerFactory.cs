using System.Collections.Generic;
using BrightspaceTestCreator.Log;
using BrightspaceTestCreator.Log.Drivers;

namespace BrightspaceTestCreator.Factories
{
    internal static class LoggerFactory
    {
        public static Logger Build(Options options)
        {
            var drivers = new List<ILogDriver>();

            if (!string.IsNullOrEmpty(options.LogFile))
                drivers.Add(new FileDriver(options.LogFile));
            else
                drivers.Add(new ConsoleDriver());

            return new Logger(drivers);
        }
    }
}
