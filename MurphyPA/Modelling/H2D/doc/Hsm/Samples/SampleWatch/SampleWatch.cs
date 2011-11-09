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

namespace Samples
{
	// SM: SampleWatch
	// State: Setting
	// State: Setting.Day
	// State: Setting.Hour
	// State: Setting.Minute
	// State: Setting.Month
	// State: TimeKeeping
	// State: TimeKeeping.Date
	// State: TimeKeeping.Time
	// Transition: ModeEvt/IncrDay()
	// Transition: ModeEvt
	// Transition: ModeEvt
	// Transition: ModeEvt/IncrMinute()
	// Transition: ModeEvt/IncrHour()
	// Transition: ModeEvt/IncrMonth()
	// Transition: SetEvt
	// Transition: SetEvt
	// Transition: SetEvt
	// Transition: SetEvt
	// Transition: SetEvt
	// Transition: t1-every 1 raise TickEvt/TickDate()
	// Transition: t0-every 1 raise TickEvt/TickTime()
	[ModelInformation (@"SampleWatch_b.sm1", "1d393ebd-7d70-4b1e-a2b0-2cb991047638", "11")]
	[TransitionEvent ("ModeEvt")]
	[TransitionEvent ("SetEvt")]
	[TransitionEvent ("TickEvt")]
	public class SampleWatch : LQHsm, ISigSampleWatch {
		
		//---------------------------------------------------------------------
		//Begin[[ClassBodyCode]]
		private string _DisplayText = "";
        public string DisplayText 
        {
            get 
            {
                return _DisplayText; 
            }
        }

        private string _DisplayBlinkText = "";
        public string DisplayBlinkText 
        {
            get 
            {
                return _DisplayBlinkText; 
            }
        }

	    DateTime _Current = DateTime.Now;

	    string _Fmt = "";
        void UpdateDateFromParts()
        {
            _DisplayText = _Current.ToString ("dd MMM");
            _DisplayBlinkText = _Current.ToString (_Fmt);
        }	    

	    void UpdateTimeFromParts()
	    {
	        _DisplayText = _Current.ToString ("HH:mm:ss");
            _DisplayBlinkText = _Current.ToString (_Fmt);
        }	    

        void TickTime()
        {
            _Current = _Current.AddSeconds (1);
            UpdateTimeFromParts ();
        }

	    void TickDate()
	    {
	        _Current = _Current.AddSeconds (1);
	        UpdateDateFromParts ();
	    }

        void SetHour()
        {
            _Fmt = "__:mm:ss";
            UpdateTimeFromParts ();
        }

	    void IncrHour()
	    {
	        _Current = _Current.AddHours (1);
	        UpdateTimeFromParts ();
	    }

        void SetMinute()
        {
            _Fmt = "HH:__:ss";
            UpdateTimeFromParts ();
        }

        void IncrMinute()
        {
            _Current = _Current.AddMinutes (1);
            UpdateTimeFromParts ();
        }

        void SetMonth()
        {
            _Fmt = "dd ___";
            UpdateDateFromParts ();
        }

        void IncrMonth()
        {
            _Current = _Current.AddMonths (1);
            UpdateDateFromParts ();
        }

	    void SetDay()
	    {
            _Fmt = "__ MMM";
            UpdateDateFromParts ();
        }
	    
        void IncrDay()
        {
            _Current = _Current.AddDays (1);
            UpdateDateFromParts ();
        }
	    
	    private bool _Blinking = false;
	    public bool Blinking { get { return _Blinking; } }
	    
	    void Blink()
	    {
	        _Blinking = true;
	    }
	    
