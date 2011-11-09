using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MurphyPA.H2D.StateInteraction;
using MurphyPA.H2D.TestApp;
using qf4net;

namespace SampleWatch
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
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
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.buttonCreateWatchInThreadPool = new System.Windows.Forms.Button();
            this.buttonCreateThreadPerHsm = new System.Windows.Forms.Button();
            this.buttonCreateWatch = new System.Windows.Forms.Button();
            this.panelView = new System.Windows.Forms.Panel();
            this.tabControlWatches = new System.Windows.Forms.TabControl();
            this.groupBox.SuspendLayout();
            this.panelView.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.buttonCreateWatchInThreadPool);
            this.groupBox.Controls.Add(this.buttonCreateThreadPerHsm);
            this.groupBox.Controls.Add(this.buttonCreateWatch);
            this.groupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox.Location = new System.Drawing.Point(0, 0);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(788, 55);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            this.groupBox.Text = " Controls ";
            // 
            // buttonCreateWatchInThreadPool
            // 
            this.buttonCreateWatchInThreadPool.Location = new System.Drawing.Point(422, 22);
            this.buttonCreateWatchInThreadPool.Name = "buttonCreateWatchInThreadPool";
            this.buttonCreateWatchInThreadPool.Size = new System.Drawing.Size(166, 23);
            this.buttonCreateWatchInThreadPool.TabIndex = 9;
            this.buttonCreateWatchInThreadPool.Tag = "Pool";
            this.buttonCreateWatchInThreadPool.Text = "Create Watch in Thread Pool";
            this.buttonCreateWatchInThreadPool.Click += new System.EventHandler(this.buttonCreateWatch_Click);
            // 
            // buttonCreateThreadPerHsm
            // 
            this.buttonCreateThreadPerHsm.Location = new System.Drawing.Point(224, 22);
            this.buttonCreateThreadPerHsm.Name = "buttonCreateThreadPerHsm";
            this.buttonCreateThreadPerHsm.Size = new System.Drawing.Size(176, 23);
            this.buttonCreateThreadPerHsm.TabIndex = 8;
            this.buttonCreateThreadPerHsm.Tag = "Own";
            this.buttonCreateThreadPerHsm.Text = "Create Watch in Own Thread";
            this.buttonCreateThreadPerHsm.Click += new System.EventHandler(this.buttonCreateWatch_Click);
            // 
            // buttonCreateWatch
            // 
            this.buttonCreateWatch.Location = new System.Drawing.Point(16, 22);
            this.buttonCreateWatch.Name = "buttonCreateWatch";
            this.buttonCreateWatch.Size = new System.Drawing.Size(188, 23);
            this.buttonCreateWatch.TabIndex = 7;
            this.buttonCreateWatch.Tag = "Shared";
            this.buttonCreateWatch.Text = "Create Watch In Shared Thread";
            this.buttonCreateWatch.Click += new System.EventHandler(this.buttonCreateWatch_Click);
            // 
            // panelView
            // 
            this.panelView.Controls.Add(this.tabControlWatches);
            this.panelView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelView.Location = new System.Drawing.Point(0, 55);
            this.panelView.Name = "panelView";
            this.panelView.Size = new System.Drawing.Size(788, 593);
            this.panelView.TabIndex = 8;
            // 
            // tabControlWatches
            // 
            this.tabControlWatches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlWatches.Location = new System.Drawing.Point(0, 0);
            this.tabControlWatches.Name = "tabControlWatches";
            this.tabControlWatches.SelectedIndex = 0;
            this.tabControlWatches.Size = new System.Drawing.Size(788, 593);
            this.tabControlWatches.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(788, 648);
            this.Controls.Add(this.panelView);
            this.Controls.Add(this.groupBox);
            this.Name = "Form1";
            this.Text = "Animated Watch Hsm";
            this.groupBox.ResumeLayout(false);
            this.panelView.ResumeLayout(false);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
		    System.Threading.Thread.CurrentThread.Name = "Main";
			Application.Run(new Form1());
		}

        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.Button buttonCreateWatch;
        private System.Windows.Forms.TabControl tabControlWatches;
        private System.Windows.Forms.Panel panelView;
        private System.Windows.Forms.Button buttonCreateThreadPerHsm;
        private System.Windows.Forms.Button buttonCreateWatchInThreadPool;

	    
	    IHsmExecutionModel _SharedExecutionModel;
        IHsmExecutionModel _ThreadPerHsmExecutionModel;
        IHsmExecutionModel _ThreadPoolExecutionModel;
	    
        private void InitHsmRunner()
        {
            _ThreadPerHsmExecutionModel = new ThreadPerHsm ();
            _SharedExecutionModel = new MultipleHsmsPerThread ();
            _ThreadPoolExecutionModel = new MultipleHsmsPerThreadPool ();
        }
	    
	    private IHsmExecutionModel GetModelForSender(object sender, out string requestedThreadingModel)
	    {
            IHsmExecutionModel  executionModel = null;
            
            Control button = (Control) sender;
            requestedThreadingModel = (string)button.Tag;
            switch(requestedThreadingModel)
            {
                case "Shared":
                    executionModel = _SharedExecutionModel;
                    break;
                case "Own":
                    executionModel = _ThreadPerHsmExecutionModel;
                    break;
                case "Pool":
                    executionModel = _ThreadPoolExecutionModel;
                    break;
                default:
                    throw new FormatException ("Unknown Requested Threading Model: " + requestedThreadingModel);
            }
	        
	        return executionModel;
	    }
	    
        private void buttonCreateWatch_Click(object sender, System.EventArgs e)
        {
            string requestedThreadingModel;
            IHsmExecutionModel  executionModel = GetModelForSender (sender, out requestedThreadingModel);
            
            string id = "Watch " + tabControlWatches.TabCount;
            TabPage tabPage = new TabPage (id + "@" + requestedThreadingModel);
            tabControlWatches.TabPages.Add (tabPage);
            WatchUserControl watchControl = new WatchUserControl ();
                        
            watchControl.Init(id, executionModel);
            watchControl.Dock = DockStyle.Fill;
            tabPage.Controls.Add (watchControl);
        }

    }
}
