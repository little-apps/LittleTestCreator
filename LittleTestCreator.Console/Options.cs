using System.IO;
using CommandLine;
using LittleTestCreator.Console.Exceptions;

namespace LittleTestCreator.Console
{
    /// <summary>
    /// Contains parsed options from command line arguments.
    /// </summary>
    internal class Options
    {
        [Value(0, HelpText = "Source document", Required = true)]
        public string SourceFile { get; set; }

        [Value(1, HelpText = "Destination CSV file", Required = true)]
        public string DestFile { get; set; }

        [Option('o', "output", HelpText = "Where to send log output. Sends to console if not specified (default).")]
        public string LogFile { get; set; }

        [Option('f', "format", HelpText = "Format of input file.", Default = InputFormats.OsConcepts)]
        public InputFormats InputFormat { get; set; }

        [Option("skip-page-breaks", Default = 0, HelpText = "Number of page breaks to skip before reading questions. (Only if Kitty format is used.)")]
        public int SkipPageBreaks { get; set; }

        /// <summary>
        /// Performs additional validation to options.
        /// </summary>
        /// <exception cref="InvalidOptionException">Thrown if option is invalid.</exception>
        public void Validate()
        {
            SourceFile = Path.GetFullPath(SourceFile);

            if (!File.Exists(SourceFile))
            {
                throw new InvalidOptionException($"Source file \"{SourceFile}\" does not exist.", nameof(SourceFile));
            }
        }

        public enum InputFormats
        {
            OsConcepts,
            Kitty,
            Kahoot
        }
    }
}
