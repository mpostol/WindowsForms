//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
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
