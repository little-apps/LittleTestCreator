using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using LittleTestCreator.OutputFormatter.Brightspace.Contracts;
using LittleTestCreator.OutputFormatter.Brightspace.OutputFormatters;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Questions;
using LittleTestCreator.Shared.Questions.MultipleChoice;
using LittleTestCreator.Shared.Questions.ShortAnswer;
using LittleTestCreator.Shared.Questions.WrittenResponse;

namespace LittleTestCreator.OutputFormatter.Brightspace
{
    public class Formatter : IOutputFormatter
    {
        public string CsvFile { get; }

        private IOutputFormatter<MultipleChoiceQuestion> MultipleChoiceFormatter { get; }
        private IOutputFormatter<TrueFalseQuestion> TrueFalseFormatter { get; }
        private IOutputFormatter<WrittenResponseQuestion> WrittenResponseFormatter { get; }
        private IOutputFormatter<ShortAnswerQuestion> ShortAnswerFormatter { get; }

        /// <summary>
        /// Constructor for Brightspace Formatter
        /// </summary>
        /// <param name="csvFile">File path for where to save CSV file.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="csvFile"/> is null, empty, or whitespace.</exception>
        public Formatter(string csvFile)
        {
            if (string.IsNullOrWhiteSpace(csvFile))
                throw new ArgumentException("CSV file path cannot be null, empty or whitespace.", nameof(csvFile));

            CsvFile = csvFile;

            MultipleChoiceFormatter = new MultipleChoiceFormatter();
            TrueFalseFormatter = new TrueFalseFormatter();
            WrittenResponseFormatter = new WrittenResponseFormatter();
            ShortAnswerFormatter = new ShortAnswerFormatter();
        }

        public void Format(IEnumerable<IQuestion> questions)
        {
            using (var fs = new StreamWriter(CsvFile))
            {
                using (var csvWriter = new CsvWriter(fs, CultureInfo.InvariantCulture))
                {
                    foreach (var question in questions.OrderBy((q) => q.Number))
                    {

                        switch (question)
                        {
                            case MultipleChoiceQuestion mcQuestion:
                                MultipleChoiceFormatter.Format(csvWriter, mcQuestion);
                                break;
                            case TrueFalseQuestion trueFalseQuestion:
                                TrueFalseFormatter.Format(csvWriter, trueFalseQuestion);
                                break;
                            case WrittenResponseQuestion writtenResponseQuestion:
                                WrittenResponseFormatter.Format(csvWriter, writtenResponseQuestion);
                                break;
                            case ShortAnswerQuestion shortAnswerQuestion:
                                ShortAnswerFormatter.Format(csvWriter, shortAnswerQuestion);
                                break;
                        }
                    }
                }

            }
        }
    }
}
