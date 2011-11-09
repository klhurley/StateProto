using System;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using qf4net;

namespace Samples.Library
{
	/// <summary>
	/// BookFrame.
	/// </summary>
    public class BookFrame : LoggingUserBase
    {
	    private string _StorageFileName;
	    
        public BookFrame(string id, IQEventManager eventManager, string storageFileName)
        {
            _StorageFileName = storageFileName;
            _Book = new Book ("Book" + id, id, eventManager);
		    
            RegisterStateChange (_Book);
            Log ();
            
            // Init or Restore
            if(File.Exists(_StorageFileName))
            {
                RestoreHsmFromFile ();
            } 
            else
            {
                Init ();
                SaveHsmToFile ();
            }
        }
	    
        #region Save
        private void SaveHsmToFile()
        {
            SaveCmd cmd = new SaveCmd (_Book, _StorageFileName);
            cmd.Completed += new HsmMementoCompleted(cmd_SaveCompleted);
            _Book.EventManager.AsyncDispatch(cmd);
        }

        private void cmd_SaveCompleted(IQSimpleCommand command, ILQHsmMemento memento)
        {
            SaveCmd cmd = (SaveCmd) command;
            using(StreamWriter sw = new StreamWriter(cmd.FileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(sw.BaseStream, memento);
            }
        }
        #endregion
	    
        #region Restore
        private void RestoreHsmFromFile()
        {
            using(StreamReader sr = new StreamReader(_StorageFileName))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object obj = bf.Deserialize(sr.BaseStream);
                ILQHsmMemento memento = (ILQHsmMemento) obj;
                RestoreCmd cmd = new RestoreCmd (_Book, memento);
                cmd.Completed += new HsmMementoCompleted(cmd_RestoreCompleted);
                _Book.EventManager.AsyncDispatch (cmd);
            }
        }	    

        private void cmd_RestoreCompleted(IQSimpleCommand command, ILQHsmMemento memento)
        {
            DoStateChange (_Book);
        }
        #endregion

        void RegisterStateChange(ILQHsm hsm)
        {
            hsm.EventManager.PolledEvent += new PolledEventHandler(EventManager_PolledEvent);
        }
	    
        public string BookState
        {
            get
            {
                StringBuilder sb = new StringBuilder ();
                sb.Append (_Book.CurrentStateName);
                sb.Append (". Due: ");
                sb.Append (_Book.DueDate.ToString ("yyyy-MM-dd HH:mm:ss"));
                return sb.ToString ();
            }
        }

        public bool FrameIsLit
        {
            get
            {
                return _Book.CurrentStateName.EndsWith ("Burning");
            }
        }

        void Init()
        {
            _Book.Init ();
        }
	    
        void Log()
        {
            new ConsoleStateEventHandler (_Book);
        }
	    
        private Book _Book;	    
	    
	    
        public void BoughtByLibrary()
        {
            _Book.SigBoughtByLibrary (null);
        }
	    
        public void Loan()
        {
            _Book.SigLoan (null);
        }
	    
        public void Return()
        {
            _Book.SigReturn (null);
        }
	    	    
        private void EventManager_PolledEvent(IQEventManager eventManager, IQHsm hsm, IQEvent ev, PollContext pollContext)
        {
            if(pollContext == PollContext.AfterHandled && hsm == _Book)
            {
                SaveHsmToFile ();
                DoStateChange ((ILQHsm)hsm);
            }
        }
	    
        private void DoStateChange(ILQHsm hsm)
        {
            EventHandler handler = StateChange;
            if(null != handler)
            {
                handler (hsm, new EventArgs ());
            }
        }
	    
        public EventHandler StateChange;


        public string[] GetCommandNamesForCurrentState()
        {
            return _Book.GetCommandNamesForCurrentState ();
        }
	    
	    public void DoCommand(string commandName)
	    {
	        _Book.AsyncDispatch (new QEvent(commandName));
        }
    }
}
