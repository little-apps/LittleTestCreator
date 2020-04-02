using System.Text.RegularExpressions;
using Doc2Brightspace.Questions;
using Doc2Brightspace.Questions.MC;

namespace Doc2Brightspace.Factories
{
    public class MCQuestionFactory : QuestionFactoryBase
    {
        private Regex _questionRegex;
        private Regex _answersRegex;

        public MCQuestionFactory()
        {
            //_questionRegex = new Regex(@"(\d+)\.([^\n]+)\n(.*)Ans:([^\n]*)", RegexOptions.Singleline);
            _questionRegex = new Regex(@"(\d+)\s*\.?(.+?)(([A-Z]\)[^\n]+\n)+)\s*Ans:([^\n]+)", RegexOptions.Singleline);

            _answersRegex = new Regex(@"([a-zA-Z])\)([^\n]+)\n");
        }

        public override bool CanBuild(string question)
        {
            var match = _questionRegex.Match(question);

            return match.Success;
        }

        public override Question Build(string contents)
        {
            var questionMatch = _questionRegex.Match(contents);

            var num = int.Parse(questionMatch.Groups[1].Value);
            var text = questionMatch.Groups[2].Value.Trim();
            var answers = questionMatch.Groups[3].Value;
            var correct = questionMatch.Groups[5].Value.Trim()[0];

            MCQuestion question = new MCQuestion(num, text);

            InsertExtras(contents, question);

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
