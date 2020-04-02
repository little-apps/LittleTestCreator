using System.Collections.Generic;
using Doc2Brightspace.Questions;

namespace Doc2Brightspace.Parsers
{
    interface IParser
    {
        List<Question> Parse(string content);
    }
}
