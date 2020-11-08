using System.Collections.Generic;
using LittleTestCreator.Shared.Questions.ShortAnswer;

namespace LittleTestCreator.InputConverter.Kahoot.Factories
{
    internal class ShortAnswerQuestionFactory
    {
        /// <summary>
        /// Creates a short answer question.
        /// </summary>
        /// <param name="number">Question number</param>
        /// <param name="questionText">Question</param>
        /// <param name="answers">Answers to question (as strings)</param>
        /// <returns>Created <seealso cref="ShortAnswerQuestion"/> instance.</returns>
        public static ShortAnswerQuestion Build(int number, string questionText, IEnumerable<string> answers)
        {
            var question = new ShortAnswerQuestion(number, questionText)
                {Id = number};

            foreach (var answer in answers)
            {
                question.AddAnswer(new ShortAnswer(answer));
            }

            return question;
        }



    }
}
