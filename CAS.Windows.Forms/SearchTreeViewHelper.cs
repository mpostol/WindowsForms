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
  /// Helper for tree searcher
  /// </summary>
  public class SearchTreeViewHelper: LabeledTreeViewPair
  {

    #region types definition
    /// <summary>
    /// Additional Delegate for node test
    /// </summary>
    public delegate bool AdditionalNodeTestDelegate( TreeNode FoundNode );
    /// <summary>
    /// Delegate to get the text to be searched
    /// </summary>
    public delegate string GetToolStripTextToFindDelegate();
    #endregion types definition


    #region public
    /// <summary>
    /// Gets or sets the information about start is passed.
    /// </summary>
    /// <value>The information start is passed.</value>
    public string InformationStartIsPassed { get; set; }
    /// <summary>
    /// Gets or sets the information about end is passed.
    /// </summary>
    /// <value>The information end is passed.</value>
    public string InformationEndIsPassed { get; set; }
    /// <summary>
    /// Gets or sets the information about element cannot be found.
    /// </summary>
    /// <value>The information cannot be found.</value>
    public string InformationCannotBeFound { get; set; }
    /// <summary>
    /// Sets the additional node test delegate.
    /// </summary>
    /// <value>The additional node test delegate.</value>
    public AdditionalNodeTestDelegate SetAdditionalNodeTestDelegate
    {
      set
      {
        m_AdditionalNodeTestDelegate = value;
      }
    }
    /// <summary>
    /// Gets or sets a value indicating whether case is ignored.
    /// </summary>
    /// <value><c>true</c> if case is ignered; otherwise, <c>false</c>.</value>
    public bool IgnoreCase { get; set; }
    /// <summary>
    /// Searches the tree.
    /// </summary>
    /// <param name="backward">if set to <c>true</c> backward search is performed.</param>
    public void Search(bool backward)
    {
      if (TreeView == null)
        return;
      //preparation for searching:
      TreeView.Focus();
      string tobesearched = m_GetToolStripTextToFindDelegate();
      StringComparison stringcmp = StringComparison.InvariantCulture;
      if (this.IgnoreCase)
        stringcmp = StringComparison.InvariantCultureIgnoreCase;
      string message_end_is_passed = "";
      if (backward) //selection of message depend on searching forward/backward
      {
        message_end_is_passed = InformationStartIsPassed;
      }
      else
      {
        message_end_is_passed = InformationEndIsPassed;
      }
      //selecting starting node:
      TreeNode StartNode = TreeView.SelectedNode;
      if (StartNode == null)
        StartNode = TreeView.Nodes[0];
      if (TreeView == null)
        return;
      //searching
      int QualtityOfEndIsPassed = 0; // here is information that search at leas once has passed end of tree
      TreeNode foundNode_prev = null;
      TreeNode foundNode = TreeViewSearcher.SearchAndReturnNextNodeThatContainsText(StartNode,
        tobesearched, !backward, false, stringcmp);//first search
      if (foundNode == null)
      {
        MessageBox.Show(message_end_is_passed); //if end is passed, dispaly message
        foundNode = TreeViewSearcher.SearchAndReturnNextNodeThatContainsText(StartNode,
        tobesearched, !backward, true, stringcmp);
        QualtityOfEndIsPassed++;
      }
      //we are sarching while any can be found but this node is node NodeClass 
      while (foundNode != null && !PerformAdditionalNodeTest(foundNode) && QualtityOfEndIsPassed < 2)
      {
        foundNode_prev = foundNode;
        foundNode = TreeViewSearcher.SearchAndReturnNextNodeThatContainsText(foundNode,
     tobesearched, !backward, false, stringcmp);
        if (foundNode == null)
        {
          if (QualtityOfEndIsPassed == 0)
          {
            MessageBox.Show(message_end_is_passed);
            QualtityOfEndIsPassed++;
          }
          else
            break;
          foundNode = TreeViewSearcher.SearchAndReturnNextNodeThatContainsText(foundNode_prev,
          tobesearched, !backward, true, stringcmp);
          QualtityOfEndIsPassed++;
        }
      }
      if (foundNode == null /* we have not found enything */
        || !PerformAdditionalNodeTest(foundNode) /* TreeNode does not represent node class */)
      {
        // message is not displayed if current node contains searched text 
        if (TreeView.SelectedNode.Text.IndexOf(tobesearched, stringcmp) < 0)
          MessageBox.Show(InformationCannotBeFound);
      }
      else
        TreeView.SelectedNode = foundNode;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="SearchTreeViewHelper"/> class.
    /// </summary>
    /// <param name="GetToolStripTextToFindDelegate">The get tool strip text to find delegate.</param>
    public SearchTreeViewHelper(GetToolStripTextToFindDelegate GetToolStripTextToFindDelegate)
    {
      m_AdditionalNodeTestDelegate = new AdditionalNodeTestDelegate(DefaultAdditionalNodeTestDelegate);
      InformationStartIsPassed = "Start of the tree is passed";
      InformationEndIsPassed = "End of the tree is passed";
      InformationCannotBeFound = "Searched element cannot be found";
      m_GetToolStripTextToFindDelegate = GetToolStripTextToFindDelegate;
    }
    #endregion

    #region private
    private AdditionalNodeTestDelegate m_AdditionalNodeTestDelegate;
    private GetToolStripTextToFindDelegate m_GetToolStripTextToFindDelegate;
    private bool DefaultAdditionalNodeTestDelegate(TreeNode FoundNode)
    {
      return true;
    }
    /// <summary>
    /// An additional node test. It test if this node is valid and return true if OK.
    /// </summary>
    /// <param name="foundNode">The found node.</param>
    /// <returns>true if OK</returns>
    private bool PerformAdditionalNodeTest(TreeNode foundNode)
    {
      if (m_AdditionalNodeTestDelegate == null)
        return true; // none additional test is required
      else
        return m_AdditionalNodeTestDelegate(foundNode);
    }
    #endregion private

  }
}
