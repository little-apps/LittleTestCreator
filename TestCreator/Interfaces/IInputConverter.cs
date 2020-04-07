using System.IO;

namespace TestCreator.Interfaces
{
    internal interface IInputConverter
    {
        /// <summary>
        /// Convert source file to stream with plain-text.
        /// </summary>
        /// <returns><seealso cref="Stream"/> with contents.</returns>
        Stream Convert();
    }
}
