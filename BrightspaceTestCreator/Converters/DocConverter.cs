using System;
using System.IO;
using BrightspaceTestCreator.Interfaces;
using Spire.Doc;

namespace BrightspaceTestCreator.Converters
{
    internal class DocConverter : IConverter
    {
        public string SourceFile { get; }
        private readonly Document _document;

        internal DocConverter(string sourceFile)
        {
            if (!File.Exists(SourceFile))
                throw new ArgumentException("Source file not found.", nameof(sourceFile));

            SourceFile = sourceFile;

            _document = new Document();
            _document.LoadFromFile(sourceFile);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Stream Convert()
        {
            var stream = new MemoryStream();
            _document.SaveToStream(stream, FileFormat.Txt);

            stream.Seek(0, SeekOrigin.Begin);

            return stream;
        }
    }
}
