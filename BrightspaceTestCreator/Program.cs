using System.IO;
using System.Linq;
using BrightspaceTestCreator.Factories;
using BrightspaceTestCreator.Formatters;
using BrightspaceTestCreator.Log;
using CommandLine;

namespace BrightspaceTestCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    var logger = LoggerFactory.Build(o);

                    if (ValidateParsed(o, logger))
                        RunWithParsed(o, logger);
                });
        }

        private static bool ValidateParsed(Options options, Logger logger)
        {
            if (!File.Exists(options.SourceFile))
            {
                logger.Log(Logger.Type.Error, $"Source file {options.SourceFile} does not exist.");
                return false;
            }

            return true;
        }

        private static void RunWithParsed(Options options, Logger logger)
        {
            var parser = ParserFactory.Build(options.SourceFile);
            var stream = parser.Parse();

            var csvFormatter = new CsvFormatter( options.DestFile, options.CourseCode);
            var questionsFactory = new QuestionsFactory(stream);

            var questions = questionsFactory.Build().ToList();
            csvFormatter.Format(questions);

            logger.Log(Logger.Type.Success,$"Generated file at '{options.DestFile}' with {questions.Count}/{questionsFactory.TotalPossibleQuestions} questions.");

        }
    }
}
