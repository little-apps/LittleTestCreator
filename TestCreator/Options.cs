using System.IO;
using CommandLine;
using TestCreator.Exceptions;

namespace TestCreator
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

        [Option("code", HelpText = "Course code to use for question IDs.")]
        public string CourseCode { get; set; }

        [Option('o', "output", HelpText = "Where to send output. Sends to console if not specified (default).")]
        public string LogFile { get; set; }

        /// <summary>
        /// Performs additional validation to options.
        /// </summary>
        /// <exception cref="InvalidOptionException">Thrown if option is invalid.</exception>
        public void Validate()
        {
            if (!File.Exists(SourceFile))
            {
                throw new InvalidOptionException($"Source file \"{SourceFile}\" does not exist.", nameof(SourceFile));
            }
        }
    }
}
