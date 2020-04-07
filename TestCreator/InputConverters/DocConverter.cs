using System;
using System.IO;
using Spire.Doc;
using TestCreator.Interfaces;

namespace TestCreator.InputConverters
{
    internal class DocConverter : IInputConverter
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
