//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace UAOOI.Windows.Forms
{

  /// <summary>
  /// About License Form 
  /// </summary>
  partial class LicenseForm
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( LicenseForm ) );
      System.Windows.Forms.ToolStripButton toolStripButton2;
      this.toolStripButton_request_for_license = new System.Windows.Forms.ToolStripButton();
      this.m_TabControl = new System.Windows.Forms.TabControl();
      this.m_TB_License = new System.Windows.Forms.TabPage();
      toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
      m_ToolStrip = new System.Windows.Forms.ToolStrip();
      toolStripButton1 = new System.Windows.Forms.ToolStripButton();
      toolStripButton2 = new System.Windows.Forms.ToolStripButton();
      toolStripContainer1.BottomToolStripPanel.SuspendLayout();
      toolStripContainer1.ContentPanel.SuspendLayout();
      toolStripContainer1.SuspendLayout();
      m_ToolStrip.SuspendLayout();
      this.m_TabControl.SuspendLayout();
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
      toolStripContainer1.ContentPanel.Controls.Add( this.m_TabControl );
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
            this.toolStripButton_request_for_license,
            toolStripButton2} );
      m_ToolStrip.Location = new System.Drawing.Point( 3, 0 );
      m_ToolStrip.Name = "m_ToolStrip";
      m_ToolStrip.Size = new System.Drawing.Size( 373, 25 );
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
      // toolStripButton_request_for_license
      // 
      this.toolStripButton_request_for_license.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton_request_for_license.Image = ( (System.Drawing.Image)( resources.GetObject( "toolStripButton_request_for_license.Image" ) ) );
      this.toolStripButton_request_for_license.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton_request_for_license.Name = "toolStripButton_request_for_license";
      this.toolStripButton_request_for_license.Size = new System.Drawing.Size( 110, 22 );
      this.toolStripButton_request_for_license.Text = "Request for license";
      this.toolStripButton_request_for_license.ToolTipText = resources.GetString( "toolStripButton_request_for_license.ToolTipText" );
      this.toolStripButton_request_for_license.Click += new System.EventHandler( this.toolStripButton_request_for_license_Click );
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
      // m_TabControl
      // 
      this.m_TabControl.Controls.Add( this.m_TB_License );
      this.m_TabControl.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_TabControl.Location = new System.Drawing.Point( 0, 0 );
      this.m_TabControl.Name = "m_TabControl";
      this.m_TabControl.SelectedIndex = 0;
      this.m_TabControl.Size = new System.Drawing.Size( 918, 466 );
      this.m_TabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
      this.m_TabControl.TabIndex = 1;
      // 
      // m_TB_License
      // 
      this.m_TB_License.Location = new System.Drawing.Point( 4, 22 );
      this.m_TB_License.Name = "m_TB_License";
      this.m_TB_License.Padding = new System.Windows.Forms.Padding( 3 );
      this.m_TB_License.Size = new System.Drawing.Size( 910, 440 );
      this.m_TB_License.TabIndex = 1;
      this.m_TB_License.Text = "License";
      this.m_TB_License.UseVisualStyleBackColor = true;
      // 
      // LicenseForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.ClientSize = new System.Drawing.Size( 918, 516 );
      this.Controls.Add( toolStripContainer1 );
      this.Margin = new System.Windows.Forms.Padding( 4 );
      this.MinimumSize = new System.Drawing.Size( 750, 550 );
      this.Name = "LicenseForm";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "License information";
      toolStripContainer1.BottomToolStripPanel.ResumeLayout( false );
      toolStripContainer1.BottomToolStripPanel.PerformLayout();
      toolStripContainer1.ContentPanel.ResumeLayout( false );
      toolStripContainer1.ResumeLayout( false );
      toolStripContainer1.PerformLayout();
      m_ToolStrip.ResumeLayout( false );
      m_ToolStrip.PerformLayout();
      this.m_TabControl.ResumeLayout( false );
      this.ResumeLayout( false );

    }
    #endregion

    private System.Windows.Forms.TabControl m_TabControl;
    private System.Windows.Forms.TabPage m_TB_License;
    private System.Windows.Forms.ToolStripButton toolStripButton_request_for_license;
  }
}