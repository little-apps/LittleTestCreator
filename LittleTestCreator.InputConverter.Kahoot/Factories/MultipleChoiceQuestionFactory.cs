using System.Collections.Generic;
using System.Linq;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Log;
using LittleTestCreator.Shared.Questions.MultipleChoice;

namespace LittleTestCreator.InputConverter.Kahoot.Factories
{
    internal static class MultipleChoiceQuestionFactory
    {
        /// <summary>
        /// Creates a multiple choice question.
        /// </summary>
        /// <param name="number">Question number</param>
        /// <param name="question">Question</param>
        /// <param name="answers">Answers to question (as a string)</param>
        /// <param name="correct">Correct answers (as a string)</param>
        /// <returns>Created <seealso cref="MultipleChoiceQuestion"/> instance</returns>
        public static MultipleChoiceQuestion Build(int number, string question, IEnumerable<string> answers, IEnumerable<string> correct)
        {
            var multipleChoice = new MultipleChoiceQuestion(number, question.Trim()) { Id = number };

            var i = 0;

            foreach (var answer in answers)
            {
                var choice = new Choice(answer);

                multipleChoice.AddChoice(choice);

                if (correct.Contains(answer))
                    multipleChoice.AddAnswer(choice);

                i++;
            }

            if (multipleChoice.Answer == null)
                Logger.Log(Logger.Type.Error, $"Could not find answer to '{question}'");

            return multipleChoice;
        }


    }
}
