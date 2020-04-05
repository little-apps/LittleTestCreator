using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrightspaceTestCreator.Interfaces
{
    interface IQuestionTypeFactory
    {
        bool CanBuild(string contents);
        IQuestion Build(string contents);
    }
}
