using System;

namespace LittleTestCreator.InputConverter.Kahoot.Exceptions
{
    public class UnknownQuestionTypeException : Exception
    {
        public UnknownQuestionTypeException(string message) : base(message)
        {

        }
    }
}
