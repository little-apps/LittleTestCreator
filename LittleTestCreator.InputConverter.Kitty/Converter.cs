﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using LittleTestCreator.InputConverter.Kitty.Factories;
using LittleTestCreator.Shared.Contracts;
using NPOI.XWPF.UserModel;

namespace LittleTestCreator.InputConverter.Kitty
{
    public class Converter : IInputConverter
    {
        private readonly Color _answerColor = Color.Red;

        private readonly string _sourceFile;
        private readonly int _skipPageBreaks;

        /// <summary>
        /// Constructor for Converter.
        /// </summary>
        /// <param name="sourceFile">Path of source Word document</param>
        /// <param name="skipPageBreaks">Number of page breaks to skip before reading</param>
        /// <exception cref="ArgumentException">Thrown if source file is null, empty, or whitespace.</exception>
        public Converter(string sourceFile, int skipPageBreaks)
        {
            if (string.IsNullOrWhiteSpace(sourceFile))
                throw new ArgumentException("Source file cannot be null, empty, or whitespace.", nameof(sourceFile));

            _sourceFile = sourceFile;
            _skipPageBreaks = skipPageBreaks;
        }

        /// <inheritdoc />
        /// <exception cref="IOException">Thrown if there is an error opening or reading the source file.</exception>
        public IEnumerable<IQuestion> Convert()
        {
            var fileStream = File.OpenRead(_sourceFile);
            var doc = new XWPFDocument(fileStream);

            var questions = 0;

            Question currentQuestion = null;
            var inQuestion = false;
            var answers = 1;
            var skippedPageBreaks = 0;

            foreach (var paragraph in doc.Paragraphs)
            {
                // Skip # of pages
                if (skippedPageBreaks < _skipPageBreaks)
                {
                    // paragraph.IsPageBreak is useless, need to find break in runs.
                    if (paragraph.Runs.Select(textRun => textRun.GetCTR()).Any(ctr => ctr.SizeOfBrArray() > 0))
                    {
                        questions = 0;
                        currentQuestion = null;
                        skippedPageBreaks++;
                    }
                }

                var numFormat = paragraph.GetNumFmt();

                // Check are we at a new question or answer?
                switch (numFormat)
                {
                    case "decimal": // Decimal ordered list means new question
                    {
                        inQuestion = true;

                        if (currentQuestion != null && skippedPageBreaks == _skipPageBreaks)
                            yield return QuestionFactory.Build(currentQuestion);

                        // Reset variables
                        currentQuestion = new Question(++questions, paragraph.Text);

                        answers = 0;
                        break;
                    }
                    
                    case "lowerLetter": // Letter ordered list means new answer.
                    {
                        currentQuestion?.Answers.Add(paragraph.Text);

                        // Check if answer is answer color
                        var color = DetermineParagraphColor(paragraph);

                        if (color.HasValue && currentQuestion != null)
                        {
                            if (IsAnswer(paragraph))
                            {
                                // This is the answer.
                                currentQuestion.CorrectAnswerIndex = answers;
                            }

                        }
                  
                        inQuestion = false;
                        answers++;

                        break;
                    }

                    default: // More text in question or answer.
                    {
                        if (inQuestion && currentQuestion != null)
                        {
                            if (IsAnswer(paragraph))
                            {
                                inQuestion = false;

                                currentQuestion.Answers.Add(paragraph.Text);
                            }
                            else
                            {
                                currentQuestion.QuestionText += paragraph.Text;
                            }
                            
                        }
                        else if (currentQuestion != null && currentQuestion.Answers.Count > 0)
                        {
                            currentQuestion.Answers[currentQuestion.Answers.Count - 1] += paragraph.Text;
                        }

                        break;
                    }
                }
            }

            // Get last remaining question.
            if (currentQuestion != null)
            {
                yield return QuestionFactory.Build(currentQuestion);
            }

        }

        /// <summary>
        /// Determines the color of text in a <seealso cref="XWPFParagraph"/>
        /// </summary>
        /// <param name="paragraph">Paragraph in Word document</param>
        /// <returns>Color as <seealso cref="Color"/> or null if unable to determine.</returns>
        private static Color? DetermineParagraphColor(XWPFParagraph paragraph)
        {
            if (paragraph.Runs.Count == 0)
                return null;

            // Color is returned as hex string "FF0000" (Why? Who knows!)
            var colorText = paragraph.Runs[0].GetColor();
            var colorNum = System.Convert.ToInt32(colorText, 16);

            return Color.FromArgb(colorNum);
        }

        /// <summary>
        /// Checks if paragraph is answer.
        /// </summary>
        /// <param name="paragraph">Paragraph to check</param>
        /// <returns>True if paragraph is answer.</returns>
        private bool IsAnswer(XWPFParagraph paragraph)
        {
            var color = DetermineParagraphColor(paragraph);

            if (!color.HasValue)
                return false;

            return color.Value.R == _answerColor.R && color.Value.G == _answerColor.G &&
                   color.Value.B == _answerColor.B;
        }
    }
}
