using System.Collections.Generic;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions.WrittenResponse
{
    /// <summary>
    /// Represents a written response question.
    /// </summary>
    public class WrittenResponseQuestion : IQuestion
    {
        private readonly IQuestion _questionImplementation;
        private WrittenResponseAnswer _answer;

        public int Id
        {
            get => _questionImplementation.Id;
            set => _questionImplementation.Id = value;
        }

        public int Number => _questionImplementation.Number;

        public string Text => _questionImplementation.Text;

        public IDictionary<string, string> Extra => _questionImplementation.Extra;

        public int Points
        {
            get => _questionImplementation.Points;
            set => _questionImplementation.Points = value;
        }

        /// <summary>
        /// Answer to written response question.
        /// </summary>
        public WrittenResponseAnswer Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                value.Owner = this;
            }
        }

        /// <summary>
        /// Constructor for written response question.
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="text">Question</param>
        public WrittenResponseQuestion(int number, string text)
        {
            _questionImplementation = new Question(number, text);
            Answer = new WrittenResponseAnswer("");
        }

        
    }
}
