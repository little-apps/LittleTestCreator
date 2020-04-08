namespace TestCreator.Interfaces
{
    internal interface IQuestionTypeFactory
    {
        /// <summary>
        /// Determines if a <seealso cref="IQuestion"/> can be created.
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        bool CanBuild(string contents);

        /// <summary>
        /// Builds a <seealso cref="IQuestion"/> from contents.
        /// </summary>
        /// <param name="contents"></param>
        /// <returns></returns>
        IQuestion Build(string contents);
    }
}
