//<summary>
//  Title   : Interface of the tree node
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20080507: mzbrzezny - created
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
  /// Interface of the tree node
  /// </summary>
  public interface ITreeNodeInterface: IDisposable
  {
    /// <summary>
    /// Gets the menu items.
    /// A node should return the items for the context menu that allow to perform any operation on the node.
    /// </summary>
    /// <returns>the menu items</returns>
    ToolStripItem[] GetMenuItems();
    /// <summary>
    /// Gets the tree current context menu.
    /// </summary>
    /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
    ContextMenuStrip Menu { get; }
    /// <summary>
    /// Gets the collection of System.Windows.Forms.TreeNode objects assigned to the current tree node.
    /// </summary>
    /// <value>A <see cref="System.Windows.Forms.TreeNodeCollection"/>that represents the tree 
    /// nodes assigned to the current tree node.</value>
    TreeNodeCollection Nodes { get; }
    /// <summary>
    /// Gets the parent <see cref="TreeView"/> that the tree node is assigned to.
    /// </summary>
    /// <value> 
    /// A <see cref="System.Windows.Forms.TreeView "/> that represents the parent 
    /// tree view that the tree node is assigned to, or null if the node has not been 
    /// assigned to a tree view.
    /// </value>
    TreeView TreeView { get; }
    /// <summary>
    /// Makes selected the current node .
    /// </summary>
    void MakeSelected();
    /// <summary>
    /// Clears this instance and removes all tree nodes from the collection.
    /// </summary>
    void Clear();
  }
}
