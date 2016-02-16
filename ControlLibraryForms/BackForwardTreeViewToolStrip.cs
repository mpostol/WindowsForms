//<summary>
//  Title   : ToolStrip with backward / forward navigation
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

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// ToolStrip with backward / forward tree navigation
  /// </summary>
  public class BackForwardTreViewToolStrip: LabeledTreeViewToolStrip
  {
    #region private
    private ToolStripButton m_toolStrip_Forward;
    private ToolStripButton m_toolStrip_Backward;
    private BackForwardTreViewHelper m_BackForwardTreViewHelper;
    private void InitializeComponent()
    {
      m_BackForwardTreViewHelper = new BackForwardTreViewHelper();
      m_LabeledTreeViewPair = m_BackForwardTreViewHelper;
      this.Text = "Navigate: ";
      m_toolStrip_Forward = new ToolStripButton( "->" );
      m_toolStrip_Backward = new ToolStripButton( "<-" );
      this.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
        m_toolStrip_Backward,
        m_toolStrip_Forward} );
      m_toolStrip_Backward.Click += new EventHandler( m_toolStrip_Backward_Click );
      m_toolStrip_Forward.Click += new EventHandler( m_toolStrip_Forward_Click );
      m_toolStrip_Backward.MouseEnter += new EventHandler( m_toolStrip_Button_MouseEnter );
      m_toolStrip_Forward.MouseEnter += new EventHandler( m_toolStrip_Button_MouseEnter );
    }
    private void m_toolStrip_Button_MouseEnter( object sender, EventArgs e )
    {
      m_toolStrip_Forward.ToolTipText = m_BackForwardTreViewHelper.GetToolTipTextForward();
      m_toolStrip_Backward.ToolTipText = m_BackForwardTreViewHelper.GetToolTipTextBackward();
    }
    private void m_toolStrip_Forward_Click( object sender, EventArgs e )
    {
      GoForward();
    }
    private void m_toolStrip_Backward_Click( object sender, EventArgs e )
    {
      GoBackward();
    }
    #endregion private
    /// <summary>
    /// Initializes a new instance of the <see cref="BackForwardTreViewToolStrip"/> class.
    /// </summary>
    public BackForwardTreViewToolStrip()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Goes the forward.
    /// </summary>
    public void GoForward()
    {
      m_BackForwardTreViewHelper.GoForward();
    }
    /// <summary>
    /// Goes the backward.
    /// </summary>
    public void GoBackward()
    {
      m_BackForwardTreViewHelper.GoBackward();
    }
    #region properties
    /// <summary>
    /// Gets or sets the tool strip forward image.
    /// </summary>
    /// <value>The tool strip forward image.</value>
    public Image ToolStripForwardImage
    {
      get
      {
        return m_toolStrip_Forward.Image;
      }
      set
      {
        if ( value == null )
          m_toolStrip_Forward.DisplayStyle = ToolStripItemDisplayStyle.Text;
        else
          m_toolStrip_Forward.DisplayStyle = ToolStripItemDisplayStyle.Image;
        m_toolStrip_Forward.Image = value;
      }
    }
    /// <summary>
    /// Gets or sets the tool strip Backward image.
    /// </summary>
    /// <value>The tool strip Backward image.</value>
    public Image ToolStripBackwardImage
    {
      get
      {
        return m_toolStrip_Backward.Image;
      }
      set
      {
        if ( value == null )
          m_toolStrip_Backward.DisplayStyle = ToolStripItemDisplayStyle.Text;
        else
          m_toolStrip_Backward.DisplayStyle = ToolStripItemDisplayStyle.Image;
        m_toolStrip_Backward.Image = value;
      }
    }
    /// <summary>
    /// Gets or sets the number of previous nodes in the tooltip.
    /// </summary>
    /// <value>The number of previous nodes in the tooltip.</value>
    public int NumberOfPreviousNodesInTheTooltip
    {
      get
      {
        return m_BackForwardTreViewHelper.NumberOfPreviousNodesInTheTooltip;
      }
      set
      {
        m_BackForwardTreViewHelper.NumberOfPreviousNodesInTheTooltip = value;
      }
    }
    #endregion properties
  }
}
