using System.Collections.Generic;
using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Log;
using LittleTestCreator.Shared.Questions.MultipleChoice;

namespace LittleTestCreator.InputConverter.Kitty.Factories
{
    internal static class MultipleChoiceQuestionFactory
    {
        /// <summary>
        /// Creates a multiple choice question.
        /// </summary>
        /// <param name="number"></param>
        /// <param name="question"></param>
        /// <param name="answers"></param>
        /// <param name="correct"></param>
        /// <returns></returns>
        public static IQuestion Build(int number, string question, IList<string> answers, int correct)
        {
            // Is it a true/false question?
            if (answers.Count == 2 && (
                answers[0].Equals("true", System.StringComparison.InvariantCultureIgnoreCase) &&
                answers[1].Equals("false", System.StringComparison.InvariantCultureIgnoreCase)
                ))
            {
                return TrueFalseQuestionFactory.Build(number, question, correct == 0);
            }

            var multipleChoice = new MultipleChoiceQuestion(number, question.Trim()) { Id = number };

            var i = 0;

            foreach (var answer in answers)
            {
                var choice = new Choice(answer.Trim());

                multipleChoice.AddChoice(choice);

                if (i == correct)
                    multipleChoice.Answer = choice;

                i++;
            }

            if (multipleChoice.Answer == null)
                Logger.Log(Logger.Type.Error, $"Could not find answer to '{question}'");

            return multipleChoice;
        }


    }
}
