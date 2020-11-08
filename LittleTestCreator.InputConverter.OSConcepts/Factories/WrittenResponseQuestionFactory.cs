using System.Text.RegularExpressions;
using LittleTestCreator.InputConverter.OSConcepts.Contracts;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Questions.WrittenResponse;

namespace LittleTestCreator.InputConverter.OSConcepts.Factories
{
    public class WrittenResponseQuestionFactory : IQuestionTypeFactory
    {
        private readonly QuestionExtraFactory _questionExtraFactory;

        private readonly Regex _questionRegex;

        public WrittenResponseQuestionFactory()
        {
            _questionExtraFactory = new QuestionExtraFactory();
            _questionRegex = new Regex(@"(\d+)\s*\.([^\n]+)\s+An(s|d):\s*(((?!True|False).)[^\n]+)\n", RegexOptions.IgnoreCase);
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
            var answer = match.Groups[4].Value.Trim();

            var question = new WrittenResponseQuestion(num, text) {Answer = new WrittenResponseAnswer(answer)};

            _questionExtraFactory.InsertExtras(contents, question);

            return question;
        }


    }
}
