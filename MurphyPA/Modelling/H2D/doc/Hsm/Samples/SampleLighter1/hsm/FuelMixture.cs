//---------------------------------------------------------------------
//Begin[[StartOfFileBlock]]
//End[[StartOfFileBlock]]
//---------------------------------------------------------------------

using System;
using qf4net;

//---------------------------------------------------------------------
//Begin[[UsingNameSpaceCodeBlock]]
//End[[UsingNameSpaceCodeBlock]]
//---------------------------------------------------------------------

namespace Samples.Lighter
{
	// SM: FuelMixture
	// State: Active
	// State: Active.FuelSupplied
	// State: Active.FuelSupplied.Burning
	// State: Active.FuelSupplied.Mixed
	// State: Active.FuelSupplied.TemporarilyNoFuel
	// State: Active.NoFuel
	// Transition: Air.Gust/SetLastGust(ev)
	// Transition: FuelDissipated
	// Transition: FuelInMixture
	// Transition: t0-after 1 raise FuelReplenished
	// Transition: Valve.StopFlow/StopFlow()
	// Transition: Air.Flow/DissipateFuel(ev); TestRates()
	// Transition: Air.Gust
	// Transition: t0-Air.Gust[FuelFlowIsStrongEnough(ev)]
	// Transition: Flint.Ignite
	// Transition: Valve.Mix/MixFuel(ev); TestRates()
	[ModelInformation (@"FuelMixture.sm1", "2ae9adcd-2338-4285-bd32-89f3fcdf7965", "5")]
	[TransitionEvent ("Flow", "Air")]
	[TransitionEvent ("FuelDissipated")]
	[TransitionEvent ("FuelInMixture")]
	[TransitionEvent ("FuelReplenished")]
	[TransitionEvent ("Gust", "Air")]
	[TransitionEvent ("Ignite", "Flint")]
	[TransitionEvent ("Mix", "Valve")]
	[TransitionEvent ("StopFlow", "Valve")]
	public class FuelMixture : LQHsm, ISigFuelMixture
	//---------------------------------------------------------------------
	//Begin[[ImplementsInterfaces]]
	//End[[ImplementsInterfaces]]
	//---------------------------------------------------------------------
	{
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		int _FuelFlowRate;
	    int _AirFlowRate;		    
	    int _LastGust;
	    
	    public int FuelFlowRate { get { return _FuelFlowRate; }}
        public int AirFlowRate { get { return _AirFlowRate; }}
	    public int LastGust { get { return _LastGust; }}
	    
	    void MixFuel(IQEvent ev)
	    {
	        _FuelFlowRate = (int)ev.QData;
	    }
	    
	    void DissipateFuel(IQEvent ev)
	    {
            _AirFlowRate = (int)ev.QData;	        
        }
	    
	    void StopFlow()
	    {
	        _FuelFlowRate = 0;
	    }
	    
	    void TestRates ()
	    {
	        if(_FuelFlowRate > _AirFlowRate)
	        {
	            SigFuelInMixture (null);
	        } else
	        {
	            SigFuelDissipated (null);
	        }
	    }

	    void SetLastGust(IQEvent ev)
	    {
            _LastGust = (int)ev.QData;	        
	    }
	    
	    bool FuelFlowIsStrongEnough (IQEvent ev)
	    {
	        SetLastGust (ev);
	        int gustLevel = (int)ev.QData;
	        return gustLevel < _FuelFlowRate;
	    }
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static FuelMixture ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new FuelMixture();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		protected override void InitializeStateMachine()
		{
			InitializeState(s_Active);
			//Begin[[InitialiseSM]]
			//End[[InitialiseSM]]
		}
		
		#region State Fields
		static protected QState s_Active;
		static protected QState s_Active_FuelSupplied;
		static protected QState s_Active_FuelSupplied_Burning;
		static protected QState s_Active_FuelSupplied_Mixed;
		static protected QState s_Active_FuelSupplied_TemporarilyNoFuel;
		static protected QState s_Active_NoFuel;
		
		#endregion
		
		#region Ports
		protected IQPort _Air;
		public IQPort Air { get { if (_Air == null) { _Air = CreatePort ("Air"); } return _Air; } }
		protected IQPort _Flint;
		public IQPort Flint { get { if (_Flint == null) { _Flint = CreatePort ("Flint"); } return _Flint; } }
		protected IQPort _Valve;
		public IQPort Valve { get { if (_Valve == null) { _Valve = CreatePort ("Valve"); } return _Valve; } }
		#endregion
		
		#region Constructors
		public FuelMixture (){
			CreateStateFields ();
		}
		
		public FuelMixture (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public FuelMixture (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public FuelMixture (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected virtual void CreateStateFields (){
			if(null == _MyStaticInstance){
				s_Active = new QState (S_Active);
				s_Active_FuelSupplied = new QState (S_Active_FuelSupplied);
				s_Active_FuelSupplied_Burning = new QState (S_Active_FuelSupplied_Burning);
				s_Active_FuelSupplied_Mixed = new QState (S_Active_FuelSupplied_Mixed);
				s_Active_FuelSupplied_TemporarilyNoFuel = new QState (S_Active_FuelSupplied_TemporarilyNoFuel);
				s_Active_NoFuel = new QState (S_Active_NoFuel);
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State Active
		[StateMethod ("Active")]
		protected virtual QState S_Active (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Init: {
				LogStateEvent (StateLogType.Init, s_Active, s_Active_NoFuel);
				InitializeState (s_Active_NoFuel);
			} return null;
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Active);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Active);
			} return null;
			case QualifiedFuelMixtureSignals.Air_Flow: {
				DissipateFuel(ev);
				TestRates();
				LogStateEvent (StateLogType.EventInternalTransition, s_Active, s_Active, "Air.Flow", "Air.Flow/DissipateFuel(ev); TestRates()");
				return null;
			}  // Air.Flow
			case QualifiedFuelMixtureSignals.Valve_Mix: {
				MixFuel(ev);
				TestRates();
				LogStateEvent (StateLogType.EventInternalTransition, s_Active, s_Active, "Valve.Mix", "Valve.Mix/MixFuel(ev); TestRates()");
				return null;
			}  // Valve.Mix
			} // switch
			
			return TopState;
		} // S_Active
		#endregion
	
		
		#region State Active_FuelSupplied
		protected static int s_trans_FuelDissipated_Active_FuelSupplied_2_Active_NoFuel = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_Valve_StopFlow_Active_FuelSupplied_2_Active_NoFuel = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Active_FuelSupplied")]
		protected virtual QState S_Active_FuelSupplied (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Active_FuelSupplied);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Active_FuelSupplied);
			} return null;
			case QualifiedFuelMixtureSignals.FuelDissipated: {
				LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied, s_Active_NoFuel, "FuelDissipated", "FuelDissipated");
				TransitionTo (s_Active_NoFuel, s_trans_FuelDissipated_Active_FuelSupplied_2_Active_NoFuel);
				return null;
			}  // FuelDissipated
			case QualifiedFuelMixtureSignals.Valve_StopFlow: {
				StopFlow();
				LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied, s_Active_NoFuel, "Valve.StopFlow", "Valve.StopFlow/StopFlow()");
				TransitionTo (s_Active_NoFuel, s_trans_Valve_StopFlow_Active_FuelSupplied_2_Active_NoFuel);
				return null;
			}  // Valve.StopFlow
			} // switch
			
			return s_Active;
		} // S_Active_FuelSupplied
		#endregion
	
		
		#region State Active_FuelSupplied_Burning
		protected static int s_trans_Air_Gust_Active_FuelSupplied_Burning_2_Active_FuelSupplied_TemporarilyNoFuel = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t0_Air_Gust_Active_FuelSupplied_Burning_2_Active_FuelSupplied_Burning = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Active_FuelSupplied_Burning")]
		protected virtual QState S_Active_FuelSupplied_Burning (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Active_FuelSupplied_Burning);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Active_FuelSupplied_Burning);
			} return null;
			case QualifiedFuelMixtureSignals.Air_Gust: {
				 if (FuelFlowIsStrongEnough(ev)) {
					LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied_Burning, s_Active_FuelSupplied_Burning, "Air.Gust", "t0-Air.Gust[FuelFlowIsStrongEnough(ev)]");
					TransitionTo (s_Active_FuelSupplied_Burning, s_trans_t0_Air_Gust_Active_FuelSupplied_Burning_2_Active_FuelSupplied_Burning);
					return null;
				}
				else {
					LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied_Burning, s_Active_FuelSupplied_TemporarilyNoFuel, "Air.Gust", "Air.Gust");
					TransitionTo (s_Active_FuelSupplied_TemporarilyNoFuel, s_trans_Air_Gust_Active_FuelSupplied_Burning_2_Active_FuelSupplied_TemporarilyNoFuel);
					return null;
				}
			}  // Air.Gust
			} // switch
			
			return s_Active_FuelSupplied;
		} // S_Active_FuelSupplied_Burning
		#endregion
	
		
		#region State Active_FuelSupplied_Mixed
		protected static int s_trans_Air_Gust_Active_FuelSupplied_Mixed_2_Active_FuelSupplied_TemporarilyNoFuel = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_Flint_Ignite_Active_FuelSupplied_Mixed_2_Active_FuelSupplied_Burning = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Active_FuelSupplied_Mixed")]
		protected virtual QState S_Active_FuelSupplied_Mixed (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Active_FuelSupplied_Mixed);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Active_FuelSupplied_Mixed);
			} return null;
			case QualifiedFuelMixtureSignals.Air_Gust: {
				SetLastGust(ev);
				LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied_Mixed, s_Active_FuelSupplied_TemporarilyNoFuel, "Air.Gust", "Air.Gust/SetLastGust(ev)");
				TransitionTo (s_Active_FuelSupplied_TemporarilyNoFuel, s_trans_Air_Gust_Active_FuelSupplied_Mixed_2_Active_FuelSupplied_TemporarilyNoFuel);
				return null;
			}  // Air.Gust
			case QualifiedFuelMixtureSignals.Flint_Ignite: {
				LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied_Mixed, s_Active_FuelSupplied_Burning, "Flint.Ignite", "Flint.Ignite");
				TransitionTo (s_Active_FuelSupplied_Burning, s_trans_Flint_Ignite_Active_FuelSupplied_Mixed_2_Active_FuelSupplied_Burning);
				return null;
			}  // Flint.Ignite
			} // switch
			
			return s_Active_FuelSupplied;
		} // S_Active_FuelSupplied_Mixed
		#endregion
	
		
		#region State Active_FuelSupplied_TemporarilyNoFuel
		protected static int s_trans_t0_FuelReplenished_Active_FuelSupplied_TemporarilyNoFuel_2_Active_FuelSupplied_Mixed = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Active_FuelSupplied_TemporarilyNoFuel")]
		protected virtual QState S_Active_FuelSupplied_TemporarilyNoFuel (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Active_FuelSupplied_TemporarilyNoFuel);
				SetTimeOut ("Active_FuelSupplied_TemporarilyNoFuel_t0_FuelReplenished", TimeSpan.FromSeconds (1), new QEvent ("FuelReplenished"), TimeOutType.Single);
			} return null;
			case QSignals.Exit: {
				ClearTimeOut ("Active_FuelSupplied_TemporarilyNoFuel_t0_FuelReplenished");
				LogStateEvent (StateLogType.Exit, s_Active_FuelSupplied_TemporarilyNoFuel);
			} return null;
			case QualifiedFuelMixtureSignals.FuelReplenished: {
				LogStateEvent (StateLogType.EventTransition, s_Active_FuelSupplied_TemporarilyNoFuel, s_Active_FuelSupplied_Mixed, "FuelReplenished", "t0-after 1 raise FuelReplenished");
				TransitionTo (s_Active_FuelSupplied_Mixed, s_trans_t0_FuelReplenished_Active_FuelSupplied_TemporarilyNoFuel_2_Active_FuelSupplied_Mixed);
				return null;
			}  // FuelReplenished
			} // switch
			
			return s_Active_FuelSupplied;
		} // S_Active_FuelSupplied_TemporarilyNoFuel
		#endregion
	
		
		#region State Active_NoFuel
		protected static int s_trans_FuelInMixture_Active_NoFuel_2_Active_FuelSupplied_Mixed = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Active_NoFuel")]
		protected virtual QState S_Active_NoFuel (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Active_NoFuel);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Active_NoFuel);
			} return null;
			case QualifiedFuelMixtureSignals.FuelInMixture: {
				LogStateEvent (StateLogType.EventTransition, s_Active_NoFuel, s_Active_FuelSupplied_Mixed, "FuelInMixture", "FuelInMixture");
				TransitionTo (s_Active_FuelSupplied_Mixed, s_trans_FuelInMixture_Active_NoFuel_2_Active_FuelSupplied_Mixed);
				return null;
			}  // FuelInMixture
			} // switch
			
			return s_Active;
		} // S_Active_NoFuel
		#endregion
	
		#region ISigFuelMixture Members
		public void SigFlow (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.Flow, data)); }
		public void SigFuelDissipated (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.FuelDissipated, data)); }
		public void SigFuelInMixture (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.FuelInMixture, data)); }
		public void SigFuelReplenished (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.FuelReplenished, data)); }
		public void SigGust (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.Gust, data)); }
		public void SigIgnite (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.Ignite, data)); }
		public void SigMix (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.Mix, data)); }
		public void SigStopFlow (object data) { AsyncDispatch (new QEvent (FuelMixtureSignals.StopFlow, data)); }
		#endregion // ISigFuelMixture Members
	} // FuelMixture
	public interface ISigFuelMixture
	{
		void SigFlow (object data);
		void SigFuelDissipated (object data);
		void SigFuelInMixture (object data);
		void SigFuelReplenished (object data);
		void SigGust (object data);
		void SigIgnite (object data);
		void SigMix (object data);
		void SigStopFlow (object data);
	}
	public class QualifiedFuelMixtureSignals
	{
		public const string Air_Flow = "Air.Flow";
		public const string Air_Gust = "Air.Gust";
		public const string Flint_Ignite = "Flint.Ignite";
		public const string FuelDissipated = "FuelDissipated";
		public const string FuelInMixture = "FuelInMixture";
		public const string FuelReplenished = "FuelReplenished";
		public const string Valve_Mix = "Valve.Mix";
		public const string Valve_StopFlow = "Valve.StopFlow";
	}
	public class FuelMixtureSignals
	{
		public const string Flow = "Flow";
		public const string FuelDissipated = "FuelDissipated";
		public const string FuelInMixture = "FuelInMixture";
		public const string FuelReplenished = "FuelReplenished";
		public const string Gust = "Gust";
		public const string Ignite = "Ignite";
		public const string Mix = "Mix";
		public const string StopFlow = "StopFlow";
	}
}
