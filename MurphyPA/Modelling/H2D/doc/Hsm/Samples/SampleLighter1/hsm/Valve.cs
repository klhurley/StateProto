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
	// SM: Valve
	// State: Closed
	// State: Empty
	// State: Open
	// Transition: Empty
	// Transition: Empty
	// Transition: User.DecreaseFlow/ChangeFlowRate(-1)
	// Transition: User.DecreaseFlow/ChangeFlowRate(-1)
	// Transition: User.IncreaseFlow/ChangeFlowRate(1)
	// Transition: User.IncreaseFlow/ChangeFlowRate(1)
	// Transition: User.Press
	// Transition: User.Release
	[ModelInformation (@"Valve.sm1", "c780d79b-93a2-4371-9f5e-6af910808d38", "7")]
	[TransitionEvent ("DecreaseFlow", "User")]
	[TransitionEvent ("Empty")]
	[TransitionEvent ("IncreaseFlow", "User")]
	[TransitionEvent ("Press", "User")]
	[TransitionEvent ("Release", "User")]
	public class Valve : LQHsm, ISigValve
	//---------------------------------------------------------------------
	//Begin[[ImplementsInterfaces]]
	//End[[ImplementsInterfaces]]
	//---------------------------------------------------------------------
	{
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		int _FlowRate = 10;
	    int _MaxFlowRate = 20;

	    public int FlowValue { get { return _FlowRate; } }
	    
	    void ChangeFlowRate(int delta)
	    {
	        int newRate = _FlowRate + delta;
	        if(newRate >= 0 && newRate <= _MaxFlowRate)
	        {
	            _FlowRate = newRate;
	        }
	    }
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static Valve ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new Valve();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		protected override void InitializeStateMachine()
		{
			InitializeState(s_Closed);
			//Begin[[InitialiseSM]]
			//End[[InitialiseSM]]
		}
		
		#region State Fields
		static protected QState s_Closed;
		static protected QState s_Empty;
		static protected QState s_Open;
		
		#endregion
		
		#region Ports
		protected IQPort _FuelMixture;
		public IQPort FuelMixture { get { if (_FuelMixture == null) { _FuelMixture = CreatePort ("FuelMixture"); } return _FuelMixture; } }
		protected IQPort _User;
		public IQPort User { get { if (_User == null) { _User = CreatePort ("User"); } return _User; } }
		#endregion
		
		#region Constructors
		public Valve (){
			CreateStateFields ();
		}
		
		public Valve (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public Valve (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public Valve (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public Valve (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public Valve (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public Valve (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Valve (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Valve (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public Valve (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected virtual void CreateStateFields (){
			if(null == _MyStaticInstance){
				s_Closed = new QState (S_Closed);
				s_Empty = new QState (S_Empty);
				s_Open = new QState (S_Open);
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State Closed
		protected static int s_trans_Empty_Closed_2_Empty = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_User_DecreaseFlow_Closed_2_Closed = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_User_IncreaseFlow_Closed_2_Closed = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_User_Press_Closed_2_Open = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Closed")]
		protected virtual QState S_Closed (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Closed, "^FuelMixture.StopFlow()");
				FuelMixture.Send (new QEvent (FuelMixtureSignals.StopFlow));
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Closed);
			} return null;
			case QualifiedValveSignals.Empty: {
				LogStateEvent (StateLogType.EventTransition, s_Closed, s_Empty, "Empty", "Empty");
				TransitionTo (s_Empty, s_trans_Empty_Closed_2_Empty);
				return null;
			}  // Empty
			case QualifiedValveSignals.User_DecreaseFlow: {
				ChangeFlowRate(-1);
				LogStateEvent (StateLogType.EventTransition, s_Closed, s_Closed, "User.DecreaseFlow", "User.DecreaseFlow/ChangeFlowRate(-1)");
				TransitionTo (s_Closed, s_trans_User_DecreaseFlow_Closed_2_Closed);
				return null;
			}  // User.DecreaseFlow
			case QualifiedValveSignals.User_IncreaseFlow: {
				ChangeFlowRate(1);
				LogStateEvent (StateLogType.EventTransition, s_Closed, s_Closed, "User.IncreaseFlow", "User.IncreaseFlow/ChangeFlowRate(1)");
				TransitionTo (s_Closed, s_trans_User_IncreaseFlow_Closed_2_Closed);
				return null;
			}  // User.IncreaseFlow
			case QualifiedValveSignals.User_Press: {
				LogStateEvent (StateLogType.EventTransition, s_Closed, s_Open, "User.Press", "User.Press");
				TransitionTo (s_Open, s_trans_User_Press_Closed_2_Open);
				return null;
			}  // User.Press
			} // switch
			
			return TopState;
		} // S_Closed
		#endregion
	
		
		#region State Empty
		[StateMethod ("Empty")]
		protected virtual QState S_Empty (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Empty, "^FuelMixture.StopFlow()");
				FuelMixture.Send (new QEvent (FuelMixtureSignals.StopFlow));
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Empty);
			} return null;
			} // switch
			
			return TopState;
		} // S_Empty
		#endregion
	
		
		#region State Open
		protected static int s_trans_Empty_Open_2_Empty = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_User_DecreaseFlow_Open_2_Open = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_User_IncreaseFlow_Open_2_Open = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_User_Release_Open_2_Closed = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Open")]
		protected virtual QState S_Open (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Open, "^FuelMixture.Mix(FlowValue)");
				FuelMixture.Send (new QEvent (FuelMixtureSignals.Mix, FlowValue));
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Open);
			} return null;
			case QualifiedValveSignals.Empty: {
				LogStateEvent (StateLogType.EventTransition, s_Open, s_Empty, "Empty", "Empty");
				TransitionTo (s_Empty, s_trans_Empty_Open_2_Empty);
				return null;
			}  // Empty
			case QualifiedValveSignals.User_DecreaseFlow: {
				ChangeFlowRate(-1);
				LogStateEvent (StateLogType.EventTransition, s_Open, s_Open, "User.DecreaseFlow", "User.DecreaseFlow/ChangeFlowRate(-1)");
				TransitionTo (s_Open, s_trans_User_DecreaseFlow_Open_2_Open);
				return null;
			}  // User.DecreaseFlow
			case QualifiedValveSignals.User_IncreaseFlow: {
				ChangeFlowRate(1);
				LogStateEvent (StateLogType.EventTransition, s_Open, s_Open, "User.IncreaseFlow", "User.IncreaseFlow/ChangeFlowRate(1)");
				TransitionTo (s_Open, s_trans_User_IncreaseFlow_Open_2_Open);
				return null;
			}  // User.IncreaseFlow
			case QualifiedValveSignals.User_Release: {
				LogStateEvent (StateLogType.EventTransition, s_Open, s_Closed, "User.Release", "User.Release");
				TransitionTo (s_Closed, s_trans_User_Release_Open_2_Closed);
				return null;
			}  // User.Release
			} // switch
			
			return TopState;
		} // S_Open
		#endregion
	
		#region ISigValve Members
		public void SigDecreaseFlow (object data) { AsyncDispatch (new QEvent (ValveSignals.DecreaseFlow, data)); }
		public void SigEmpty (object data) { AsyncDispatch (new QEvent (ValveSignals.Empty, data)); }
		public void SigIncreaseFlow (object data) { AsyncDispatch (new QEvent (ValveSignals.IncreaseFlow, data)); }
		public void SigPress (object data) { AsyncDispatch (new QEvent (ValveSignals.Press, data)); }
		public void SigRelease (object data) { AsyncDispatch (new QEvent (ValveSignals.Release, data)); }
		#endregion // ISigValve Members
	} // Valve
	public interface ISigValve
	{
		void SigDecreaseFlow (object data);
		void SigEmpty (object data);
		void SigIncreaseFlow (object data);
		void SigPress (object data);
		void SigRelease (object data);
	}
	public class QualifiedValveSignals
	{
		public const string Empty = "Empty";
		public const string User_DecreaseFlow = "User.DecreaseFlow";
		public const string User_IncreaseFlow = "User.IncreaseFlow";
		public const string User_Press = "User.Press";
		public const string User_Release = "User.Release";
	}
	public class ValveSignals
	{
		public const string DecreaseFlow = "DecreaseFlow";
		public const string Empty = "Empty";
		public const string IncreaseFlow = "IncreaseFlow";
		public const string Press = "Press";
		public const string Release = "Release";
	}
}
