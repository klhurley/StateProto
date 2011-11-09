using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using MurphyPA.H2D.StateInteraction;
using MurphyPA.H2D.TestApp;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// Summary description for WatchUserControl.
	/// </summary>
	public class WatchUserControl : System.Windows.Forms.UserControl
	{
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Label labelCurrentDisplay;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCurrentState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonModeEvent;
        private System.Windows.Forms.Button buttonSetEvent;
        private System.Windows.Forms.Button buttonStartWatch;
        private System.Windows.Forms.TabControl tabControlHsmAndProperties;
        private System.Windows.Forms.TabPage tabPageHsm;
        private System.Windows.Forms.Panel panelViewHsm;
        private System.Windows.Forms.TabPage tabPageProperties;
        private System.Windows.Forms.Panel panelViewPropertyGrid;
        private System.Windows.Forms.PropertyGrid propertyGrid;
        private System.ComponentModel.IContainer components;

		public WatchUserControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.panelView = new System.Windows.Forms.Panel();
            this.tabControlHsmAndProperties = new System.Windows.Forms.TabControl();
            this.tabPageHsm = new System.Windows.Forms.TabPage();
            this.panelViewHsm = new System.Windows.Forms.Panel();
            this.tabPageProperties = new System.Windows.Forms.TabPage();
            this.panelViewPropertyGrid = new System.Windows.Forms.Panel();
            this.propertyGrid = new System.Windows.Forms.PropertyGrid();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.labelCurrentDisplay = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCurrentState = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonModeEvent = new System.Windows.Forms.Button();
            this.buttonSetEvent = new System.Windows.Forms.Button();
            this.buttonStartWatch = new System.Windows.Forms.Button();
            this.panelView.SuspendLayout();
            this.tabControlHsmAndProperties.SuspendLayout();
            this.tabPageHsm.SuspendLayout();
            this.tabPageProperties.SuspendLayout();
            this.panelViewPropertyGrid.SuspendLayout();
            this.groupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.tabControlHsmAndProperties);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 110);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(796, 582);
            this.panelView.TabIndex = 10;
            // 
            // tabControlHsmAndProperties
            // 
            this.tabControlHsmAndProperties.Controls.Add(this.tabPageHsm);
            this.tabControlHsmAndProperties.Controls.Add(this.tabPageProperties);
            this.tabControlHsmAndProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlHsmAndProperties.Location = new System.Drawing.Point(0, 0);
            this.tabControlHsmAndProperties.Name = "tabControlHsmAndProperties";
            this.tabControlHsmAndProperties.SelectedIndex = 0;
            this.tabControlHsmAndProperties.Size = new System.Drawing.Size(796, 582);
            this.tabControlHsmAndProperties.TabIndex = 0;
            // 
            // tabPageHsm
            // 
            this.tabPageHsm.Controls.Add(this.panelViewHsm);
            this.tabPageHsm.Location = new System.Drawing.Point(4, 22);
            this.tabPageHsm.Name = "tabPageHsm";
            this.tabPageHsm.Size = new System.Drawing.Size(788, 556);
            this.tabPageHsm.TabIndex = 0;
            this.tabPageHsm.Text = "State Machine";
            // 
            // panelViewHsm
            // 
            this.panelViewHsm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewHsm.Location = new System.Drawing.Point(0, 0);
            this.panelViewHsm.Name = "panelViewHsm";
            this.panelViewHsm.Size = new System.Drawing.Size(788, 556);
            this.panelViewHsm.TabIndex = 0;
            // 
            // tabPageProperties
            // 
            this.tabPageProperties.Controls.Add(this.panelViewPropertyGrid);
            this.tabPageProperties.Location = new System.Drawing.Point(4, 22);
            this.tabPageProperties.Name = "tabPageProperties";
            this.tabPageProperties.Size = new System.Drawing.Size(788, 562);
            this.tabPageProperties.TabIndex = 1;
            this.tabPageProperties.Text = "Properties";
            // 
            // panelViewPropertyGrid
            // 
            this.panelViewPropertyGrid.Controls.Add(this.propertyGrid);
            this.panelViewPropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelViewPropertyGrid.Location = new System.Drawing.Point(0, 0);
            this.panelViewPropertyGrid.Name = "panelViewPropertyGrid";
            this.panelViewPropertyGrid.Size = new System.Drawing.Size(788, 562);
            this.panelViewPropertyGrid.TabIndex = 15;
            // 
            // propertyGrid
            // 
            this.propertyGrid.CommandsVisibleIfAvailable = true;
            this.propertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid.HelpVisible = false;
            this.propertyGrid.LargeButtons = false;
            this.propertyGrid.LineColor = System.Drawing.SystemColors.ScrollBar;
            this.propertyGrid.Location = new System.Drawing.Point(0, 0);
            this.propertyGrid.Name = "propertyGrid";
            this.propertyGrid.Size = new System.Drawing.Size(788, 562);
            this.propertyGrid.TabIndex = 0;
            this.propertyGrid.Text = "propertyGrid1";
            this.propertyGrid.ToolbarVisible = false;
            this.propertyGrid.ViewBackColor = System.Drawing.SystemColors.Window;
            this.propertyGrid.ViewForeColor = System.Drawing.SystemColors.WindowText;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.labelCurrentDisplay);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.labelCurrentState);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.buttonModeEvent);
            this.groupBox.Controls.Add(this.buttonSetEvent);
            this.groupBox.Controls.Add(this.buttonStartWatch);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(796, 110);
            this.groupBox.TabIndex = 9;
            this.groupBox.TabStop = false;
            this.groupBox.Text = " Controls ";
            // 
            // labelCurrentDisplay
            // 
            this.labelCurrentDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentDisplay.BackColor = System.Drawing.Color.Lime;
            this.labelCurrentDisplay.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
            this.labelCurrentDisplay.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelCurrentDisplay.Location = new System.Drawing.Point(334, 64);
            this.labelCurrentDisplay.Name = "labelCurrentDisplay";
            this.labelCurrentDisplay.Size = new System.Drawing.Size(446, 34);
            this.labelCurrentDisplay.TabIndex = 13;
            this.labelCurrentDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(218, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Current Display";
            // 
            // labelCurrentState
            // 
            this.labelCurrentState.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
                | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCurrentState.Location = new System.Drawing.Point(336, 30);
            this.labelCurrentState.Name = "labelCurrentState";
            this.labelCurrentState.Size = new System.Drawing.Size(444, 23);
            this.labelCurrentState.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(218, 30);
            this.label1.Name = "label1";
            this.label1.TabIndex = 10;
            this.label1.Text = "Current State:";
            // 
            // buttonModeEvent
            // 
            this.buttonModeEvent.Enabled = false;
            this.buttonModeEvent.Location = new System.Drawing.Point(114, 66);
            this.buttonModeEvent.Name = "buttonModeEvent";
            this.buttonModeEvent.Size = new System.Drawing.Size(92, 23);
            this.buttonModeEvent.TabIndex = 9;
            this.buttonModeEvent.Text = "Mode Event";
            this.buttonModeEvent.Click += new System.EventHandler(this.buttonModeEvent_Click);
            // 
            // buttonSetEvent
            // 
            this.buttonSetEvent.Enabled = false;
            this.buttonSetEvent.Location = new System.Drawing.Point(16, 66);
            this.buttonSetEvent.Name = "buttonSetEvent";
            this.buttonSetEvent.Size = new System.Drawing.Size(92, 23);
            this.buttonSetEvent.TabIndex = 8;
            this.buttonSetEvent.Text = "Set Event";
            this.buttonSetEvent.Click += new System.EventHandler(this.buttonSetEvent_Click);
            // 
            // buttonStartWatch
            // 
            this.buttonStartWatch.Location = new System.Drawing.Point(18, 32);
            this.buttonStartWatch.Name = "buttonStartWatch";
            this.buttonStartWatch.Size = new System.Drawing.Size(188, 23);
            this.buttonStartWatch.TabIndex = 7;
            this.buttonStartWatch.Text = "Start Watch";
            this.buttonStartWatch.Click += new System.EventHandler(this.buttonStartWatch_Click);
            // 
            // WatchUserControl
            // 
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.groupBox);
            this.Name = "WatchUserControl";
            this.Size = new System.Drawing.Size(796, 692);
            this.Load += new System.EventHandler(this.WatchUserControl_Load);
            this.panelView.ResumeLayout(false);
            this.tabControlHsmAndProperties.ResumeLayout(false);
            this.tabPageHsm.ResumeLayout(false);
            this.tabPageProperties.ResumeLayout(false);
            this.panelViewPropertyGrid.ResumeLayout(false);
            this.groupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion
	    
        ILQHsm _Hsm;
	    Samples.SampleWatch _SampleWatch;
        Samples.ISigSampleWatch _HsmSignals;
        StateDiagramView _View;
	    string _Id;
	    IHsmExecutionModel _ExecutionModel;
	    
	    public void Init(string id, IHsmExecutionModel executionModel)
	    {
	        _Id = id;
	        _ExecutionModel = executionModel;
        }
	    
	    
        private void WatchUserControl_Load(object sender, System.EventArgs e)
        {            
            _View = new StateDiagramView (false);
            panelViewHsm.Controls.Add (_View);
            _View.Dock = DockStyle.Fill;
	        
            _View.StateControl.LoadFileDirect (@"..\..\Samples\SampleWatch_b.sm1");	        
        }

        private void buttonStartWatch_Click(object sender, System.EventArgs e)
        {
            buttonStartWatch.Enabled = false;
            
            _SampleWatch = _ExecutionModel.CreateHsm (_Id);
            _Hsm = _SampleWatch; // use it as a straight on state machine
            _HsmSignals = _Hsm as Samples.ISigSampleWatch; // use it as a source of signals -- instead of calling AsyncDispatch() on _Hsm
                        
            SetupHsmEvents (_Hsm);
            _Hsm.Init ();
        
            EnableEvents ();
        }

        private void SetupHsmEvents (ILQHsm hsm)
        {
            StateProtoViewAnimator animator = new StateProtoViewAnimator(hsm, _View);
            animator.TransitionDelay = 0;
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
                string currentStateName = _Hsm.CurrentStateName;
                labelCurrentState.Text = currentStateName;
                if(_SampleWatch.Blinking)
                {
                    if(labelCurrentDisplay.Text != _SampleWatch.DisplayText)
                    {
                        labelCurrentDisplay.Text = _SampleWatch.DisplayText;
                    } 
                    else
                    {
                        labelCurrentDisplay.Text = _SampleWatch.DisplayBlinkText;
                    }
                } 
                else
                {
                    labelCurrentDisplay.Text = _SampleWatch.DisplayText;                    
                }
                
                propertyGrid.SelectedObject = _Hsm;                
            }
        }
	}
}
