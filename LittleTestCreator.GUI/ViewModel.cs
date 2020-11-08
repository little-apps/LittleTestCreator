using System.ComponentModel;
using System.IO;
using System.Windows.Data;
using LittleTestCreator.GUI.Exceptions;

namespace LittleTestCreator.GUI
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _sourceFile;
        private string _destFile;
        private string _skipPageBreaks;
        
        public CollectionView Inputs { get; }
        public CollectionView Outputs { get; }

        public string SourceFile
        {
            get => _sourceFile;
            set
            {
                _sourceFile = value;
                OnPropertyChanged(nameof(SourceFile));
            }
        }

        public string DestinationFile
        {
            get => _destFile;
            set
            {
                _destFile = value;
                OnPropertyChanged(nameof(DestinationFile));
            }
        }

        public string SkipPageBreaks
        {
            get => _skipPageBreaks;
            set
            {
                _skipPageBreaks = value;
                OnPropertyChanged(nameof(SkipPageBreaks));
            }
        }

        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ViewModel()
        {
            SourceFile = "";
            DestinationFile = "";
            SkipPageBreaks = "0";

            Inputs = new CollectionView(Models.InputConverter.BuildInputConverters());
            Outputs = new CollectionView(Models.OutputFormatter.BuildOutputFormatters());
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(SourceFile))
                throw new InvalidOptionException(nameof(SourceFile), "No source file is specified.");

            if (!File.Exists(SourceFile))
                throw new InvalidOptionException(nameof(SourceFile), "Source file could not be found.");

            if (string.IsNullOrEmpty(DestinationFile))
                throw new InvalidOptionException(nameof(DestinationFile), "No destination file is specified.");

            if (((Models.InputConverter) Inputs.CurrentItem).Name == Models.InputConverter.Kitty)
            {
                if (!uint.TryParse(SkipPageBreaks, out _))
                    throw new InvalidOptionException(nameof(SkipPageBreaks), "Skip page breaks is not a valid number.");
            }
        }
    }
}
