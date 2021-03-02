using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml.Linq;
using Barotrauma_Mod_Generator.PatchOperations;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Barotrauma_Mod_Generator.Util
{
    internal static class FormUtils
    {
        public static string ShowFolderBrowserDialog()
        {
            using var dialog = new CommonOpenFileDialog
                               {
                                   IsFolderPicker = true,
                                   EnsureFileExists = true,
                                   EnsurePathExists = true
                               };
            return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : "";
        }

        public static string ShowFolderBrowserDialog(string defaultDirectory)
        {
            using var dialog = new CommonOpenFileDialog
                               {
                                   IsFolderPicker = true,
                                   EnsureFileExists = true,
                                   EnsurePathExists = true,
                                   DefaultDirectory = defaultDirectory
                               };
            return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : "";
        }

        public static string ShowFileBrowserDialog(string extension = "")
        {
            using var dialog = new CommonOpenFileDialog
                               {
                                   EnsureFileExists = true,
                                   EnsurePathExists = true
                               };
            dialog.FileOk += (sender, parameter) =>
                             {
                                 var commonOpenFileDialog = (CommonOpenFileDialog) sender;
                                 var filenames = new Collection<string>();
                                 typeof(CommonOpenFileDialog)
                                     .GetMethod("PopulateWithFileNames", BindingFlags.Instance | BindingFlags.NonPublic)
                                     ?.Invoke(commonOpenFileDialog, new object[] {filenames});
                                 string filename = filenames[0];
                                 if (extension != "" && Path.GetExtension(filename) != extension)
                                 {
                                     parameter.Cancel = true;
                                     MessageBox.Show($"The selected file does not have the extension {extension}.",
                                                     "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                 }
                             };
            return dialog.ShowDialog() == CommonFileDialogResult.Ok ? dialog.FileName : "";
        }

        public static IEnumerable<string> DiscoverDirectories(string filepath)
        {
            return Directory.GetDirectories(filepath, "*", SearchOption.AllDirectories);
        }

        public static void CreateDirectories(IEnumerable<string> filepaths)
        {
            foreach (string filepath in filepaths) Directory.CreateDirectory(filepath);
        }

        public static void CreatePatchedFile(string inputFilepath, string outputDirectory, string baroDirectory)
        {
            string outputFile = Path.Combine(outputDirectory, Path.GetFileName(inputFilepath));
            Console.WriteLine("Creating file from {0}", inputFilepath);
            XDocument diff = XDocument.Load(inputFilepath);
            // if the input file is not a diff, assume it is a non-diff mod file to be copied across
            XDocument patched;
            if (Directory.Exists(baroDirectory))
                patched = ApplyPatchOperation.ApplyAll(diff, baroDirectory) ?? diff;
            else
                patched = ApplyPatchOperation.ApplyAll(diff) ?? diff;

            patched.Save(outputFile);
            Console.WriteLine("Saved to {0}", outputFile);
        }
    }
}
