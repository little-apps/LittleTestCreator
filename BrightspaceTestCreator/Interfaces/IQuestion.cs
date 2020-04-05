using System.Collections.Generic;

namespace BrightspaceTestCreator.Interfaces
{
    /// <summary>
    /// Common information for all question types.
    /// </summary>
    public interface IQuestion
    {
        int Id { get; set; }
        int Number { get; }
        string Text { get; }
        IDictionary<string, string> Extra { get; }

    }
}
