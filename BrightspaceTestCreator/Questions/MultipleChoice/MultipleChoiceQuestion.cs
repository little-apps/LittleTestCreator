using System.Collections.Generic;
using System.Linq;

namespace BrightspaceTestCreator.Questions.MultipleChoice
{
    public class MultipleChoiceQuestion : Question
    {
        private readonly List<Choice> _choices = new List<Choice>();

        public IEnumerable<Choice> Choices => _choices.OrderBy((choice) => choice.Order);

        public Choice Answer { get; set; }

        public MultipleChoiceQuestion(int number, string text) : base(number, text)
        {
        }

        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
        }

        public Choice this[char order] => _choices.First((choice) => order == choice.Order);
    }
}
