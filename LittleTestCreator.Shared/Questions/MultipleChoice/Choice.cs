using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions.MultipleChoice
{
    /// <summary>
    /// Represents a choice in a multiple choice question.
    /// </summary>
    public class Choice : IAnswer<MultipleChoiceQuestion>
    {
        /// <summary>
        /// Order letter of choice (A, B, C, etc.)
        /// </summary>
        public char Order { get; set; }

        public MultipleChoiceQuestion Owner { get; set; }
        public string Text { get; }

        /// <summary>
        /// Constructor for choice.
        /// </summary>
        /// <param name="text">Choice</param>
        public Choice(string text)
        {
            Text = text;
        }

        /// <summary>
        /// Constructor for choice.
        /// </summary>
        /// <param name="order">Letter or number used to order choice.</param>
        /// <param name="text">Choice</param>
        public Choice(char order, string text)
        {
            Order = order;
            Text = text;
        }
    }
}
