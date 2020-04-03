using System;
using System.IO;
using BrightspaceTestCreator.Parsers;

namespace BrightspaceTestCreator.Factories
{
    class ParserFactory
    {
        public static IParser Build(string sourceFile)
        {
            var fileExt = Path.GetExtension(sourceFile).ToLower();

            if (fileExt == ".rtf")
                return new RtfParser(sourceFile);
            
            throw new ArgumentException($"Unable to determine parser for file extension '{fileExt}'.", nameof(sourceFile));
        }
    }
}
