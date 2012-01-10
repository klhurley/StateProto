using System;
using System.IO;
using System.Configuration;

namespace MurphyPA.H2D.TestApp
{
	using System.Windows.Forms;
	/// <summary>
	/// Summary description for LoadFileWithDialogCommand.
	/// </summary>
	public class LoadFileWithDialogCommand : DiagramCommandBase
	{
		OpenFileDialog _OpenFileDialog;
		public LoadFileWithDialogCommand (IUIInterationContext context, OpenFileDialog openFileDialog, Button button, MenuItem menuItem)
			: base (context, button, menuItem)
		{
			_OpenFileDialog = openFileDialog;
		}

		public override void Execute()
		{
            string lastFileDirectory = Properties.Settings.Default.LastFileOpenDirectory;

            if (lastFileDirectory.Length == 0)
            {
                lastFileDirectory = Environment.CurrentDirectory;
            }

            _OpenFileDialog.InitialDirectory = lastFileDirectory;
			DialogResult dialogResult = _OpenFileDialog.ShowDialog ();
			if (dialogResult == DialogResult.OK)
			{
				Context.ClearModel ();
				LoadFile (_OpenFileDialog.FileName);
				Context.ShowHeader ();
				Context.Model.Header.ReadOnly = Context.Model.HasGlyphs();
                Properties.Settings.Default.LastFileOpenDirectory = Path.GetDirectoryName(_OpenFileDialog.FileName);
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
		}

		private void LoadFile (string fileName)
		{
			LoadFileCommand command = new LoadFileCommand (fileName, Context);
			command.Execute ();
		}
	}
}
