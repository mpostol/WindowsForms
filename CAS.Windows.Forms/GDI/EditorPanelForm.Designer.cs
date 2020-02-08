//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace UAOOI.Windows.Forms.GDI
{

  /// <summary>
  /// Form that contains Editor Panel
  /// </summary>
  partial class EditorPanelForm
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
      this.MyEditorPanel = new EditorPanel();
      this.SuspendLayout();
      // 
      // MyEditorPanel
      // 
      this.MyEditorPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.MyEditorPanel.AutoScroll = true;
      this.MyEditorPanel.Location = new System.Drawing.Point(12, 12);
      this.MyEditorPanel.Name = "MyEditorPanel";
      this.MyEditorPanel.Size = new System.Drawing.Size(635, 457);
      this.MyEditorPanel.TabIndex = 0;
      // 
      // EditorPanelForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(659, 481);
      this.Controls.Add(this.MyEditorPanel);
      this.Name = "EditorPanelForm";
      this.Text = "EditorPanelForm";
      this.ResumeLayout(false);
    }

    #endregion
    private EditorPanel MyEditorPanel;

  }
}