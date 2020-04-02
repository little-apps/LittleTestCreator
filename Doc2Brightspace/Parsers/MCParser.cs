using System.Collections.Generic;
using System.Text.RegularExpressions;
using Doc2Brightspace.Factories;
using Doc2Brightspace.Questions;

namespace Doc2Brightspace.Parsers
{
    public class MCParser : IParser
    {
        public List<Question> Parse(string content)
        {
            var questions = new List<Question>();

            var regex = new Regex(@"([ \t]*\d+\.[^\n]+\n(?:[ \t]*[a-zA-Z]\)[^\n]+\n)+\s*(?:(?!\d+\.\s).)*)", RegexOptions.Multiline | RegexOptions.Singleline);

            var mcQuestionFactory = new MCQuestionFactory();

            foreach (Match match in regex.Matches(content))
            {
                var question = mcQuestionFactory.Build(match.Value);

                questions.Add(question);
            }

            return questions;
        }
    }
}
