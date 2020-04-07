using System.Collections.Generic;
using TestCreator.Interfaces;

namespace TestCreator.Questions
{
    internal sealed class Question : IQuestion
    {
        public int Id { get; set; }
        public int Number { get; }
        public string Text { get; }
        public IDictionary<string, string> Extra { get; }

        internal Question(int number, string text)
        {
            Number = number;
            Text = text;
            Extra = new Dictionary<string, string>();
        }
    }
}
