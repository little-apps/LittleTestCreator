using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.InputConverter.Kitty.Factories
{
    internal static class QuestionFactory
    {
        /// <summary>
        /// Creates a <seealso cref="IQuestion"/> from a <seealso cref="Question"/> instance.
        /// </summary>
        /// <param name="kittyQuestion">Question information to use to build.</param>
        /// <returns>Created <seealso cref="IQuestion"/> instance.</returns>
        internal static IQuestion Build(Question kittyQuestion)
        {
            // If we have answers, it's a multiple choice question
            return 
                kittyQuestion.Answers.Count > 0 ? 
                    MultipleChoiceQuestionFactory.Build(kittyQuestion.Number, kittyQuestion.QuestionText, kittyQuestion.Answers, kittyQuestion.CorrectAnswerIndex) : 
                    WrittenResponseQuestionFactory.Build(kittyQuestion.Number, kittyQuestion.QuestionText);
        }
    }
}
