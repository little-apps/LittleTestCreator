using System.Collections.Generic;

namespace LittleTestCreator.Shared.Contracts
{
    /// <summary>
    /// Defines output formatter.
    /// </summary>
    public interface IOutputFormatter
    {
        /// <summary>
        /// Formats question instances to output format.
        /// </summary>
        /// <param name="questions">Questions to format.</param>
        void Format(IEnumerable<IQuestion> questions);
    }
}
