using System.Collections.Generic;

namespace LittleTestCreator.Shared.Contracts
{
    /// <summary>
    /// Defines input converter.
    /// </summary>
    public interface IInputConverter
    {
        /// <summary>
        /// Converts input into a list of <seealso cref="IQuestion"/>s.
        /// </summary>
        /// <returns><seealso cref="IEnumerable{T}"/> containing <seealso cref="IQuestion"/> implementations.</returns>
        IEnumerable<IQuestion> Convert();
    }
}
