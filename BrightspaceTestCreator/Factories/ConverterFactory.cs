using System;
using System.IO;
using BrightspaceTestCreator.Converters;
using BrightspaceTestCreator.Interfaces;

namespace BrightspaceTestCreator.Factories
{
    internal static class ConverterFactory
    {
        public static IConverter Build(string sourceFile)
        {
            if (string.IsNullOrEmpty(sourceFile))
                throw new ArgumentNullException(nameof(sourceFile));

            var fileExt = Path.GetExtension(sourceFile).ToLower();

            switch (fileExt)
            {
                case ".rtf":
                    return new RtfConverter(sourceFile);
                case ".doc":
                case ".docx":
                    return new DocConverter(sourceFile);
                default:
                    throw new ArgumentException($"Unable to determine parser for file extension '{fileExt}'.", nameof(sourceFile));
            }
        }
    }
}
