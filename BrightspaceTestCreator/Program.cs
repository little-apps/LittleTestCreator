﻿using System.IO;
using System.Linq;
using BrightspaceTestCreator.Factories;
using BrightspaceTestCreator.Formatters;
using BrightspaceTestCreator.Log;
using BrightspaceTestCreator.Log.Drivers;
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
                    AddLogDrivers(o);

                    if (ValidateParsed(o, logger))
                        RunWithParsed(o, logger);
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
            var parser = ParserFactory.Build(options.SourceFile);
            var stream = parser.Parse();

            var csvFormatter = new CsvFormatter( options.DestFile, options.CourseCode);
            var questionsFactory = new QuestionsFactory(stream);

            var questions = questionsFactory.Build().ToList();
            csvFormatter.Format(questions);

                Logger.Log(Logger.Type.Success,$"Generated file at '{options.DestFile}' with {questions.Count}/{questionsFactory.TotalPossibleQuestions} questions.");

        }
    }
}
