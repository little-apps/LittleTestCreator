using CsvHelper;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.OutputFormatter.Brightspace.Contracts
{
    internal interface IOutputFormatter<in T> where T : IQuestion
    {
        /// <summary>
        /// Formats question to CSV format.
        /// </summary>
        /// <param name="csvWriter">CSV writer</param>
        /// <param name="question">Question to format</param>
        void Format(IWriter csvWriter, T question);
    }
}
