using TestCreator.Interfaces;

namespace TestCreator.Questions.MultipleChoice
{
    public class Choice : IAnswer
    {
        public char Order { get; set; }

        public string Text { get; }

        public bool IsCorrect { get; }

        public Choice(string text, bool isCorrect = false)
        {
            Text = text;
            IsCorrect = isCorrect;
        }

        public Choice(char order, string text, bool isCorrect = false)
        {
            Order = order;
            Text = text;
            IsCorrect = IsCorrect;
        }
    }
}
