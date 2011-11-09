using System;
using qf4net;

namespace Samples.Library
{
	/// <summary>
	/// BaseCmd.
	/// </summary>
	public abstract class BaseCmd : IQSimpleCommand
	{
	    ILQHsm _Hsm;	    
	    protected ILQHsm Hsm { get { return _Hsm; }}
	    	    
		public BaseCmd(ILQHsm hsm)
		{
		    _Hsm = hsm;
		}
	    
	    public abstract void Execute ();
	    
	    public event HsmMementoCompleted Completed;
	    
	    protected void DoCompleted(ILQHsmMemento memento)
	    {
	        HsmMementoCompleted handler = Completed;
	        if(null != handler)
	        {
	            handler (this, memento);
	        }
	    }
	}
    
    public delegate void HsmMementoCompleted (IQSimpleCommand command, ILQHsmMemento memento);
}
