using System.Collections.Generic;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Questions.MultipleChoice;

namespace LittleTestCreator.Shared.Questions
{
    /// <summary>
    /// Represents a true/false question.
    /// </summary>
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

        public int Points
        {
            get => _questionImplementation.Points;
            set => _questionImplementation.Points = value;
        }

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

            set => _mcQuestion.AddAnswer(!value.HasValue ? null : _mcQuestion[value.Value ? 'A' : 'B']);
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
