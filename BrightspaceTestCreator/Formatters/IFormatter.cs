using System.Collections.Generic;
using BrightspaceTestCreator.Questions;

namespace BrightspaceTestCreator.Formatters
{
    internal interface IFormatter
    {
        void Format(IEnumerable<Question> questions);
    }
}
