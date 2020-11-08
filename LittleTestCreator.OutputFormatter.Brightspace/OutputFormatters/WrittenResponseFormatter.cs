using CsvHelper;
using LittleTestCreator.OutputFormatter.Brightspace.Contracts;
using LittleTestCreator.Shared.Questions.WrittenResponse;

namespace LittleTestCreator.OutputFormatter.Brightspace.OutputFormatters
{
    class WrittenResponseFormatter : IOutputFormatter<WrittenResponseQuestion>
    {
        public void Format(IWriter csvWriter, WrittenResponseQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("WR");

            csvWriter.NextRecord();
            csvWriter.WriteField("ID");
            csvWriter.WriteField(question.Id);

            csvWriter.NextRecord();
            csvWriter.WriteField("Title");
            csvWriter.WriteField(question.Text);

            csvWriter.NextRecord();
            csvWriter.WriteField("QuestionText");
            csvWriter.WriteField(question.Text);

            csvWriter.NextRecord();
            csvWriter.WriteField("Points");
            csvWriter.WriteField(question.Points);
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
    }
}
