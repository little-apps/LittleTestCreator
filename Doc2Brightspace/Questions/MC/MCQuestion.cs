using System.Collections.Generic;
using System.Linq;

namespace Doc2Brightspace.Questions.MC
{
    public class MCQuestion : Question
    {
        private List<Choice> _choices = new List<Choice>();

        public IEnumerable<Choice> Choices => _choices.OrderBy((choice) => choice.Order);

        public Choice Answer { get; set; }

        public MCQuestion(int number, string text) : base(number, text)
        {
        }

        public void AddChoice(Choice choice)
        {
            _choices.Add(choice);
        }

        public Choice this[char order]
        {
            get => _choices.First((choice) => order == choice.Order);
        }
    }
}
