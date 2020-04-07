using System;
using System.IO;
using System.Windows.Forms;
using TestCreator.Interfaces;

namespace TestCreator.InputConverters
{
    internal class RtfConverter : IInputConverter
    {
        public string SourceFile { get; }

        internal RtfConverter(string sourceFile)
        {
            if (!File.Exists(SourceFile))
                throw new ArgumentException("Source file not found.", nameof(sourceFile));

            SourceFile = sourceFile;
        }

        public Stream Convert()
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
