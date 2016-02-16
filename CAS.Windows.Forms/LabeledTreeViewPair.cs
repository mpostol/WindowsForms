//<summary>
//  Title   : Pair of label and tree view
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
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
