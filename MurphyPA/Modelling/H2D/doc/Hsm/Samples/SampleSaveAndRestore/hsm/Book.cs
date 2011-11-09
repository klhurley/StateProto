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

namespace Samples.Library
{
	// SM: Book
	// State: NotOwnedByLibrary
	// State: NotOwnedByLibrary.Destroyed
	// State: NotOwnedByLibrary.GivenAway
	// State: NotOwnedByLibrary.Lost
	// State: NotOwnedByLibrary.OtherOwner
	// State: OwnedByLibrary
	// State: OwnedByLibrary.InLibrary
	// State: OwnedByLibrary.InLibrary.Misplaced
	// State: OwnedByLibrary.InLibrary.OnShelf
	// State: OwnedByLibrary.NotifyingAccountMustPayFine
	// State: OwnedByLibrary.NotifyingAccountMustPayFine.LoanFine
	// State: OwnedByLibrary.NotifyingAccountMustPayFine.LossFine
	// State: OwnedByLibrary.OnLoan
	// Transition: BoughtByLibrary
	// Transition: GiveAway
	// Transition: Loan/SetLoanDetails()
	// Transition: Lost
	// Transition: Lost
	// Transition: Misplace
	// Transition: Notified
	// Transition: Notified
	// Transition: Return
	// Transition: t0-Return[IsLate()]
	// Transition: TooWornOut
	[ModelInformation (@"Book.sm1", "85e9b28f-11cf-413d-945a-9aba3a427419", "4")]
	[TransitionEvent ("BoughtByLibrary")]
	[TransitionEvent ("GiveAway")]
	[TransitionEvent ("Loan")]
	[TransitionEvent ("Lost")]
	[TransitionEvent ("Misplace")]
	[TransitionEvent ("Notified")]
	[TransitionEvent ("Return")]
	[TransitionEvent ("TooWornOut")]
	public class Book : LQHsm, ISigBook
	//---------------------------------------------------------------------
	//Begin[[ImplementsInterfaces]]
	//End[[ImplementsInterfaces]]
	//---------------------------------------------------------------------
	{
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		private DateTime _DueDate;
	    public DateTime DueDate { get { return _DueDate; } set { _DueDate = value; } }

	    private void SetLoanDetails()
	    {
	        _DueDate = DateTime.Now.AddMinutes (1);
	    }
	    
	    private bool IsLate()
	    {
	        return _DueDate < DateTime.Now;
	    }
	    
        #region GetCommandNamesForCurrentState -- this should be in base LQHsm class
        public string[] GetCommandNamesForCurrentState ()
        {            
            System.Collections.ArrayList commandList = new System.Collections.ArrayList();
            string[] commandNames = GetCommandNamesForCurrentState (CurrentStateMethod, commandList);
            return commandNames;
        }

        string[] GetCommandNamesForCurrentState (System.Reflection.MethodInfo state, System.Collections.ArrayList commandList)
        {            
            StateCommandAttribute[] commands = (StateCommandAttribute[])state.GetCustomAttributes (typeof (StateCommandAttribute), false);            
            if(commands != null)
            {
                foreach(StateCommandAttribute command in commands)
                {
                    commandList.Add (command.CommandName);
                }
            }
            object result = state.Invoke (this, new object[] {new QEvent(QSignals.Empty)});
            if(null != result)
            {
                state = ((QState) result).Method;
                GetCommandNamesForCurrentState (state, commandList);
            }
            string[] commandNames = (string[])commandList.ToArray (typeof (string));
            return commandNames;
        }
        #endregion
	    

        #region Save/Restore
        protected override void SaveFields(ILQHsmMemento memento)
        {
            memento.AddField ("DueDate", _DueDate, typeof(DateTime));
        }
	    
        protected override void RestoreFields(ILQHsmMemento memento)
        {
            _DueDate = (DateTime)memento.GetFieldFor ("DueDate").Value;
        }
        #endregion
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static Book ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new Book();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		protected override void InitializeStateMachine()
		{
			InitializeState(s_NotOwnedByLibrary);
			//Begin[[InitialiseSM]]
			//End[[InitialiseSM]]
		}
		
		#region State Fields
		static protected QState s_NotOwnedByLibrary;
		static protected QState s_NotOwnedByLibrary_Destroyed;
		static protected QState s_NotOwnedByLibrary_GivenAway;
		static protected QState s_NotOwnedByLibrary_Lost;
		static protected QState s_NotOwnedByLibrary_OtherOwner;
		static protected QState s_OwnedByLibrary;
		static protected QState s_OwnedByLibrary_InLibrary;
		static protected QState s_OwnedByLibrary_InLibrary_Misplaced;
		static protected QState s_OwnedByLibrary_InLibrary_OnShelf;
		static protected QState s_OwnedByLibrary_NotifyingAccountMustPayFine;
		static protected QState s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine;
		static protected QState s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine;
		static protected QState s_OwnedByLibrary_OnLoan;
		
		#endregion
		#region Constructors
		public Book (){
			CreateStateFields ();
		}
		
		public Book (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public Book (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public Book (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public Book (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public Book (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public Book (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Book (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public Book (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public Book (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected virtual void CreateStateFields (){
			if(null == _MyStaticInstance){
				s_NotOwnedByLibrary = new QState (S_NotOwnedByLibrary);
				s_NotOwnedByLibrary_Destroyed = new QState (S_NotOwnedByLibrary_Destroyed);
				s_NotOwnedByLibrary_GivenAway = new QState (S_NotOwnedByLibrary_GivenAway);
				s_NotOwnedByLibrary_Lost = new QState (S_NotOwnedByLibrary_Lost);
				s_NotOwnedByLibrary_OtherOwner = new QState (S_NotOwnedByLibrary_OtherOwner);
				s_OwnedByLibrary = new QState (S_OwnedByLibrary);
				s_OwnedByLibrary_InLibrary = new QState (S_OwnedByLibrary_InLibrary);
				s_OwnedByLibrary_InLibrary_Misplaced = new QState (S_OwnedByLibrary_InLibrary_Misplaced);
				s_OwnedByLibrary_InLibrary_OnShelf = new QState (S_OwnedByLibrary_InLibrary_OnShelf);
				s_OwnedByLibrary_NotifyingAccountMustPayFine = new QState (S_OwnedByLibrary_NotifyingAccountMustPayFine);
				s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine = new QState (S_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine);
				s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine = new QState (S_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine);
				s_OwnedByLibrary_OnLoan = new QState (S_OwnedByLibrary_OnLoan);
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State NotOwnedByLibrary
		[StateMethod ("NotOwnedByLibrary")]
		protected virtual QState S_NotOwnedByLibrary (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Init: {
				LogStateEvent (StateLogType.Init, s_NotOwnedByLibrary, s_NotOwnedByLibrary_OtherOwner);
				InitializeState (s_NotOwnedByLibrary_OtherOwner);
			} return null;
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_NotOwnedByLibrary);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_NotOwnedByLibrary);
			} return null;
			} // switch
			
			return TopState;
		} // S_NotOwnedByLibrary
		#endregion
	
		
		#region State NotOwnedByLibrary_Destroyed
		[StateMethod ("NotOwnedByLibrary_Destroyed")]
		protected virtual QState S_NotOwnedByLibrary_Destroyed (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_NotOwnedByLibrary_Destroyed);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_NotOwnedByLibrary_Destroyed);
			} return null;
			} // switch
			
			return s_NotOwnedByLibrary;
		} // S_NotOwnedByLibrary_Destroyed
		#endregion
	
		
		#region State NotOwnedByLibrary_GivenAway
		[StateMethod ("NotOwnedByLibrary_GivenAway")]
		protected virtual QState S_NotOwnedByLibrary_GivenAway (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_NotOwnedByLibrary_GivenAway);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_NotOwnedByLibrary_GivenAway);
			} return null;
			} // switch
			
			return s_NotOwnedByLibrary;
		} // S_NotOwnedByLibrary_GivenAway
		#endregion
	
		
		#region State NotOwnedByLibrary_Lost
		[StateMethod ("NotOwnedByLibrary_Lost")]
		protected virtual QState S_NotOwnedByLibrary_Lost (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_NotOwnedByLibrary_Lost);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_NotOwnedByLibrary_Lost);
			} return null;
			} // switch
			
			return s_NotOwnedByLibrary;
		} // S_NotOwnedByLibrary_Lost
		#endregion
	
		
		#region State NotOwnedByLibrary_OtherOwner
		protected static int s_trans_BoughtByLibrary_NotOwnedByLibrary_OtherOwner_2_OwnedByLibrary_InLibrary = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("NotOwnedByLibrary_OtherOwner")]
		[StateCommand ("BoughtByLibrary")]
		protected virtual QState S_NotOwnedByLibrary_OtherOwner (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_NotOwnedByLibrary_OtherOwner);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_NotOwnedByLibrary_OtherOwner);
			} return null;
			case QualifiedBookSignals.BoughtByLibrary: {
				LogStateEvent (StateLogType.EventTransition, s_NotOwnedByLibrary_OtherOwner, s_OwnedByLibrary_InLibrary, "BoughtByLibrary", "BoughtByLibrary");
				TransitionTo (s_OwnedByLibrary_InLibrary, s_trans_BoughtByLibrary_NotOwnedByLibrary_OtherOwner_2_OwnedByLibrary_InLibrary);
				return null;
			}  // BoughtByLibrary
			} // switch
			
			return s_NotOwnedByLibrary;
		} // S_NotOwnedByLibrary_OtherOwner
		#endregion
	
		
		#region State OwnedByLibrary
		protected static int s_trans_GiveAway_OwnedByLibrary_2_NotOwnedByLibrary_GivenAway = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_TooWornOut_OwnedByLibrary_2_NotOwnedByLibrary_Destroyed = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("OwnedByLibrary")]
		[StateCommand ("GiveAway")]
		[StateCommand ("TooWornOut")]
		protected virtual QState S_OwnedByLibrary (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Init: {
				LogStateEvent (StateLogType.Init, s_OwnedByLibrary, s_OwnedByLibrary_InLibrary);
				InitializeState (s_OwnedByLibrary_InLibrary);
			} return null;
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary);
			} return null;
			case QualifiedBookSignals.GiveAway: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary, s_NotOwnedByLibrary_GivenAway, "GiveAway", "GiveAway");
				TransitionTo (s_NotOwnedByLibrary_GivenAway, s_trans_GiveAway_OwnedByLibrary_2_NotOwnedByLibrary_GivenAway);
				return null;
			}  // GiveAway
			case QualifiedBookSignals.TooWornOut: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary, s_NotOwnedByLibrary_Destroyed, "TooWornOut", "TooWornOut");
				TransitionTo (s_NotOwnedByLibrary_Destroyed, s_trans_TooWornOut_OwnedByLibrary_2_NotOwnedByLibrary_Destroyed);
				return null;
			}  // TooWornOut
			} // switch
			
			return TopState;
		} // S_OwnedByLibrary
		#endregion
	
		
		#region State OwnedByLibrary_InLibrary
		protected static int s_trans_Loan_OwnedByLibrary_InLibrary_2_OwnedByLibrary_OnLoan = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_Lost_OwnedByLibrary_InLibrary_2_NotOwnedByLibrary_Lost = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("OwnedByLibrary_InLibrary")]
		[StateCommand ("Loan")]
		[StateCommand ("Lost")]
		protected virtual QState S_OwnedByLibrary_InLibrary (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Init: {
				LogStateEvent (StateLogType.Init, s_OwnedByLibrary_InLibrary, s_OwnedByLibrary_InLibrary_OnShelf);
				InitializeState (s_OwnedByLibrary_InLibrary_OnShelf);
			} return null;
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_InLibrary);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_InLibrary);
			} return null;
			case QualifiedBookSignals.Loan: {
				SetLoanDetails();
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_InLibrary, s_OwnedByLibrary_OnLoan, "Loan", "Loan/SetLoanDetails()");
				TransitionTo (s_OwnedByLibrary_OnLoan, s_trans_Loan_OwnedByLibrary_InLibrary_2_OwnedByLibrary_OnLoan);
				return null;
			}  // Loan
			case QualifiedBookSignals.Lost: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_InLibrary, s_NotOwnedByLibrary_Lost, "Lost", "Lost");
				TransitionTo (s_NotOwnedByLibrary_Lost, s_trans_Lost_OwnedByLibrary_InLibrary_2_NotOwnedByLibrary_Lost);
				return null;
			}  // Lost
			} // switch
			
			return s_OwnedByLibrary;
		} // S_OwnedByLibrary_InLibrary
		#endregion
	
		
		#region State OwnedByLibrary_InLibrary_Misplaced
		[StateMethod ("OwnedByLibrary_InLibrary_Misplaced")]
		protected virtual QState S_OwnedByLibrary_InLibrary_Misplaced (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_InLibrary_Misplaced);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_InLibrary_Misplaced);
			} return null;
			} // switch
			
			return s_OwnedByLibrary_InLibrary;
		} // S_OwnedByLibrary_InLibrary_Misplaced
		#endregion
	
		
		#region State OwnedByLibrary_InLibrary_OnShelf
		protected static int s_trans_Misplace_OwnedByLibrary_InLibrary_OnShelf_2_OwnedByLibrary_InLibrary_Misplaced = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("OwnedByLibrary_InLibrary_OnShelf")]
		[StateCommand ("Misplace")]
		protected virtual QState S_OwnedByLibrary_InLibrary_OnShelf (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_InLibrary_OnShelf);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_InLibrary_OnShelf);
			} return null;
			case QualifiedBookSignals.Misplace: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_InLibrary_OnShelf, s_OwnedByLibrary_InLibrary_Misplaced, "Misplace", "Misplace");
				TransitionTo (s_OwnedByLibrary_InLibrary_Misplaced, s_trans_Misplace_OwnedByLibrary_InLibrary_OnShelf_2_OwnedByLibrary_InLibrary_Misplaced);
				return null;
			}  // Misplace
			} // switch
			
			return s_OwnedByLibrary_InLibrary;
		} // S_OwnedByLibrary_InLibrary_OnShelf
		#endregion
	
		
		#region State OwnedByLibrary_NotifyingAccountMustPayFine
		[StateMethod ("OwnedByLibrary_NotifyingAccountMustPayFine")]
		[StateCommand ("Notified")]
		protected virtual QState S_OwnedByLibrary_NotifyingAccountMustPayFine (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_NotifyingAccountMustPayFine);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_NotifyingAccountMustPayFine);
			} return null;
			} // switch
			
			return s_OwnedByLibrary;
		} // S_OwnedByLibrary_NotifyingAccountMustPayFine
		#endregion
	
		
		#region State OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine
		protected static int s_trans_Notified_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine_2_OwnedByLibrary_InLibrary = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine")]
		protected virtual QState S_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine);
			} return null;
			case QualifiedBookSignals.Notified: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine, s_OwnedByLibrary_InLibrary, "Notified", "Notified");
				TransitionTo (s_OwnedByLibrary_InLibrary, s_trans_Notified_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine_2_OwnedByLibrary_InLibrary);
				return null;
			}  // Notified
			} // switch
			
			return s_OwnedByLibrary_NotifyingAccountMustPayFine;
		} // S_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine
		#endregion
	
		
		#region State OwnedByLibrary_NotifyingAccountMustPayFine_LossFine
		protected static int s_trans_Notified_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine_2_NotOwnedByLibrary_Lost = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("OwnedByLibrary_NotifyingAccountMustPayFine_LossFine")]
		protected virtual QState S_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine);
			} return null;
			case QualifiedBookSignals.Notified: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine, s_NotOwnedByLibrary_Lost, "Notified", "Notified");
				TransitionTo (s_NotOwnedByLibrary_Lost, s_trans_Notified_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine_2_NotOwnedByLibrary_Lost);
				return null;
			}  // Notified
			} // switch
			
			return s_OwnedByLibrary_NotifyingAccountMustPayFine;
		} // S_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine
		#endregion
	
		
		#region State OwnedByLibrary_OnLoan
		protected static int s_trans_Lost_OwnedByLibrary_OnLoan_2_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_Return_OwnedByLibrary_OnLoan_2_OwnedByLibrary_InLibrary = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t0_Return_OwnedByLibrary_OnLoan_2_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("OwnedByLibrary_OnLoan")]
		[StateCommand ("Return")]
		[StateCommand ("Lost")]
		protected virtual QState S_OwnedByLibrary_OnLoan (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_OwnedByLibrary_OnLoan);
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_OwnedByLibrary_OnLoan);
			} return null;
			case QualifiedBookSignals.Lost: {
				LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_OnLoan, s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine, "Lost", "Lost");
				TransitionTo (s_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine, s_trans_Lost_OwnedByLibrary_OnLoan_2_OwnedByLibrary_NotifyingAccountMustPayFine_LossFine);
				return null;
			}  // Lost
			case QualifiedBookSignals.Return: {
				 if (IsLate()) {
					LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_OnLoan, s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine, "Return", "t0-Return[IsLate()]");
					TransitionTo (s_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine, s_trans_t0_Return_OwnedByLibrary_OnLoan_2_OwnedByLibrary_NotifyingAccountMustPayFine_LoanFine);
					return null;
				}
				else {
					LogStateEvent (StateLogType.EventTransition, s_OwnedByLibrary_OnLoan, s_OwnedByLibrary_InLibrary, "Return", "Return");
					TransitionTo (s_OwnedByLibrary_InLibrary, s_trans_Return_OwnedByLibrary_OnLoan_2_OwnedByLibrary_InLibrary);
					return null;
				}
			}  // Return
			} // switch
			
			return s_OwnedByLibrary;
		} // S_OwnedByLibrary_OnLoan
		#endregion
	
		#region ISigBook Members
		public void SigBoughtByLibrary (object data) { AsyncDispatch (new QEvent (BookSignals.BoughtByLibrary, data)); }
		public void SigGiveAway (object data) { AsyncDispatch (new QEvent (BookSignals.GiveAway, data)); }
		public void SigLoan (object data) { AsyncDispatch (new QEvent (BookSignals.Loan, data)); }
		public void SigLost (object data) { AsyncDispatch (new QEvent (BookSignals.Lost, data)); }
		public void SigMisplace (object data) { AsyncDispatch (new QEvent (BookSignals.Misplace, data)); }
		public void SigNotified (object data) { AsyncDispatch (new QEvent (BookSignals.Notified, data)); }
		public void SigReturn (object data) { AsyncDispatch (new QEvent (BookSignals.Return, data)); }
		public void SigTooWornOut (object data) { AsyncDispatch (new QEvent (BookSignals.TooWornOut, data)); }
		#endregion // ISigBook Members
	} // Book
	public interface ISigBook
	{
		void SigBoughtByLibrary (object data);
		void SigGiveAway (object data);
		void SigLoan (object data);
		void SigLost (object data);
		void SigMisplace (object data);
		void SigNotified (object data);
		void SigReturn (object data);
		void SigTooWornOut (object data);
	}
	public class QualifiedBookSignals
	{
		public const string BoughtByLibrary = "BoughtByLibrary";
		public const string GiveAway = "GiveAway";
		public const string Loan = "Loan";
		public const string Lost = "Lost";
		public const string Misplace = "Misplace";
		public const string Notified = "Notified";
		public const string Return = "Return";
		public const string TooWornOut = "TooWornOut";
	}
	public class BookSignals
	{
		public const string BoughtByLibrary = "BoughtByLibrary";
		public const string GiveAway = "GiveAway";
		public const string Loan = "Loan";
		public const string Lost = "Lost";
		public const string Misplace = "Misplace";
		public const string Notified = "Notified";
		public const string Return = "Return";
		public const string TooWornOut = "TooWornOut";
	}
}