	    void NoBlink()
	    {
	        _Blinking = false;
	    }
		//End[[ClassBodyCode]]
		//---------------------------------------------------------------------
		#region Boiler plate static stuff
		protected static new TransitionChainStore s_TransitionChainStore = 
			new TransitionChainStore(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
		static object _MyStaticInstance;
		static SampleWatch ()
		{
			s_TransitionChainStore.ShrinkToActualSize();
		    _MyStaticInstance = new SampleWatch();
		}
		protected override TransitionChainStore TransChainStore
		{
			get { return s_TransitionChainStore; }
		}
		#endregion
		
		protected override void InitializeStateMachine()
		{
			InitializeState(s_Setting);
			//Begin[[InitialiseSM]]
			//End[[InitialiseSM]]
		}
		
		#region State Fields
		static protected QState s_Setting;
		static protected QState s_Setting_Day;
		static protected QState s_Setting_Hour;
		static protected QState s_Setting_Minute;
		static protected QState s_Setting_Month;
		static protected QState s_TimeKeeping;
		static protected QState s_TimeKeeping_Date;
		static protected QState s_TimeKeeping_Time;
		
		protected QState _TimeKeeping_DeepHistory;
		#endregion
		#region Constructors
		public SampleWatch (){
			CreateStateFields ();
		}
		
		public SampleWatch (bool createEventManager)
		  : base (createEventManager) {
			CreateStateFields ();
		}
		
		public SampleWatch (IQEventManager eventManager)
		  : base (eventManager) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, string groupId)
		  : base (id, groupId) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, IQEventManager eventManager)
		  : base (id, eventManager) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, string groupId, IQEventManager eventManager)
		  : base (id, groupId, eventManager) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, string groupId, IQHsmLifeCycleManager lifeCycleManager)
		  : base (id, groupId, lifeCycleManager) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, IQHsmExecutionContext executionContext)
		  : base (id, executionContext) {
			CreateStateFields ();
		}
		
		public SampleWatch (string id, string groupId, IQHsmExecutionContext executionContext)
		  : base (id, groupId, executionContext) {
			CreateStateFields ();
		}
		
		#endregion // Constructors
		#region Create State Fields
		protected virtual void CreateStateFields (){
			if(null == _MyStaticInstance){
				s_Setting = new QState (S_Setting);
				s_Setting_Day = new QState (S_Setting_Day);
				s_Setting_Hour = new QState (S_Setting_Hour);
				s_Setting_Minute = new QState (S_Setting_Minute);
				s_Setting_Month = new QState (S_Setting_Month);
				s_TimeKeeping = new QState (S_TimeKeeping);
				s_TimeKeeping_Date = new QState (S_TimeKeeping_Date);
				s_TimeKeeping_Time = new QState (S_TimeKeeping_Time);
			}
		}
		#endregion
		
		#region State History Serialiser/Deserialiser
		protected override void SaveHistoryStates(ISerialisationContext context)
		{
			base.SaveHistoryStates (context);
			if (null == _TimeKeeping_DeepHistory)
			{
				context.Formatter.Serialize (context.Stream, null);
			}
			else
			{
				context.Formatter.Serialize (context.Stream, _TimeKeeping_DeepHistory.Method.Name);
			}
		}
		
		protected override void LoadHistoryStates(ISerialisationContext context)
		{
			base.LoadHistoryStates (context);
			string methodName_TimeKeeping = (string) context.Formatter.Deserialize (context.Stream);
			if (null == methodName_TimeKeeping)
			{
				_TimeKeeping_DeepHistory = null;
			}
			else
			{
				_TimeKeeping_DeepHistory = (QState) Delegate.CreateDelegate (typeof (QState), this, methodName_TimeKeeping);
			}
		}
		#endregion
		
		#region State History Memento
		protected override void SaveHistoryStates(ILQHsmMemento memento)
		{
			base.SaveHistoryStates (memento);
			if (null == _TimeKeeping_DeepHistory)
			{
				memento.AddHistoryState ("TimeKeeping", null);
			}
			else
			{
				memento.AddHistoryState ("TimeKeeping", _TimeKeeping_DeepHistory.Method);
			}
		}
		
		protected override void RestoreHistoryStates(ILQHsmMemento memento)
		{
			base.RestoreHistoryStates (memento);
			IStateMethodInfo stateInfo_TimeKeeping = memento.GetHistoryStateFor("TimeKeeping");
			if (null == stateInfo_TimeKeeping)
			{
				_TimeKeeping_DeepHistory = null;
			}
			else
			{
				_TimeKeeping_DeepHistory = (QState) Delegate.CreateDelegate (typeof (QState), this, stateInfo_TimeKeeping.Method.Name);
			}
		}
		#endregion
		
		#region Restore History State Extra
		
		public void SpecialCase_RestoreHistoryStatesRelatedToCurrentState(ILQHsmMemento memento)
		{
			if(s_TimeKeeping_Date.Method == this.CurrentStateMethod){
				_TimeKeeping_DeepHistory = s_TimeKeeping_Date;
			}
			else if(s_TimeKeeping_Time.Method == this.CurrentStateMethod){
				_TimeKeeping_DeepHistory = s_TimeKeeping_Time;
			}
		}
		#endregion
		
		#region IsFinalState
		public override bool IsFinalState (QState state){
			return false
			;
		}
		#endregion // IsFinalState
		
		
		#region State Setting
		protected static int s_trans_SetEvt_Setting_2_TimeKeeping = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Setting")]
		protected virtual QState S_Setting (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Init: {
				LogStateEvent (StateLogType.Init, s_Setting, s_Setting_Hour);
				InitializeState (s_Setting_Hour);
			} return null;
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Setting, "Blink()");
				Blink();
			} return null;
			case QSignals.Exit: {
				NoBlink();
				LogStateEvent (StateLogType.Exit, s_Setting, "NoBlink()");
			} return null;
			case QualifiedSampleWatchSignals.SetEvt: {
				QState toState_TimeKeeping = _TimeKeeping_DeepHistory == null ? s_TimeKeeping : _TimeKeeping_DeepHistory;
				LogStateEvent (StateLogType.EventTransition, s_Setting, toState_TimeKeeping, "SetEvt", "SetEvt");
				TransitionTo (toState_TimeKeeping);
				return null;
			}  // SetEvt
			} // switch
			
			return TopState;
		} // S_Setting
		#endregion
	
		
		#region State Setting_Day
		protected static int s_trans_ModeEvt_Setting_Day_2_Setting_Day = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_SetEvt_Setting_Day_2_Setting_Month = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Setting_Day")]
		protected virtual QState S_Setting_Day (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Setting_Day, "SetDay()");
				SetDay();
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Setting_Day);
			} return null;
			case QualifiedSampleWatchSignals.ModeEvt: {
				IncrDay();
				LogStateEvent (StateLogType.EventTransition, s_Setting_Day, s_Setting_Day, "ModeEvt", "ModeEvt/IncrDay()");
				TransitionTo (s_Setting_Day, s_trans_ModeEvt_Setting_Day_2_Setting_Day);
				return null;
			}  // ModeEvt
			case QualifiedSampleWatchSignals.SetEvt: {
				LogStateEvent (StateLogType.EventTransition, s_Setting_Day, s_Setting_Month, "SetEvt", "SetEvt");
				TransitionTo (s_Setting_Month, s_trans_SetEvt_Setting_Day_2_Setting_Month);
				return null;
			}  // SetEvt
			} // switch
			
			return s_Setting;
		} // S_Setting_Day
		#endregion
	
		
		#region State Setting_Hour
		protected static int s_trans_ModeEvt_Setting_Hour_2_Setting_Hour = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_SetEvt_Setting_Hour_2_Setting_Minute = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Setting_Hour")]
		protected virtual QState S_Setting_Hour (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Setting_Hour, "SetHour()");
				SetHour();
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Setting_Hour);
			} return null;
			case QualifiedSampleWatchSignals.ModeEvt: {
				IncrHour();
				LogStateEvent (StateLogType.EventTransition, s_Setting_Hour, s_Setting_Hour, "ModeEvt", "ModeEvt/IncrHour()");
				TransitionTo (s_Setting_Hour, s_trans_ModeEvt_Setting_Hour_2_Setting_Hour);
				return null;
			}  // ModeEvt
			case QualifiedSampleWatchSignals.SetEvt: {
				LogStateEvent (StateLogType.EventTransition, s_Setting_Hour, s_Setting_Minute, "SetEvt", "SetEvt");
				TransitionTo (s_Setting_Minute, s_trans_SetEvt_Setting_Hour_2_Setting_Minute);
				return null;
			}  // SetEvt
			} // switch
			
			return s_Setting;
		} // S_Setting_Hour
		#endregion
	
		
		#region State Setting_Minute
		protected static int s_trans_ModeEvt_Setting_Minute_2_Setting_Minute = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_SetEvt_Setting_Minute_2_Setting_Day = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Setting_Minute")]
		protected virtual QState S_Setting_Minute (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Setting_Minute, "SetMinute()");
				SetMinute();
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Setting_Minute);
			} return null;
			case QualifiedSampleWatchSignals.ModeEvt: {
				IncrMinute();
				LogStateEvent (StateLogType.EventTransition, s_Setting_Minute, s_Setting_Minute, "ModeEvt", "ModeEvt/IncrMinute()");
				TransitionTo (s_Setting_Minute, s_trans_ModeEvt_Setting_Minute_2_Setting_Minute);
				return null;
			}  // ModeEvt
			case QualifiedSampleWatchSignals.SetEvt: {
				LogStateEvent (StateLogType.EventTransition, s_Setting_Minute, s_Setting_Day, "SetEvt", "SetEvt");
				TransitionTo (s_Setting_Day, s_trans_SetEvt_Setting_Minute_2_Setting_Day);
				return null;
			}  // SetEvt
			} // switch
			
			return s_Setting;
		} // S_Setting_Minute
		#endregion
	
		
		#region State Setting_Month
		protected static int s_trans_ModeEvt_Setting_Month_2_Setting_Month = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("Setting_Month")]
		protected virtual QState S_Setting_Month (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_Setting_Month, "SetMonth()");
				SetMonth();
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_Setting_Month);
			} return null;
			case QualifiedSampleWatchSignals.ModeEvt: {
				IncrMonth();
				LogStateEvent (StateLogType.EventTransition, s_Setting_Month, s_Setting_Month, "ModeEvt", "ModeEvt/IncrMonth()");
				TransitionTo (s_Setting_Month, s_trans_ModeEvt_Setting_Month_2_Setting_Month);
				return null;
			}  // ModeEvt
			} // switch
			
			return s_Setting;
		} // S_Setting_Month
		#endregion
	
		
		#region State TimeKeeping
		protected static int s_trans_SetEvt_TimeKeeping_2_Setting = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("TimeKeeping")]
		protected virtual QState S_TimeKeeping (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Init: {
				LogStateEvent (StateLogType.Init, s_TimeKeeping, s_TimeKeeping_Time);
				InitializeState (s_TimeKeeping_Time);
			} return null;
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_TimeKeeping);
				_TimeKeeping_DeepHistory = s_TimeKeeping;
			} return null;
			case QSignals.Exit: {
				LogStateEvent (StateLogType.Exit, s_TimeKeeping);
			} return null;
			case QualifiedSampleWatchSignals.SetEvt: {
				LogStateEvent (StateLogType.EventTransition, s_TimeKeeping, s_Setting, "SetEvt", "SetEvt");
				TransitionTo (s_Setting, s_trans_SetEvt_TimeKeeping_2_Setting);
				return null;
			}  // SetEvt
			} // switch
			
			return TopState;
		} // S_TimeKeeping
		#endregion
	
		
		#region State TimeKeeping_Date
		protected static int s_trans_ModeEvt_TimeKeeping_Date_2_TimeKeeping_Time = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t1_TickEvt_TimeKeeping_Date_2_TimeKeeping_Date = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("TimeKeeping_Date")]
		protected virtual QState S_TimeKeeping_Date (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_TimeKeeping_Date);
				_TimeKeeping_DeepHistory = s_TimeKeeping_Date;
				SetTimeOut ("TimeKeeping_Date_t1_TickEvt", TimeSpan.FromSeconds (1), new QEvent ("TickEvt"), TimeOutType.Repeat);
			} return null;
			case QSignals.Exit: {
				ClearTimeOut ("TimeKeeping_Date_t1_TickEvt");
				LogStateEvent (StateLogType.Exit, s_TimeKeeping_Date);
			} return null;
			case QualifiedSampleWatchSignals.ModeEvt: {
				LogStateEvent (StateLogType.EventTransition, s_TimeKeeping_Date, s_TimeKeeping_Time, "ModeEvt", "ModeEvt");
				TransitionTo (s_TimeKeeping_Time, s_trans_ModeEvt_TimeKeeping_Date_2_TimeKeeping_Time);
				return null;
			}  // ModeEvt
			case QualifiedSampleWatchSignals.TickEvt: {
				TickDate();
				LogStateEvent (StateLogType.EventTransition, s_TimeKeeping_Date, s_TimeKeeping_Date, "TickEvt", "t1-every 1 raise TickEvt/TickDate()");
				TransitionTo (s_TimeKeeping_Date, s_trans_t1_TickEvt_TimeKeeping_Date_2_TimeKeeping_Date);
				return null;
			}  // TickEvt
			} // switch
			
			return s_TimeKeeping;
		} // S_TimeKeeping_Date
		#endregion
	
		
		#region State TimeKeeping_Time
		protected static int s_trans_ModeEvt_TimeKeeping_Time_2_TimeKeeping_Date = s_TransitionChainStore.GetOpenSlot ();
		protected static int s_trans_t0_TickEvt_TimeKeeping_Time_2_TimeKeeping_Time = s_TransitionChainStore.GetOpenSlot ();
		[StateMethod ("TimeKeeping_Time")]
		protected virtual QState S_TimeKeeping_Time (IQEvent ev){
			switch (ev.QSignal){
			case QSignals.Entry: {
				LogStateEvent (StateLogType.Entry, s_TimeKeeping_Time);
				_TimeKeeping_DeepHistory = s_TimeKeeping_Time;
				SetTimeOut ("TimeKeeping_Time_t0_TickEvt", TimeSpan.FromSeconds (1), new QEvent ("TickEvt"), TimeOutType.Repeat);
			} return null;
			case QSignals.Exit: {
				ClearTimeOut ("TimeKeeping_Time_t0_TickEvt");
				LogStateEvent (StateLogType.Exit, s_TimeKeeping_Time);
			} return null;
			case QualifiedSampleWatchSignals.ModeEvt: {
				LogStateEvent (StateLogType.EventTransition, s_TimeKeeping_Time, s_TimeKeeping_Date, "ModeEvt", "ModeEvt");
				TransitionTo (s_TimeKeeping_Date, s_trans_ModeEvt_TimeKeeping_Time_2_TimeKeeping_Date);
				return null;
			}  // ModeEvt
			case QualifiedSampleWatchSignals.TickEvt: {
				TickTime();
				LogStateEvent (StateLogType.EventTransition, s_TimeKeeping_Time, s_TimeKeeping_Time, "TickEvt", "t0-every 1 raise TickEvt/TickTime()");
				TransitionTo (s_TimeKeeping_Time, s_trans_t0_TickEvt_TimeKeeping_Time_2_TimeKeeping_Time);
				return null;
			}  // TickEvt
			} // switch
			
			return s_TimeKeeping;
		} // S_TimeKeeping_Time
		#endregion
	
		#region ISigSampleWatch Members
		public void SigModeEvt (object data) { AsyncDispatch (new QEvent (SampleWatchSignals.ModeEvt, data)); }
		public void SigSetEvt (object data) { AsyncDispatch (new QEvent (SampleWatchSignals.SetEvt, data)); }
		public void SigTickEvt (object data) { AsyncDispatch (new QEvent (SampleWatchSignals.TickEvt, data)); }
		#endregion // ISigSampleWatch Members
	} // SampleWatch
	public interface ISigSampleWatch
	{
		void SigModeEvt (object data);
		void SigSetEvt (object data);
		void SigTickEvt (object data);
	}
	public class QualifiedSampleWatchSignals
	{
		public const string ModeEvt = "ModeEvt";
		public const string SetEvt = "SetEvt";
		public const string TickEvt = "TickEvt";
	}
	public class SampleWatchSignals
	{
		public const string ModeEvt = "ModeEvt";
		public const string SetEvt = "SetEvt";
		public const string TickEvt = "TickEvt";
	}
}
