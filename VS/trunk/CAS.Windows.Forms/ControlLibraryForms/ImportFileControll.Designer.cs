namespace CAS.Lib.ControlLibrary
{
  partial class ImportFileControll
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
      this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      this.textBox_info = new System.Windows.Forms.TextBox();
      this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
      this.label1 = new System.Windows.Forms.Label();
      this.textBox_filename = new System.Windows.Forms.TextBox();
      this.button_browse = new System.Windows.Forms.Button();
      this.propertyGrid_info = new System.Windows.Forms.PropertyGrid();
      this.openFileDialog_for_import = new System.Windows.Forms.OpenFileDialog();
      this.tableLayoutPanel1.SuspendLayout();
      this.flowLayoutPanel1.SuspendLayout();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      this.tableLayoutPanel1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.tableLayoutPanel1.ColumnCount = 1;
      this.tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 50F ) );
      this.tableLayoutPanel1.Controls.Add( this.textBox_info, 0, 0 );
      this.tableLayoutPanel1.Controls.Add( this.flowLayoutPanel1, 0, 1 );
      this.tableLayoutPanel1.Controls.Add( this.propertyGrid_info, 0, 2 );
      this.tableLayoutPanel1.Location = new System.Drawing.Point( 3, 3 );
      this.tableLayoutPanel1.Name = "tableLayoutPanel1";
      this.tableLayoutPanel1.RowCount = 3;
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 66.48936F ) );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 33.51064F ) );
      this.tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 178F ) );
      this.tableLayoutPanel1.Size = new System.Drawing.Size( 434, 367 );
      this.tableLayoutPanel1.TabIndex = 0;
      // 
      // textBox_info
      // 
      this.textBox_info.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.textBox_info.Location = new System.Drawing.Point( 3, 3 );
      this.textBox_info.Multiline = true;
      this.textBox_info.Name = "textBox_info";
      this.textBox_info.ReadOnly = true;
      this.textBox_info.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.textBox_info.Size = new System.Drawing.Size( 428, 119 );
      this.textBox_info.TabIndex = 0;
      this.textBox_info.Text = "Import Description";
      // 
      // flowLayoutPanel1
      // 
      this.flowLayoutPanel1.Controls.Add( this.label1 );
      this.flowLayoutPanel1.Controls.Add( this.textBox_filename );
      this.flowLayoutPanel1.Controls.Add( this.button_browse );
      this.flowLayoutPanel1.Location = new System.Drawing.Point( 3, 128 );
      this.flowLayoutPanel1.Name = "flowLayoutPanel1";
      this.flowLayoutPanel1.Size = new System.Drawing.Size( 417, 29 );
      this.flowLayoutPanel1.TabIndex = 2;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point( 3, 0 );
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size( 69, 13 );
      this.label1.TabIndex = 1;
      this.label1.Text = "File to import:";
      // 
      // textBox_filename
      // 
      this.textBox_filename.Location = new System.Drawing.Point( 78, 3 );
      this.textBox_filename.Name = "textBox_filename";
      this.textBox_filename.Size = new System.Drawing.Size( 225, 20 );
      this.textBox_filename.TabIndex = 2;
      this.textBox_filename.TextChanged += new System.EventHandler( this.textBox_filename_TextChanged );
      // 
      // button_browse
      // 
      this.button_browse.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.button_browse.Location = new System.Drawing.Point( 309, 3 );
      this.button_browse.Name = "button_browse";
      this.button_browse.Size = new System.Drawing.Size( 75, 23 );
      this.button_browse.TabIndex = 3;
      this.button_browse.Text = "Browse";
      this.button_browse.Click += new System.EventHandler( this.button1_Click );
      // 
      // propertyGrid_info
      // 
      this.propertyGrid_info.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
                  | System.Windows.Forms.AnchorStyles.Left )
                  | System.Windows.Forms.AnchorStyles.Right ) ) );
      this.propertyGrid_info.Location = new System.Drawing.Point( 3, 191 );
      this.propertyGrid_info.Name = "propertyGrid_info";
      this.propertyGrid_info.Size = new System.Drawing.Size( 428, 173 );
      this.propertyGrid_info.TabIndex = 3;
      // 
      // ImportFileControll
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add( this.tableLayoutPanel1 );
      this.Name = "ImportFileControll";
      this.Size = new System.Drawing.Size( 446, 379 );
      this.tableLayoutPanel1.ResumeLayout( false );
      this.tableLayoutPanel1.PerformLayout();
      this.flowLayoutPanel1.ResumeLayout( false );
      this.flowLayoutPanel1.PerformLayout();
      this.ResumeLayout( false );

    }

    #endregion

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    private System.Windows.Forms.TextBox textBox_info;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox textBox_filename;
    private System.Windows.Forms.Button button_browse;
    private System.Windows.Forms.PropertyGrid propertyGrid_info;
    internal System.Windows.Forms.OpenFileDialog openFileDialog_for_import;
  }
}
