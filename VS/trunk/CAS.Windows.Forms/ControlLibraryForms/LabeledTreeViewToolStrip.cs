//<summary>
//  Title   : ToolStrip with Label and tree view
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
// 20090428: mzbrzezny: created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>      

using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// ToolStrip with Label and tree view
  /// </summary>
  public class LabeledTreeViewToolStrip: ToolStrip
  {
    #region private
    /// <summary>
    /// TreeView member
    /// </summary>
    protected LabeledTreeViewPair m_LabeledTreeViewPair;
    private ToolStripLabel m_toolStripLabel_info;
    private void InitializeComponent()
    {
      m_LabeledTreeViewPair = new LabeledTreeViewPair();
      m_LabeledTreeViewPair.Label = "Label:";
      m_toolStripLabel_info = new ToolStripLabel( m_LabeledTreeViewPair.Label );
      this.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
        m_toolStripLabel_info} );
    }
    #endregion private
    /// <summary>
    /// Initializes a new instance of the <see cref="BackForwardTreViewToolStrip"/> class.
    /// </summary>
    public LabeledTreeViewToolStrip()
    {
      InitializeComponent();
    }
    #region properties
    /// <summary>
    /// Gets or sets the text associated with this control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The text associated with this control.
    /// </returns>
    public new string Text
    {
      get
      {
        return m_toolStripLabel_info.Text;
      }
      set
      {
        m_LabeledTreeViewPair.Label = value;
        m_toolStripLabel_info.Text = value;
        base.Text = value;
      }
    }
    /// <summary>
    /// Gets or sets the tree view.
    /// </summary>
    /// <value>The tree view.</value>
    public virtual TreeView TreeView
    {
      get
      {
        return m_LabeledTreeViewPair.TreeView;
      }
      set
      {
        m_LabeledTreeViewPair.TreeView = value;
      }
    }
    #endregion properties
  }
}
