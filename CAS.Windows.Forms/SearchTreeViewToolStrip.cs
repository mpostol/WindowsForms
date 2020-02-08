//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Drawing;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// ToolStrip with searcher of the TreeView
  /// </summary>
  public class SearchTreeViewToolStrip : LabeledTreeViewToolStrip
  {

    #region private
    private SearchTreeViewHelper m_SearchTreeViewHelper;
    private ToolStripComboBox m_toolStripSearchComboBox_ToBeSearched;
    private ToolStripButton m_toolStrip_Forward;
    private ToolStripButton m_toolStrip_Backward;
    private ToolStripLabel m_toolStripLabel_ingorecase;
    private ToolStripButton m_toolStripButton_ignorecase;
    private void InitializeComponent()
    {
      this.m_SearchTreeViewHelper = new SearchTreeViewHelper(
        new SearchTreeViewHelper.GetToolStripTextToFindDelegate(getToolStripTextToFind));
      this.m_LabeledTreeViewPair = this.m_SearchTreeViewHelper;
      this.Text = "Search:";
      m_toolStripSearchComboBox_ToBeSearched = new ToolStripComboBox();
      m_toolStrip_Forward = new ToolStripButton("->");
      m_toolStrip_Backward = new ToolStripButton("<-");
      m_toolStripLabel_ingorecase = new ToolStripLabel
      {
        Text = "Ignore case:"
      };
      this.m_toolStripButton_ignorecase = new System.Windows.Forms.ToolStripButton
      {
        Checked = true,
        CheckOnClick = true,
        CheckState = System.Windows.Forms.CheckState.Checked,
        DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text,
        ImageTransparentColor = System.Drawing.Color.Magenta,
        Name = "m_toolStripButton_ignorecase",
        Size = new System.Drawing.Size(68, 22),
        Text = "a/A"
      };
      this.m_toolStripButton_ignorecase.CheckedChanged += new EventHandler(m_toolStripButton_ignorecase_CheckedChanged);
      UpdateIgnoreCase();

      this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        m_toolStripSearchComboBox_ToBeSearched,
        m_toolStrip_Backward,
        m_toolStrip_Forward,
        m_toolStripLabel_ingorecase,
        m_toolStripButton_ignorecase});
      this.m_toolStripSearchComboBox_ToBeSearched.Name = "m_toolStripSearchComboBox_ToBeSearched";
      this.m_toolStripSearchComboBox_ToBeSearched.Size = new System.Drawing.Size(121, 25);
      this.m_toolStripSearchComboBox_ToBeSearched.KeyPress += new KeyPressEventHandler(m_toolStripSearchComboBox_ToBeSearched_KeyPress);
      m_toolStrip_Backward.Click += new EventHandler(m_toolStrip_Backward_Click);
      m_toolStrip_Forward.Click += new EventHandler(m_toolStrip_Forward_Click);

    }
    private void m_toolStripButton_ignorecase_CheckedChanged(object sender, EventArgs e)
    {
      UpdateIgnoreCase();
    }
    private void UpdateIgnoreCase()
    {
      m_SearchTreeViewHelper.IgnoreCase = this.m_toolStripButton_ignorecase.Checked;
      if (this.m_toolStripButton_ignorecase.Checked)
        m_toolStripLabel_ingorecase.Text = "Ignore case:";
      else
        m_toolStripLabel_ingorecase.Text = "Case sensitive:";
    }
    private string getToolStripTextToFind()
    {
      string ret = "";
      if (!string.IsNullOrEmpty(m_toolStripSearchComboBox_ToBeSearched.Text))
      {
        ret = m_toolStripSearchComboBox_ToBeSearched.Text.Trim();
      }
      if (!string.IsNullOrEmpty(ret))
      {
        if (m_toolStripSearchComboBox_ToBeSearched.Items.Count == 0 ||
          m_toolStripSearchComboBox_ToBeSearched.Items[0] == null ||
          (m_toolStripSearchComboBox_ToBeSearched.Items[0] != null &&
          m_toolStripSearchComboBox_ToBeSearched.Items[0].ToString() != ret))
        {
          m_toolStripSearchComboBox_ToBeSearched.Items.Insert(0, ret);
        }
      }
      return ret;
    }
    private void m_toolStripSearchComboBox_ToBeSearched_KeyPress(object sender, KeyPressEventArgs e)
    {
      if (e.KeyChar == (char)Keys.Return)
        m_SearchTreeViewHelper.Search(false);
    }
    private void m_toolStrip_Forward_Click(object sender, EventArgs e)
    {
      m_SearchTreeViewHelper.Search(false);
    }
    private void m_toolStrip_Backward_Click(object sender, EventArgs e)
    {
      m_SearchTreeViewHelper.Search(true);
    }
    #endregion private

    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="BackForwardTreViewToolStrip"/> class.
    /// </summary>
    public SearchTreeViewToolStrip()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Sets the additional node test delegate.
    /// </summary>
    /// <value>The additional node test delegate.</value>
    public SearchTreeViewHelper.AdditionalNodeTestDelegate SetAdditionalNodeTestDelegate
    {
      set => m_SearchTreeViewHelper.SetAdditionalNodeTestDelegate = value;
    }
    /// <summary>
    /// Gets or sets the tool strip forward image.
    /// </summary>
    /// <value>The tool strip forward image.</value>
    public Image ToolStripForwardImage
    {
      get => m_toolStrip_Forward.Image;
      set
      {
        if (value == null)
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
      get => m_toolStrip_Backward.Image;
      set
      {
        if (value == null)
          m_toolStrip_Backward.DisplayStyle = ToolStripItemDisplayStyle.Text;
        else
          m_toolStrip_Backward.DisplayStyle = ToolStripItemDisplayStyle.Image;
        m_toolStrip_Backward.Image = value;
      }
    }
    /// <summary>
    /// Gets or sets the information about start is passed.
    /// </summary>
    /// <value>The information start is passed.</value>
    public string InformationStartIsPassed
    {
      get => m_SearchTreeViewHelper.InformationStartIsPassed;
      set => m_SearchTreeViewHelper.InformationStartIsPassed = value;
    }
    /// <summary>
    /// Gets or sets the information about end is passed.
    /// </summary>
    /// <value>The information end is passed.</value>
    public string InformationEndIsPassed
    {
      get => m_SearchTreeViewHelper.InformationEndIsPassed;
      set => m_SearchTreeViewHelper.InformationEndIsPassed = value;
    }
    /// <summary>
    /// Gets or sets the information about element cannot be found.
    /// </summary>
    /// <value>The information cannot be found.</value>
    public string InformationCannotBeFound
    {
      get => m_SearchTreeViewHelper.InformationCannotBeFound;
      set => m_SearchTreeViewHelper.InformationCannotBeFound = value;
    }
    #endregion properties

  }
}
