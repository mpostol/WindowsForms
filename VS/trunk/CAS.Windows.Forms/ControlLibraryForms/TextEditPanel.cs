//<summary>
//  Title   : Panel to edit text
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20080425: mzbrzezny : created;
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Panel to edit text
  /// </summary>
  public partial class TextEditPanel: UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="TextEditPanel"/> class.
    /// </summary>
    public TextEditPanel()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Gets or sets the edited text.
    /// </summary>
    /// <value>The edited text.</value>
    public string EditedText
    {
      get
      {
        return textBox.Text;
      }
      set
      {
        textBox.Text = value;
      }
    }
    /// <summary>
    /// Adds the controls to tool strip.
    /// </summary>
    /// <param name="ToolStripItems">The tool strip items.</param>
    public void AddControlsToToolStrip( ToolStripItem[] ToolStripItems )
    {
      toolStrip.Items.AddRange( ToolStripItems );
    }

    private void textBox_KeyDown(object sender, KeyEventArgs e)
    {

    }
  }
}
