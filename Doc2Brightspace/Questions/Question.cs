using System.Collections.Generic;

namespace Doc2Brightspace.Questions
{
    public abstract class Question
    {
        public int Id { get; set; }
        public int Number { get; }
        public string Text { get; }
        public Dictionary<string, string> Extra { get; }

        public Question(int number, string text)
        {
            Number = number;
            Text = text;
            Extra = new Dictionary<string, string>();
        }
    }
}
