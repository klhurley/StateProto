using System;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// ThreadPerHsm.
	/// </summary>
	public class ThreadPerHsm : IHsmExecutionModel
	{
        #region IHsmExecutionModel Members

        private IQEventManager InitHsmRunner(string id)
        {
            IQEventManager eventManager = new QMultiHsmEventManager(new QSystemTimer());        
            IQEventManagerRunner runner = new QThreadedEventManagerRunner ("Thr4Hsm" + id, eventManager);	 
            runner.Start ();
            return eventManager;
        }

        public Samples.SampleWatch CreateHsm(string id)
        {
            IQEventManager eventManager = InitHsmRunner (id);

            Samples.SampleWatch sampleWatch
                = new Samples.SampleWatch (id, eventManager);
            return sampleWatch;
        }

        #endregion
    }
}
