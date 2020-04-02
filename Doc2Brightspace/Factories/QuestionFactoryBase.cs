using System.Text.RegularExpressions;
using Doc2Brightspace.Questions;

namespace Doc2Brightspace.Factories
{
    public abstract class QuestionFactoryBase
    {
        private Regex _difficultyRegex = new Regex(@"Difficulty: (.*)");
        private Regex _feedbackRegex = new Regex(@"Feedback: (.*)");

        public abstract bool CanBuild(string contents);
        public abstract Question Build(string contents);

        public void InsertExtras(string contents, Question question)
        {
            var difficultyMatch = _difficultyRegex.Match(contents);

            if (difficultyMatch.Success && difficultyMatch.Groups[1].Value.Trim() != "")
            {
                int difficulty;
                
                switch (difficultyMatch.Groups[1].Value.Trim().ToLower())
                {
                    case "medium":
                    case "moderate":
                        {
                            difficulty = 2;
                            break;
                        }

                    case "hard":
                        {
                            difficulty = 3;
                            break;
                        }

                    default:
                        {
                            difficulty = 1;
                            break;
                        }
                }

                question.Extra.Add("difficulty", difficulty.ToString());
            }

            var feedbackMatch = _feedbackRegex.Match(contents);

            if (feedbackMatch.Success && feedbackMatch.Groups[1].Value.Trim() != "")
                question.Extra.Add("feedback", feedbackMatch.Groups[1].Value.Trim());
        }
    }
}
