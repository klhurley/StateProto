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
	// SM: Flint
	// State: NoSparks
	// State: Sparking
	// Transition: t1-every SparkFrequencyInterval() raise Spark/^FuelMixture.Ignite()
	// Transition: t0-after RandomSpinInterval() raise StopSpinning
	// Transition: User.Spin
	[ModelInformation (@"Flint.sm1", "fa7a4d7c-8e52-4e9d-96b3-325cb7cf9a5d", "3")]
	[TransitionEvent ("Spark")]
	[TransitionEvent ("Spin", "User")]
	[TransitionEvent ("StopSpinning")]
	public class Flint : LQHsm, ISigFlint
	//---------------------------------------------------------------------
	//Begin[[ImplementsInterfaces]]
	//End[[ImplementsInterfaces]]
	//---------------------------------------------------------------------
	{
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		double SparkFrequencyInterval()
	    {
	        return 0.2;
	    }
	    
	    double RandomSpinInterval()
	    {
	        Random rnd = new Random ();
	        double result = 0.1 + rnd.Next (5) * 0.1;
	        return result;
	    }
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static Flint ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new Flint();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		protected override void InitializeStateMachine()
		{
			InitializeState(s_NoSparks);
			//Begin[[InitialiseSM]]
			//End[[InitialiseSM]]
		}
		
		#region State Fields
		static protected QState s_NoSparks;
		static protected QState s_Sparking;
		
		#endregion
		
		#region Ports
		protected IQPort _FuelMixture;
		public IQPort FuelMixture { get { if (_FuelMixture == null) { _FuelMixture = CreatePort ("FuelMixture"); } return _FuelMixture; } }
		protected IQPort _User;
		public IQPort User { get { if (_User == null) { _User = CreatePort ("User"); } return _User; } }
		#endregion
		
		#region Constructors
		public Flint (){
			CreateStateFields ();
		}
		
		public Flint (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public Flint (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public Flint (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public Flint (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public Flint (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public Flint (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Flint (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Flint (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public Flint (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected virtual void CreateStateFields (){
			if(null == _MyStaticInstance){
				s_NoSparks = new QState (S_NoSparks);
				s_Sparking = new QState (S_Sparking);
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State NoSparks
		protected static int s_trans_User_Spin_NoSparks_2_Sparking = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("NoSparks")]
		protected virtual QState S_NoSparks (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_NoSparks);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_NoSparks);
			} return null;
			case QualifiedFlintSignals.User_Spin: {
				LogStateEvent (StateLogType.EventTransition, s_NoSparks, s_Sparking, "User.Spin", "User.Spin");
				TransitionTo (s_Sparking, s_trans_User_Spin_NoSparks_2_Sparking);
				return null;
			}  // User.Spin
			} // switch
			
			return TopState;
		} // S_NoSparks
		#endregion
	
		
		#region State Sparking
		protected static int s_trans_t0_StopSpinning_Sparking_2_NoSparks = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t1_Spark_Sparking_2_Sparking = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Sparking")]
		protected virtual QState S_Sparking (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Sparking);
				SetTimeOut ("Sparking_t1_Spark", TimeSpan.FromSeconds (SparkFrequencyInterval()), new QEvent ("Spark"), TimeOutType.Repeat);
				SetTimeOut ("Sparking_t0_StopSpinning", TimeSpan.FromSeconds (RandomSpinInterval()), new QEvent ("StopSpinning"), TimeOutType.Single);
			} return null;
			case QSignals.Exit: {
				ClearTimeOut ("Sparking_t1_Spark");
				ClearTimeOut ("Sparking_t0_StopSpinning");
				LogStateEvent (StateLogType.Exit, s_Sparking);
			} return null;
			case QualifiedFlintSignals.Spark: {
				FuelMixture.Send (new QEvent (FuelMixtureSignals.Ignite));
				LogStateEvent (StateLogType.EventTransition, s_Sparking, s_Sparking, "Spark", "t1-every SparkFrequencyInterval() raise Spark/^FuelMixture.Ignite()");
				TransitionTo (s_Sparking, s_trans_t1_Spark_Sparking_2_Sparking);
				return null;
			}  // Spark
			case QualifiedFlintSignals.StopSpinning: {
				LogStateEvent (StateLogType.EventTransition, s_Sparking, s_NoSparks, "StopSpinning", "t0-after RandomSpinInterval() raise StopSpinning");
				TransitionTo (s_NoSparks, s_trans_t0_StopSpinning_Sparking_2_NoSparks);
				return null;
			}  // StopSpinning
			} // switch
			
			return TopState;
		} // S_Sparking
		#endregion
	
		#region ISigFlint Members
		public void SigIgnite (object data) { AsyncDispatch (new QEvent (FlintSignals.Ignite, data)); }
		public void SigSpark (object data) { AsyncDispatch (new QEvent (FlintSignals.Spark, data)); }
		public void SigSpin (object data) { AsyncDispatch (new QEvent (FlintSignals.Spin, data)); }
		public void SigStopSpinning (object data) { AsyncDispatch (new QEvent (FlintSignals.StopSpinning, data)); }
		#endregion // ISigFlint Members
	} // Flint
	public interface ISigFlint
	{
		void SigIgnite (object data);
		void SigSpark (object data);
		void SigSpin (object data);
		void SigStopSpinning (object data);
	}
	public class QualifiedFlintSignals
	{
		public const string Ignite = "Ignite";
		public const string Spark = "Spark";
		public const string StopSpinning = "StopSpinning";
		public const string User_Spin = "User.Spin";
	}
	public class FlintSignals
	{
		public const string Ignite = "Ignite";
		public const string Spark = "Spark";
		public const string Spin = "Spin";
		public const string StopSpinning = "StopSpinning";
	}
}
