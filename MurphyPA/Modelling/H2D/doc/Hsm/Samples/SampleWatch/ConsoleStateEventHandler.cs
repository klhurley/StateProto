using System;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// Summary description for ConsoleStateEventHandler.
	/// </summary>
	public class ConsoleStateEventHandler : LoggingUserBase
	{
	    ILQHsm _Hsm;
		public ConsoleStateEventHandler(ILQHsm hsm)
		{
		    _Hsm = hsm;
		    RegisterEvents ();
        }

	    private void RegisterEvents()
	    {
            _Hsm.StateChange += new EventHandler(_Hsm_StateChange);
	        _Hsm.UnhandledTransition += new DispatchUnhandledTransitionHandler(_Hsm_UnhandledTransition);
	        _Hsm.DispatchException += new DispatchExceptionHandler(_Hsm_DispatchException);
	    }
	    
	    private string StateNameFrom(QState state)
	    {
	        if (state == null) return "NULLSTATE";
	        return state.Method.Name;
	    }
	    
        private void _Hsm_StateChange(object sender, EventArgs e)
        {
            LogStateEventArgs sa = (LogStateEventArgs) e;
            switch(sa.LogType)
            {
            case StateLogType.Init:
            case StateLogType.Entry:
            case StateLogType.Exit:
                {
                    Logger.Info("StateChange: {0} {1}", sa.LogType, StateNameFrom(sa.State));                    
                }
                break;
            case StateLogType.EventTransition:
                {
                    Logger.Info("StateChange: {0} {1} {2} {3}", sa.LogType, 
                                StateNameFrom(sa.State), 
                                StateNameFrom(sa.NextState), sa.EventDescription);                    
                }
                break;
            default:
                {
                    Logger.Info("StateChange(defaultHandler): {0} {1}", sa.LogType, StateNameFrom(sa.State));
                } break;
            }
        }

        private void _Hsm_UnhandledTransition(IQHsm hsm, System.Reflection.MethodInfo stateMethod, IQEvent ev)
        {
            Logger.Info("UnhandledTransition: {0} {1} {2}", hsm, stateMethod.Name, ev);
        }

        private void _Hsm_DispatchException(Exception ex, IQHsm hsm, System.Reflection.MethodInfo stateMethod, IQEvent ev)
        {
            Logger.Error(ex, "DispatchException: {0} {1} {2}", hsm, stateMethod.Name, ev);
        }
    }
}
