using System;
using qf4net;

namespace Samples.Library
{
	/// <summary>
	/// RestoreCmd.
	/// </summary>
    public class RestoreCmd : BaseCmd
    {
        ILQHsmMemento _Memento;
	    
        public RestoreCmd(ILQHsm hsm, ILQHsmMemento memento)
	    : base(hsm)
        {
            _Memento = memento;
        }

        public override void Execute()
        {
            Hsm.RestoreFromMemento (_Memento);
            DoCompleted (_Memento);
        }
    }
}
