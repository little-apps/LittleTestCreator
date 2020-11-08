using System.Collections.Generic;
using System.Linq;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions.MultipleChoice
{
    /// <summary>
    /// Represents a multiple choice question.
    /// </summary>
    /// <remarks>A multiple choice question can have one or more correct answers.</remarks>
    public class MultipleChoiceQuestion : IQuestion
    {
        private readonly List<Choice> _choices = new List<Choice>();
        private readonly List<Choice> _answers = new List<Choice>();
        private readonly IQuestion _questionImplementation;

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
        /// Available choices.
        /// </summary>
        public IEnumerable<Choice> Choices => _choices.OrderBy((choice) => choice.Order);

        /// <summary>
        /// Gets or sets the correct answer.
        /// </summary>
        public Choice Answer
        {
            get => _answers.FirstOrDefault();
            set => SetAnswer(value);
        }

        /// <summary>
        /// Correct answers to question.
        /// </summary>
        public IEnumerable<Choice> Answers => _answers;

        /// <summary>
        /// Constructor for multiple choice question.
        /// </summary>
        /// <param name="number">Number</param>
        /// <param name="text">Question</param>
        public MultipleChoiceQuestion(int number, string text)
        {
            _questionImplementation = new Question(number, text);
        }

        /// <summary>
        /// Adds a choice for the multiple choice question.
        /// </summary>
        /// <param name="choice"><seealso cref="Choice"/> to add.</param>
        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
            choice.Owner = this;
        }

        /// <summary>
        /// Adds an correct answer.
        /// </summary>
        /// <param name="choice"><seealso cref="Choice"/> to add as answer.</param>
        public void AddAnswer(Choice choice)
        {
            _answers.Add(choice);
        }

        /// <summary>
        /// Removes any existing answers and adds a single answer.
        /// </summary>
        /// <param name="choice"><seealso cref="Choice"/> to set as answer.</param>
        public void SetAnswer(Choice choice)
        {
            _answers.Clear();
            _answers.Add(choice);
        }

        /// <summary>
        /// Allows choices for <seealso cref="MultipleChoiceQuestion"/> to be accessed as an array.
        /// </summary>
        /// <param name="order">Number or letter of choice.</param>
        /// <returns>Returns <seealso cref="Choice"/> with letter or number.</returns>
        public Choice this[char order] => _choices.First((choice) => order == choice.Order);
        
    }
}
