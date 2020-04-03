using System;
using System.IO;
using System.Windows.Forms;

namespace BrightspaceTestCreator.Parsers
{
    internal class RtfParser : IParser
    {
        public string SourceFile { get; }

        internal RtfParser(string sourceFile)
        {
            if (!File.Exists(SourceFile))
                throw new ArgumentException("Source file not found.", nameof(sourceFile));

            SourceFile = sourceFile;
        }

        public Stream Parse()
        {
            var textStream = new MemoryStream();

            using (var richTextBox = new RichTextBox())
            {
                richTextBox.LoadFile(SourceFile);
                richTextBox.SaveFile(textStream, RichTextBoxStreamType.PlainText);
            }

            return textStream;
        }
    }
}
