﻿using System;
using System.Globalization;
using System.IO;
using TestCreator.Interfaces;
using TestCreator.OutputFormatters;

namespace TestCreator.Factories
{
    internal static class OutputFormatterFactory
    {
        public static IOutputFormatter Build(Options options)
        {
            var outputFile = options.DestFile;

            if (outputFile == null)
                throw new ArgumentNullException(nameof(outputFile));

            var fileExt = Path.GetExtension(outputFile).ToLower(CultureInfo.InvariantCulture);

            switch (fileExt)
            {
                case ".csv":
                    return new CsvFormatter(outputFile);
                default:
                    throw new ArgumentException($"Unknown output file extension: {fileExt}");
            }
        }
    }
}