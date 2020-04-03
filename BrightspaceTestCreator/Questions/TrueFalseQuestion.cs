using BrightspaceTestCreator.Questions.MultipleChoice;

namespace BrightspaceTestCreator.Questions
{
    public class TrueFalseQuestion : Question
    {
        private readonly MultipleChoiceQuestion _mcQuestion;

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

        public TrueFalseQuestion(int number, string text) : base(number, text)
        {
            _mcQuestion = new MultipleChoiceQuestion(number, text);
            _mcQuestion.AddChoice(new Choice('A', "True"));
            _mcQuestion.AddChoice(new Choice('B', "False"));
        }


    }
}
