using System;

namespace TestCreator.Exceptions
{
    internal class InvalidOptionException : Exception
    {
        /// <summary>
        /// Name of Option property that's invalid.
        /// </summary>
        public string PropertyName { get; set; }

        /// <summary>
        /// Constructs InvalidOptionException instance.
        /// </summary>
        /// <param name="message">Exception message</param>
        public InvalidOptionException(string message) : base(message)
        {

        }

        /// <summary>
        /// Constructs InvalidOptionException instance.
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="propertyName">Name of invalid Option property/</param>
        public InvalidOptionException(string message, string propertyName) : base(message)
        {
            PropertyName = propertyName;
        }
    }
}
