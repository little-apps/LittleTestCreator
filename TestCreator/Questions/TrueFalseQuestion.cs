using System.Collections.Generic;
using TestCreator.Interfaces;
using TestCreator.Questions.MultipleChoice;

namespace TestCreator.Questions
{
    public class TrueFalseQuestion : IQuestion
    {
        private readonly MultipleChoiceQuestion _mcQuestion;
        private readonly IQuestion _questionImplementation;

        public int Id
        {
            get => _questionImplementation.Id;
            set => _questionImplementation.Id = value;
        }

        public int Number => _questionImplementation.Number;

        public string Text => _questionImplementation.Text;

        public IDictionary<string, string> Extra => _questionImplementation.Extra;

        /// <summary>
        /// Answer to the true/false question.
        /// </summary>
        /// <remarks>Either true/false, or, null if no answer specified.</remarks>
        public bool? Answer
        {
            get
            {
                if (_mcQuestion.Answer == null)
                    return null;

                return  _mcQuestion.Answer.Order == 'A';
            }

            set => _mcQuestion.Answer = !value.HasValue ? null : _mcQuestion[value.Value ? 'A' : 'B'];
        }

        public TrueFalseQuestion(int number, string text)
        {
            _questionImplementation = new Question(number, text);
            _mcQuestion = new MultipleChoiceQuestion(number, text);
            _mcQuestion.AddChoice(new Choice('A', "True"));
            _mcQuestion.AddChoice(new Choice('B', "False"));
        }


        
    }
}
