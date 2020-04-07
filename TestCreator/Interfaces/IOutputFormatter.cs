using System.Collections.Generic;

namespace TestCreator.Interfaces
{
    internal interface IOutputFormatter
    {
        void Format(IEnumerable<IQuestion> questions);
    }
}
