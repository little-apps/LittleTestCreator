using CsvHelper;
using LittleTestCreator.OutputFormatter.Brightspace.Contracts;
using LittleTestCreator.Shared.Questions;

namespace LittleTestCreator.OutputFormatter.Brightspace.OutputFormatters
{
    class TrueFalseFormatter : IOutputFormatter<TrueFalseQuestion>
    {
        public void Format(IWriter csvWriter, TrueFalseQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("TF");
            csvWriter.WriteField("");
            csvWriter.WriteField("");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("ID");
            csvWriter.WriteField(question.Id);
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Title");
            csvWriter.WriteField(question.Text);
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
            csvWriter.WriteField(question.Points);
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
    }
}
