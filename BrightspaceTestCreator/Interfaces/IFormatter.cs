using System.Collections.Generic;
using BrightspaceTestCreator.Questions;

namespace BrightspaceTestCreator.Interfaces
{
    internal interface IFormatter
    {
        void Format(IEnumerable<IQuestion> questions);
    }
}
