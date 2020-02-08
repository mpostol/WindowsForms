//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Windows.Forms;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// Form that contains Editor Panel
  /// </summary>
  public partial class EditorPanelForm: Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="EditorPanelForm"/> class.
    /// </summary>
    public EditorPanelForm()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Gets the editor panel.
    /// </summary>
    /// <value>The editor panel.</value>
    public EditorPanel EditorPanel
    {
      get
      {
        return MyEditorPanel;
      }
    }
  }
}
