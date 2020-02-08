//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{

  /// <summary>
  /// Generic and disposable <see cref="TreeNode"/>
  /// </summary>
  [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2237:MarkISerializableTypesWithSerializable")]
  public abstract class GenericTreeNode<ObjectType, ParentType>: TreeNode, ITreeNodeInterface
    where ObjectType: class
    where ParentType: class, ITreeNodeInterface
  {

    #region private
    private List<List<ToolStripMenuItem>> m_ListOfListOfToolStripMenuItem = new List<List<ToolStripMenuItem>>();
    /// <summary>
    /// Adds the tool strip menu items to array.
    /// </summary>
    /// <param name="ArrayOfToolStripMenuItem">The array of tool strip menu items.</param>
    protected void AddToolStripMenuItemArray( ToolStripMenuItem[] ArrayOfToolStripMenuItem )
    {
      List<ToolStripMenuItem> MyList = new List<ToolStripMenuItem>( ArrayOfToolStripMenuItem.Length );
      MyList.AddRange( ArrayOfToolStripMenuItem );
      m_ListOfListOfToolStripMenuItem.Add( MyList );
    }
    /// <summary>
    /// Assigns the index of the image.
    /// </summary>
    protected abstract void AssignImageIndex();
    #endregion
    #region Constructors
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    /// <param name="node">The node to add new object.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public GenericTreeNode( string text, ObjectType obj, ParentType node )
      : this( text, obj )
    {
      node.Nodes.Add( this );
      m_ListOfListOfToolStripMenuItem = new List<List<ToolStripMenuItem>>();
    }
    /// <summary>
    /// Initializes a new instance of the class.
    /// </summary>
    /// <param name="text">The label <see cref="System.Windows.Forms.TreeNode.Text"/> of the new tree node.</param>
    /// <param name="obj">The object coupled with the node.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public GenericTreeNode( string text, ObjectType obj )
      : base( text )
    {
      Tag = obj;
      if ( obj != null )
        AssignImageIndex();
    }
    #endregion
    #region ITreeNodeInterface Members
    /// <summary>
    /// Gets the menu items.
    /// A node should return the items for the context menu that allow to perform any operation on the node.
    /// </summary>
    /// <returns>the menu items</returns>
    public ToolStripItem[] GetMenuItems()
    {
      int count = 0;
      foreach ( List<ToolStripMenuItem> list in m_ListOfListOfToolStripMenuItem )
        count = list.Count + 1;
      ToolStripItem[] tobereturned = new ToolStripItem[ count ];
      int idx = 0;
      foreach ( List<ToolStripMenuItem> list in m_ListOfListOfToolStripMenuItem )
      {
        foreach ( ToolStripMenuItem item in list )
          tobereturned[ idx++ ] = item;
        tobereturned[ idx++ ] = new ToolStripSeparator();
      }
      return tobereturned;
    }
    /// <summary>
    /// Gets the tree current context menu.
    /// </summary>
    /// <value>The menu <see cref="ContextMenuStrip"/>.</value>
    /// <remarks>Implements <see cref="ITreeNodeInterface"/></remarks>
    public abstract ContextMenuStrip Menu { get; }
    /// <summary>
    /// Makes selected the current node .
    /// </summary>
    public virtual void MakeSelected()
    {
      TreeView.SelectedNode = this;
    }
    /// <summary>
    /// Disposes and removes all tree nodes from the collection.
    /// </summary>
    public void Clear() { DisposeChildren(); }
    #endregion
    #region IDisposable Members
    private bool disposed = false;
    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    /// <remarks>Do not make this method virtual. A derived class should not be able to override this method.</remarks>
    public void Dispose()
    {
      Dispose( true );
      // This object will be cleaned up by the Dispose method.
      // Therefore, you should call GC.SupressFinalize to
      // take this object off the finalization queue
      // and prevent finalization code for this object
      // from executing a second time.
      GC.SuppressFinalize( this );
    }
    // Dispose(bool disposing) executes in two distinct scenarios.
    // If disposing equals true, the method has been called directly
    // or indirectly by a user's code. Managed and unmanaged resources
    // can be disposed.
    // If disposing equals false, the method has been called by the
    // runtime from inside the finalizer and you should not reference
    // other objects. Only unmanaged resources can be disposed.
    /// <summary>
    /// Recursively searches the tree and free objects.
    /// </summary>
    protected virtual void Dispose( bool disposing )
    {
      System.Diagnostics.Debug.Assert( !disposed );
      // Check to see if Dispose has already been called.
      if ( this.disposed )
        return;
      // If disposing equals true, dispose all managed and unmanaged resources.
      if ( disposing )
        DisposeChildren();
      // Call the appropriate methods to clean up unmanaged resources here.
      // If disposing is false, only the following code is executed.
      disposed = true;
    }
    /// <summary>
    /// Disposes the children.
    /// </summary>
    protected void DisposeChildren()
    {
      foreach ( IDisposable node in this.Nodes )
      {
        node.Dispose();
      }
      Nodes.Clear();
    }
    /// <summary>
    /// Releases unmanaged resources and performs other cleanup operations before the
    /// <see cref="GenericTreeNode&lt;ObjectType, ParentType&gt;"/> is reclaimed by garbage collection.
    /// </summary>
    ~GenericTreeNode()
    {
      // Do not re-create Dispose clean-up code here.
      // Calling Dispose(false) is optimal in terms of
      // readability and maintainability.
      Dispose( false );
    }
    #endregion
    #region public
    /// <summary>
    /// Gets the parent tree node of the current tree node.
    /// </summary>
    /// <value>Parent <see cref="TreeNode"/></value>
    /// <returns>A <see cref="T:System.Windows.Forms.TreeNode"/> that represents the parent of the current tree node.</returns>
    public new ParentType Parent { get { return base.Parent as ParentType; } }
    /// <summary>
    /// Gets or sets the object that contains data about the tree node.
    /// </summary>
    /// <value></value>
    /// <returns>An uset OPCType object that contains data about the tree node. The default is null.</returns>
    public virtual new ObjectType Tag
    {
      get { return base.Tag as ObjectType; }
      set { base.Tag = value; }
    }
    #endregion

  }
}
