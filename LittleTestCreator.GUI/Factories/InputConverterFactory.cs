using LittleTestCreator.Shared.Contracts;
using KittyConverter = LittleTestCreator.InputConverter.Kitty.Converter;
using OSConverter = LittleTestCreator.InputConverter.OSConcepts.Converter;
using KahootConverter = LittleTestCreator.InputConverter.Kahoot.Converter;

namespace LittleTestCreator.GUI.Factories
{
    internal static class InputConverterFactory
    {
        /// <summary>
        /// Builds <seealso cref="IInputConverter"/> using options to convert input file.
        /// </summary>
        /// <param name="viewModel"><seealso cref="ViewModel"/> from command line.</param>
        /// <returns>Instance of <seealso cref="IInputConverter"/></returns>
        public static IInputConverter Build(ViewModel viewModel)
        {
            var inputConverter = (Models.InputConverter) viewModel.Inputs.CurrentItem;

            switch (inputConverter.Name)
            {
                case Models.InputConverter.Kitty:
                    return new KittyConverter(viewModel.SourceFile, int.Parse(viewModel.SkipPageBreaks));
                case Models.InputConverter.Kahoot:
                    return new KahootConverter(viewModel.SourceFile);
                case Models.InputConverter.OSConcepts:
                default:
                    return new OSConverter(viewModel.SourceFile);
            }
        }
    }
}
