//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace UAOOI.Windows.Forms
{
  partial class TextEditPanel
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
      this.toolStrip = new System.Windows.Forms.ToolStrip();
      this.textBox = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // toolStrip
      // 
      this.toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.toolStrip.Location = new System.Drawing.Point( 0, 180 );
      this.toolStrip.Name = "toolStrip";
      this.toolStrip.Size = new System.Drawing.Size( 228, 25 );
      this.toolStrip.TabIndex = 0;
      this.toolStrip.Text = "toolStrip1";
      // 
      // textBox
      // 
      this.textBox.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.textBox.Location = new System.Drawing.Point( 4, 4 );
      this.textBox.Margin = new System.Windows.Forms.Padding( 4, 4, 4, 4 );
      this.textBox.Multiline = true;
      this.textBox.Name = "textBox";
      this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox.Size = new System.Drawing.Size( 214, 172 );
      this.textBox.TabIndex = 1;
      this.textBox.Text = " ";
      this.textBox.KeyDown += new System.Windows.Forms.KeyEventHandler( this.textBox_KeyDown );
      // 
      // TextEditPanel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 8F, 16F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add( this.textBox );
      this.Controls.Add( this.toolStrip );
      this.Margin = new System.Windows.Forms.Padding( 4, 4, 4, 4 );
      this.Name = "TextEditPanel";
      this.Size = new System.Drawing.Size( 228, 205 );
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.ToolStrip toolStrip;
    private System.Windows.Forms.TextBox textBox;
  }
}
