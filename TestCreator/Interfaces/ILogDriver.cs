namespace TestCreator.Interfaces
{
    /// <summary>
    /// Defines driver for handling log messages.
    /// </summary>
    internal interface ILogDriver
    {
        void Warning(string message);
        void Info(string message);
        void Success(string message);
        void Error(string message);
    }
}
