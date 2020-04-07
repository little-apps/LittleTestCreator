using System.Collections.Generic;
using TestCreator.Interfaces;

namespace TestCreator.Questions.WrittenResponse
{
    internal class WrittenResponseQuestion : IQuestion
    {
        private readonly IQuestion _questionImplementation;

        public int Id
        {
            get => _questionImplementation.Id;
            set => _questionImplementation.Id = value;
        }

        public int Number => _questionImplementation.Number;

        public string Text => _questionImplementation.Text;

        public IDictionary<string, string> Extra => _questionImplementation.Extra;

        public WrittenResponseAnswer Answer { get; set; }

        public WrittenResponseQuestion(int number, string text)
        {
            _questionImplementation = new Question(number, text);
        }

        
    }
}
