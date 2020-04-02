using System.Collections.Generic;
using Doc2Brightspace.Questions;

namespace Doc2Brightspace.Formatters
{
    interface IFormatter
    {
        void Format(IEnumerable<Question> questions);
    }
}
