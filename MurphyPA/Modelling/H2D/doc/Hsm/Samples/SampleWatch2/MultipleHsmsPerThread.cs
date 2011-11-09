using System;
using qf4net;

namespace SampleWatch
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

        public Samples.SampleWatch CreateHsm(string id)
        {
            Samples.SampleWatch sampleWatch
                = new Samples.SampleWatch (id, _EventManager);
            return sampleWatch;
        }

        #endregion
    }
}
