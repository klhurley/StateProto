using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Button buttonCreateWatch;
        private System.Windows.Forms.Button buttonSetEvent;
        private System.Windows.Forms.Button buttonModeEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentState;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentDisplay;
        private System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
            this.components = new System.ComponentModel.Container();
            this.buttonCreateWatch = new System.Windows.Forms.Button();
            this.buttonSetEvent = new System.Windows.Forms.Button();
            this.buttonModeEvent = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.labelCurrentState = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentDisplay = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // buttonCreateWatch
            // 
            this.buttonCreateWatch.Location = new System.Drawing.Point(20, 24);
            this.buttonCreateWatch.Name = "buttonCreateWatch";
            this.buttonCreateWatch.Size = new System.Drawing.Size(92, 23);
            this.buttonCreateWatch.TabIndex = 0;
            this.buttonCreateWatch.Text = "Create Watch";
            this.buttonCreateWatch.Click += new System.EventHandler(this.buttonCreateWatch_Click);
            // 
            // buttonSetEvent
            // 
            this.buttonSetEvent.Enabled = false;
            this.buttonSetEvent.Location = new System.Drawing.Point(20, 66);
            this.buttonSetEvent.Name = "buttonSetEvent";
            this.buttonSetEvent.Size = new System.Drawing.Size(92, 23);
            this.buttonSetEvent.TabIndex = 1;
            this.buttonSetEvent.Text = "Set Event";
            this.buttonSetEvent.Click += new System.EventHandler(this.buttonSetEvent_Click);
            // 
            // buttonModeEvent
            // 
            this.buttonModeEvent.Enabled = false;
            this.buttonModeEvent.Location = new System.Drawing.Point(20, 104);
            this.buttonModeEvent.Name = "buttonModeEvent";
            this.buttonModeEvent.Size = new System.Drawing.Size(92, 23);
            this.buttonModeEvent.TabIndex = 2;
            this.buttonModeEvent.Text = "Mode Event";
            this.buttonModeEvent.Click += new System.EventHandler(this.buttonModeEvent_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(188, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 3;
            this.label1.Text = "Current State:";
            // 
            // labelCurrentState
            // 
            this.labelCurrentState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentState.Location = new System.Drawing.Point(188, 70);
            this.labelCurrentState.Name = "labelCurrentState";
            this.labelCurrentState.Size = new System.Drawing.Size(226, 23);
            this.labelCurrentState.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(188, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current Display";
            // 
            // labelCurrentDisplay
            // 
            this.labelCurrentDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentDisplay.BackColor = System.Drawing.Color.Lime;
            this.labelCurrentDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.labelCurrentDisplay.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelCurrentDisplay.Location = new System.Drawing.Point(188, 154);
            this.labelCurrentDisplay.Name = "labelCurrentDisplay";
            this.labelCurrentDisplay.Size = new System.Drawing.Size(226, 40);
            this.labelCurrentDisplay.TabIndex = 6;
            this.labelCurrentDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(438, 218);
            this.Controls.Add(this.labelCurrentDisplay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelCurrentState);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonModeEvent);
            this.Controls.Add(this.buttonSetEvent);
            this.Controls.Add(this.buttonCreateWatch);
            this.Name = "Form1";
            this.Text = "Watch Hsm";
            this.Load += new System.EventHandler(this.Form1_Load);
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

        ILQHsm _Hsm;
        Samples.ISigSampleWatch _HsmSignals;
	    Samples.SampleWatch _SampleWatch;
	    IQEventManager _EventManager;
	    IQEventManagerRunner _Runner;


	    private void Form1_Load(object sender, System.EventArgs e)
        {
            _EventManager = new QMultiHsmEventManager(new QSystemTimer());        
	        _Runner = new QGUITimerEventManagerRunner (_EventManager, 1);	        
	        _Runner.Start ();
        }
	    
        private void buttonCreateWatch_Click(object sender, System.EventArgs e)
        {
            _SampleWatch = new Samples.SampleWatch (_EventManager);
            _Hsm = _SampleWatch; // use it as a straight on state machine
            _HsmSignals = _SampleWatch; // use it as a source of signals -- instead of calling AsyncDispatch() on _Hsm
            
            SetupHsmEvents (_Hsm);
            _Hsm.Init ();            
        
            EnableEvents ();
        }

        private void SetupHsmEvents (ILQHsm hsm)
        {
            // hook events
            new ConsoleStateEventHandler (hsm);
        }
	    
        private void EnableEvents()
	    {
	        buttonSetEvent.Enabled = true;
	        buttonModeEvent.Enabled = true;
	    }

        private void buttonSetEvent_Click(object sender, System.EventArgs e)
        {
            _HsmSignals.SigSetEvt(null);
        }

        private void buttonModeEvent_Click(object sender, System.EventArgs e)
        {
            _HsmSignals.SigModeEvt(null);        
        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {
            if(_Hsm != null)
            {
                labelCurrentState.Text = _Hsm.CurrentStateName;
                if(_SampleWatch.Blinking)
                {
                    if(labelCurrentDisplay.Text != _SampleWatch.DisplayText)
                    {
                        labelCurrentDisplay.Text = _SampleWatch.DisplayText;
                    } else
                    {
                        labelCurrentDisplay.Text = _SampleWatch.DisplayBlinkText;
                    }
                } else
                {
                    labelCurrentDisplay.Text = _SampleWatch.DisplayText;                    
                }
            }
        }
	}
}
