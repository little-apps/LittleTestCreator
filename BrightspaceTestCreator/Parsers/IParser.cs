using System.IO;

namespace BrightspaceTestCreator.Parsers
{
    internal interface IParser
    {
        /// <summary>
        /// Parse source file without any formatting.
        /// </summary>
        /// <returns><seealso cref="Stream"/> with contents.</returns>
        Stream Parse();
    }
}
