using System;
using LittleTestCreator.Shared.Contracts;

namespace LittleTestCreator.Shared.Questions.ShortAnswer
{
    /// <summary>
    /// Represents the answer to written response question.
    /// </summary>
    public class ShortAnswer : IAnswer<ShortAnswerQuestion>
    {
        public ShortAnswerQuestion Owner { get; set; }
        public string Text { get; }
        public uint Points { get; }

        public ShortAnswer(string text, uint points = 100)
        {
            if (points > 100)
                throw new ArgumentOutOfRangeException(nameof(points), "Points cannot be greater than 100.");

            Text = text;
            Points = points;
        }
    }
}
