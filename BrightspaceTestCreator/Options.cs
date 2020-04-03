using CommandLine;

namespace BrightspaceTestCreator
{
    internal class Options
    {
        [Value(0, HelpText = "Source document")]
        public string SourceFile { get; set; }

        [Value(1, HelpText = "Destination CSV file")]
        public string DestFile { get; set; }

        [Option("code", HelpText = "Course code to use for question IDs.")]
        public string CourseCode { get; set; }

        [Option('o', "output", HelpText = "Where to send output. Sends to console if not specified (default).")]
        public string LogFile { get; set; }
    }
}
