namespace LittleTestCreator.Shared.Contracts
{
    /// <summary>
    /// Defines an answer to a question.
    /// </summary>
    /// <typeparam name="T">Question type answer belongs to.</typeparam>
    public interface IAnswer<T> where T : IQuestion
    {
        /// <summary>
        /// <seealso cref="IQuestion"/> that answer belongs to.
        /// </summary>
        T Owner { get; set; }

        /// <summary>
        /// Contents of answer.
        /// </summary>
        string Text { get; }
    }
}
