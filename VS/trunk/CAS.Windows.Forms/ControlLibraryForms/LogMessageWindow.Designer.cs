namespace CAS.Lib.ControlLibrary
{
  partial class LogMessageWindow
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
      this.button_ok = new System.Windows.Forms.Button();
      this.textBox_log = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // button_ok
      // 
      this.button_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
      this.button_ok.Location = new System.Drawing.Point( 99, 231 );
      this.button_ok.Name = "button_ok";
      this.button_ok.Size = new System.Drawing.Size( 75, 23 );
      this.button_ok.TabIndex = 0;
      this.button_ok.Text = "OK";
      this.button_ok.UseVisualStyleBackColor = true;
      this.button_ok.Click += new System.EventHandler( this.button_ok_Click );
      // 
      // textBox_log
      // 
      this.textBox_log.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.textBox_log.Location = new System.Drawing.Point( 12, 12 );
      this.textBox_log.Multiline = true;
      this.textBox_log.Name = "textBox_log";
      this.textBox_log.ReadOnly = true;
      this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox_log.Size = new System.Drawing.Size( 268, 207 );
      this.textBox_log.TabIndex = 1;
      // 
      // LogMessageWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 292, 266 );
      this.Controls.Add( this.textBox_log );
      this.Controls.Add( this.button_ok );
      this.Name = "LogMessageWindow";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.Text = "Log Message Window";
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button button_ok;
    private System.Windows.Forms.TextBox textBox_log;
  }
}