//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// About License Form 
  /// </summary>
  partial class AboutForm
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
    #region Windows Form Designer generated code
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.Windows.Forms.ToolStripContainer toolStripContainer1;
      System.Windows.Forms.ToolStrip m_ToolStrip;
      System.Windows.Forms.ToolStripButton toolStripButton1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( AboutForm ) );
      System.Windows.Forms.ToolStripButton toolStripButton2;
      this.m_about = new About();
      toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      m_ToolStrip = new System.Windows.Forms.ToolStrip();
      toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      toolStripButton2 = new System.Windows.Forms.ToolStripButton();
      toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      toolStripContainer1.ContentPanel.SuspendLayout();
      toolStripContainer1.SuspendLayout();
      m_ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripContainer1
      // 
      // 
      // toolStripContainer1.BottomToolStripPanel
      // 
      toolStripContainer1.BottomToolStripPanel.Controls.Add( m_ToolStrip );
      // 
      // toolStripContainer1.ContentPanel
      // 
      toolStripContainer1.ContentPanel.Controls.Add( this.m_about );
      toolStripContainer1.ContentPanel.Size = new System.Drawing.Size( 918, 466 );
      toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      // 
      // toolStripContainer1.LeftToolStripPanel
      // 
      toolStripContainer1.LeftToolStripPanel.Enabled = false;
      toolStripContainer1.Location = new System.Drawing.Point( 0, 0 );
      toolStripContainer1.Name = "toolStripContainer1";
      // 
      // toolStripContainer1.RightToolStripPanel
      // 
      toolStripContainer1.RightToolStripPanel.Enabled = false;
      toolStripContainer1.Size = new System.Drawing.Size( 918, 516 );
      toolStripContainer1.TabIndex = 3;
      toolStripContainer1.Text = "toolStripContainer1";
      // 
      // m_ToolStrip
      // 
      m_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      m_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            toolStripButton1,
            toolStripButton2} );
      m_ToolStrip.Location = new System.Drawing.Point( 3, 0 );
      m_ToolStrip.Name = "m_ToolStrip";
      m_ToolStrip.Size = new System.Drawing.Size( 386, 25 );
      m_ToolStrip.TabIndex = 3;
      m_ToolStrip.Text = "toolStrip1";
      // 
      // toolStripButton1
      // 
      toolStripButton1.AutoSize = false;
      toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      toolStripButton1.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton1.Image" ) ) );
      toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
      toolStripButton1.Name = "toolStripButton1";
      toolStripButton1.Size = new System.Drawing.Size( 100, 22 );
      toolStripButton1.Text = "OK";
      toolStripButton1.Click += new System.EventHandler( this.m_button_OK_Click );
      // 
      // toolStripButton2
      // 
      toolStripButton2.AutoSize = false;
      toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      toolStripButton2.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton2.Image" ) ) );
      toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
      toolStripButton2.Name = "toolStripButton2";
      toolStripButton2.Size = new System.Drawing.Size( 120, 22 );
      toolStripButton2.Text = "System Information";
      toolStripButton2.Click += new System.EventHandler( this.m_button_Sysinfo_Click );
      // 
      // m_about
      // 
      this.m_about.AutoSize = true;
      this.m_about.Cursor = System.Windows.Forms.Cursors.Default;
      this.m_about.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_about.Location = new System.Drawing.Point( 0, 0 );
      this.m_about.Margin = new System.Windows.Forms.Padding( 2 );
      this.m_about.MinimumSize = new System.Drawing.Size( 700, 300 );
      this.m_about.Name = "m_about";
      this.m_about.Size = new System.Drawing.Size( 918, 466 );
      this.m_about.TabIndex = 1;
      // 
      // AboutForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size( 918, 516 );
      this.Controls.Add( toolStripContainer1 );
      this.Margin = new System.Windows.Forms.Padding( 4 );
      this.MinimumSize = new System.Drawing.Size( 750, 550 );
      this.Name = "AboutForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "About Product";
      toolStripContainer1.BottomToolStripPanel.ResumeLayout( false );
      toolStripContainer1.BottomToolStripPanel.PerformLayout();
      toolStripContainer1.ContentPanel.ResumeLayout( false );
      toolStripContainer1.ContentPanel.PerformLayout();
      toolStripContainer1.ResumeLayout( false );
      toolStripContainer1.PerformLayout();
      m_ToolStrip.ResumeLayout( false );
      m_ToolStrip.PerformLayout();
      this.ResumeLayout( false );

    }
    #endregion

    private About m_about;
  }
}