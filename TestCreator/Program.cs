using System;
using System.Linq;
using CommandLine;
using TestCreator.Exceptions;
using TestCreator.Factories;
using TestCreator.Log;
using TestCreator.Log.Drivers;

namespace TestCreator
{
    internal static class Program
    {
        /// <summary>
        /// Entry point to program.
        /// </summary>
        /// <param name="args">Arguments passed in command line.</param>
        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Options>(args)
                .MapResult(o =>
                {
                    AddLogDrivers(o);

                    try
                    {
                        o.Validate();

                        return RunWithParsed(o);
                    }
                    catch (InvalidOptionException ex)
                    {
                        Logger.Log(Logger.Type.Error, ex.Message);
                        return 1;
                    }
                },
                    _ => 1);

            Logger.Close();
        }

        /// <summary>
        /// Adds log drivers to Logger
        /// </summary>
        /// <param name="options">Program run options.</param>
        private static void AddLogDrivers(Options options)
        {
            if (!string.IsNullOrEmpty(options.LogFile))
                Logger.AddDriver(new FileDriver(options.LogFile));
            else
                Logger.AddDriver(new ConsoleDriver());;
        }

        /// <summary>
        /// Performs program execution with valid options.
        /// </summary>
        /// <param name="options">Program run options</param>
        private static int RunWithParsed(Options options)
        {
            try
            {
                var converter = InputConverterFactory.Build(options.SourceFile);
                var stream = converter.Convert();

                var formatter = OutputFormatterFactory.Build(options);

                var questionsFactory = new QuestionsFactory(stream);

                var questions = questionsFactory.Build().ToList();
                formatter.Format(questions);

                Logger.Log(Logger.Type.Success,$"Generated file at '{options.DestFile}' with {questions.Count}/{questionsFactory.TotalPossibleQuestions} questions.");

                return 0;
            }
            catch (Exception ex)
            {
                Logger.Log(Logger.Type.Error, ex.Message);

                return 1;
            }
            
        }
    }
}
