using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace WpfApp7
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            if (dlg.ShowDialog() == true)
            {
                File.WriteAllText(dlg.FileName, textBox.Text);
            }
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text documents (.txt)|*.txt"
            };

            if (dlg.ShowDialog() == true)
            {
                textBox.Text = File.ReadAllText(dlg.FileName);
            }
        }

        private void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBox.SelectedText);
        }

        private void CutButton_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.SetText(textBox.SelectedText);
            textBox.SelectedText = string.Empty;
        }

        private void BoldButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOrRemoveStyleToSelectedText(TextBlock.FontWeightProperty, FontWeights.Bold);
        }

        private void ItalicButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOrRemoveStyleToSelectedText(TextBlock.FontStyleProperty, FontStyles.Italic);
        }

        private void UnderlineButton_Click(object sender, RoutedEventArgs e)
        {
            ApplyOrRemoveStyleToSelectedText(Inline.TextDecorationsProperty, TextDecorations.Underline);
        }

        private void ApplyOrRemoveStyleToSelectedText(DependencyProperty property, object value)
        {
            if (textBox.SelectionLength > 0)
            {
                // If there is a selection, apply the style to the selected text.
                //object value1 = textBox.Selection.ApplyPropertyValue(property, value);
            }
            else
            {
                // If there is no selection, apply the style to the current caret position.
                //textBox.Selection.ApplyPropertyValue(property, value);
            }
        }
    }
}
