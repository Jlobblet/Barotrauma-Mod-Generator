using System;
using System.IO;
using System.Windows.Forms;
using Barotrauma_Mod_Generator.Util;

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
            string filepath =
                FormUtils.ShowFolderBrowserDialog(BaroDirectoryTextbox.Text == "" ? BaroDirectoryTextbox.Text : null);
            OutputDirectoryTextBox.Text = filepath;
        }

        private void SingleInputBrowse_Click(object sender, EventArgs e)
        {
            string filepath = FormUtils.ShowFileBrowserDialog(".xml");
            SingleInputTextBox.Text = filepath;
        }

        private void MultiInputBrowseButton_Click(object sender, EventArgs e)
        {
            string filepath =
                FormUtils.ShowFolderBrowserDialog(BaroDirectoryTextbox.Text == "" ? BaroDirectoryTextbox.Text : null);
            MultiInputTextBox.Text = filepath;
        }

        private void ModeTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            string baroRootDirectory = BaroDirectoryTextbox.Text;
            if (!Directory.Exists(baroRootDirectory))
                throw new ArgumentException("The Barotrauma Root Directory provided does not exist.");
            string outputDirectory = OutputDirectoryTextBox.Text;
            if (!Directory.Exists(outputDirectory))
                throw new ArgumentException("The output directory provided does not exist.");
            if (ModeTabControl.SelectedTab == ModeTabControl.TabPages[0])
            {
                // single
                string inputDiff = SingleInputTextBox.Text;
                FormUtils.CreatePatchedFile(inputDiff, outputDirectory, baroRootDirectory);
            }
            else
            {
                // multi
                string inputDirectory = MultiInputTextBox.Text;
                Console.WriteLine($"Creating files from diffs found in {inputDirectory}");
                foreach (string inputDiff in Directory.EnumerateFiles(inputDirectory, "*.*",
                                                                      SearchOption.AllDirectories))
                {
                    string relativeOutputDirectory =
                        Path.GetRelativePath(inputDirectory, Path.GetDirectoryName(inputDiff)!);
                    string outputFileDirectory = Path.Combine(outputDirectory, relativeOutputDirectory);
                    Directory.CreateDirectory(outputFileDirectory);
                    if (Path.GetExtension(inputDiff) == ".xml")
                        FormUtils.CreatePatchedFile(inputDiff, outputFileDirectory, baroRootDirectory);
                    else
                        File.Copy(inputDiff, Path.Combine(outputFileDirectory, Path.GetFileName(inputDiff)), true);
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
