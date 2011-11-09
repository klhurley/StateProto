using System;
using qf4net;

namespace Samples.Library
{
	/// <summary>
	/// MultipleHsmsPerThread.
	/// </summary>
    public class MultipleHsmsPerThread : LoggingUserBase, IHsmExecutionModel
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
            _EventManager.EMDispatchCommandException += new EventManagerDispatchCommandExceptionHandler(_EventManager_EMDispatchCommandException);
            _EventManager.EMDispatchException += new EventManagerDispatchExceptionHandler(_EventManager_EMDispatchException);
            IQEventManagerRunner runner = new QThreadedEventManagerRunner ("ThrShared", _EventManager);	 
            runner.Start ();
        }

        public BookFrame CreateHsm(string id, string storageFileName)
        {
            BookFrame bookFrame
                = new BookFrame (id, _EventManager, storageFileName);
            return bookFrame;
        }
        #endregion

        private void _EventManager_EMDispatchCommandException(IQEventManager eventManager, Exception ex, IQSimpleCommand command)
        {
            Logger.Error (ex, command.ToString ());
        }

        private void _EventManager_EMDispatchException(IQEventManager eventManager, Exception ex, IQHsm hsm, IQEvent ev)
        {
            Logger.Error (ex, hsm.ToString () + " " + ev.ToString());
        }
    }
}
