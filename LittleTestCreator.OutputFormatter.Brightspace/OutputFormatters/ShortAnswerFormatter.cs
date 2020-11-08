using CsvHelper;
using LittleTestCreator.OutputFormatter.Brightspace.Contracts;
using LittleTestCreator.Shared.Questions.ShortAnswer;

namespace LittleTestCreator.OutputFormatter.Brightspace.OutputFormatters
{
    class ShortAnswerFormatter : IOutputFormatter<ShortAnswerQuestion>
    {
        public void Format(IWriter csvWriter, ShortAnswerQuestion question)
        {
            csvWriter.NextRecord();
            csvWriter.WriteField("NewQuestion");
            csvWriter.WriteField("SA");

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

            var inputs = question.Inputs;
            var inputSize = question.Extra.ContainsKey("InputSize") ? uint.Parse(question.Extra["InputSize"]) : ShortAnswerQuestion.DefaultInputSize;

            csvWriter.NextRecord();
            csvWriter.WriteField("InputBox");
            csvWriter.WriteField(inputs);
            csvWriter.WriteField(inputSize);

            foreach (var answer in question.Answers)
            {
                csvWriter.NextRecord();
                csvWriter.WriteField("Answer");
                csvWriter.WriteField(answer.Points);
                csvWriter.WriteField(answer.Text);
            }

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
