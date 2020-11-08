using System;

namespace LittleTestCreator.GUI.Exceptions
{
    class InvalidOptionException : Exception
    {
        public string PropertyName { get; }

        public InvalidOptionException(string paramName, string message) : base(message)
        {
            PropertyName = paramName;
        }
    }
}
