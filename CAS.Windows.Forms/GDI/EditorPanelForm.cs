//<summary>
//  Title   : Form that contains Editor Panel
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    <date> - <author>: <description>
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary.GDI
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
