using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions.WrittenResponse
{
    /// <summary>
    /// Represents the answer to written response question.
    /// </summary>
    public class WrittenResponseAnswer : IAnswer<WrittenResponseQuestion>
    {
        public WrittenResponseQuestion Owner { get; set; }
        public string Text { get; }

        /// <summary>
        /// Constructor for written response answer.
        /// </summary>
        /// <param name="text">Possible answer for written response question.</param>
        public WrittenResponseAnswer(string text)
        {
            Text = text;
        }
    }
}
