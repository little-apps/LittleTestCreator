using System.Collections.Generic;
using System.Linq;
using BrightspaceTestCreator.Interfaces;

namespace BrightspaceTestCreator.Questions.MultipleChoice
{
    public class MultipleChoiceQuestion : IQuestion
    {
        private readonly List<Choice> _choices = new List<Choice>();
        private readonly IQuestion _questionImplementation;

        public int Id
        {
            get => _questionImplementation.Id;
            set => _questionImplementation.Id = value;
        }

        public int Number => _questionImplementation.Number;

        public string Text => _questionImplementation.Text;

        public IDictionary<string, string> Extra => _questionImplementation.Extra;

        public IEnumerable<Choice> Choices => _choices.OrderBy((choice) => choice.Order);

        public Choice Answer { get; set; }

        public MultipleChoiceQuestion(int number, string text)
        {
            _questionImplementation = new Question(number, text);
        }

        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
        }

        public Choice this[char order] => _choices.First((choice) => order == choice.Order);
        
    }
}
