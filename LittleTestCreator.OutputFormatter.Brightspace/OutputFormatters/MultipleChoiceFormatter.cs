using CsvHelper;
using System.Linq;
using LittleTestCreator.OutputFormatter.Brightspace.Contracts;
using LittleTestCreator.Shared.Questions.MultipleChoice;

namespace LittleTestCreator.OutputFormatter.Brightspace.OutputFormatters
{
    class MultipleChoiceFormatter : IOutputFormatter<MultipleChoiceQuestion>
    {
        public void Format(IWriter csvWriter, MultipleChoiceQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("MC");
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("ID");
            csvWriter.WriteField(question.Id);
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Title");
            csvWriter.WriteField(question.Text);
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("QuestionText");
            csvWriter.WriteField(question.Text);
            csvWriter.WriteField("");

            csvWriter.NextRecord();
            csvWriter.WriteField("Points");
            csvWriter.WriteField(question.Points);
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
                var points = question.Answers.Contains(choice) ? 100 : 0;

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
    }
}
