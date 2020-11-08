using System.Collections.Generic;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions.ShortAnswer
{
    /// <summary>
    /// Represents a short answer question.
    /// </summary>
    public class ShortAnswerQuestion : IQuestion
    {
        public const uint DefaultInputSize = 40;

        private readonly IQuestion _questionImplementation;
        private readonly List<ShortAnswer> _answers;

        public int Id
        {
            get => _questionImplementation.Id;
            set => _questionImplementation.Id = value;
        }

        public int Number => _questionImplementation.Number;

        public string Text => _questionImplementation.Text;

        public IDictionary<string, string> Extra => _questionImplementation.Extra;

        public uint Inputs { get => (uint) Answers.Count; }

        public int Points
        {
            get => _questionImplementation.Points;
            set => _questionImplementation.Points = value;
        }

        public IReadOnlyCollection<ShortAnswer> Answers
        {
            get => _answers;
        }

        /// <summary>
        /// Constructor for short answer question.
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="text">Question</param>
        public ShortAnswerQuestion(int number, string text)
        {
            _questionImplementation = new Question(number, text);
            _answers = new List<ShortAnswer>();
        }

        /// <summary>
        /// Adds an answer for short answer question and sets the owner of the answer to this <see cref="ShortAnswerQuestion"/>.
        /// </summary>
        /// <param name="shortAnswer">Short answer question to associate with this question.</param>
        public void AddAnswer(ShortAnswer shortAnswer)
        {
            shortAnswer.Owner = this;
            _answers.Add(shortAnswer);
        }

        /// <summary>
        /// Removes an answer from this question.
        /// </summary>
        /// <param name="shortAnswer">Short answer question to remove.</param>
        /// <returns>True if the answer was removed.</returns>
        public bool RemoveAnswer(ShortAnswer shortAnswer)
        {
            return _answers.Remove(shortAnswer);
        }
    }
}
