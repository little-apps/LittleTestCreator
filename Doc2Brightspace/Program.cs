using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Doc2Brightspace.Factories;
using Doc2Brightspace.Formatters;

namespace Doc2Brightspace
{
    class Program
    {
        static void Main(string[] args)
        {
            const string courseCode = "CMPS369";
            const string baseDir = @"C:\Users\nhamnett\Documents\Winter 2020\CMPS369\D2L\doc2bp";

            foreach (var sourceFile in Directory.EnumerateFiles(Path.Combine(baseDir, "rtf"), "*.rtf"))
            {
                var destFile = Path.Combine(baseDir, "text", Path.GetFileNameWithoutExtension(sourceFile) + ".txt");

                RichTextBox richTextBox = new RichTextBox();

                richTextBox.LoadFile(sourceFile);

                //var destFile = Path.GetTempFileName();

                richTextBox.SaveFile(destFile, RichTextBoxStreamType.PlainText);

                var csvFile = Path.Combine(baseDir, Path.GetFileNameWithoutExtension(sourceFile) + ".csv");

                var csvFormatter = new CsvFormatter(courseCode, csvFile);
                var questionsFactory = new QuestionsFactory(destFile);

                var questions = questionsFactory.Build();
                csvFormatter.Format(questions);

                Console.WriteLine($"Generate CSV file at '{csvFile}' with {questions.Count()}/{questionsFactory.TotalPossibleQuestions} questions.");
            }

            Console.ReadLine();
        }
    }
}
