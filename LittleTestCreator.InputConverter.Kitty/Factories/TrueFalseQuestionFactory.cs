using LittleTestCreator.Shared.Contracts;
using LittleTestCreator.Shared.Log;
using LittleTestCreator.Shared.Questions;

namespace LittleTestCreator.InputConverter.Kitty.Factories
{
    internal class TrueFalseQuestionFactory
    {
        /// <summary>
        /// Creates a true/false question.
        /// </summary>
        /// <param name="number">Question number</param>
        /// <param name="question">Question</param>
        /// <param name="answer">Answer (true, false, or null meaning unknown).</param>
        /// <returns>Created <seealso cref="TrueFalseQuestion"/> instance.</returns>
        public static IQuestion Build(int number, string question, bool? answer)
        {
            var trueFalse = new TrueFalseQuestion(number, question.Trim()) {Id = number, Answer = answer};

            if (trueFalse.Answer == null)
                Logger.Log(Logger.Type.Error, $"Could not find answer to '{question}'");

            return trueFalse;
        }


    }
}
