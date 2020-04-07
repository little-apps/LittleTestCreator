using TestCreator.Interfaces;

namespace TestCreator.Questions.WrittenResponse
{
    internal class WrittenResponseAnswer : IAnswer
    {
        public string Text { get; }

        public WrittenResponseAnswer(string text)
        {
            Text = text;
        }
    }
}
