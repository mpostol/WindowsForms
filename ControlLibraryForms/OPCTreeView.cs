//<summary>
//  Title   : OPC products dedicated <see cref="TreeView"/> 
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>
using System;
using System.Windows.Forms;
namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// OPC products dedicated <see cref="TreeView"/> 
  /// </summary>
  public partial class OPCTreeView: TreeView
  {
    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="OPCTreeView"/> class.
    /// </summary>
    public OPCTreeView()
    {
      InitializeComponent();
      this.ImageList = m_IimageListLibrary.ProjectImageList;
    }
    #endregion
    #region public
    /// <summary>
    /// Clears this instance.
    /// </summary>
    public void Clear()
    {
      foreach ( IDisposable node in this.Nodes )
        node.Dispose();
      this.Nodes.Clear();
      System.Diagnostics.Debug.Assert( this.Nodes.Count == 0 );
    }
    #endregion
  }
}
