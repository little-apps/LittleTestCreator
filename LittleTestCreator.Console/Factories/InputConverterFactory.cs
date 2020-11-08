using LittleTestCreator.Shared.Contracts;
using KittyConverter = LittleTestCreator.InputConverter.Kitty.Converter;
using OSConverter = LittleTestCreator.InputConverter.OSConcepts.Converter;
using KahootConverter = LittleTestCreator.InputConverter.Kahoot.Converter;

namespace LittleTestCreator.Console.Factories
{
    internal static class InputConverterFactory
    {
        /// <summary>
        /// Builds <seealso cref="IInputConverter"/> using options to convert input file.
        /// </summary>
        /// <param name="o"><seealso cref="Options"/> from command line.</param>
        /// <returns>Instance of <seealso cref="IInputConverter"/></returns>
        public static IInputConverter Build(Options o)
        {
            switch (o.InputFormat)
            {
                case Options.InputFormats.Kitty:
                    return new KittyConverter(o.SourceFile, o.SkipPageBreaks);
                case Options.InputFormats.Kahoot:
                    return new KahootConverter(o.SourceFile);
                case Options.InputFormats.OsConcepts:
                default:
                    return new OSConverter(o.SourceFile);
            }
        }
    }
}
