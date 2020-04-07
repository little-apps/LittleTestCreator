using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using TestCreator.Interfaces;
using TestCreator.Questions;
using TestCreator.Questions.MultipleChoice;
using TestCreator.Questions.WrittenResponse;

namespace TestCreator.OutputFormatters
{
    public class CsvFormatter : IOutputFormatter
    {
        public string CsvFile { get; }
        public string Prefix { get; }

        public CsvFormatter(string csvFile, string prefix = "")
        {
            CsvFile = csvFile;
            Prefix = prefix;
        }

        public void Format(IEnumerable<IQuestion> questions)
        {
            using (var fs = new StreamWriter(CsvFile))
            {
                using (var csvWriter = new CsvHelper.CsvWriter(fs, CultureInfo.InvariantCulture))
                {
                    foreach (var question in questions.OrderBy((q) => q.Number))
                    {
                        switch (question)
                        {
                            case MultipleChoiceQuestion mcQuestion:
                                FormatMultipleChoice(csvWriter, mcQuestion);
                                break;
                            case TrueFalseQuestion trueFalseQuestion:
                                FormatTrueFalse(csvWriter, trueFalseQuestion);
                                break;
                            case WrittenResponseQuestion writtenResponseQuestion:
                                FormatWrittenResponse(csvWriter, writtenResponseQuestion);
                                break;
                        }
                    }
                }
                
            }

                
        }

        private void FormatMultipleChoice(IWriter csvWriter, MultipleChoiceQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("MC");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("ID");
            csvWriter.WriteField(GenerateQuestionId(question));
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Title");
            csvWriter.WriteField(GenerateTitle(question));
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("QuestionText");
            csvWriter.WriteField(question.Text);
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Points");
            csvWriter.WriteField(1);
            csvWriter.WriteField("");

            if (question.Extra.ContainsKey("difficulty"))
            {
                csvWriter.NextRecord();
                csvWriter.WriteField("Difficulty");
                csvWriter.WriteField(question.Extra["difficulty"]);
                csvWriter.WriteField("");
            }

            foreach (var choice in question.Choices)
            {
                var points = question.Answer == choice ? 100 : 0;

                csvWriter.NextRecord();
                csvWriter.WriteField("Option");
                csvWriter.WriteField(points);
                csvWriter.WriteField(choice.Text);
                csvWriter.WriteField("");
                csvWriter.WriteField("");
            }

            csvWriter.NextRecord();
            csvWriter.NextRecord();

        }

        private void FormatTrueFalse(IWriter csvWriter, TrueFalseQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("TF");
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("ID");
            csvWriter.WriteField(GenerateQuestionId(question));
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Title");
            csvWriter.WriteField(GenerateTitle(question));
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("QuestionText");
            csvWriter.WriteField(question.Text);
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Points");
            csvWriter.WriteField(1);
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            if (question.Extra.ContainsKey("difficulty"))
            {
                csvWriter.NextRecord();
                csvWriter.WriteField("Difficulty");
                csvWriter.WriteField(question.Extra["difficulty"]);
                csvWriter.WriteField("");
                csvWriter.WriteField("");
                csvWriter.WriteField("");
            }

            csvWriter.NextRecord();
            csvWriter.WriteField("TRUE");
            csvWriter.WriteField(question.Answer.HasValue && question.Answer.Value ? 100 : 0);
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("FALSE");
            csvWriter.WriteField(question.Answer.HasValue && !question.Answer.Value ? 100 : 0);
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            if (question.Extra.ContainsKey("feedback"))
            {
                csvWriter.NextRecord();
                csvWriter.WriteField("Feedback");
                csvWriter.WriteField(question.Extra["feedback"]);
                csvWriter.WriteField("");
                csvWriter.WriteField("");
                csvWriter.WriteField("");
            }

            csvWriter.NextRecord();
            csvWriter.NextRecord();
        }

        private void FormatWrittenResponse(IWriter csvWriter, WrittenResponseQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("WR");

            csvWriter.NextRecord();
            csvWriter.WriteField("ID");
            csvWriter.WriteField(GenerateQuestionId(question));

            csvWriter.NextRecord();
            csvWriter.WriteField("Title");
            csvWriter.WriteField(GenerateTitle(question));

            csvWriter.NextRecord();
            csvWriter.WriteField("QuestionText");
            csvWriter.WriteField(question.Text);

            csvWriter.NextRecord();
            csvWriter.WriteField("Points");
            csvWriter.WriteField(1);
            csvWriter.WriteField("");

            if (question.Extra.ContainsKey("difficulty"))
            {
                csvWriter.NextRecord();
                csvWriter.WriteField("Difficulty");
                csvWriter.WriteField(question.Extra["difficulty"]);
            }

            csvWriter.NextRecord();
            csvWriter.WriteField("AnswerKey");
            csvWriter.WriteField(question.Answer.Text);

            if (question.Extra.ContainsKey("feedback"))
            {
                csvWriter.NextRecord();
                csvWriter.WriteField("Feedback");
                csvWriter.WriteField(question.Extra["feedback"]);
            }

            csvWriter.NextRecord();
            csvWriter.NextRecord();

        }

        private string GenerateTitle(IQuestion question)
        {
            if (question.Text.Length <= 60)
                return question.Text;

            return question.Text.Substring(0, 60);
        }

        private string GenerateQuestionId(IQuestion question)
        {
            var prefix = !string.IsNullOrEmpty(Prefix) ? Prefix + "-" : "";

            return $"{prefix}{question.Id}";
        }
    }
}
