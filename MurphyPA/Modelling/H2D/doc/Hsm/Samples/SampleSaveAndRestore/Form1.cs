using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Samples.Library
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button buttonCreateBook;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxBookState;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label labelBookName;
        private System.Windows.Forms.TextBox textBoxBookName;
        private System.Windows.Forms.ListBox listBoxCommands;
        private System.Windows.Forms.GroupBox groupBoxSignals;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonRaiseSignal;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            InitHsmRunner ();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose( bool disposing )
        {
            if( disposing )
            {
                if (components != null) 
                {
                    components.Dispose();
                }
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCreateBook = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.textBoxBookState = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelBookName = new System.Windows.Forms.Label();
            this.textBoxBookName = new System.Windows.Forms.TextBox();
            this.listBoxCommands = new System.Windows.Forms.ListBox();
            this.groupBoxSignals = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonRaiseSignal = new System.Windows.Forms.Button();
            this.panelInfo.SuspendLayout();
            this.groupBoxSignals.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateBook
            // 
            this.buttonCreateBook.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCreateBook.Location = new System.Drawing.Point(406, 20);
            this.buttonCreateBook.Name = "buttonCreateBook";
            this.buttonCreateBook.Size = new System.Drawing.Size(102, 23);
            this.buttonCreateBook.TabIndex = 1;
            this.buttonCreateBook.Text = "Create Book";
            this.buttonCreateBook.Click += new System.EventHandler(this.buttonCreateBook_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfo.Controls.Add(this.textBoxBookState);
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Location = new System.Drawing.Point(22, 362);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(486, 62);
            this.panelInfo.TabIndex = 8;
            // 
            // textBoxBookState
            // 
            this.textBoxBookState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBookState.Location = new System.Drawing.Point(140, 18);
            this.textBoxBookState.Name = "textBoxBookState";
            this.textBoxBookState.ReadOnly = true;
            this.textBoxBookState.Size = new System.Drawing.Size(332, 20);
            this.textBoxBookState.TabIndex = 0;
            this.textBoxBookState.Text = "";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.TabIndex = 0;
            this.label1.Text = "Book State";
            // 
            // labelBookName
            // 
            this.labelBookName.Location = new System.Drawing.Point(28, 18);
            this.labelBookName.Name = "labelBookName";
            this.labelBookName.TabIndex = 10;
            this.labelBookName.Text = "Book Name";
            // 
            // textBoxBookName
            // 
            this.textBoxBookName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxBookName.Location = new System.Drawing.Point(140, 20);
            this.textBoxBookName.Name = "textBoxBookName";
            this.textBoxBookName.Size = new System.Drawing.Size(252, 20);
            this.textBoxBookName.TabIndex = 0;
            this.textBoxBookName.Text = "Things that go Bump in the Night";
            this.textBoxBookName.TextChanged += new System.EventHandler(this.textBoxBookName_TextChanged);
            // 
            // listBoxCommands
            // 
            this.listBoxCommands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxCommands.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxCommands.Location = new System.Drawing.Point(3, 16);
            this.listBoxCommands.Name = "listBoxCommands";
            this.listBoxCommands.Size = new System.Drawing.Size(466, 247);
            this.listBoxCommands.TabIndex = 2;
            this.listBoxCommands.DoubleClick += new System.EventHandler(this.listBoxCommands_DoubleClick);
            this.listBoxCommands.SelectedIndexChanged += new System.EventHandler(this.listBoxCommands_SelectedIndexChanged);
            // 
            // groupBoxSignals
            // 
            this.groupBoxSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
                | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSignals.Controls.Add(this.panel1);
            this.groupBoxSignals.Controls.Add(this.listBoxCommands);
            this.groupBoxSignals.Location = new System.Drawing.Point(26, 70);
            this.groupBoxSignals.Name = "groupBoxSignals";
            this.groupBoxSignals.Size = new System.Drawing.Size(472, 274);
            this.groupBoxSignals.TabIndex = 12;
            this.groupBoxSignals.TabStop = false;
            this.groupBoxSignals.Text = " Signals ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonRaiseSignal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 227);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 44);
            this.panel1.TabIndex = 3;
            // 
            // buttonRaiseSignal
            // 
            this.buttonRaiseSignal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRaiseSignal.Enabled = false;
            this.buttonRaiseSignal.Location = new System.Drawing.Point(336, 12);
            this.buttonRaiseSignal.Name = "buttonRaiseSignal";
            this.buttonRaiseSignal.Size = new System.Drawing.Size(114, 23);
            this.buttonRaiseSignal.TabIndex = 0;
            this.buttonRaiseSignal.Text = "Raise Signal";
            this.buttonRaiseSignal.Click += new System.EventHandler(this.listBoxCommands_DoubleClick);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(520, 450);
            this.Controls.Add(this.groupBoxSignals);
            this.Controls.Add(this.textBoxBookName);
            this.Controls.Add(this.labelBookName);
            this.Controls.Add(this.panelInfo);
            this.Controls.Add(this.buttonCreateBook);
            this.Name = "Form1";
            this.Text = "Book Sample";
            this.panelInfo.ResumeLayout(false);
            this.groupBoxSignals.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() 
        {
            Application.Run(new Form1());
        }

        IHsmExecutionModel _SharedExecutionModel;
	    
        private void InitHsmRunner()
        {
            _SharedExecutionModel = new MultipleHsmsPerThread ();
        }

        BookFrame frame;
        int _Counter = 0;
	    
        private void buttonCreateBook_Click(object sender, System.EventArgs e)
        {
            string bookName = textBoxBookName.Text;
            bookName = bookName.Trim ();
            if(bookName != "")
            {
                bookName = bookName + ".HsmState";
                
                _Counter++;
                string id = _Counter.ToString (); // Guid.NewGuid ().ToString ();
                frame = _SharedExecutionModel.CreateHsm (id, bookName);
            
                frame.StateChange += new EventHandler(stateChange);

                UpdateStates ();
            }
        }
	    
        private void stateChange(object sender, EventArgs e)
        {
            if(this.InvokeRequired)
            {
                this.Invoke (new EventHandler (stateChange), new object[] {e});
            } 
            else
            {                
                UpdateStates ();
            }
        }	    

        private void UpdateStates ()
        {
            UpdateButtonStates (this);
            textBoxBookState.Text = frame.BookState;
            listBoxCommands.Items.Clear ();
            listBoxCommands.Items.AddRange (frame.GetCommandNamesForCurrentState());    
            buttonRaiseSignal.Enabled = false;
        }

	    private void CheckRaiseSignalButtonEnabled()
	    {
            buttonRaiseSignal.Enabled = listBoxCommands.Items.Count > 0;
	    }

	    public void UpdateButtonStates(Form form)
        {            
            foreach(Control control in form.Controls)
            {
                if (control is Button)
                {
                    control.Enabled = false;
                }
            }

            string[] commandNames = frame.GetCommandNamesForCurrentState ();
            foreach(string commandName in commandNames)
            {
                foreach(Control control in form.Controls)
                {
                    if (control is Button)
                    {
                        Button button = (Button) control;
                        if(button.Name == "button" + commandName)
                        {
                            button.Enabled = true;
                        }
                    }
                }
            }
        }

	    private void RaiseSelectedSignal()
	    {
	        frame.DoCommand (listBoxCommands.SelectedItem.ToString ());
	    }
	    
        private void listBoxCommands_DoubleClick(object sender, System.EventArgs e)
        {
            RaiseSelectedSignal();
        }

        private void textBoxBookName_TextChanged(object sender, System.EventArgs e)
        {
            buttonCreateBook.Enabled = textBoxBookName.Text.Trim() != "";        
        }

        private void listBoxCommands_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            CheckRaiseSignalButtonEnabled();        
        }
    }
}
