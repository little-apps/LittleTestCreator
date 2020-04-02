using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Doc2Brightspace.Questions;

namespace Doc2Brightspace.Factories
{
    public class QuestionsFactory
    {
        public string SourceFile { get; }

        public int TotalPossibleQuestions
        {
            get
            {
                var content = File.ReadAllText(SourceFile);

                return int.Parse(Regex.Match(content, @"(\d+)(?!.*\d+\.\s)", RegexOptions.Singleline).Value);
            }
        }
            

        public QuestionsFactory(string sourceFile)
        {
            SourceFile = sourceFile;
        }

        public IEnumerable<Question> Build()
        {
            IReadOnlyList<QuestionFactoryBase> questionFactories = new List<QuestionFactoryBase>
            {
                new MCQuestionFactory(),
                new TrueFalseQuestionFactory(),
                new WrittenResponseQuestionFactory()
            };

            var content = File.ReadAllText(SourceFile);

            var questionRegex = new Regex(@"([ \t]*\d+\s*\.?[^\n]+\n(?:(?!\n\d+\s*\.?\s).)*)", RegexOptions.Singleline | RegexOptions.Multiline);
            var currentId = 1;

            foreach (Match match in questionRegex.Matches(content))
            {
                foreach (var questionFactory in questionFactories)
                {
                    if (questionFactory.CanBuild(match.Value))
                    {
                        var question = questionFactory.Build(match.Value);

                        question.Id = currentId++;

                        yield return question;

                        break;
                    }
                }
            }
        }
    }
}
