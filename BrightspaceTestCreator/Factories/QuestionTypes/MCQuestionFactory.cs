using System.Text.RegularExpressions;
using BrightspaceTestCreator.Interfaces;
using BrightspaceTestCreator.Questions.MultipleChoice;

namespace BrightspaceTestCreator.Factories.QuestionTypes
{
    public class MCQuestionFactory : IQuestionTypeFactory
    {
        private readonly QuestionExtraFactory _questionExtraFactory;
        private Regex _questionRegex;
        private Regex _answersRegex;

        public MCQuestionFactory()
        {
            _questionExtraFactory = new QuestionExtraFactory();

            //_questionRegex = new Regex(@"(\d+)\.([^\n]+)\n(.*)Ans:([^\n]*)", RegexOptions.Singleline);
            _questionRegex = new Regex(@"(\d+)\s*\.?(.+?)(([A-Z]\)[^\n]+\n)+)\s*Ans:([^\n]+)", RegexOptions.Singleline);

            _answersRegex = new Regex(@"([a-zA-Z])\)([^\n]+)\n");
        }

        public bool CanBuild(string question)
        {
            var match = _questionRegex.Match(question);

            return match.Success;
        }

        public IQuestion Build(string contents)
        {
            var questionMatch = _questionRegex.Match(contents);

            var num = int.Parse(questionMatch.Groups[1].Value);
            var text = questionMatch.Groups[2].Value.Trim();
            var answers = questionMatch.Groups[3].Value;
            var correct = questionMatch.Groups[5].Value.Trim()[0];

            MultipleChoiceQuestion question = new MultipleChoiceQuestion(num, text);

            _questionExtraFactory.InsertExtras(contents, question);

            foreach (Match answerMatch in _answersRegex.Matches(answers))
            {
                var option = answerMatch.Groups[1].Value.Trim()[0];
                var answerText = answerMatch.Groups[2].Value.Trim();

                var choice = new Choice(option, answerText);

                question.AddChoice(choice);

                if (correct == option)
                    question.Answer = choice;
            }

            return question;
        }
    }
}
