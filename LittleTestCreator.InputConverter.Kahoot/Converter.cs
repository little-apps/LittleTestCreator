using System;
using System.Collections.Generic;
using System.IO;
using LittleTestCreator.InputConverter.Kahoot.Factories;
using LittleTestCreator.Shared.Contracts;
using NPOI.SS.UserModel;

namespace LittleTestCreator.InputConverter.Kahoot
{
    public class Converter : IInputConverter
    {
        private readonly IWorkbook _workbook;
        private readonly string _reportSheetName;

        public Converter(string inputFile)
        {
            if (string.IsNullOrWhiteSpace(inputFile))
                throw new ArgumentException("Input file cannot be empty or null.", nameof(inputFile));

            var fileStream = File.OpenRead(inputFile);
            _workbook = WorkbookFactory.Create(fileStream);

            var lastSheetName = _workbook.GetSheetName(_workbook.NumberOfSheets - 1);

            if (string.IsNullOrWhiteSpace(lastSheetName) || !lastSheetName.ToLowerInvariant().Contains("rawreport"))
                throw new ArgumentException("Input file does not appear to be a valid Kahoot! report.", nameof(inputFile));

            _reportSheetName = lastSheetName;
        }

        public IEnumerable<IQuestion> Convert()
        {
            var sheet = _workbook.GetSheet(_reportSheetName);

            IRow lastRow = null;
            var lastRowId = "";

            // Loop through each row (skipping first row).
            for (var rowNum = 1; rowNum <= sheet.LastRowNum; rowNum++)
            {
                var row = sheet.GetRow(rowNum);

                var currentRowId = row.GetCell(0)?.StringCellValue;

                if (currentRowId != null &&
                    !currentRowId.Equals(lastRowId, StringComparison.InvariantCultureIgnoreCase))
                {
                    if (lastRow != null)
                    {
                        // Create question from last row.
                        yield return QuestionFactory.Build(lastRow);
                    }

                    // Set new last row.
                    lastRow = row;
                    lastRowId = currentRowId;
                }
            }

            // Handle last row
            yield return QuestionFactory.Build(lastRow);
        }
    }
}
