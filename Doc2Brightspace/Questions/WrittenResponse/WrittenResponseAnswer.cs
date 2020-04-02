namespace Doc2Brightspace.Questions.WrittenResponse
{
    class WrittenResponseAnswer : IAnswer
    {
        public string Text { get; }

        public WrittenResponseAnswer(string text)
        {
            Text = text;
        }
    }
}
