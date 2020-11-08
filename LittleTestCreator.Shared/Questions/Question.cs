using System.Collections.Generic;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions
{
    internal sealed class Question : IQuestion
    {
        /// <inheritdoc />
        public int Id { get; set; }

        /// <inheritdoc />
        public int Number { get; }

        /// <inheritdoc />
        public string Text { get; }

        /// <inheritdoc />
        public IDictionary<string, string> Extra { get; }

        /// <inheritdoc />
        public int Points { get; set; }

        /// <summary>
        /// Constructor for Question
        /// </summary>
        /// <param name="number">Question number</param>
        /// <param name="text">Question text</param>
        internal Question(int number, string text)
        {
            Number = number;
            Text = text;
            Extra = new Dictionary<string, string>();
            Points = 1;
        }
    }
}
