namespace UAOOI.Windows.Forms
{
  partial class ServiceControlToolStrip
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
        components.Dispose();
      base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.toolStripLabel_main = new System.Windows.Forms.ToolStripLabel();
      this.toolStripButton_start = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton_stop = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton_restart = new System.Windows.Forms.ToolStripButton();
      this.toolStripLabel_status_text = new System.Windows.Forms.ToolStripLabel();
      this.toolStripLabel_status = new System.Windows.Forms.ToolStripLabel();
      this.serviceController = new System.ServiceProcess.ServiceController();
      this.SuspendLayout();
      // 
      // toolStripLabel_main
      // 
      this.toolStripLabel_main.Name = "toolStripLabel_main";
      this.toolStripLabel_main.Size = new System.Drawing.Size(121, 13);
      this.toolStripLabel_main.Text = "Local Service controller:";
      // 
      // toolStripButton_start
      // 
      this.toolStripButton_start.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton_start.Image = global::UAOOI.Windows.Forms.Properties.Resources.start;
      this.toolStripButton_start.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton_start.Name = "toolStripButton_start";
      this.toolStripButton_start.Size = new System.Drawing.Size(23, 20);
      this.toolStripButton_start.Click += new System.EventHandler(toolStripButton_start_Click);
      this.toolStripButton_start.Text = "Start";
      this.toolStripButton_start.ToolTipText = "Start service";
      // 
      // toolStripButton_stop
      // 
      this.toolStripButton_stop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton_stop.Image = global::UAOOI.Windows.Forms.Properties.Resources.stop;
      this.toolStripButton_stop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton_stop.Name = "toolStripButton_stop";
      this.toolStripButton_stop.Size = new System.Drawing.Size(23, 4);
      this.toolStripButton_stop.Click += new System.EventHandler(toolStripButton_stop_Click);
      this.toolStripButton_stop.Text = "Stop";
      this.toolStripButton_stop.ToolTipText = "Stop service";
      // 
      // toolStripButton_restart
      // 
      this.toolStripButton_restart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.toolStripButton_restart.Image = UAOOI.Windows.Forms.Properties.Resources.restart;
      this.toolStripButton_restart.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton_restart.Name = "toolStripButton_restart";
      this.toolStripButton_restart.Size = new System.Drawing.Size(23, 4);
      this.toolStripButton_restart.Click += new System.EventHandler(toolStripButton_restart_Click);
      this.toolStripButton_restart.Text = "Restart";
      this.toolStripButton_restart.ToolTipText = "Restart service";
      // 
      // toolStripLabel_status_text
      // 
      this.toolStripLabel_status_text.Name = "toolStripLabel_status_text";
      this.toolStripLabel_status_text.Size = new System.Drawing.Size(23, 23);
      this.toolStripLabel_status_text.Text = "Status:";
      // 
      // toolStripLabel_status
      // 
      this.toolStripLabel_status.Name = "toolStripLabel_status";
      this.toolStripLabel_status.Size = new System.Drawing.Size(23, 23);
      this.toolStripLabel_status.Text = "toolStripLabel2";
      this.toolStripLabel_status.MouseEnter += new System.EventHandler(toolStripLabel_status_MouseEnter);
      // 
      // ServiceControlToolStrip
      // 
      this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_main,
            this.toolStripButton_start,
            this.toolStripButton_stop,
            this.toolStripButton_restart,
            this.toolStripLabel_status_text,
            this.toolStripLabel_status});
      this.ResumeLayout(false);

    }
    #endregion

    private System.Windows.Forms.ToolStripLabel toolStripLabel_main;
    private System.Windows.Forms.ToolStripButton toolStripButton_start;
    private System.Windows.Forms.ToolStripButton toolStripButton_stop;
    private System.Windows.Forms.ToolStripButton toolStripButton_restart;
    private System.Windows.Forms.ToolStripLabel toolStripLabel_status_text;
    private System.Windows.Forms.ToolStripLabel toolStripLabel_status;
    private System.ServiceProcess.ServiceController serviceController;
  }
}
