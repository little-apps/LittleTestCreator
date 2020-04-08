using System.Collections.Generic;

namespace TestCreator.Interfaces
{
    /// <summary>
    /// Defines output formatter.
    /// </summary>
    internal interface IOutputFormatter
    {
        /// <summary>
        /// Formats question instances to output format.
        /// </summary>
        /// <param name="questions">Questions to format.</param>
        void Format(IEnumerable<IQuestion> questions);
    }
}
