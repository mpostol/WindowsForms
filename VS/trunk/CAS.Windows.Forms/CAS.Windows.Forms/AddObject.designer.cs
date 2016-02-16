namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Form allowing to modify properties of new created object.
  /// </summary>
  /// <typeparam name="TObject">Type of the object to modify and accept properties.</typeparam>
  partial class AddObject<TObject>
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
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.ToolStripContainer cm_toolStripContainer;
      this.cm_ToolStrip = new System.Windows.Forms.ToolStrip();
      this.cm_TSButtonZaakceptuj = new System.Windows.Forms.ToolStripButton();
      this.cm_TSButtonZakoñcz = new System.Windows.Forms.ToolStripButton();
      this.cm_PropertyGrid = new System.Windows.Forms.PropertyGrid();
      this.propertyGridExpandAllExpander1 = new CAS.Lib.ControlLibrary.PropertyGridExpandAllExpander( this.components );
      cm_toolStripContainer = new System.Windows.Forms.ToolStripContainer();
      cm_toolStripContainer.BottomToolStripPanel.SuspendLayout();
      cm_toolStripContainer.ContentPanel.SuspendLayout();
      cm_toolStripContainer.SuspendLayout();
      this.cm_ToolStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // cm_toolStripContainer
      // 
      // 
      // cm_toolStripContainer.BottomToolStripPanel
      // 
      cm_toolStripContainer.BottomToolStripPanel.Controls.Add( this.cm_ToolStrip );
      // 
      // cm_toolStripContainer.ContentPanel
      // 
      cm_toolStripContainer.ContentPanel.Controls.Add( this.cm_PropertyGrid );
      cm_toolStripContainer.ContentPanel.Size = new System.Drawing.Size( 382, 223 );
      cm_toolStripContainer.Dock = System.Windows.Forms.DockStyle.Fill;
      cm_toolStripContainer.Location = new System.Drawing.Point( 0, 0 );
      cm_toolStripContainer.Name = "cm_toolStripContainer";
      cm_toolStripContainer.Size = new System.Drawing.Size( 382, 273 );
      cm_toolStripContainer.TabIndex = 0;
      cm_toolStripContainer.Text = "CreateNewObject";
      // 
      // cm_ToolStrip
      // 
      this.cm_ToolStrip.Dock = System.Windows.Forms.DockStyle.None;
      this.cm_ToolStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.cm_TSButtonZaakceptuj,
            this.cm_TSButtonZakoñcz} );
      this.cm_ToolStrip.Location = new System.Drawing.Point( 3, 0 );
      this.cm_ToolStrip.Name = "cm_ToolStrip";
      this.cm_ToolStrip.Size = new System.Drawing.Size( 210, 25 );
      this.cm_ToolStrip.TabIndex = 0;
      this.cm_ToolStrip.Text = "toolStrip1";
      // 
      // cm_TSButtonZaakceptuj
      // 
      this.cm_TSButtonZaakceptuj.AutoSize = false;
      this.cm_TSButtonZaakceptuj.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.cm_TSButtonZaakceptuj.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cm_TSButtonZaakceptuj.Name = "cm_TSButtonZaakceptuj";
      this.cm_TSButtonZaakceptuj.Size = new System.Drawing.Size( 100, 22 );
      this.cm_TSButtonZaakceptuj.Text = "OK";
      this.cm_TSButtonZaakceptuj.Click += new System.EventHandler( this.cm_TSButtonAccept_Click );
      // 
      // cm_TSButtonZakoñcz
      // 
      this.cm_TSButtonZakoñcz.AutoSize = false;
      this.cm_TSButtonZakoñcz.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
      this.cm_TSButtonZakoñcz.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.cm_TSButtonZakoñcz.Name = "cm_TSButtonZakoñcz";
      this.cm_TSButtonZakoñcz.Size = new System.Drawing.Size( 100, 22 );
      this.cm_TSButtonZakoñcz.Text = "Cancel";
      this.cm_TSButtonZakoñcz.Click += new System.EventHandler( this.cm_TSButtonCancel_Click );
      // 
      // cm_PropertyGrid
      // 
      this.cm_PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
      this.cm_PropertyGrid.Location = new System.Drawing.Point( 0, 0 );
      this.cm_PropertyGrid.Name = "cm_PropertyGrid";
      this.cm_PropertyGrid.Size = new System.Drawing.Size( 382, 223 );
      this.cm_PropertyGrid.TabIndex = 0;
      // 
      // propertyGridExpandAllExpander1
      // 
      this.propertyGridExpandAllExpander1.MyPropertyGrid = null;
      // 
      // AddObject
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size( 382, 273 );
      this.Controls.Add( cm_toolStripContainer );
      this.MinimumSize = new System.Drawing.Size( 240, 300 );
      this.Name = "AddObject";
      this.Text = "Setup new object properties";
      cm_toolStripContainer.BottomToolStripPanel.ResumeLayout( false );
      cm_toolStripContainer.BottomToolStripPanel.PerformLayout();
      cm_toolStripContainer.ContentPanel.ResumeLayout( false );
      cm_toolStripContainer.ResumeLayout( false );
      cm_toolStripContainer.PerformLayout();
      this.cm_ToolStrip.ResumeLayout( false );
      this.cm_ToolStrip.PerformLayout();
      this.ResumeLayout( false );

    }

    #endregion
    private System.Windows.Forms.ToolStrip cm_ToolStrip;
    private System.Windows.Forms.ToolStripButton cm_TSButtonZaakceptuj;
    private System.Windows.Forms.ToolStripButton cm_TSButtonZakoñcz;
    private System.Windows.Forms.PropertyGrid cm_PropertyGrid;
    private PropertyGridExpandAllExpander propertyGridExpandAllExpander1;
  }
}