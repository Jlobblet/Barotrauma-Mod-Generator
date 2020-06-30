namespace Barotrauma_Mod_Generator
{
    partial class ModGeneratorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BarotraumaDirectoryGroupBox = new System.Windows.Forms.GroupBox();
            this.BaroDirectoryTextbox = new System.Windows.Forms.TextBox();
            this.BaroDirectoryBrowse = new System.Windows.Forms.Button();
            this.OutputDirectoryTextBox = new System.Windows.Forms.TextBox();
            this.OutputDirectoryBrowse = new System.Windows.Forms.Button();
            this.OutputDirectoryGroupBox = new System.Windows.Forms.GroupBox();
            this.ModeTabControl = new System.Windows.Forms.TabControl();
            this.SingleInputTab = new System.Windows.Forms.TabPage();
            this.SingleInputBrowseButton = new System.Windows.Forms.Button();
            this.SingleInputTextBox = new System.Windows.Forms.TextBox();
            this.MultiInputTab = new System.Windows.Forms.TabPage();
            this.MultiInputBrowseButton = new System.Windows.Forms.Button();
            this.MultiInputTextBox = new System.Windows.Forms.TextBox();
            this.GoButton = new System.Windows.Forms.Button();
            this.OutputRichTextBox = new System.Windows.Forms.RichTextBox();
            this.BarotraumaDirectoryGroupBox.SuspendLayout();
            this.OutputDirectoryGroupBox.SuspendLayout();
            this.ModeTabControl.SuspendLayout();
            this.SingleInputTab.SuspendLayout();
            this.MultiInputTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // BarotraumaDirectoryGroupBox
            // 
            this.BarotraumaDirectoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BarotraumaDirectoryGroupBox.Controls.Add(this.BaroDirectoryTextbox);
            this.BarotraumaDirectoryGroupBox.Controls.Add(this.BaroDirectoryBrowse);
            this.BarotraumaDirectoryGroupBox.Location = new System.Drawing.Point(12, 12);
            this.BarotraumaDirectoryGroupBox.Name = "BarotraumaDirectoryGroupBox";
            this.BarotraumaDirectoryGroupBox.Size = new System.Drawing.Size(802, 65);
            this.BarotraumaDirectoryGroupBox.TabIndex = 0;
            this.BarotraumaDirectoryGroupBox.TabStop = false;
            this.BarotraumaDirectoryGroupBox.Text = "Barotrauma Root Directory";
            // 
            // BaroDirectoryTextbox
            // 
            this.BaroDirectoryTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BaroDirectoryTextbox.Location = new System.Drawing.Point(6, 26);
            this.BaroDirectoryTextbox.Name = "BaroDirectoryTextbox";
            this.BaroDirectoryTextbox.Size = new System.Drawing.Size(719, 27);
            this.BaroDirectoryTextbox.TabIndex = 0;
            // 
            // BaroDirectoryBrowse
            // 
            this.BaroDirectoryBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BaroDirectoryBrowse.Location = new System.Drawing.Point(731, 26);
            this.BaroDirectoryBrowse.Name = "BaroDirectoryBrowse";
            this.BaroDirectoryBrowse.Size = new System.Drawing.Size(65, 27);
            this.BaroDirectoryBrowse.TabIndex = 1;
            this.BaroDirectoryBrowse.Text = "Browse";
            this.BaroDirectoryBrowse.UseVisualStyleBackColor = true;
            this.BaroDirectoryBrowse.Click += new System.EventHandler(this.BaroDirectoryBrowse_Click);
            // 
            // OutputDirectoryTextbox
            // 
            this.OutputDirectoryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDirectoryTextBox.Location = new System.Drawing.Point(6, 26);
            this.OutputDirectoryTextBox.Name = "OutputDirectoryTextbox";
            this.OutputDirectoryTextBox.Size = new System.Drawing.Size(719, 27);
            this.OutputDirectoryTextBox.TabIndex = 2;
            // 
            // OutputDirectoryBrowse
            // 
            this.OutputDirectoryBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDirectoryBrowse.Location = new System.Drawing.Point(731, 26);
            this.OutputDirectoryBrowse.Name = "OutputDirectoryBrowse";
            this.OutputDirectoryBrowse.Size = new System.Drawing.Size(65, 27);
            this.OutputDirectoryBrowse.TabIndex = 3;
            this.OutputDirectoryBrowse.Text = "Browse";
            this.OutputDirectoryBrowse.UseVisualStyleBackColor = true;
            this.OutputDirectoryBrowse.Click += new System.EventHandler(this.OutputDirectoryBrowse_Click);
            // 
            // OutputDirectoryGroupBox
            // 
            this.OutputDirectoryGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputDirectoryGroupBox.Controls.Add(this.OutputDirectoryTextBox);
            this.OutputDirectoryGroupBox.Controls.Add(this.OutputDirectoryBrowse);
            this.OutputDirectoryGroupBox.Location = new System.Drawing.Point(12, 83);
            this.OutputDirectoryGroupBox.Name = "OutputDirectoryGroupBox";
            this.OutputDirectoryGroupBox.Size = new System.Drawing.Size(802, 65);
            this.OutputDirectoryGroupBox.TabIndex = 0;
            this.OutputDirectoryGroupBox.TabStop = false;
            this.OutputDirectoryGroupBox.Text = "Output Directory";
            // 
            // ModeTabControl
            // 
            this.ModeTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ModeTabControl.Controls.Add(this.SingleInputTab);
            this.ModeTabControl.Controls.Add(this.MultiInputTab);
            this.ModeTabControl.Location = new System.Drawing.Point(12, 154);
            this.ModeTabControl.Name = "ModeTabControl";
            this.ModeTabControl.SelectedIndex = 1;
            this.ModeTabControl.Size = new System.Drawing.Size(802, 64);
            this.ModeTabControl.TabIndex = 4;
            this.ModeTabControl.SelectedIndexChanged += new System.EventHandler(this.ModeTabControl_SelectedIndexChanged);
            // 
            // SingleInputTab
            // 
            this.SingleInputTab.BackColor = System.Drawing.Color.Transparent;
            this.SingleInputTab.Controls.Add(this.SingleInputBrowseButton);
            this.SingleInputTab.Controls.Add(this.SingleInputTextBox);
            this.SingleInputTab.Location = new System.Drawing.Point(4, 29);
            this.SingleInputTab.Name = "SingleInputTab";
            this.SingleInputTab.Padding = new System.Windows.Forms.Padding(3);
            this.SingleInputTab.Size = new System.Drawing.Size(794, 31);
            this.SingleInputTab.TabIndex = 0;
            this.SingleInputTab.Text = "Single Input";
            // 
            // SingleInputBrowseButton
            // 
            this.SingleInputBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SingleInputBrowseButton.Location = new System.Drawing.Point(726, 3);
            this.SingleInputBrowseButton.Name = "SingleInputBrowseButton";
            this.SingleInputBrowseButton.Size = new System.Drawing.Size(65, 27);
            this.SingleInputBrowseButton.TabIndex = 6;
            this.SingleInputBrowseButton.Text = "Browse";
            this.SingleInputBrowseButton.UseVisualStyleBackColor = true;
            this.SingleInputBrowseButton.Click += new System.EventHandler(this.SingleInputBrowse_Click);
            // 
            // SingleInputTextBox
            // 
            this.SingleInputTextBox.AllowDrop = true;
            this.SingleInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SingleInputTextBox.Location = new System.Drawing.Point(3, 3);
            this.SingleInputTextBox.Name = "SingleInputTextBox";
            this.SingleInputTextBox.Size = new System.Drawing.Size(718, 27);
            this.SingleInputTextBox.TabIndex = 5;
            // 
            // MultiInputTab
            // 
            this.MultiInputTab.BackColor = System.Drawing.Color.Transparent;
            this.MultiInputTab.Controls.Add(this.MultiInputBrowseButton);
            this.MultiInputTab.Controls.Add(this.MultiInputTextBox);
            this.MultiInputTab.Location = new System.Drawing.Point(4, 29);
            this.MultiInputTab.Name = "MultiInputTab";
            this.MultiInputTab.Padding = new System.Windows.Forms.Padding(3);
            this.MultiInputTab.Size = new System.Drawing.Size(794, 31);
            this.MultiInputTab.TabIndex = 1;
            this.MultiInputTab.Text = "Folder Input";
            // 
            // MultiInputBrowseButton
            // 
            this.MultiInputBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MultiInputBrowseButton.Location = new System.Drawing.Point(726, 3);
            this.MultiInputBrowseButton.Name = "MultiInputBrowseButton";
            this.MultiInputBrowseButton.Size = new System.Drawing.Size(65, 27);
            this.MultiInputBrowseButton.TabIndex = 6;
            this.MultiInputBrowseButton.Text = "Browse";
            this.MultiInputBrowseButton.UseVisualStyleBackColor = true;
            this.MultiInputBrowseButton.Click += new System.EventHandler(this.MultiInputBrowseButton_Click);
            // 
            // MultiInputTextBox
            // 
            this.MultiInputTextBox.AllowDrop = true;
            this.MultiInputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MultiInputTextBox.Location = new System.Drawing.Point(3, 3);
            this.MultiInputTextBox.Name = "MultiInputTextBox";
            this.MultiInputTextBox.Size = new System.Drawing.Size(718, 27);
            this.MultiInputTextBox.TabIndex = 5;
            // 
            // GoButton
            // 
            this.GoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.GoButton.Location = new System.Drawing.Point(646, 220);
            this.GoButton.Name = "GoButton";
            this.GoButton.Size = new System.Drawing.Size(168, 58);
            this.GoButton.TabIndex = 7;
            this.GoButton.Text = "Go";
            this.GoButton.UseVisualStyleBackColor = true;
            this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
            // 
            // OutputRichTextBox
            // 
            this.OutputRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OutputRichTextBox.Location = new System.Drawing.Point(12, 220);
            this.OutputRichTextBox.Name = "OutputRichTextBox";
            this.OutputRichTextBox.Size = new System.Drawing.Size(628, 58);
            this.OutputRichTextBox.TabIndex = 8;
            this.OutputRichTextBox.Text = "";
            // 
            // ModGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 290);
            this.Controls.Add(this.OutputRichTextBox);
            this.Controls.Add(this.GoButton);
            this.Controls.Add(this.ModeTabControl);
            this.Controls.Add(this.OutputDirectoryGroupBox);
            this.Controls.Add(this.BarotraumaDirectoryGroupBox);
            this.MinimumSize = new System.Drawing.Size(844, 337);
            this.Name = "ModGeneratorForm";
            this.Text = "Browse";
            this.BarotraumaDirectoryGroupBox.ResumeLayout(false);
            this.BarotraumaDirectoryGroupBox.PerformLayout();
            this.OutputDirectoryGroupBox.ResumeLayout(false);
            this.OutputDirectoryGroupBox.PerformLayout();
            this.ModeTabControl.ResumeLayout(false);
            this.SingleInputTab.ResumeLayout(false);
            this.SingleInputTab.PerformLayout();
            this.MultiInputTab.ResumeLayout(false);
            this.MultiInputTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox BarotraumaDirectoryGroupBox;
        private System.Windows.Forms.TextBox BaroDirectoryTextbox;
        private System.Windows.Forms.Button BaroDirectoryBrowse;
        private System.Windows.Forms.TextBox OutputDirectoryTextBox;
        private System.Windows.Forms.Button OutputDirectoryBrowse;
        private System.Windows.Forms.GroupBox OutputDirectoryGroupBox;
        private System.Windows.Forms.TabControl ModeTabControl;
        private System.Windows.Forms.TabPage SingleInputTab;
        private System.Windows.Forms.TabPage MultiInputTab;
        private System.Windows.Forms.Button SingleInputBrowseButton;
        private System.Windows.Forms.TextBox SingleInputTextBox;
        private System.Windows.Forms.Button MultiInputBrowseButton;
        private System.Windows.Forms.TextBox MultiInputTextBox;
        private System.Windows.Forms.Button GoButton;
        private System.Windows.Forms.RichTextBox OutputRichTextBox;
    }
}

