﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace ZeroMunge
{
	public partial class SoundMungeForm : Form
	{
		string projectDir = "";
		string soundDir = "";

		public SoundMungeForm(string projectDirectory = "")
		{
			InitializeComponent();
			projectDir = projectDirectory;
		}


		// When the form has loaded:
		// Set the tooltips and prompt the user to select a project folder.
		private void SoundMungeForm_Load(object sender, EventArgs e)
		{
			SetToolTips();

			if (projectDir == "")
			{
				Prompt_AddProject();
			}
			else
			{
				AddProject(projectDir);
			}
		}


		// When the 'Browse' button is clicked:
		// Open a prompt to select a project folder and populate the treeview.
		private void btn_Browse_Click(object sender, EventArgs e)
		{
			Prompt_AddProject();
		}


		// When the 'Apply' button is clicked:
		// Apply the modifications to the project folder's soundmunge.bat file.
		private void btn_Apply_Click(object sender, EventArgs e)
		{
			if (File.Exists(projectDir + "\\soundmunge.bat"))
			{
				DialogResult overwritePrompt = MessageBox.Show(string.Format("This will overwrite the contents of \"{0}\". Do you want to continue?", projectDir + "\\soundmunge.bat"), "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

				if (overwritePrompt == DialogResult.Yes)
				{
					ModifySoundFile();
				}
			}
			else
			{
				ModifySoundFile();
			}
		}


		// When the user clicks the "Help" button:
		// Open the Help file at the "User Interface: Modify Munged Sound Folders" topic.
		private void btn_Help_Click(object sender, EventArgs e)
		{
			Utilities.OpenHelp(this, "topic_ui_modifymungedsoundfolders");
		}


		// After a node has been checked in the TreeView:
		// Check/uncheck all child nodes.
		private void tv_SoundFolders_AfterCheck(object sender, TreeViewEventArgs e)
		{
			// Did the user cause the checked state to change?
			if (e.Action != TreeViewAction.Unknown)
			{
				if (e.Node.Nodes.Count > 0)
				{
					CheckAllChildNodes(e.Node, e.Node.Checked);
				}
			}
		}


		/// <summary>
		/// Sets the form's tooltips.
		/// </summary>
		private void SetToolTips()
		{
			FormTooltips.AutoPopDelay = Properties.Settings.Default.TooltipPopDelay;

			// Sound Munge Form
			FormTooltips.SetToolTip(btn_Browse, Tooltips.SoundMungeForm.Browse);
			FormTooltips.SetToolTip(btn_Apply, Tooltips.SoundMungeForm.Apply);
			FormTooltips.SetToolTip(btn_Close, Tooltips.SoundMungeForm.Close);
			FormTooltips.SetToolTip(btn_Help, Tooltips.SoundMungeForm.HelpButton);
		}


		/// <summary>
		/// Recursively sets the checked state of the specified TreeNode's child nodes.
		/// </summary>
		/// <param name="treeNode">Node to set checked state for all children.</param>
		/// <param name="nodeChecked">True, check node. False, uncheck node.</param>
		private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
		{
			foreach (TreeNode node in treeNode.Nodes)
			{
				node.Checked = nodeChecked;
				if (node.Nodes.Count > 0)
				{
					CheckAllChildNodes(node, nodeChecked);
				}
			}
		}
		

		/// <summary>
		/// Open a prompt to select a project folder to add to the TreeView.
		/// </summary>
		private void Prompt_AddProject()
		{
			CommonOpenFileDialog openDlg_AddProjectPrompt = new CommonOpenFileDialog
			{
				Title = "Select Project Folder",
				DefaultDirectory = "C:\\BF2_ModTools",
				IsFolderPicker = true,
				RestoreDirectory = true
			};

			// Auto-detect the munge.bat file inside each selected folder and add it to the file list
			if (openDlg_AddProjectPrompt.ShowDialog() == CommonFileDialogResult.Ok)
			{
				AddProject(openDlg_AddProjectPrompt.FileName);
			}
		}


		/// <summary>
		/// Populate the treeview with the sound folders.
		/// </summary>
		/// <param name="dir">Project directory.</param>
		private void AddProject(string dir)
		{
			try
			{
				projectDir = dir;
				txt_ProjectDirectory.Text = projectDir;

				if (!Directory.Exists(projectDir + "\\_BUILD"))
					throw new DirectoryNotFoundException("Invalid project directory specified.");

				// Get the project ID
				string projectID = Utilities.GetProjectID(projectDir);
				string projectRoot = new DirectoryInfo(projectDir).Name;

				soundDir = new DirectoryInfo(projectDir).FullName + "\\Sound";
				string[] soundFolders = Directory.GetDirectories(soundDir);


				// Populate the treeview with the sound folders
				tv_SoundFolders.BeginUpdate();
				tv_SoundFolders.Nodes.Clear();

				foreach (string folder in soundFolders)
				{
					tv_SoundFolders.Nodes.Add(new DirectoryInfo(folder).Name.ToLower());

					// World sound folders become children of the 'worlds' node
					if (new DirectoryInfo(folder).Name.ToLower() == "worlds")
					{
						foreach (string childFolder in Directory.GetDirectories(soundDir + "\\worlds"))
						{
							tv_SoundFolders.Nodes.GetNodeByValue("worlds").Nodes.Add(new DirectoryInfo(childFolder).Name.ToLower());
						}
					}
				}

				tv_SoundFolders.EndUpdate();
				tv_SoundFolders.ExpandAll();
				tv_SoundFolders.Nodes[0].EnsureVisible();

				// Auto-checkmark sound folders that are already called in the soundmunge.bat
				foreach (string line in File.ReadAllLines(projectDir + "\\soundmunge.bat"))
				{
					if (line.StartsWith("@call soundmungedir") || line.StartsWith("call soundmungedir"))
					{
						foreach (TreeNode node in tv_SoundFolders.Nodes)
						{
							if (node.FullPath.ToLower() == "worlds")
							{
								foreach (TreeNode childNode in node.Nodes)
								{
									if (line.ToLower().Contains("sound\\" + childNode.FullPath + " "))
									{
										childNode.Checked = true;
										break;
									}
								}
								break;
							}
							else
							{
								if (line.ToLower().Contains("sound\\".ToLower() + node.FullPath + " "))
								{
									node.Checked = true;
									break;
								}
							}
						}
					}
				}
			}
			catch (System.Security.SecurityException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (PathTooLongException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (UnauthorizedAccessException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (DirectoryNotFoundException ex)
			{
				Trace.WriteLine(ex.Message);

				// Show error message allowing user to select a different directory, ignore the error, or abort the operation
				DialogResult dr = MessageBox.Show(string.Format("Unable to find _BUILD directory in \"{0}\".\n\nPlease specify a valid project directory, e.g. \"C:\\BF2_ModTools\\data_ABC\".", dir), "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
				switch (dr)
				{
					case DialogResult.Abort:
						Close();
						break;
					case DialogResult.Retry:
						Prompt_AddProject();
						break;
				}
			}
			catch (IOException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Trace.WriteLine(ex.Message);
				throw;
			}
			catch (ArgumentNullException ex)
			{
				Trace.WriteLine(ex.Message);
				throw;
			}
			catch (ArgumentException ex)
			{
				Trace.WriteLine(ex.Message);
				throw;
			}
		}


		/// <summary>
		/// Applies the modifications to the soundmunge.bat file.
		/// </summary>
		private void ModifySoundFile()
		{
			try
			{
				string filePath = projectDir + "\\soundmunge.bat";

				// soundmungedir line templates
				string munge_cw = @"@call soundmungedir _BUILD\sound\cw\%MUNGE_DIR%     sound\cw     sound\cw\%MUNGE_PLATFORM%     %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound cw";
				string munge_gcw = @"@call soundmungedir _BUILD\sound\gcw\%MUNGE_DIR%    sound\gcw    sound\gcw\%MUNGE_PLATFORM%    %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound gcw";
				string munge_global = @"@call soundmungedir _BUILD\sound\global\%MUNGE_DIR% sound\global sound\global\%MUNGE_PLATFORM% %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound global nolevelfile";
				string munge_shell = @"@call soundmungedir _BUILD\sound\shell\%MUNGE_DIR%  sound\shell  sound\shell\%MUNGE_PLATFORM%  %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound shell";
				string munge_world = @"@call soundmungedir _BUILD\sound\worlds\@#$\%MUNGE_DIR% sound\worlds\@#$ sound\worlds\@#$\%MUNGE_PLATFORM% %MUNGE_PLATFORM% _BUILD _LVL_%MUNGE_PLATFORM%\sound _BUILD\sound @#$";
				string xcopy = @"xcopy _LVL_%MUNGE_PLATFORM%\sound\*  %BF2_SOUNDPATH%GameData\addon\@#$\data\_LVL_PC\Sound\ /Y";

				if (File.Exists(filePath))
				{
					List<string> fileContents = File.ReadAllLines(filePath).ToList();
					List<string> newFileContents = new List<string>();

					newFileContents.Add("@if %1x==x goto noplatform");
					newFileContents.Add("@set MUNGE_PLATFORM=%1");
					newFileContents.Add("@set MUNGE_DIR=MUNGED\\%MUNGE_PLATFORM%");
					newFileContents.Add("@rem EDIT THE LINE BELOW TO POINT TO YOUR BF2 INSTALL PATH");
					newFileContents.Add("@set BF2_SOUNDPATH=\"@#$\\\"".Replace("@#$", new DirectoryInfo(Properties.Settings.Default.GameDirectory).Parent.FullName));
					newFileContents.Add("");
					newFileContents.Add("@rem Munge global, shell and side specific sound data");

					TreeNode node_cw = tv_SoundFolders.Nodes.GetNodeByValue("cw");
					if (node_cw != null && node_cw.Checked)
						newFileContents.Add(munge_cw);

					TreeNode node_gcw = tv_SoundFolders.Nodes.GetNodeByValue("gcw");
					if (node_gcw != null && node_gcw.Checked)
						newFileContents.Add(munge_gcw);

					TreeNode node_global = tv_SoundFolders.Nodes.GetNodeByValue("global");
					if (node_global != null && node_global.Checked)
						newFileContents.Add(munge_global);

					TreeNode node_shell = tv_SoundFolders.Nodes.GetNodeByValue("shell");
					if (node_shell != null && node_shell.Checked)
						newFileContents.Add(munge_shell);

					newFileContents.Add("@rem Munge world specific sound data");

					TreeNode node_worlds = tv_SoundFolders.Nodes.GetNodeByValue("worlds");
					if (node_worlds != null)
					{
						List<TreeNode> selectedNodes = node_worlds.Nodes.Descendants()
							.Where(n => n.Checked)
							.ToList();

						foreach (TreeNode node in selectedNodes)
						{
							newFileContents.Add(munge_world.Replace("@#$", node.Text));
						}
					}

					newFileContents.Add("");
					newFileContents.Add(xcopy.Replace("@#$", Utilities.GetProjectID(projectDir)));
					newFileContents.Add("");
					newFileContents.Add("@goto exit");
					newFileContents.Add(":noplatform");
					newFileContents.Add("@echo Platform must be specified as the first argument");
					newFileContents.Add(":exit");


					File.WriteAllLines(projectDir + "\\soundmunge.bat", newFileContents, Encoding.UTF8);
				}
			}
			catch (System.Security.SecurityException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (PathTooLongException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (UnauthorizedAccessException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (DirectoryNotFoundException ex)
			{
				Trace.WriteLine(ex.Message);
				//rootPaths.Remove(curRoot);

				//// Show error message allowing user to select a different directory, ignore the error, or abort the operation
				//DialogResult dr = MessageBox.Show(string.Format("Unable to find _BUILD directory in \"{0}\".", openDlg_AddProjectPrompt.FileName), "Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
				//switch (dr)
				//{
				//	case DialogResult.Abort:
				//		Close();
				//		break;
				//	case DialogResult.Retry:
				//		Prompt_AddProject();
				//		break;
				//}
			}
			catch (IOException ex)
			{
				Trace.WriteLine(ex.Message);
			}
			catch (ArgumentOutOfRangeException ex)
			{
				Trace.WriteLine(ex.Message);
				throw;
			}
			catch (ArgumentNullException ex)
			{
				Trace.WriteLine(ex.Message);
				throw;
			}
			catch (ArgumentException ex)
			{
				Trace.WriteLine(ex.Message);
				throw;
			}
		}
	}
}
