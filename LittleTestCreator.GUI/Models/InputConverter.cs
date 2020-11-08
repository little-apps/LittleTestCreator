using System.Collections.Generic;

namespace LittleTestCreator.GUI.Models
{
    public class InputConverter
    {
        public const string Kahoot = "Kahoot!";
        public const string Kitty = "Kitty";
        public const string OSConcepts = "Operating System Concepts";

        public string Name { get; }
        public string Filters { get; }

        public InputConverter(string name, string filters)
        {
            Name = name;
            Filters = filters;
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<InputConverter> BuildInputConverters()
        {
            return new List<InputConverter>
            {
                new InputConverter(Kahoot, "Kahoot Report (*.xlsx)|*.xlsx|All files (*.*)|*.*"),
                new InputConverter(Kitty, "Word Document (*.doc)|*.doc|Word Document XML (*.docx)|*.docx|All files (*.*)|*.*"),
                new InputConverter(OSConcepts, "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*")
            };
        }
    }
}
