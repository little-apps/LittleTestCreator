using System;
using System.IO;
using System.Linq;
using BrightspaceTestCreator.Factories;
using BrightspaceTestCreator.Log;
using BrightspaceTestCreator.Log.Drivers;
using CommandLine;

namespace BrightspaceTestCreator
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .WithParsed(o =>
                {
                    AddLogDrivers(o);

                    if (ValidateParsed(o))
                        RunWithParsed(o);
                });

            Logger.Close();
        }

        private static void AddLogDrivers(Options options)
        {
            if (!string.IsNullOrEmpty(options.LogFile))
                Logger.AddDriver(new FileDriver(options.LogFile));
            else
                Logger.AddDriver(new ConsoleDriver());;
        }

        private static bool ValidateParsed(Options options)
        {
            if (!File.Exists(options.SourceFile))
            {
                Logger.Log(Logger.Type.Error, $"Source file {options.SourceFile} does not exist.");
                return false;
            }

            return true;
        }

        private static void RunWithParsed(Options options)
        {
            try
            {
                var converter = ConverterFactory.Build(options.SourceFile);
                var stream = converter.Convert();

                var formatter = OutputFormatterFactory.Build(options);

                var questionsFactory = new QuestionsFactory(stream);

                var questions = questionsFactory.Build().ToList();
                formatter.Format(questions);

                Logger.Log(Logger.Type.Success,$"Generated file at '{options.DestFile}' with {questions.Count}/{questionsFactory.TotalPossibleQuestions} questions.");

            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Type.Error, ex.Message);
            }
            
        }
    }
}
