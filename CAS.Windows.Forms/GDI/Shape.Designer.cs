namespace UAOOI.Windows.Forms.GDI
{
  partial class Shape
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
      this.SuspendLayout();
      // 
      // Shape
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Name = "Shape";
      this.Load += new System.EventHandler( this.Shape_Load );
      this.LocationChanged += new System.EventHandler( this.Shape_LocationChanged );
      this.Paint += new System.Windows.Forms.PaintEventHandler( this.Shape_Paint );
      this.MouseMove += new System.Windows.Forms.MouseEventHandler( this.Shape_MouseMove );
      this.Scroll += new System.Windows.Forms.ScrollEventHandler( this.Shape_Scroll );
      this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.Shape_MouseDown );
      this.Resize += new System.EventHandler( this.Shape_Resize );
      this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.Shape_MouseUp );
      this.ResumeLayout( false );

    }

    #endregion
  }
}
