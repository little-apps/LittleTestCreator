namespace LittleTestCreator.Shared.Contracts
{
    /// <summary>
    /// Defines driver for handling log messages.
    /// </summary>
    public interface ILogDriver
    {
        /// <summary>
        /// Handle warning message.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Warning(string message);

        /// <summary>
        /// Handle info message.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Info(string message);

        /// <summary>
        /// Handle success message.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Success(string message);

        /// <summary>
        /// Handle error message.
        /// </summary>
        /// <param name="message">Log message.</param>
        void Error(string message);
    }
}
