//<summary>
//  Title   : Form that contains Editor Panel
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    200803 - mzbrzezny: created
//    <date> - <author>: <description>
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>
namespace CAS.Lib.ControlLibrary.GDI
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
      this.MyEditorPanel = new CAS.Lib.ControlLibrary.GDI.EditorPanel();
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