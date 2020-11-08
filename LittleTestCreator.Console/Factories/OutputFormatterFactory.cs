using System;
using System.Globalization;
using System.IO;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.OutputFormatter.Brightspace;

namespace LittleTestCreator.Console.Factories
{
    internal static class OutputFormatterFactory
    {
        /// <summary>
        /// Builds <seealso cref="IOutputFormatter"/> from options to create output.
        /// </summary>
        /// <param name="options"><seealso cref="Options"/> instance.</param>
        /// <returns>Instance of <seealso cref="IOutputFormatter"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if output file is not specified.</exception>\
        /// <exception cref="ArgumentException">Thrown if unable to determine output formatter.</exception>
        public static IOutputFormatter Build(Options options)
        {
            var outputFile = options.DestFile;

            if (outputFile == null)
                throw new ArgumentNullException(nameof(outputFile));

            var fileExt = Path.GetExtension(outputFile).ToLower(CultureInfo.InvariantCulture);

            switch (fileExt)
            {
                case ".csv":
                    return new Formatter(outputFile);
                default:
                    throw new ArgumentException($"Unknown output file extension: {fileExt}");
            }
        }
    }
}
