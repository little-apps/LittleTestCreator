using Doc2Brightspace.Questions.MC;

namespace Doc2Brightspace.Questions
{
    public class TrueFalseQuestion : Question
    {
        private MCQuestion _mcQuestion;

        public bool? Answer
        {
            get
            {
                if (_mcQuestion.Answer == null)
                    return null;

                return  _mcQuestion.Answer.Order == 'A';
            }

            set
            {
                if (!value.HasValue)
                    _mcQuestion.Answer = null;

                _mcQuestion.Answer = _mcQuestion[value.Value ? 'A' : 'B'];
            }
        }

        public TrueFalseQuestion(int number, string text) : base(number, text)
        {
            _mcQuestion = new MCQuestion(number, text);
            _mcQuestion.AddChoice(new Choice('A', "True"));
            _mcQuestion.AddChoice(new Choice('B', "False"));
        }


    }
}
