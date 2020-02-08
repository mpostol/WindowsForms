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
  /// Pair of label and tree view
  /// </summary>
  public class LabeledTreeViewPair
  {

    /// <summary>
    /// Gets or sets the tree view.
    /// </summary>
    /// <value>The tree view.</value>
    public virtual TreeView TreeView { get; set; }
    /// <summary>
    /// Gets or sets the label.
    /// </summary>
    /// <value>The label.</value>
    public string Label { get; set; }

  }
}
