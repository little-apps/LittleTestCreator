using System.Collections.Generic;

namespace LittleTestCreator.Shared.Contracts
{
    /// <summary>
    /// Contract for questions.
    /// </summary>
    public interface IQuestion
    {
        /// <summary>
        /// Question ID
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Question number (maybe different than ID)
        /// </summary>
        int Number { get; }

        /// <summary>
        /// Question contents.
        /// </summary>
        string Text { get; }

        /// <summary>
        /// Any extra info details for question.
        /// </summary>
        IDictionary<string, string> Extra { get; }

        /// <summary>
        /// Points question is worth.
        /// </summary>
        int Points { get; set; }
    }
}
