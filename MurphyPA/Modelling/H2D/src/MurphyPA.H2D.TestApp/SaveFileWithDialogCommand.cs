using System;
using System.IO;

namespace MurphyPA.H2D.TestApp
{
	using System.Windows.Forms;
	/// <summary>
	/// Summary description for SaveFileWithDialogCommand.
	/// </summary>
	public class SaveFileWithDialogCommand : DiagramCommandBase
	{
		SaveFileDialog _SaveFileDialog;
		public SaveFileWithDialogCommand (IUIInterationContext context, SaveFileDialog saveFileDialog, Button button, MenuItem menuItem)
			: base (context, button, menuItem)
		{
			_SaveFileDialog = saveFileDialog;
		}

		public override void Execute()
		{
			if (!Context.Model.HasGlyphs ())
			{
				return;
			}

            string lastFileDirectory = 	(string)Properties.Settings.Default["LastFileOpenDirectory"];

            if (lastFileDirectory.Length == 0)
            {
                lastFileDirectory = Environment.CurrentDirectory;
            }

            _SaveFileDialog.InitialDirectory = lastFileDirectory;
			if (Context.LastFileName == null)
			{
				Context.LastFileName = Context.Model.Header.Name;
			}
			_SaveFileDialog.FileName = Context.LastFileName;
			DialogResult dialogResult = _SaveFileDialog.ShowDialog ();
			if (dialogResult == DialogResult.OK)
			{
				string fileName = _SaveFileDialog.FileName;
				SaveFile (fileName);

                Properties.Settings.Default["LastFileOpenDirectory"] = Path.GetDirectoryName(fileName);
                Properties.Settings.Default.Save();
            }
		}

		private void SaveFile (string fileName)
		{
			if (!Context.Model.HasGlyphs ())
			{
				return;
			}

			SaveGlyphDataFile saveFile = new SaveGlyphDataFile (Context.Model);
			saveFile.Save (fileName);
			Context.LastFileName = fileName;
		}
	}
}
