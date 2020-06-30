using Barotrauma_Mod_Generator.Util;
using System;
using System.IO;
using System.Windows.Forms;

namespace Barotrauma_Mod_Generator
{
    public partial class ModGeneratorForm : Form
    {
        public ModGeneratorForm()
        {
            InitializeComponent();
            BaroDirectoryTextbox.Text = Settings.Default.BaroDirectory;
            Console.SetOut(new MultiTextWriter(new ControlWriter(OutputRichTextBox), Console.Out));
            Console.Out.NewLine = "\n";
        }

        private void BaroDirectoryBrowse_Click(object sender, System.EventArgs e)
        {
            string filepath = FormUtils.ShowFolderBrowserDialog();
            BaroDirectoryTextbox.Text = filepath;
            Settings.Default.BaroDirectory = filepath;
            Settings.Default.Save();
        }

        private void OutputDirectoryBrowse_Click(object sender, System.EventArgs e)
        {
            string filepath = FormUtils.ShowFolderBrowserDialog(BaroDirectoryTextbox.Text == "" ? BaroDirectoryTextbox.Text : null);
            OutputDirectoryTextBox.Text = filepath;
        }

        private void SingleInputBrowse_Click(object sender, System.EventArgs e)
        {
            string filepath = FormUtils.ShowFileBrowserDialog(".xml");
            SingleInputTextBox.Text = filepath;
        }

        private void MultiInputBrowseButton_Click(object sender, System.EventArgs e)
        {
            string filepath = FormUtils.ShowFolderBrowserDialog(BaroDirectoryTextbox.Text == "" ? BaroDirectoryTextbox.Text : null);
            MultiInputTextBox.Text = filepath;
        }

        private void ModeTabControl_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void GoButton_Click(object sender, System.EventArgs e)
        {
            if (ModeTabControl.SelectedTab == ModeTabControl.TabPages[0])
            {
                // single
                string inputDiff = SingleInputTextBox.Text;
                string outputDirectory = OutputDirectoryTextBox.Text;
                string outputFile = Path.Combine(outputDirectory, Path.GetFileName(inputDiff));
                FormUtils.CreatePatchedFile(inputDiff, outputFile);
            }
            else
            {
                // multi
                string inputDirectory = MultiInputTextBox.Text;
                string outputDirecory = OutputDirectoryTextBox.Text;
                foreach (string inputDiff in Directory.EnumerateFiles(inputDirectory, "*.xml"))
                {
                    string outputFile = Path.Combine(outputDirecory, Path.GetFileName(inputDiff));
                    Directory.CreateDirectory(Path.GetDirectoryName(outputFile));
                    FormUtils.CreatePatchedFile(inputDiff, outputFile);
                }
            }
        }
        private void OutputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.SelectionStart = OutputRichTextBox.Text.Length;
            OutputRichTextBox.ScrollToCaret();
        }
    }
}
