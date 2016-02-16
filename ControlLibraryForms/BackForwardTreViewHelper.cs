//<summary>
//  Title   : Helper for Backward/Forwarde tree navigation
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

using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Helper for Backward/Forwarde tree navigation
  /// </summary>
  public class BackForwardTreViewHelper: LabeledTreeViewPair
  {
    #region private
    private Stack<TreeNode> m_Stack_Forward;
    private Stack<TreeNode> m_Stack_Backward;
    private bool ThisSelectOperationIsInternal = false;
    private void ListNodesInStack( StringBuilder ToolTipText, ref Stack<TreeNode> stack, int limit )
    {
      foreach ( var tn in stack )
      {
        if ( tn != null )
          ToolTipText.AppendLine( tn.Text );
        if ( --limit <= 0 )
        {
          ToolTipText.AppendLine( "..." );
          break;
        }
      }
    }
    private void m_TreeView_BeforeSelect( object sender, TreeViewCancelEventArgs e )
    {
      if ( !ThisSelectOperationIsInternal && TreeView.SelectedNode != null )
        m_Stack_Backward.Push( TreeView.SelectedNode );
    }
    private void m_TreeView_AfterSelect( object sender, TreeViewEventArgs e )
    {
      if ( !ThisSelectOperationIsInternal )
        m_Stack_Forward.Clear();
      ThisSelectOperationIsInternal = false;
    }
    #endregion private
    /// <summary>
    /// Initializes a new instance of the <see cref="BackForwardTreViewHelper"/> class.
    /// </summary>
    public BackForwardTreViewHelper()
    {
      this.NumberOfPreviousNodesInTheTooltip = 5;
      m_Stack_Backward = new Stack<TreeNode>();
      m_Stack_Forward = new Stack<TreeNode>();
    }
    /// <summary>
    /// Goes the forward.
    /// </summary>
    public void GoForward()
    {
      if ( TreeView == null )
        return;
      if ( m_Stack_Forward.Count > 0 )
      {
        m_Stack_Backward.Push( TreeView.SelectedNode );
        ThisSelectOperationIsInternal = true;
        TreeNode newTreeNode = m_Stack_Forward.Pop();
        TreeView.SelectedNode = newTreeNode;
      }
    }
    /// <summary>
    /// Goes the backward.
    /// </summary>
    public void GoBackward()
    {
      if ( TreeView == null )
        return;
      if ( m_Stack_Backward.Count > 0 )
      {
        ThisSelectOperationIsInternal = true;
        TreeNode newTreeNode = m_Stack_Backward.Pop();
        m_Stack_Forward.Push( TreeView.SelectedNode );
        TreeView.SelectedNode = newTreeNode;
      }
    }
    /// <summary>
    /// Gets or sets the tree view.
    /// </summary>
    /// <value>The tree view.</value>
    public override TreeView TreeView
    {
      get
      {
        return base.TreeView;
      }
      set
      {
        if ( base.TreeView != null )
        {
          //detach from events
          base.TreeView.AfterSelect -= m_TreeView_AfterSelect;
          base.TreeView.BeforeSelect -= m_TreeView_BeforeSelect;
        }
        base.TreeView = value;
        if ( base.TreeView != null )
        {
          base.TreeView.AfterSelect += m_TreeView_AfterSelect;
          base.TreeView.BeforeSelect += m_TreeView_BeforeSelect;
        }
      }
    }
    /// <summary>
    /// Gets or sets the number of previous nodes in the tooltip.
    /// </summary>
    /// <value>The number of previous nodes in the tooltip.</value>
    public int NumberOfPreviousNodesInTheTooltip { get; set; }
    /// <summary>
    /// Gets the tool tip text for forward direction.
    /// </summary>
    /// <returns></returns>
    public string GetToolTipTextForward()
    {
      StringBuilder ToolTipText = new StringBuilder();
      ToolTipText.AppendFormat( "{0} Count: {1}, nodes:\n\r", "->", m_Stack_Forward.Count );
      ListNodesInStack( ToolTipText, ref m_Stack_Forward, NumberOfPreviousNodesInTheTooltip );
      return ToolTipText.ToString();
    }
    /// <summary>
    /// Gets the tool tip text for backward direction.
    /// </summary>
    /// <returns></returns>
    public string GetToolTipTextBackward()
    {
      StringBuilder ToolTipText = new StringBuilder();
      ToolTipText.AppendFormat( "{0} Count: {1}, nodes:\n\r", "<-", m_Stack_Backward.Count );
      ListNodesInStack( ToolTipText, ref m_Stack_Backward, NumberOfPreviousNodesInTheTooltip );
      return ToolTipText.ToString();
    }
  }
}
