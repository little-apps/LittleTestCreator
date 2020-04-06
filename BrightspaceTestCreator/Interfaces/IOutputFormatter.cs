using System.Collections.Generic;

namespace BrightspaceTestCreator.Interfaces
{
    internal interface IOutputFormatter
    {
        void Format(IEnumerable<IQuestion> questions);
    }
}
