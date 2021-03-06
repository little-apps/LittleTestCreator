﻿using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LittleTestCreator.Shared.Questions.WrittenResponse;

namespace LittleTestCreator.InputConverter.Kitty.Factories
{
    internal class WrittenResponseQuestionFactory
    {
        /// <summary>
        /// Creates a written response question.
        /// </summary>
        /// <param name="number">Question number</param>
        /// <param name="question">Question</param>
        /// <param name="answers">Answer(s) to question</param>
        /// <returns>Created <seealso cref="WrittenResponseQuestion"/> instance</returns>
        /// <remarks>This does not include the answer to the question.</remarks>
        public static WrittenResponseQuestion Build(int number, string question, IEnumerable<string> answers)
        {
            // Parse # of marks.
            var regex = new Regex(@"\((\d+) marks?\)");

            var match = regex.Match(question);
            var points = 1;

            if (match.Success)
            {
                var marksText = match.Groups[1].Value;

                if (int.TryParse(marksText, out points))
                {
                    question = regex.Replace(question, "");
                }
            }

            var writtenResponseAnswer = new WrittenResponseAnswer(string.Join("\r\n", answers));

            return new WrittenResponseQuestion(number, question.Trim()) { Id = number, Points = points, Answer = writtenResponseAnswer };
        }


    }
}
