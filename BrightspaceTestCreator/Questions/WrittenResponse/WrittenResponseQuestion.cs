namespace BrightspaceTestCreator.Questions.WrittenResponse
{
    internal class WrittenResponseQuestion : Question
    {
        public WrittenResponseAnswer Answer { get; set; }

        public WrittenResponseQuestion(int number, string text) : base(number, text)
        {
        }
    }
}
