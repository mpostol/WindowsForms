namespace CAS.Lib.ControlLibrary
{
    /// <summary>
    /// Component shows CAS about information
    /// </summary>
  partial class About
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
      System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( About ) );
      System.Windows.Forms.RichTextBox richTextBox1;
      System.Windows.Forms.RichTextBox richTextBox2;
      this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
      this.LabelProgramVer = new System.Windows.Forms.Label();
      this.m_pictureBox = new System.Windows.Forms.PictureBox();
      this.m_ProductLabel = new System.Windows.Forms.Label();
      this.m_label_user = new System.Windows.Forms.Label();
      this.webBrowser = new System.Windows.Forms.WebBrowser();
      tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
      richTextBox1 = new System.Windows.Forms.RichTextBox();
      richTextBox2 = new System.Windows.Forms.RichTextBox();
      tableLayoutPanel1.SuspendLayout();
      this.tableLayoutPanel2.SuspendLayout();
      ( (System.ComponentModel.ISupportInitialize)( this.m_pictureBox ) ).BeginInit();
      this.SuspendLayout();
      // 
      // tableLayoutPanel1
      // 
      tableLayoutPanel1.AutoSize = true;
      tableLayoutPanel1.ColumnCount = 2;
      tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      tableLayoutPanel1.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      tableLayoutPanel1.Controls.Add( this.tableLayoutPanel2, 0, 0 );
      tableLayoutPanel1.Controls.Add( this.m_ProductLabel, 0, 1 );
      tableLayoutPanel1.Controls.Add( richTextBox1, 0, 3 );
      tableLayoutPanel1.Controls.Add( this.m_label_user, 1, 1 );
      tableLayoutPanel1.Controls.Add( richTextBox2, 0, 2 );
      tableLayoutPanel1.Controls.Add( this.webBrowser, 0, 4 );
      tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
      tableLayoutPanel1.Location = new System.Drawing.Point( 0, 0 );
      tableLayoutPanel1.MinimumSize = new System.Drawing.Size( 600, 300 );
      tableLayoutPanel1.Name = "tableLayoutPanel1";
      tableLayoutPanel1.RowCount = 5;
      tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      tableLayoutPanel1.RowStyles.Add( new System.Windows.Forms.RowStyle( System.Windows.Forms.SizeType.Absolute, 20F ) );
      tableLayoutPanel1.Size = new System.Drawing.Size( 706, 365 );
      tableLayoutPanel1.TabIndex = 12;
      // 
      // tableLayoutPanel2
      // 
      this.tableLayoutPanel2.AutoSize = true;
      this.tableLayoutPanel2.BackColor = System.Drawing.Color.White;
      this.tableLayoutPanel2.ColumnCount = 2;
      tableLayoutPanel1.SetColumnSpan( this.tableLayoutPanel2, 2 );
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle( System.Windows.Forms.SizeType.Percent, 100F ) );
      this.tableLayoutPanel2.ColumnStyles.Add( new System.Windows.Forms.ColumnStyle() );
      this.tableLayoutPanel2.Controls.Add( this.LabelProgramVer, 0, 0 );
      this.tableLayoutPanel2.Controls.Add( this.m_pictureBox, 1, 0 );
      this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel2.Location = new System.Drawing.Point( 3, 3 );
      this.tableLayoutPanel2.Name = "tableLayoutPanel2";
      this.tableLayoutPanel2.RowCount = 1;
      this.tableLayoutPanel2.RowStyles.Add( new System.Windows.Forms.RowStyle() );
      this.tableLayoutPanel2.Size = new System.Drawing.Size( 700, 61 );
      this.tableLayoutPanel2.TabIndex = 13;
      // 
      // LabelProgramVer
      // 
      this.LabelProgramVer.BackColor = System.Drawing.Color.Transparent;
      this.LabelProgramVer.Dock = System.Windows.Forms.DockStyle.Fill;
      this.LabelProgramVer.Location = new System.Drawing.Point( 2, 0 );
      this.LabelProgramVer.Margin = new System.Windows.Forms.Padding( 2, 0, 2, 0 );
      this.LabelProgramVer.Name = "LabelProgramVer";
      this.LabelProgramVer.Size = new System.Drawing.Size( 596, 61 );
      this.LabelProgramVer.TabIndex = 1;
      this.LabelProgramVer.Text = "Product";
      this.LabelProgramVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // m_pictureBox
      // 
      this.m_pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_pictureBox.ErrorImage = null;
      this.m_pictureBox.Image = ( (System.Drawing.Image)( resources.GetObject( "m_pictureBox.Image" ) ) );
      this.m_pictureBox.InitialImage = null;
      this.m_pictureBox.Location = new System.Drawing.Point( 600, 0 );
      this.m_pictureBox.Margin = new System.Windows.Forms.Padding( 0 );
      this.m_pictureBox.Name = "m_pictureBox";
      this.m_pictureBox.Size = new System.Drawing.Size( 100, 61 );
      this.m_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.m_pictureBox.TabIndex = 2;
      this.m_pictureBox.TabStop = false;
      // 
      // m_ProductLabel
      // 
      this.m_ProductLabel.AutoSize = true;
      this.m_ProductLabel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_ProductLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.m_ProductLabel.Location = new System.Drawing.Point( 3, 67 );
      this.m_ProductLabel.Name = "m_ProductLabel";
      this.m_ProductLabel.Size = new System.Drawing.Size( 114, 21 );
      this.m_ProductLabel.TabIndex = 11;
      this.m_ProductLabel.Text = "Product is licensed to: ";
      this.m_ProductLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // richTextBox1
      // 
      richTextBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
      richTextBox1.CausesValidation = false;
      tableLayoutPanel1.SetColumnSpan( richTextBox1, 2 );
      richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
      richTextBox1.HideSelection = false;
      richTextBox1.Location = new System.Drawing.Point( 2, 194 );
      richTextBox1.Margin = new System.Windows.Forms.Padding( 2 );
      richTextBox1.Name = "richTextBox1";
      richTextBox1.ReadOnly = true;
      richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      richTextBox1.Size = new System.Drawing.Size( 702, 58 );
      richTextBox1.TabIndex = 4;
      richTextBox1.TabStop = false;
      richTextBox1.Text = "CAS\nPL 90-441 Poland Lodz  al. T. Kosciuszki 103/105\ntel/fax: +48(42)686 25 47; +" +
          "48(42)686 50 28\nhttp://www.cas.eu";
      richTextBox1.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler( this.richTextBox_LinkClicked );
      // 
      // m_label_user
      // 
      this.m_label_user.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_label_user.ImeMode = System.Windows.Forms.ImeMode.NoControl;
      this.m_label_user.Location = new System.Drawing.Point( 123, 67 );
      this.m_label_user.Name = "m_label_user";
      this.m_label_user.Size = new System.Drawing.Size( 580, 21 );
      this.m_label_user.TabIndex = 12;
      this.m_label_user.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // richTextBox2
      // 
      richTextBox2.CausesValidation = false;
      tableLayoutPanel1.SetColumnSpan( richTextBox2, 2 );
      richTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
      richTextBox2.Location = new System.Drawing.Point( 2, 90 );
      richTextBox2.Margin = new System.Windows.Forms.Padding( 2 );
      richTextBox2.Name = "richTextBox2";
      richTextBox2.ReadOnly = true;
      richTextBox2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
      richTextBox2.Size = new System.Drawing.Size( 702, 100 );
      richTextBox2.TabIndex = 9;
      richTextBox2.Tag = "";
      richTextBox2.Text = resources.GetString( "richTextBox2.Text" );
      richTextBox2.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler( this.richTextBox_LinkClicked );
      // 
      // webBrowser
      // 
      tableLayoutPanel1.SetColumnSpan( this.webBrowser, 2 );
      this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
      this.webBrowser.Location = new System.Drawing.Point( 3, 257 );
      this.webBrowser.MinimumSize = new System.Drawing.Size( 700, 100 );
      this.webBrowser.Name = "webBrowser";
      this.webBrowser.Size = new System.Drawing.Size( 700, 105 );
      this.webBrowser.TabIndex = 13;
      this.webBrowser.Url = new System.Uri( "http://www.commsvr.com/rss/commservernews_en.rss", System.UriKind.Absolute );
      this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler( this.webBrowser_DocumentCompleted );
      // 
      // About
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.AutoSize = true;
      this.Controls.Add( tableLayoutPanel1 );
      this.Margin = new System.Windows.Forms.Padding( 2 );
      this.MinimumSize = new System.Drawing.Size( 600, 350 );
      this.Name = "About";
      this.Size = new System.Drawing.Size( 706, 365 );
      tableLayoutPanel1.ResumeLayout( false );
      tableLayoutPanel1.PerformLayout();
      this.tableLayoutPanel2.ResumeLayout( false );
      this.tableLayoutPanel2.PerformLayout();
      ( (System.ComponentModel.ISupportInitialize)( this.m_pictureBox ) ).EndInit();
      this.ResumeLayout( false );
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label LabelProgramVer;
    private System.Windows.Forms.PictureBox m_pictureBox;
    private System.Windows.Forms.Label m_ProductLabel;
    private System.Windows.Forms.Label m_label_user;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    private System.Windows.Forms.WebBrowser webBrowser;
  }
}
