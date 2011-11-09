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
	// SM: Air
	// State: Moving
	// State: Moving.Draft
	// State: Moving.Gusting
	// State: Still
	// Transition: t1-every RandomDraftInterval() raise Draft/RandomlyChangeFlowRate()
	// Transition: Gust/^FuelMixture.Gust(RandomGustRate)
	// Transition: t0-every RandomGustInterval() raise Gust[JustChangeFlowRate()]/RandomlyChangeGustFlowRate(); ; ^FuelMixture.Flow(FlowRate)
	// Transition: PressureDecrease
	// Transition: PressureDecrease
	// Transition: PressureIncrease
	// Transition: PressureIncrease
	[ModelInformation (@"Air.sm1", "a82cbd8f-bbcf-4935-a04f-c1dfc68fa492", "6")]
	[TransitionEvent ("Draft")]
	[TransitionEvent ("Gust")]
	[TransitionEvent ("PressureDecrease")]
	[TransitionEvent ("PressureIncrease")]
	public class Air : LQHsm, ISigAir
	//---------------------------------------------------------------------
	//Begin[[ImplementsInterfaces]]
	//End[[ImplementsInterfaces]]
	//---------------------------------------------------------------------
	{
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		int _FlowRate;
        public int FlowRate { get { return _FlowRate; }}
	    
	    const int _StandardFlowMin = 1;
	    const int _StandardFlowMax = 10;
	    const int _GustFlowMin = 7;
	    const int _GustFlowMax = 15;
        const int _GustMin = 12;
        const int _GustMax = 19;
	    	    
        double RandomDraftInterval()
        {
            Random rnd = new Random ();
            double result = 1.0 + rnd.NextDouble ();
            return result;
        }
               
	    void RandomlyChangeFlowRate()
	    {
            Random rnd = new Random ();
            int result = rnd.Next(_StandardFlowMin, _StandardFlowMax);
            _FlowRate = result;	        
	    }
	    
	    void SetFlowToZero()
	    {
	        _FlowRate = 0;
	    }
               
        void RandomlyChangeGustFlowRate()
        {
            Random rnd = new Random ();
            int result = rnd.Next(_GustFlowMin, _GustFlowMax);
            _FlowRate = result;
        }

	    bool JustChangeFlowRate()
	    {
            Random rnd = new Random ();
            return rnd.Next (10) > 6;	        
	    }
	    
	    double RandomGustInterval()
	    {
            Random rnd = new Random ();
            double result = 1.0 + rnd.NextDouble ();
            return result;	        
	    }
                        
	    int RandomGustRate
	    {
	        get
	        {
                Random rnd = new Random ();
                int result = rnd.Next(_FlowRate, _GustMax);
                return result; 
            }
	    }
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static Air ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new Air();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		protected override void InitializeStateMachine()
		{
			InitializeState(s_Still);
			//Begin[[InitialiseSM]]
			//End[[InitialiseSM]]
		}
		
		#region State Fields
		static protected QState s_Moving;
		static protected QState s_Moving_Draft;
		static protected QState s_Moving_Gusting;
		static protected QState s_Still;
		
		#endregion
		
		#region Ports
		protected IQPort _FuelMixture;
		public IQPort FuelMixture { get { if (_FuelMixture == null) { _FuelMixture = CreatePort ("FuelMixture"); } return _FuelMixture; } }
		#endregion
		
		#region Constructors
		public Air (){
			CreateStateFields ();
		}
		
		public Air (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public Air (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public Air (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public Air (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public Air (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public Air (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Air (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Air (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public Air (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected virtual void CreateStateFields (){
			if(null == _MyStaticInstance){
				s_Moving = new QState (S_Moving);
				s_Moving_Draft = new QState (S_Moving_Draft);
				s_Moving_Gusting = new QState (S_Moving_Gusting);
				s_Still = new QState (S_Still);
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State Moving
		[StateMethod ("Moving")]
		protected virtual QState S_Moving (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Moving);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Moving);
			} return null;
			} // switch
			
			return TopState;
		} // S_Moving
		#endregion
	
		
		#region State Moving_Draft
		protected static int s_trans_PressureDecrease_Moving_Draft_2_Still = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_PressureIncrease_Moving_Draft_2_Moving_Gusting = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t1_Draft_Moving_Draft_2_Moving_Draft = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Moving_Draft")]
		protected virtual QState S_Moving_Draft (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Moving_Draft, "^FuelMixture.Flow(FlowRate)");
				FuelMixture.Send (new QEvent (FuelMixtureSignals.Flow, FlowRate));
				SetTimeOut ("Moving_Draft_t1_Draft", TimeSpan.FromSeconds (RandomDraftInterval()), new QEvent ("Draft"), TimeOutType.Repeat);
			} return null;
			case QSignals.Exit: {
				ClearTimeOut ("Moving_Draft_t1_Draft");
				LogStateEvent (StateLogType.Exit, s_Moving_Draft);
			} return null;
			case QualifiedAirSignals.Draft: {
				RandomlyChangeFlowRate();
				LogStateEvent (StateLogType.EventTransition, s_Moving_Draft, s_Moving_Draft, "Draft", "t1-every RandomDraftInterval() raise Draft/RandomlyChangeFlowRate()");
				TransitionTo (s_Moving_Draft, s_trans_t1_Draft_Moving_Draft_2_Moving_Draft);
				return null;
			}  // Draft
			case QualifiedAirSignals.PressureDecrease: {
				LogStateEvent (StateLogType.EventTransition, s_Moving_Draft, s_Still, "PressureDecrease", "PressureDecrease");
				TransitionTo (s_Still, s_trans_PressureDecrease_Moving_Draft_2_Still);
				return null;
			}  // PressureDecrease
			case QualifiedAirSignals.PressureIncrease: {
				LogStateEvent (StateLogType.EventTransition, s_Moving_Draft, s_Moving_Gusting, "PressureIncrease", "PressureIncrease");
				TransitionTo (s_Moving_Gusting, s_trans_PressureIncrease_Moving_Draft_2_Moving_Gusting);
				return null;
			}  // PressureIncrease
			} // switch
			
			return s_Moving;
		} // S_Moving_Draft
		#endregion
	
		
		#region State Moving_Gusting
		protected static int s_trans_Gust_Moving_Gusting_2_Moving_Gusting = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_PressureDecrease_Moving_Gusting_2_Moving_Draft = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t0_Gust_Moving_Gusting_2_Moving_Gusting = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Moving_Gusting")]
		protected virtual QState S_Moving_Gusting (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Moving_Gusting);
				SetTimeOut ("Moving_Gusting_t0_Gust", TimeSpan.FromSeconds (RandomGustInterval()), new QEvent ("Gust"), TimeOutType.Repeat);
			} return null;
			case QSignals.Exit: {
				ClearTimeOut ("Moving_Gusting_t0_Gust");
				LogStateEvent (StateLogType.Exit, s_Moving_Gusting);
			} return null;
			case QualifiedAirSignals.Gust: {
				 if (JustChangeFlowRate()) {
					RandomlyChangeGustFlowRate();
					FuelMixture.Send (new QEvent (FuelMixtureSignals.Flow, FlowRate));
					LogStateEvent (StateLogType.EventTransition, s_Moving_Gusting, s_Moving_Gusting, "Gust", "t0-every RandomGustInterval() raise Gust[JustChangeFlowRate()]/RandomlyChangeGustFlowRate(); ; ^FuelMixture.Flow(FlowRate)");
					TransitionTo (s_Moving_Gusting, s_trans_t0_Gust_Moving_Gusting_2_Moving_Gusting);
					return null;
				}
				else {
					FuelMixture.Send (new QEvent (FuelMixtureSignals.Gust, RandomGustRate));
					LogStateEvent (StateLogType.EventTransition, s_Moving_Gusting, s_Moving_Gusting, "Gust", "Gust/^FuelMixture.Gust(RandomGustRate)");
					TransitionTo (s_Moving_Gusting, s_trans_Gust_Moving_Gusting_2_Moving_Gusting);
					return null;
				}
			}  // Gust
			case QualifiedAirSignals.PressureDecrease: {
				LogStateEvent (StateLogType.EventTransition, s_Moving_Gusting, s_Moving_Draft, "PressureDecrease", "PressureDecrease");
				TransitionTo (s_Moving_Draft, s_trans_PressureDecrease_Moving_Gusting_2_Moving_Draft);
				return null;
			}  // PressureDecrease
			} // switch
			
			return s_Moving;
		} // S_Moving_Gusting
		#endregion
	
		
		#region State Still
		protected static int s_trans_PressureIncrease_Still_2_Moving_Draft = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Still")]
		protected virtual QState S_Still (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Still, "SetFlowToZero(); ; ^FuelMixture.Flow(FlowRate)");
				SetFlowToZero();
				FuelMixture.Send (new QEvent (FuelMixtureSignals.Flow, FlowRate));
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Still);
			} return null;
			case QualifiedAirSignals.PressureIncrease: {
				LogStateEvent (StateLogType.EventTransition, s_Still, s_Moving_Draft, "PressureIncrease", "PressureIncrease");
				TransitionTo (s_Moving_Draft, s_trans_PressureIncrease_Still_2_Moving_Draft);
				return null;
			}  // PressureIncrease
			} // switch
			
			return TopState;
		} // S_Still
		#endregion
	
		#region ISigAir Members
		public void SigDraft (object data) { AsyncDispatch (new QEvent (AirSignals.Draft, data)); }
		public void SigGust (object data) { AsyncDispatch (new QEvent (AirSignals.Gust, data)); }
		public void SigPressureDecrease (object data) { AsyncDispatch (new QEvent (AirSignals.PressureDecrease, data)); }
		public void SigPressureIncrease (object data) { AsyncDispatch (new QEvent (AirSignals.PressureIncrease, data)); }
		#endregion // ISigAir Members
	} // Air
	public interface ISigAir
	{
		void SigDraft (object data);
		void SigGust (object data);
		void SigPressureDecrease (object data);
		void SigPressureIncrease (object data);
	}
	public class QualifiedAirSignals
	{
		public const string Draft = "Draft";
		public const string Gust = "Gust";
		public const string PressureDecrease = "PressureDecrease";
		public const string PressureIncrease = "PressureIncrease";
	}
	public class AirSignals
	{
		public const string Draft = "Draft";
		public const string Gust = "Gust";
		public const string PressureDecrease = "PressureDecrease";
		public const string PressureIncrease = "PressureIncrease";
	}
}
