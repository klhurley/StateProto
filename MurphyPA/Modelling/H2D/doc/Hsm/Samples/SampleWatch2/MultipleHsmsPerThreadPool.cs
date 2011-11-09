using System;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// MultipleHsmsPerThread.
	/// </summary>
    public class MultipleHsmsPerThreadPool : IHsmExecutionModel
    {
	    IQHsmLifeCycleManager _LifeCycleManager;
        
	    public MultipleHsmsPerThreadPool()
	    {
	        InitHsmRunner ();   
	    }
	    
        #region IHsmExecutionModel Members

        private void InitHsmRunner()
        {
            IQEventManager[] eventManagers = new IQEventManager[]
                {
                    new QMultiHsmEventManager(new QSystemTimer()),  
                    new QMultiHsmEventManager(new QSystemTimer()),
                    new QMultiHsmEventManager(new QSystemTimer()),
                    new QMultiHsmEventManager(new QSystemTimer()),
                    new QMultiHsmEventManager(new QSystemTimer()) 
                };
            QHsmLifeCycleManagerWithHsmEventsBaseAndMultipleEventManagers lifeCycleManager = new QHsmLifeCycleManagerWithHsmEventsBaseAndMultipleEventManagers (eventManagers);
            
            int counter = 0;
            foreach (IQEventManager eventManager in eventManagers)
            {
                IQEventManagerRunner runner = new QThreadedEventManagerRunner ("Pool-Thr" + counter.ToString(), eventManager);
                runner.Start ();
                counter++;
            }
            _LifeCycleManager = lifeCycleManager;
        }

        public Samples.SampleWatch CreateHsm(string id)
        {
            Samples.SampleWatch sampleWatch
                = new Samples.SampleWatch (id, id, _LifeCycleManager);
            return sampleWatch;
        }

        #endregion
    }
}
