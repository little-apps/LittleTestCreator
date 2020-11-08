using System;
using System.Text.RegularExpressions;
using LittleTestCreator.InputConverter.OSConcepts.Contracts;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Questions;

namespace LittleTestCreator.InputConverter.OSConcepts.Factories
{
    public class TrueFalseQuestionFactory : IQuestionTypeFactory
    {
        private readonly QuestionExtraFactory _questionExtraFactory;

        private readonly Regex _questionRegex;


        public TrueFalseQuestionFactory()
        {
            _questionExtraFactory = new QuestionExtraFactory();
            _questionRegex = new Regex(@"(\d+)\s*\.([^\n]+)\s*Ans:\s*(True|False)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

        public bool CanBuild(string contents)
        {
            return _questionRegex.IsMatch(contents);
        }

        public IQuestion Build(string contents)
        {
            var match = _questionRegex.Match(contents);

            var num = int.Parse(match.Groups[1].Value);
            var text = match.Groups[2].Value.Trim();
            var answer = match.Groups[3].Value;

            var question = new TrueFalseQuestion(num, text);

            if (answer.Equals("true", StringComparison.CurrentCultureIgnoreCase))
                question.Answer = true;
            else if (answer.Equals("false", StringComparison.CurrentCultureIgnoreCase))
                question.Answer = false;

            _questionExtraFactory.InsertExtras(contents, question);

            return question;
        }


    }
}
