namespace CAS.Lib.ControlLibrary
{
  partial class DockPanelUserControl
  {
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose( bool disposing )
    {
      if ( disposing && ( components != null ) )
      {
        components.Dispose();
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
      this.label_title = new System.Windows.Forms.Label();
      this.contextMenuStrip_label = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.panel_main = new System.Windows.Forms.Panel();
      this.button_exit = new System.Windows.Forms.Button();
      this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip_label.SuspendLayout();
      this.SuspendLayout();
      // 
      // label_title
      // 
      this.label_title.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.label_title.ContextMenuStrip = this.contextMenuStrip_label;
      this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
      this.label_title.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.label_title.Location = new System.Drawing.Point( 0, 0 );
      this.label_title.Margin = new System.Windows.Forms.Padding( 3 );
      this.label_title.Name = "label_title";
      this.label_title.Size = new System.Drawing.Size( 150, 20 );
      this.label_title.TabIndex = 0;
      this.label_title.Text = "label1";
      this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // contextMenuStrip_label
      // 
      this.contextMenuStrip_label.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem} );
      this.contextMenuStrip_label.Name = "contextMenuStrip_label";
      this.contextMenuStrip_label.Size = new System.Drawing.Size( 153, 48 );
      // 
      // panel_main
      // 
      this.panel_main.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.panel_main.Location = new System.Drawing.Point( 0, 22 );
      this.panel_main.Name = "panel_main";
      this.panel_main.Size = new System.Drawing.Size( 149, 127 );
      this.panel_main.TabIndex = 1;
      // 
      // button_exit
      // 
      this.button_exit.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.button_exit.BackColor = System.Drawing.SystemColors.ActiveCaption;
      this.button_exit.FlatAppearance.BorderSize = 0;
      this.button_exit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
      this.button_exit.Font = new System.Drawing.Font( "Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ( (byte)( 238 ) ) );
      this.button_exit.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
      this.button_exit.Location = new System.Drawing.Point( 128, 0 );
      this.button_exit.Name = "button_exit";
      this.button_exit.Size = new System.Drawing.Size( 22, 20 );
      this.button_exit.TabIndex = 2;
      this.button_exit.Text = "X";
      this.button_exit.UseVisualStyleBackColor = false;
      this.button_exit.Click += new System.EventHandler( this.button_exit_Click );
      // 
      // closeToolStripMenuItem
      // 
      this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
      this.closeToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
      this.closeToolStripMenuItem.Text = "Close";
      this.closeToolStripMenuItem.Click += new System.EventHandler( this.closeToolStripMenuItem_Click );
      // 
      // DockPanelUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add( this.button_exit );
      this.Controls.Add( this.panel_main );
      this.Controls.Add( this.label_title );
      this.Name = "DockPanelUserControl";
      this.contextMenuStrip_label.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.Label label_title;
    private System.Windows.Forms.Panel panel_main;
    private System.Windows.Forms.Button button_exit;
    /// <summary>
    /// The context menu strip label
    /// </summary>
    protected System.Windows.Forms.ContextMenuStrip contextMenuStrip_label;
    private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
  }
}
