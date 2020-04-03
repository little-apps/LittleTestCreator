using System;
using System.Text.RegularExpressions;
using BrightspaceTestCreator.Questions;

namespace BrightspaceTestCreator.Factories
{
    public class TrueFalseQuestionFactory : QuestionFactoryBase
    {
        private Regex _questionRegex;
        

        public TrueFalseQuestionFactory()
        {
            _questionRegex = new Regex(@"(\d+)\s*\.([^\n]+)\s*Ans:\s*(True|False)", RegexOptions.Singleline | RegexOptions.IgnoreCase);
        }

        public override bool CanBuild(string contents)
        {
            return _questionRegex.IsMatch(contents);
        }

        public override Question Build(string contents)
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

            InsertExtras(contents, question);

            return question;
        }

        
    }
}
