using System.Collections.Generic;

namespace LittleTestCreator.GUI.Models
{
    class OutputFormatter
    {
        public const string Brightspace = "Brightspace";

        public string Name { get; }
        public string Filters { get; }

        public OutputFormatter(string name, string filters)
        {
            Name = name;
            Filters = filters;
        }

        public override string ToString()
        {
            return Name;
        }

        public static IEnumerable<OutputFormatter> BuildOutputFormatters()
        {
            return new List<OutputFormatter>
            {
                new OutputFormatter(Brightspace, "Brightspace Format (*.csv)|*.csv|All files (*.*)|*.*")
            };
        }
    }
}
