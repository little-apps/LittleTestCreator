using System.Collections.Generic;

namespace LittleTestCreator.InputConverter.Kitty
{
    public class Question
    {
        public int Number { get; set; }

        public string QuestionText { get; set; }

        public List<string> Answers { get; }

        public int CorrectAnswerIndex { get; set; }

        public Question(int number, string questionText)
        {
            Number = number;
            QuestionText = questionText;
            Answers = new List<string>();
            CorrectAnswerIndex = -1;
        }

    }
}
