namespace TestCreator.Interfaces
{
    internal interface ILogDriver
    {
        void Warning(string message);
        void Info(string message);
        void Success(string message);
        void Error(string message);
    }
}
