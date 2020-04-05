using System.Text.RegularExpressions;
using BrightspaceTestCreator.Interfaces;
using BrightspaceTestCreator.Questions;

namespace BrightspaceTestCreator.Factories
{
    public abstract class QuestionFactoryBase
    {
        private readonly Regex _difficultyRegex = new Regex(@"Difficulty: (.*)");
        private readonly Regex _feedbackRegex = new Regex(@"Feedback: (.*)");

        public abstract bool CanBuild(string contents);
        public abstract IQuestion Build(string contents);

        public void InsertExtras(string contents, IQuestion question)
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
