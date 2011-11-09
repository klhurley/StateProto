using System;
using System.Text;
using qf4net;

namespace Samples.Lighter
{
	/// <summary>
	/// Summary description for LighterFrame.
	/// </summary>
	public class LighterFrame
	{
		public LighterFrame(string id, IQEventManager eventManager)
		{
		    _Air = new Air ("Air" + id, id, eventManager);
		    _Flint = new Flint ("Flint" + id, id, eventManager);
		    _FuelMixture = new FuelMixture ("FuelMixture" + id, id, eventManager);
		    _Valve = new Valve ("Valve" + id, id, eventManager);
		    
            RegisterStateChange (eventManager);
            LinkPorts ();
            Log ();
		    Init ();
		}
	    
	    void LinkPorts()
	    {
	        _Air.FuelMixture.QEvents += new QEventHandler(_FuelMixture.Air.Receive);
            _Valve.FuelMixture.QEvents += new QEventHandler(_FuelMixture.Valve.Receive);
            _Flint.FuelMixture.QEvents += new QEventHandler(_FuelMixture.Flint.Receive);	        
        }
	    
	    void RegisterStateChange(IQEventManager eventManager)
	    {
            eventManager.PolledEvent += new PolledEventHandler(EventManager_PolledEvent);
	    }
	    
	    public string ValveState
	    {
	        get
	        {
	            return _Valve.CurrentStateName + "/" + _Valve.FlowValue;
	        }
	    }

	    public string FlintState
	    {
	        get
	        {
                return _Flint.CurrentStateName;
            }
	    }

	    public string AirFlowState
	    {
	        get
	        {
	            return _Air.CurrentStateName + "/" + _Air.FlowRate;
	        }
	    }

	    public string FuelMixtureState
	    {
	        get
	        {
                StringBuilder sb = new StringBuilder ();
	            sb.Append (_FuelMixture.CurrentStateName);
	            sb.AppendFormat (" /fuel={0}", _FuelMixture.FuelFlowRate);
	            sb.AppendFormat (" /air={0}", _FuelMixture.AirFlowRate);
                if(_Air.CurrentStateName.EndsWith ("Gusting "))
                {
                    sb.AppendFormat (" /lastgust={0}", _FuelMixture.LastGust);
                }
	            return sb.ToString ();
            }
	    }

	    public bool FrameIsLit
	    {
	        get
	        {
	            return _FuelMixture.CurrentStateName.EndsWith ("Burning");
	        }
	    }

	    void Init()
	    {
            _Air.Init ();
            _Flint.Init ();
            _FuelMixture.Init ();
            _Valve.Init ();	        
	    }
	    
	    void Log()
	    {
	        new ConsoleStateEventHandler (_Air);
            new ConsoleStateEventHandler (_Flint);
            new ConsoleStateEventHandler (_FuelMixture);
            new ConsoleStateEventHandler (_Valve);
        }
	    
	    private Air _Air;
	    private Flint _Flint;
	    private FuelMixture _FuelMixture;
	    private Valve _Valve;
	    

	    public void SpinFlint()
	    {
	        _Flint.User.Receive (null, new QEvent(FlintSignals.Spin));
	    }

	    public void PressValve()
	    {
	        _Valve.User.Receive (null, new QEvent (ValveSignals.Press));
	    }

	    public void ReleaseValve()
	    {
            _Valve.User.Receive (null, new QEvent (ValveSignals.Release));
        }

	    public void IncreaseAirFlow()
	    {
	        _Air.SigPressureIncrease (null);
        }

	    public void DecreaseAirFlow()
	    {
            _Air.SigPressureDecrease (null);
        }

        public void IncreaseFuelFlow()
        {
            _Valve.User.Receive (null, new QEvent (ValveSignals.IncreaseFlow));
        }

        public void DecreaseFuelFlow()
        {
            _Valve.User.Receive (null, new QEvent (ValveSignals.DecreaseFlow));
        }
	    
        private void EventManager_PolledEvent(IQEventManager eventManager, IQHsm hsm, IQEvent ev, PollContext pollContext)
        {
            EventHandler handler = StateChange;
            if(null != handler)
            {
                handler (hsm, new EventArgs ());
            }
        }
	    
        public EventHandler StateChange;
	    
    }
}
