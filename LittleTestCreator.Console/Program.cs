using System;
using System.Linq;
using CommandLine;
using LittleTestCreator.Console.Exceptions;
using LittleTestCreator.Console.Factories;
using LittleTestCreator.Shared.Log;
using ConsoleDriver = LittleTestCreator.Console.LogDrivers.ConsoleDriver;
using FileDriver = LittleTestCreator.Console.LogDrivers.FileDriver;

namespace LittleTestCreator.Console
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
                Logger.Driver = new FileDriver(options.LogFile);
            else
                Logger.Driver = new ConsoleDriver();

        }

        /// <summary>
        /// Performs program execution with valid options.
        /// </summary>
        /// <param name="options">Program run options</param>
        private static int RunWithParsed(Options options)
        {
            try
            {
                var converter = InputConverterFactory.Build(options);
                var questions = converter.Convert();

                var formatter = OutputFormatterFactory.Build(options);
                formatter.Format(questions);

                Logger.Log(Logger.Type.Success, $"Generated file at '{options.DestFile}' with {questions.Count()} questions.");

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
