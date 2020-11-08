using System;
using System.Linq;
using System.Windows;
using LittleTestCreator.GUI.Factories;
using Microsoft.Win32;

namespace LittleTestCreator.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public ViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ViewModel = new ViewModel();
            DataContext = ViewModel;
        }

        private void buttonSourceFileBrowse_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                Multiselect = false
            };

            var inputConverter = (Models.InputConverter) ViewModel.Inputs.CurrentItem;
            openFileDialog.Filter = inputConverter.Filters;

            if (openFileDialog.ShowDialog(this).GetValueOrDefault())
            {
                ViewModel.SourceFile = openFileDialog.FileNames[0];
            }
        }

        private void buttonDestinationFileBrowse_Click(object sender, RoutedEventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
            {
                CheckPathExists = true
            };

            var outputConverter = (Models.OutputFormatter) ViewModel.Outputs.CurrentItem;
            saveFileDialog.Filter = outputConverter.Filters;

            if (saveFileDialog.ShowDialog(this).GetValueOrDefault())
            {
                ViewModel.DestinationFile = saveFileDialog.FileName;
            }
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ViewModel.Validate();

                var converter = InputConverterFactory.Build(ViewModel);
                var questions = converter.Convert().ToArray();

                var formatter = OutputFormatterFactory.Build(ViewModel);
                formatter.Format(questions);

                MessageBox.Show(this, $"Generated file at '{ViewModel.DestinationFile}' with {questions.Length} questions.",
                    "Test Creator", MessageBoxButton.OK, MessageBoxImage.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message, "Test Creator", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
