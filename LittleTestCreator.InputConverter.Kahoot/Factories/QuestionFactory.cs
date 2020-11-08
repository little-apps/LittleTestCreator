using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using LittleTestCreator.InputConverter.Kahoot.Exceptions;
using LittleTestCreator.Shared.Contracts;
using NPOI.SS.UserModel;

namespace LittleTestCreator.InputConverter.Kahoot.Factories
{
    internal static class QuestionFactory
    {
        /// <summary>
        /// Creates a question from a row in the Excel spreadsheet.
        /// </summary>
        /// <param name="row"><seealso cref="IRow"/> in Excel spreadsheet.</param>
        /// <returns>Either a short answer, multiple choice, or true/false question implementation of <seealso cref="IQuestion"/></returns>
        /// <exception cref="UnknownQuestionTypeException">Thrown if unable to determine type of question.</exception>
        internal static IQuestion Build(IRow row)
        {
            var idType = row.GetCell(0).StringCellValue.ToLowerInvariant();

            var idText = Regex.Match(idType, "(\\d+)").Groups[1].Value;
            var id = int.Parse(idText);

            var question = row.GetCell(1).StringCellValue;

            var answers = GetAnswerCells(row);

            var correctCell = row.GetCell(6);
            var correctAnswers = GetCorrectAnswers(answers, correctCell);
            

            if (idType.Contains("open-ended"))
            {
                return ShortAnswerQuestionFactory.Build(id, question, answers);
            } 
            else if (idType.Contains("quiz"))
            {
                // Can be T/F or MC.

                if (answers.Count == 2 && 
                    answers[0].Equals("true", StringComparison.InvariantCultureIgnoreCase) &&
                    answers[1].Equals("false", StringComparison.InvariantCultureIgnoreCase))
                {
                    var answer = correctAnswers.First();

                    // T/F question
                    return TrueFalseQuestionFactory.Build(id, question,
                        answer.Equals("true", StringComparison.InvariantCultureIgnoreCase));
                }

                return MultipleChoiceQuestionFactory.Build(id, question, answers, correctAnswers);
            }
            else
            {
                throw new UnknownQuestionTypeException($"Cannot determine question type from {id}");
            }

        }

        /// <summary>
        /// This method uses the answers put by players to cross-reference the correct answers.
        /// The report contains a single cell containing all of the correct answers separated by comma.
        /// Since an answer can contain a comma, this method needs to check if a comma is part of an answer or it means it's another answer.
        /// </summary>
        /// <param name="answers">Answers put by players.</param>
        /// <param name="cell">Cell containing answers seperated by commas</param>
        /// <returns>List of correct answers to question.</returns>
        private static IEnumerable<string> GetCorrectAnswers(ICollection<string> answers, ICell cell)
        {
            var value = cell.StringCellValue;

            if (!value.Contains(",") || answers.Contains(value))
            {
                yield return value;
                yield break;
            }

            var currentAnswer = "";

            var parts = value.Split(',');

            foreach (var part in parts)
            {
                currentAnswer += part;

                if (answers.Contains(currentAnswer.Trim()))
                {
                    yield return currentAnswer.Trim();
                    currentAnswer = "";
                } 
                else
                {
                    currentAnswer += ",";
                }
            }

            /*using (var memStream = new MemoryStream(Encoding.UTF8.GetBytes(value)))
            {
                memStream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(memStream))
                {
                    using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        csvReader.Configuration.HasHeaderRecord = false;

                        csvReader.Read();

                        for (var i = 0; csvReader.TryGetField(i, out value); i++)
                        {
                            if (answers.Contains(value))
                            {
                                yield return value;
                            }
                        }
                    }
                }

            }*/
        }

        /// <summary>
        /// Gets all answers from players.
        /// </summary>
        /// <param name="row">Row containing answers</param>
        /// <returns>Any answers found in cells 2-5 in row.</returns>
        private static IList<string> GetAnswerCells(IRow row)
        {
            var answers = new List<string>();

            for (var cellNum = 2; cellNum <= 5; cellNum++)
            {
                var cellValue = row.GetCell(cellNum).StringCellValue;

                if (!string.IsNullOrWhiteSpace(cellValue))
                    answers.Add(cellValue);
            }

            return answers;
        }
    }
}
