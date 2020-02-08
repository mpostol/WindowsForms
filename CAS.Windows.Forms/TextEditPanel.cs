//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// Panel to edit text
  /// </summary>
  public partial class TextEditPanel : UserControl
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
      get => textBox.Text;
      set => textBox.Text = value;
    }
    /// <summary>
    /// Adds the controls to tool strip.
    /// </summary>
    /// <param name="ToolStripItems">The tool strip items.</param>
    public void AddControlsToToolStrip(ToolStripItem[] ToolStripItems)
    {
      toolStrip.Items.AddRange(ToolStripItems);
    }
    private void textBox_KeyDown(object sender, KeyEventArgs e) { }

  }
}
