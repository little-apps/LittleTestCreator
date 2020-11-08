using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LittleTestCreator.InputConverter.OSConcepts.Factories;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.InputConverter.OSConcepts
{
    public class Converter : IInputConverter
    {
        public string SourceFile { get; }

        /// <summary>
        /// Constructor for converter.
        /// </summary>
        /// <param name="sourceFile">Path to source RTF document.</param>
        /// <exception cref="ArgumentException">Thrown if source file is null, empty, or whitespace.</exception>
        public Converter(string sourceFile)
        {
            if (string.IsNullOrWhiteSpace(sourceFile))
                throw new ArgumentException("Source file cannot be null, empty, or whitespace.", nameof(sourceFile));

            SourceFile = sourceFile;
        }

        /// <inheritdoc />
        /// <exception cref="IOException">Thrown if unable to read from <seealso cref="SourceFile"/>.</exception>
        public IEnumerable<IQuestion> Convert()
        {
            var stream = new MemoryStream();

            using (var richTextBox = new RichTextBox())
            {
                richTextBox.LoadFile(SourceFile);
                richTextBox.SaveFile(stream, RichTextBoxStreamType.PlainText);
            }

            var questionsFactory = new QuestionsFactory(stream);

            return questionsFactory.Build();
        }
    }
}
