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
  /// This class is responsible for searching the tree
  /// </summary>
  public class TreeViewSearcher
  {

    #region private
    private delegate TreeNode GetNodeDelegate(TreeNode CurrentTreeNode,
      bool JumpWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached);
    private static TreeNode GetLastNodeOfTheTreeViewStartingFromNode(TreeNode treeNode)
    {
      if (treeNode == null)
        throw new ArgumentNullException("treeNode cannot be null");
      TreeNode toBeReturned = treeNode;
      while (toBeReturned.Nodes.Count > 0)
      {
        toBeReturned = toBeReturned.Nodes[toBeReturned.Nodes.Count - 1];
      }
      return toBeReturned;
    }
    #endregion private

    #region public
    /// <summary>
    /// Gets the last node of the tree view.
    /// </summary>
    /// <param name="treeView">The tree view.</param>
    /// <returns>last node of the tree view</returns>
    public static TreeNode GetLastNodeOfTheTreeView(TreeView treeView)
    {
      if (treeView == null)
        return null;
      if (treeView.Nodes.Count == 0)
        return null;
      TreeNode toBeReturned = treeView.Nodes[treeView.Nodes.Count - 1];
      toBeReturned = GetLastNodeOfTheTreeViewStartingFromNode(toBeReturned);
      return toBeReturned;
    }
    /// <summary>
    /// Gets the next node.
    /// </summary>
    /// <param name="CurrentTreeNode">The current tree node.</param>
    /// <param name="JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached">
    /// if set to <c>true</c> jump to the beginning when end of tree is 
    /// reached or return null if it is false and end of tree is reached.</param>
    /// <returns>the next node.</returns>
    public static TreeNode GetNextNode(TreeNode CurrentTreeNode,
      bool JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached)
    {
      if (CurrentTreeNode == null)
        throw new ArgumentNullException("CurrentTreeNode cannot be null");
      if (CurrentTreeNode.Nodes.Count > 0)
        return CurrentTreeNode.Nodes[0];
      if (CurrentTreeNode.NextNode != null)
        return CurrentTreeNode.NextNode;
      TreeNode newCurrentTreeNode = CurrentTreeNode;
      while (true)
      {
        if (newCurrentTreeNode.Parent == null)
        {
          if (newCurrentTreeNode.TreeView == null)
            throw new ArgumentException("This CurrentTreeNode is not a member of a TreeView");
          if (JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached)
            return CurrentTreeNode.TreeView.Nodes[0];
          else
            return null;
        }
        if (newCurrentTreeNode.Parent.NextNode != null)
          return newCurrentTreeNode.Parent.NextNode;
        newCurrentTreeNode = newCurrentTreeNode.Parent;
      }
    }
    /// <summary>
    /// Gets the previous node.
    /// </summary>
    /// <param name="CurrentTreeNode">The current tree node.</param>
    /// <param name="JumpToTheEndWhenBeginningOfTreeIsReachedOrReturnNullIfItIsFalseAndBeginningOfTreeIsReached">
    /// if set to <c>true</c> jump to the end when beginning of tree is reached or return null if it is false 
    /// and beginning of tree is reached.</param>
    /// <returns>the previous node.</returns>
    public static TreeNode GetPreviousNode(TreeNode CurrentTreeNode,
      bool JumpToTheEndWhenBeginningOfTreeIsReachedOrReturnNullIfItIsFalseAndBeginningOfTreeIsReached)
    {
      if (CurrentTreeNode == null)
        throw new ArgumentNullException("CurrentTreeNode cannot be null");
      if (CurrentTreeNode.PrevNode != null)
      {
        return GetLastNodeOfTheTreeViewStartingFromNode(CurrentTreeNode.PrevNode);
      }
      if (CurrentTreeNode.Parent != null)
      {
        int previusnodeindex = CurrentTreeNode.Parent.Nodes.IndexOf(CurrentTreeNode) - 1;
        if (previusnodeindex < 0)
          return CurrentTreeNode.Parent;
        else
          return GetLastNodeOfTheTreeViewStartingFromNode(CurrentTreeNode.Parent.Nodes[previusnodeindex]);
      }
      else
      {
        if (CurrentTreeNode.TreeView == null)
          throw new ArgumentException("This CurrentTreeNode is not a member of a TreeView");
        if (JumpToTheEndWhenBeginningOfTreeIsReachedOrReturnNullIfItIsFalseAndBeginningOfTreeIsReached)
          return GetLastNodeOfTheTreeView(CurrentTreeNode.TreeView);
        else
          return null;
      }
    }
    /// <summary>
    /// Searches the and return next node that contains text.
    /// </summary>
    /// <param name="StartTreeNode">The start tree node.</param>
    /// <param name="TextToBeSearched">The text to be searched.</param>
    /// <param name="Forward">if set to <c>true</c> [forward].</param>
    /// <param name="JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached">if set to <c>true</c> [jump to the beginning when end of tree is reached or return null if it is false and end of tree is reached].</param>
    /// <param name="stringComparison">The string comparison.</param>
    /// <returns>tree node if searching succeeded</returns>
    public static TreeNode SearchAndReturnNextNodeThatContainsText
      (TreeNode StartTreeNode, string TextToBeSearched, bool Forward,
      bool JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached,
      StringComparison stringComparison)
    {
      if (StartTreeNode == null)
        throw new ArgumentNullException("StartTreeNode cannot be null");
      GetNodeDelegate GetNode;
      if (Forward)
        GetNode = new GetNodeDelegate(GetNextNode);
      else
        GetNode = new GetNodeDelegate(GetPreviousNode);
      TreeNode nextnode = GetNode(StartTreeNode, JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached);
      bool nodeIsFound = false;
      while (nextnode != null && nextnode != StartTreeNode)
      {
        if (nextnode.Text.IndexOf(TextToBeSearched, stringComparison) >= 0)
        {
          nodeIsFound = true;
          break;
        }
        nextnode = GetNode(nextnode, JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached);
      }
      if (nodeIsFound)
        return nextnode;
      else
        return null;
    }
    /// <summary>
    /// Searches the and select next node that contains text.
    /// </summary>
    /// <param name="treeView">The tree view.</param>
    /// <param name="TextToBeSearched">The text to be searched.</param>
    /// <param name="Forward">if set to <c>true</c> [forward].</param>
    /// <param name="JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached">if set to <c>true</c> [jump to the beginning when end of tree is reached or return null if it is false and end of tree is reached].</param>
    /// <param name="stringComparison">The string comparison.</param>
    /// <returns></returns>
    public static bool SearchAndSelectNextNodeThatContainsText(TreeView treeView, string TextToBeSearched, bool Forward, bool JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached, StringComparison stringComparison)
    {
      if (treeView == null || TextToBeSearched == null)
        throw new ArgumentNullException();
      TreeNode startingNode = treeView.SelectedNode;
      if (startingNode == null)
        startingNode = treeView.Nodes[0];
      if (startingNode == null)
        return false;
      TreeNode foundnode = SearchAndReturnNextNodeThatContainsText(startingNode, TextToBeSearched, Forward,
        JumpToTheBeginningWhenEndOfTreeIsReachedOrReturnNullIfItIsFalseAndEndOfTreeIsReached, stringComparison);
      if (foundnode != null)
        treeView.SelectedNode = foundnode;
      return foundnode != null;
    }
    #endregion
  }
}
