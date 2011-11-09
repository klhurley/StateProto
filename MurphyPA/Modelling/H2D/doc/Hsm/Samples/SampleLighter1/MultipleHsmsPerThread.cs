using System;
using qf4net;

namespace Samples.Lighter
{
	/// <summary>
	/// MultipleHsmsPerThread.
	/// </summary>
    public class MultipleHsmsPerThread : IHsmExecutionModel
    {
        IQEventManager _EventManager;
        
	    public MultipleHsmsPerThread()
	    {
	        InitHsmRunner ();   
	    }
	    
        #region IHsmExecutionModel Members

        private void InitHsmRunner()
        {
            _EventManager = new QMultiHsmEventManager(new QSystemTimer());        
            IQEventManagerRunner runner = new QThreadedEventManagerRunner ("ThrShared", _EventManager);	 
            runner.Start ();
        }

        public LighterFrame CreateHsm(string id)
        {
            LighterFrame ligherFrame
                = new LighterFrame (id, _EventManager);
            return ligherFrame;
        }

        #endregion
    }
}
