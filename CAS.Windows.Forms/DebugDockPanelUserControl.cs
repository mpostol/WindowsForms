//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.IO;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// debug panel with label and close button that can be used for docking
  /// </summary>
  public class DebugDockPanelUserControl: DockPanelUserControl
  {
    class MyOutputStream: TextWriter
    {
      const int LinesBuffeSize = 500;
      const double FreeBuffer = 0.1;
      private DebugDockPanelUserControl myParent;
      internal MyOutputStream( DebugDockPanelUserControl parent )
        : base()
      {
        myParent = parent;
      }
      public override void Write( char value )
      {
        if ( !myParent.Visible )
          myParent.Show();
        if ( myParent.OutputTextBox.Lines.Length > LinesBuffeSize ) //protection from too many lines in output
        {
          int index = System.Convert.ToInt32( FreeBuffer * myParent.OutputTextBox.Text.Length );
          if ( index < myParent.OutputTextBox.Text.Length )
            myParent.OutputTextBox.Text = myParent.OutputTextBox.Text.Substring( index );
          else
            myParent.OutputTextBox.Text = "";
        }
        myParent.OutputTextBox.AppendText( System.Convert.ToString( value ) );
      }
      public override System.Text.Encoding Encoding
      {
        get { return System.Text.Encoding.Default; }
      }
    }
    internal TextBox OutputTextBox { get; private set; }
    private MyOutputStream myStream;
    private ToolStripMenuItem clearOutputToolStripMenuItem;
    private TextBoxBaseWithTraceListener m_TraceListener;
    /// <summary>
    /// Initializes a new instance of the <see cref="DebugDockPanelUserControl"/> class.
    /// </summary>
    public DebugDockPanelUserControl()
    {
      this.InitializeComponent();
      OutputTextBox = new TextBox();
      OutputTextBox.Multiline = true;
      OutputTextBox.ReadOnly = true;
      OutputTextBox.ScrollBars = ScrollBars.Both;
      this.MainControl = OutputTextBox;
      this.Label = "Debug Panel";
      myStream = new MyOutputStream( this );
      m_TraceListener = new TextBoxBaseWithTraceListener();
      m_TraceListener.OutputTextBox = OutputTextBox;
    }
    /// <summary>
    /// gets or sets The text associated with this control.
    /// </summary>
    /// <value>text inside the output</value>
    /// <returns>
    /// The text associated with this control.
    /// </returns>
    public new string Text
    {
      get
      {
        return OutputTextBox.Text;
      }
      set
      {
        OutputTextBox.Text = value;
      }
    }
    /// <summary>
    /// Gets the text writer stream.
    /// </summary>
    /// <value>The text writer stream.</value>
    public TextWriter TextWriterStream
    {
      get
      {
        return myStream;
      }
    }
    /// <summary>
    /// Gets or sets the name of the trace listener coupled with this output window.
    /// </summary>
    /// <value>The name of the trace listener.</value>
    public string TraceListenerName
    {
      get
      {
        return m_TraceListener.Name;
      }
      set
      {
        m_TraceListener.Name = value;
      }
    }
    /// <summary>
    /// Initializes the component.
    /// </summary>
    private void InitializeComponent()
    {
      this.clearOutputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.SuspendLayout();
      // 
      // clearOutputToolStripMenuItem1
      // 
      this.clearOutputToolStripMenuItem.Name = "clearOutputToolStripMenuItem1";
      this.clearOutputToolStripMenuItem.Size = new System.Drawing.Size( 152, 22 );
      this.clearOutputToolStripMenuItem.Text = "Clear Output";
      this.clearOutputToolStripMenuItem.Click += new System.EventHandler( this.clearOutputToolStripMenuItem1_Click );
      // 
      // DebugDockPanelUserControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.Name = "DebugDockPanelUserControl";
      //
      // contextMenuStrip_label
      //
      this.contextMenuStrip_label.Items.Add( this.clearOutputToolStripMenuItem );
      this.ResumeLayout( false );
    }
    private void clearOutputToolStripMenuItem1_Click( object sender, System.EventArgs e )
    {
      OutputTextBox.Clear();
    }
  }
}
