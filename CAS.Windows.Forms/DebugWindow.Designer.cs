namespace UAOOI.Windows.Forms
{

  partial class DebugWindow
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
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DebugWindow));
      this.textBox_debug = new System.Windows.Forms.TextBox();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.toolStripButton_clear = new System.Windows.Forms.ToolStripButton();
      this.toolStripButton_alwaysontop = new System.Windows.Forms.ToolStripButton();
      this.toolStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // textBox_debug
      // 
      this.textBox_debug.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.textBox_debug.Location = new System.Drawing.Point(12, 28);
      this.textBox_debug.Multiline = true;
      this.textBox_debug.Name = "textBox_debug";
      this.textBox_debug.ReadOnly = true;
      this.textBox_debug.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox_debug.Size = new System.Drawing.Size(268, 226);
      this.textBox_debug.TabIndex = 0;
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_clear,
            this.toolStripButton_alwaysontop});
      this.toolStrip1.Location = new System.Drawing.Point(0, 0);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(292, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // toolStripButton_clear
      // 
      this.toolStripButton_clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton_clear.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_clear.Image")));
      this.toolStripButton_clear.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton_clear.Name = "toolStripButton_clear";
      this.toolStripButton_clear.Size = new System.Drawing.Size(36, 22);
      this.toolStripButton_clear.Text = "Clear";
      this.toolStripButton_clear.Click += new System.EventHandler(this.toolStripButton_clear_Click);
      // 
      // toolStripButton_alwaysontop
      // 
      this.toolStripButton_alwaysontop.CheckOnClick = true;
      this.toolStripButton_alwaysontop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.toolStripButton_alwaysontop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_alwaysontop.Image")));
      this.toolStripButton_alwaysontop.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.toolStripButton_alwaysontop.Name = "toolStripButton_alwaysontop";
      this.toolStripButton_alwaysontop.Size = new System.Drawing.Size(79, 22);
      this.toolStripButton_alwaysontop.Text = "Always on top";
      this.toolStripButton_alwaysontop.Click += new System.EventHandler(this.toolStripButton_always_ontop_Click);
      // 
      // DebugWindow
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.textBox_debug);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Name = "DebugWindow";
      this.Text = "Debug Window";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBox_debug;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.ToolStripButton toolStripButton_clear;
    private System.Windows.Forms.ToolStripButton toolStripButton_alwaysontop;

  }
}