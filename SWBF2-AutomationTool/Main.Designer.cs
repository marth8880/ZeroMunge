﻿namespace SWBF2_AutomationTool
{
    partial class AutomationTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutomationTool));
            this.btn_Submit = new System.Windows.Forms.Button();
            this.clist_Files = new System.Windows.Forms.CheckedListBox();
            this.btn_AddFiles = new System.Windows.Forms.Button();
            this.openDlg_AddFilesPrompt = new System.Windows.Forms.OpenFileDialog();
            this.btn_RemoveFile = new System.Windows.Forms.Button();
            this.FormTooltips = new System.Windows.Forms.ToolTip(this.components);
            this.btn_ClearLog = new System.Windows.Forms.Button();
            this.btn_CopyLog = new System.Windows.Forms.Button();
            this.btn_SaveLog = new System.Windows.Forms.Button();
            this.btn_AddFolders = new System.Windows.Forms.Button();
            this.text_OutputLog = new System.Windows.Forms.RichTextBox();
            this.lbl_OutputLogLines = new System.Windows.Forms.Label();
            this.saveDlg_SaveLogPrompt = new System.Windows.Forms.SaveFileDialog();
            this.btn_AddProject = new System.Windows.Forms.Button();
            this.btn_RemoveAllFiles = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Submit
            // 
            this.btn_Submit.Location = new System.Drawing.Point(669, 13);
            this.btn_Submit.Name = "btn_Submit";
            this.btn_Submit.Size = new System.Drawing.Size(102, 23);
            this.btn_Submit.TabIndex = 0;
            this.btn_Submit.Text = "Run";
            this.FormTooltips.SetToolTip(this.btn_Submit, "Executes each file in the list recursively.");
            this.btn_Submit.UseVisualStyleBackColor = true;
            this.btn_Submit.Click += new System.EventHandler(this.btn_Submit_Click);
            // 
            // clist_Files
            // 
            this.clist_Files.CheckOnClick = true;
            this.clist_Files.FormattingEnabled = true;
            this.clist_Files.Location = new System.Drawing.Point(13, 13);
            this.clist_Files.Name = "clist_Files";
            this.clist_Files.ScrollAlwaysVisible = true;
            this.clist_Files.Size = new System.Drawing.Size(650, 319);
            this.clist_Files.TabIndex = 1;
            // 
            // btn_AddFiles
            // 
            this.btn_AddFiles.AccessibleDescription = "";
            this.btn_AddFiles.AllowDrop = true;
            this.btn_AddFiles.Location = new System.Drawing.Point(669, 71);
            this.btn_AddFiles.Name = "btn_AddFiles";
            this.btn_AddFiles.Size = new System.Drawing.Size(102, 23);
            this.btn_AddFiles.TabIndex = 2;
            this.btn_AddFiles.Tag = "";
            this.btn_AddFiles.Text = "Add Files...";
            this.FormTooltips.SetToolTip(this.btn_AddFiles, "Opens a prompt to add files to the list of files.");
            this.btn_AddFiles.UseVisualStyleBackColor = true;
            this.btn_AddFiles.Click += new System.EventHandler(this.btn_AddFiles_Click);
            // 
            // openDlg_AddFilesPrompt
            // 
            this.openDlg_AddFilesPrompt.Filter = "Batch files|*.bat";
            this.openDlg_AddFilesPrompt.Multiselect = true;
            this.openDlg_AddFilesPrompt.Title = "Add Files";
            this.openDlg_AddFilesPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.openDlg_AddFilesPrompt_FileOk);
            // 
            // btn_RemoveFile
            // 
            this.btn_RemoveFile.Location = new System.Drawing.Point(669, 158);
            this.btn_RemoveFile.Name = "btn_RemoveFile";
            this.btn_RemoveFile.Size = new System.Drawing.Size(102, 23);
            this.btn_RemoveFile.TabIndex = 3;
            this.btn_RemoveFile.Text = "Remove";
            this.FormTooltips.SetToolTip(this.btn_RemoveFile, "Removes the selected file.");
            this.btn_RemoveFile.UseVisualStyleBackColor = true;
            this.btn_RemoveFile.Click += new System.EventHandler(this.btn_RemoveFile_Click);
            // 
            // btn_ClearLog
            // 
            this.btn_ClearLog.Location = new System.Drawing.Point(669, 526);
            this.btn_ClearLog.Name = "btn_ClearLog";
            this.btn_ClearLog.Size = new System.Drawing.Size(102, 23);
            this.btn_ClearLog.TabIndex = 7;
            this.btn_ClearLog.Text = "Clear Log";
            this.FormTooltips.SetToolTip(this.btn_ClearLog, "Clears the contents of the output log.");
            this.btn_ClearLog.UseVisualStyleBackColor = true;
            this.btn_ClearLog.Click += new System.EventHandler(this.btn_ClearLog_Click);
            // 
            // btn_CopyLog
            // 
            this.btn_CopyLog.Location = new System.Drawing.Point(669, 468);
            this.btn_CopyLog.Name = "btn_CopyLog";
            this.btn_CopyLog.Size = new System.Drawing.Size(102, 23);
            this.btn_CopyLog.TabIndex = 8;
            this.btn_CopyLog.Text = "Copy to Clipboard";
            this.FormTooltips.SetToolTip(this.btn_CopyLog, "Copies the contents of the output log to the clipboard.");
            this.btn_CopyLog.UseVisualStyleBackColor = true;
            this.btn_CopyLog.Click += new System.EventHandler(this.btn_CopyLog_Click);
            // 
            // btn_SaveLog
            // 
            this.btn_SaveLog.Location = new System.Drawing.Point(669, 497);
            this.btn_SaveLog.Name = "btn_SaveLog";
            this.btn_SaveLog.Size = new System.Drawing.Size(102, 23);
            this.btn_SaveLog.TabIndex = 9;
            this.btn_SaveLog.Text = "Save Log...";
            this.btn_SaveLog.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FormTooltips.SetToolTip(this.btn_SaveLog, "Opens a prompt to save the contents of the output log to a new file.");
            this.btn_SaveLog.UseVisualStyleBackColor = true;
            this.btn_SaveLog.Click += new System.EventHandler(this.btn_SaveLog_Click);
            // 
            // btn_AddFolders
            // 
            this.btn_AddFolders.Location = new System.Drawing.Point(669, 100);
            this.btn_AddFolders.Name = "btn_AddFolders";
            this.btn_AddFolders.Size = new System.Drawing.Size(102, 23);
            this.btn_AddFolders.TabIndex = 10;
            this.btn_AddFolders.Text = "Add Folders...";
            this.FormTooltips.SetToolTip(this.btn_AddFolders, "Opens a prompt to add folders containing munge.bat files to the file list.");
            this.btn_AddFolders.UseVisualStyleBackColor = true;
            this.btn_AddFolders.Click += new System.EventHandler(this.btn_AddFolders_Click);
            // 
            // text_OutputLog
            // 
            this.text_OutputLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_OutputLog.ForeColor = System.Drawing.Color.Black;
            this.text_OutputLog.Location = new System.Drawing.Point(13, 338);
            this.text_OutputLog.Name = "text_OutputLog";
            this.text_OutputLog.ReadOnly = true;
            this.text_OutputLog.Size = new System.Drawing.Size(651, 211);
            this.text_OutputLog.TabIndex = 5;
            this.text_OutputLog.Text = "";
            this.text_OutputLog.WordWrap = false;
            this.text_OutputLog.TextChanged += new System.EventHandler(this.text_OutputLog_TextChanged);
            // 
            // lbl_OutputLogLines
            // 
            this.lbl_OutputLogLines.AutoSize = true;
            this.lbl_OutputLogLines.Location = new System.Drawing.Point(666, 340);
            this.lbl_OutputLogLines.Name = "lbl_OutputLogLines";
            this.lbl_OutputLogLines.Size = new System.Drawing.Size(44, 13);
            this.lbl_OutputLogLines.TabIndex = 6;
            this.lbl_OutputLogLines.Text = "Lines: 1";
            // 
            // saveDlg_SaveLogPrompt
            // 
            this.saveDlg_SaveLogPrompt.DefaultExt = "log";
            this.saveDlg_SaveLogPrompt.FileName = "Munge_OutputLog";
            this.saveDlg_SaveLogPrompt.Filter = "Log files|*.log";
            this.saveDlg_SaveLogPrompt.Title = "Save Log";
            this.saveDlg_SaveLogPrompt.FileOk += new System.ComponentModel.CancelEventHandler(this.saveDlg_SaveLogPrompt_FileOk);
            // 
            // btn_AddProject
            // 
            this.btn_AddProject.Location = new System.Drawing.Point(669, 129);
            this.btn_AddProject.Name = "btn_AddProject";
            this.btn_AddProject.Size = new System.Drawing.Size(102, 23);
            this.btn_AddProject.TabIndex = 11;
            this.btn_AddProject.Text = "Add Project...";
            this.FormTooltips.SetToolTip(this.btn_AddProject, "Opens a prompt to select a project folder whose common munge.bat files will be ad" +
        "ded to the file list.");
            this.btn_AddProject.UseVisualStyleBackColor = true;
            this.btn_AddProject.Click += new System.EventHandler(this.btn_AddProject_Click);
            // 
            // btn_RemoveAllFiles
            // 
            this.btn_RemoveAllFiles.Location = new System.Drawing.Point(669, 187);
            this.btn_RemoveAllFiles.Name = "btn_RemoveAllFiles";
            this.btn_RemoveAllFiles.Size = new System.Drawing.Size(102, 23);
            this.btn_RemoveAllFiles.TabIndex = 0;
            this.btn_RemoveAllFiles.Text = "Remove All";
            this.btn_RemoveAllFiles.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.FormTooltips.SetToolTip(this.btn_RemoveAllFiles, "Removes all files from the file list.");
            this.btn_RemoveAllFiles.UseVisualStyleBackColor = true;
            this.btn_RemoveAllFiles.Click += new System.EventHandler(this.btn_RemoveAllFiles_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Enabled = false;
            this.btn_Cancel.Location = new System.Drawing.Point(669, 42);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(102, 23);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // AutomationTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_RemoveAllFiles);
            this.Controls.Add(this.btn_AddProject);
            this.Controls.Add(this.btn_AddFolders);
            this.Controls.Add(this.btn_SaveLog);
            this.Controls.Add(this.btn_CopyLog);
            this.Controls.Add(this.btn_ClearLog);
            this.Controls.Add(this.lbl_OutputLogLines);
            this.Controls.Add(this.text_OutputLog);
            this.Controls.Add(this.btn_RemoveFile);
            this.Controls.Add(this.btn_AddFiles);
            this.Controls.Add(this.clist_Files);
            this.Controls.Add(this.btn_Submit);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "AutomationTool";
            this.Text = "Automation Tool";
            this.Load += new System.EventHandler(this.AutomationTool_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Submit;
        private System.Windows.Forms.Button btn_AddFiles;
        private System.Windows.Forms.OpenFileDialog openDlg_AddFilesPrompt;
        private System.Windows.Forms.Button btn_RemoveFile;
        private System.Windows.Forms.ToolTip FormTooltips;
        private System.Windows.Forms.RichTextBox text_OutputLog;
        private System.Windows.Forms.Label lbl_OutputLogLines;
        private System.Windows.Forms.Button btn_ClearLog;
        private System.Windows.Forms.Button btn_CopyLog;
        private System.Windows.Forms.Button btn_SaveLog;
        private System.Windows.Forms.SaveFileDialog saveDlg_SaveLogPrompt;
        private System.Windows.Forms.CheckedListBox clist_Files;
        private System.Windows.Forms.Button btn_AddFolders;
        private System.Windows.Forms.Button btn_AddProject;
        private System.Windows.Forms.Button btn_RemoveAllFiles;
        private System.Windows.Forms.Button btn_Cancel;
    }
}

