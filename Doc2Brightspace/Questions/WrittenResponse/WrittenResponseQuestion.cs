namespace Doc2Brightspace.Questions.WrittenResponse
{
    class WrittenResponseQuestion : Question
    {
        public WrittenResponseAnswer Answer { get; set; }

        public WrittenResponseQuestion(int number, string text) : base(number, text)
        {
        }
    }
}
