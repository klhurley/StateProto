//---------------------------------------------------------------------
//Begin[[StartOfFileBlock]]
//End[[StartOfFileBlock]]
//---------------------------------------------------------------------

using System;
using true;
using qf4net;

//---------------------------------------------------------------------
//Begin[[UsingNameSpaceCodeBlock]]
//End[[UsingNameSpaceCodeBlock]]
//---------------------------------------------------------------------

namespace MurphyPA.SM
{
	// SM: 
	// State: Zombie::Init
	// State: Zombie::Init.FindPlayer
	// State: Zombie::Init.FindPlayer.NOT_NAMED
	[ModelInformation (@"", "2674859e-d84e-4a61-a46c-e87d317abecf", "0")]
	public class  : Zombie, ISig
	//---------------------------------------------------------------------
	//Begin[[ImplementsInterfaces]]
	//End[[ImplementsInterfaces]]
	//---------------------------------------------------------------------
	{
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static  ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new ();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		
		#region State Fields
		static protected QState s_Zombie::Init;
		static protected QState s_Zombie::Init_FindPlayer;
		static protected QState s_Zombie::Init_FindPlayer_NOT_NAMED;
		
		#endregion
		#region Constructors
		public  (){
			CreateStateFields ();
		}
		
		public  (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public  (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public  (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public  (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public  (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public  (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public  (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public  (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public  (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected override void CreateStateFields (){
			if(null == _MyStaticInstance){
				base.CreateStateFields ();
				s_Zombie::Init = new QState (S_Zombie::Init);
				s_Zombie::Init_FindPlayer = new QState (S_Zombie::Init_FindPlayer);
				s_Zombie::Init_FindPlayer_NOT_NAMED = new QState (S_Zombie::Init_FindPlayer_NOT_NAMED);
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State Zombie::Init
		[StateMethod ("Zombie::Init")]
		protected virtual QState S_Zombie::Init (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Zombie::Init, "Zombie::ExitDoor");
				Zombie::ExitDoor;
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Zombie::Init);
			} return null;
			} // switch
			
			return TopState;
		} // S_Zombie::Init
		#endregion
	
		
		#region State Zombie::Init_FindPlayer
		[StateMethod ("Zombie::Init_FindPlayer")]
		protected virtual QState S_Zombie::Init_FindPlayer (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Zombie::Init_FindPlayer);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Zombie::Init_FindPlayer);
			} return null;
			} // switch
			
			return s_Zombie::Init;
		} // S_Zombie::Init_FindPlayer
		#endregion
	
		
		#region State Zombie::Init_FindPlayer_NOT_NAMED
		[StateMethod ("Zombie::Init_FindPlayer_NOT_NAMED")]
		protected virtual QState S_Zombie::Init_FindPlayer_NOT_NAMED (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Zombie::Init_FindPlayer_NOT_NAMED);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Zombie::Init_FindPlayer_NOT_NAMED);
			} return null;
			} // switch
			
			return s_Zombie::Init_FindPlayer;
		} // S_Zombie::Init_FindPlayer_NOT_NAMED
		#endregion
	
		#region ISig Members
		#endregion // ISig Members
	} // 
	public interface ISig
	{
	}
	public class QualifiedSignals
	{
	}
	public class Signals
	{
	}
}
