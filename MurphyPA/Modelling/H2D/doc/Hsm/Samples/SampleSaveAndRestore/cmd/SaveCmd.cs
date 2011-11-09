using System;
using qf4net;

namespace Samples.Library
{
	/// <summary>
	/// SaveCmd.
	/// </summary>
	public class SaveCmd : BaseCmd
	{
	    string _FileName;
	    public string FileName { get { return _FileName; } set { _FileName = value; } }
	    
        public SaveCmd(ILQHsm hsm, string fileName)
            : base(hsm)
        {
            _FileName = fileName;
        }

	    public override void Execute()
	    {
	        ILQHsmMemento memento = new LQHsmMemento ();
	        Hsm.SaveToMemento (memento);
	        DoCompleted (memento);
	    }
	}
}
