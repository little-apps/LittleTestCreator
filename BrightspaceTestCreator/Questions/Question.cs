﻿using System.Collections.Generic;

namespace BrightspaceTestCreator.Questions
{
    /// <summary>
    /// Common information for all question types.
    /// </summary>
    public abstract class Question
    {
        public int Id { get; set; }
        public int Number { get; }
        public string Text { get; }
        public Dictionary<string, string> Extra { get; }

        public Question(int number, string text)
        {
            Number = number;
            Text = text;
            Extra = new Dictionary<string, string>();
        }
    }
}