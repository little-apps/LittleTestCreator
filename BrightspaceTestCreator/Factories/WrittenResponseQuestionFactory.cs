﻿using System.Text.RegularExpressions;
using BrightspaceTestCreator.Interfaces;
using BrightspaceTestCreator.Questions;
using BrightspaceTestCreator.Questions.WrittenResponse;

namespace BrightspaceTestCreator.Factories
{
    public class WrittenResponseQuestionFactory : QuestionFactoryBase
    {
        private Regex _questionRegex;

        public WrittenResponseQuestionFactory()
        {
            _questionRegex = new Regex(@"(\d+)\s*\.([^\n]+)\s+An(s|d):\s*(((?!True|False).)[^\n]+)\n", RegexOptions.IgnoreCase);
        }

        public override bool CanBuild(string contents)
        {
            return _questionRegex.IsMatch(contents);
        }

        public override IQuestion Build(string contents)
        {
            var match = _questionRegex.Match(contents);

            var num = int.Parse(match.Groups[1].Value);
            var text = match.Groups[2].Value.Trim();
            var answer = match.Groups[4].Value.Trim();

            var question = new WrittenResponseQuestion(num, text);

            question.Answer = new WrittenResponseAnswer(answer);

            InsertExtras(contents, question);

            return question;
        }

        
    }
}
