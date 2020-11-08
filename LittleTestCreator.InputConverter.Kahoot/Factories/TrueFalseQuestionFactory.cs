using LittleTestCreator.Shared.Log;
using LittleTestCreator.Shared.Questions;

namespace LittleTestCreator.InputConverter.Kahoot.Factories
{
    internal class TrueFalseQuestionFactory
    {
        /// <summary>
        /// Creates a true/false question.
        /// </summary>
        /// <param name="number">Question number</param>
        /// <param name="question">Question</param>
        /// <param name="answer">Answer to question (true, false, null meaning unknown)</param>
        /// <returns>Created <seealso cref="TrueFalseQuestion"/> instance</returns>
        public static TrueFalseQuestion Build(int number, string question, bool? answer)
        {
            var trueFalse = new TrueFalseQuestion(number, question) {Id = number, Answer = answer};

            if (trueFalse.Answer == null)
                Logger.Log(Logger.Type.Error, $"Could not find answer to '{question}'");

            return trueFalse;
        }


    }
}
