﻿namespace UAOOI.Windows.Forms.CodeProtectControls
{
  partial class UnlockKeyDialog
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
      System.Windows.Forms.ToolTip m_ToolTip;
      System.Windows.Forms.Label labelUnlock;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof(UnlockKeyDialog) );
      this.m_UnlockKey = new System.Windows.Forms.TextBox();
      this.m_OKButton = new System.Windows.Forms.Button();
      this.m_CancelButton = new System.Windows.Forms.Button();
      this.m_SplitContainer = new System.Windows.Forms.SplitContainer();
      this.m_HelpText = new System.Windows.Forms.RichTextBox();
      m_ToolTip = new System.Windows.Forms.ToolTip( this.components );
      labelUnlock = new System.Windows.Forms.Label();
      this.m_SplitContainer.Panel1.SuspendLayout();
      this.m_SplitContainer.Panel2.SuspendLayout();
      this.m_SplitContainer.SuspendLayout();
      this.SuspendLayout();
      // 
      // m_ToolTip
      // 
      m_ToolTip.IsBalloon = true;
      // 
      // m_UlockKey
      // 
      this.m_UnlockKey.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.m_UnlockKey.Location = new System.Drawing.Point( 0, 18 );
      this.m_UnlockKey.Name = "m_UlockKey";
      this.m_UnlockKey.Size = new System.Drawing.Size( 580, 20 );
      this.m_UnlockKey.TabIndex = 1;
      m_ToolTip.SetToolTip( this.m_UnlockKey, "In the \"Unlock key\" text box enter your key." );
      // 
      // labelUnlock
      // 
      labelUnlock.Dock = System.Windows.Forms.DockStyle.Top;
      labelUnlock.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
      labelUnlock.Location = new System.Drawing.Point( 0, 0 );
      labelUnlock.Name = "labelUnlock";
      labelUnlock.Size = new System.Drawing.Size( 580, 13 );
      labelUnlock.TabIndex = 2;
      labelUnlock.Text = "Unlock key";
      m_ToolTip.SetToolTip( labelUnlock, "In the \"Unlock key\" text box enter or paste your key and press OK button." );
      // 
      // m_OKButton
      // 
      this.m_OKButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left ) ) );
      this.m_OKButton.Location = new System.Drawing.Point( 0, 478 );
      this.m_OKButton.Name = "m_OKButton";
      this.m_OKButton.Size = new System.Drawing.Size( 75, 23 );
      this.m_OKButton.TabIndex = 2;
      this.m_OKButton.Text = "OK";
      this.m_OKButton.UseVisualStyleBackColor = true;
      this.m_OKButton.Click += new System.EventHandler( this.m_OKButton_Click );
      // 
      // m_CancelButton
      // 
      this.m_CancelButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.m_CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.m_CancelButton.Location = new System.Drawing.Point( 505, 478 );
      this.m_CancelButton.Name = "m_CancelButton";
      this.m_CancelButton.Size = new System.Drawing.Size( 75, 23 );
      this.m_CancelButton.TabIndex = 3;
      this.m_CancelButton.Text = "Cancel";
      this.m_CancelButton.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.m_SplitContainer.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.m_SplitContainer.Location = new System.Drawing.Point( 0, 0 );
      this.m_SplitContainer.Name = "splitContainer1";
      this.m_SplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer1.Panel1
      // 
      this.m_SplitContainer.Panel1.Controls.Add( this.m_HelpText );
      // 
      // splitContainer1.Panel2
      // 
      this.m_SplitContainer.Panel2.Controls.Add( labelUnlock );
      this.m_SplitContainer.Panel2.Controls.Add( this.m_UnlockKey );
      this.m_SplitContainer.Size = new System.Drawing.Size( 580, 472 );
      this.m_SplitContainer.SplitterDistance = 430;
      this.m_SplitContainer.TabIndex = 4;
      // 
      // m_HelpText
      // 
      this.m_HelpText.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.m_HelpText.Location = new System.Drawing.Point( 3, 3 );
      this.m_HelpText.Name = "m_HelpText";
      this.m_HelpText.ReadOnly = true;
      this.m_HelpText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
      this.m_HelpText.Size = new System.Drawing.Size( 574, 424 );
      this.m_HelpText.TabIndex = 1;
      this.m_HelpText.Text = "HelpText";
      this.m_HelpText.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler( this.m_HelpText_LinkClicked );
      // 
      // UlockKeyDialog
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
      this.CancelButton = this.m_CancelButton;
      this.ClientSize = new System.Drawing.Size( 580, 506 );
      this.Controls.Add( this.m_SplitContainer );
      this.Controls.Add( this.m_CancelButton );
      this.Controls.Add( this.m_OKButton );
      this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size( 250, 130 );
      this.Name = "UlockKeyDialog";
      this.Text = "Unlock software";
      m_ToolTip.SetToolTip( this, resources.GetString( "$this.ToolTip" ) );
      this.m_SplitContainer.Panel1.ResumeLayout( false );
      this.m_SplitContainer.Panel2.ResumeLayout( false );
      this.m_SplitContainer.Panel2.PerformLayout();
      this.m_SplitContainer.ResumeLayout( false );
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.Button m_OKButton;
    private System.Windows.Forms.Button m_CancelButton;
    private System.Windows.Forms.SplitContainer m_SplitContainer;
    private System.Windows.Forms.TextBox m_UnlockKey;
    private System.Windows.Forms.RichTextBox m_HelpText;

  }
}
