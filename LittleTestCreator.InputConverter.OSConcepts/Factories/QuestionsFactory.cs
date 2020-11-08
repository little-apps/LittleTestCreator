using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using LittleTestCreator.InputConverter.OSConcepts.Contracts;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.InputConverter.OSConcepts.Factories
{
    public class QuestionsFactory
    {
        private StreamReader StreamReader { get; }

        /// <summary>
        /// Creates instance of QuestionsFactory.
        /// </summary>
        /// <param name="stream">Stream to read questions from.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="stream"/> is not seekable or readable.</exception>
        public QuestionsFactory(Stream stream)
        {
            if (!stream.CanRead)
                throw new ArgumentException("Stream must be readable.", nameof(stream));

            if (!stream.CanSeek)
                throw new ArgumentException("Stream must be seekable.", nameof(stream));

            StreamReader = new StreamReader(stream);
        }

        /// <summary>
        /// Builds questions from stream contents.
        /// </summary>
        /// <returns>IEnumerable list of <seealso cref="IQuestion"/> instances.</returns>
        public IEnumerable<IQuestion> Build()
        {
            IReadOnlyList<IQuestionTypeFactory> questionFactories = new List<IQuestionTypeFactory>
            {
                new MultipleChoiceQuestionFactory(),
                new TrueFalseQuestionFactory(),
                new WrittenResponseQuestionFactory()
            };

            StreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            var content = StreamReader.ReadToEnd();

            var questionRegex = new Regex(@"([ \t]*\d+\s*\.?[^\n]+\n(?:(?!\n\d+\s*\.?\s).)*)", RegexOptions.Singleline | RegexOptions.Multiline);
            var currentId = 1;

            foreach (Match match in questionRegex.Matches(content))
            {
                foreach (var questionFactory in questionFactories)
                {
                    if (!questionFactory.CanBuild(match.Value)) 
                        continue;

                    var question = questionFactory.Build(match.Value);

                    question.Id = currentId++;

                    yield return question;

                    break;
                }
            }
        }
    }
}
