using System;
using LittleTestCreator.OutputFormatter.Brightspace;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.GUI.Factories
{
    internal static class OutputFormatterFactory
    {
        /// <summary>
        /// Builds <seealso cref="IOutputFormatter"/> from options to create output.
        /// </summary>
        /// <param name="viewModel"><seealso cref="ViewModel"/> instance.</param>
        /// <returns>Instance of <seealso cref="IOutputFormatter"/></returns>
        /// <exception cref="ArgumentNullException">Thrown if output file is not specified.</exception>\
        /// <exception cref="ArgumentException">Thrown if unable to determine output formatter.</exception>
        public static IOutputFormatter Build(ViewModel viewModel)
        {
            var outputFile = viewModel.DestinationFile;

            if (outputFile == null)
                throw new ArgumentNullException(nameof(outputFile));

            var outputFormat = (Models.OutputFormatter) viewModel.Outputs.CurrentItem;

            switch (outputFormat.Name)
            {
                case Models.OutputFormatter.Brightspace:
                    return new Formatter(outputFile);
                default:
                    throw new ArgumentException($"Unknown output format: {outputFormat}");
            }
        }
    }
}
