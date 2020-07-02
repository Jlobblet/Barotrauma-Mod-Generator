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

        private void BaroDirectoryBrowse_Click(object sender, EventArgs e)
        {
            string filepath = FormUtils.ShowFolderBrowserDialog();
            BaroDirectoryTextbox.Text = filepath;
            Settings.Default.BaroDirectory = filepath;
            Settings.Default.Save();
        }

        private void OutputDirectoryBrowse_Click(object sender, EventArgs e)
        {
            string filepath = FormUtils.ShowFolderBrowserDialog(BaroDirectoryTextbox.Text == "" ? BaroDirectoryTextbox.Text : null);
            OutputDirectoryTextBox.Text = filepath;
        }

        private void SingleInputBrowse_Click(object sender, EventArgs e)
        {
            string filepath = FormUtils.ShowFileBrowserDialog(".xml");
            SingleInputTextBox.Text = filepath;
        }

        private void MultiInputBrowseButton_Click(object sender, EventArgs e)
        {
            string filepath = FormUtils.ShowFolderBrowserDialog(BaroDirectoryTextbox.Text == "" ? BaroDirectoryTextbox.Text : null);
            MultiInputTextBox.Text = filepath;
        }

        private void ModeTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if (ModeTabControl.SelectedTab == ModeTabControl.TabPages[0])
            {
                // single
                string inputDiff = SingleInputTextBox.Text;
                string outputDirectory = OutputDirectoryTextBox.Text;
                FormUtils.CreatePatchedFile(inputDiff, outputDirectory, BaroDirectoryTextbox.Text);
            }
            else
            {
                // multi
                string inputDirectory = MultiInputTextBox.Text;
                string outputDirectory = OutputDirectoryTextBox.Text;
                Console.WriteLine("Creating files from diffs found in {0}", inputDirectory);
                foreach (string inputDiff in Directory.EnumerateFiles(inputDirectory, "*.xml", SearchOption.AllDirectories))
                {
                    string relativeOutputDirectory = Path.GetRelativePath(inputDirectory, inputDiff);
                    FormUtils.CreatePatchedFile(inputDiff, Path.Combine(outputDirectory, relativeOutputDirectory), BaroDirectoryTextbox.Text);
                }
                Console.WriteLine("Finished!");
            }
        }

        private void OutputRichTextBox_TextChanged(object sender, EventArgs e)
        {
            OutputRichTextBox.SelectionStart = OutputRichTextBox.Text.Length;
            OutputRichTextBox.ScrollToCaret();
        }
    }
}
