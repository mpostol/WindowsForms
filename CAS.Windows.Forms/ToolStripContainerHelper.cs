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
  /// Helper that provides some additional functionality for ToolStripContainer
  /// </summary>
  public class ToolStripContainerHelper
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ToolStripContainerHelper"/> class.
    /// </summary>
    /// <param name="Container">The Tool Strip Container.</param>
    public ToolStripContainerHelper(ToolStripContainer Container)
    {
      myToolStripContainer = Container;
    }
    /// <summary>
    /// Gets the list of tool strip menu item.
    /// </summary>
    /// <returns>list of ToolStripMenuItems to hide and unhide toolstrips</returns>
    public ToolStripMenuItem[] GetListOfToolStripMenuItem()
    {
      List<ToolStripMenuItem> menuItemList = new List<ToolStripMenuItem>();
      foreach (Control f in myToolStripContainer.ContentPanel.Controls)
      {
        CreateMenuItem(menuItemList, f);
      }
      foreach (Control f in myToolStripContainer.TopToolStripPanel.Controls)
      {
        CreateMenuItem(menuItemList, f);
      }
      foreach (Control f in myToolStripContainer.BottomToolStripPanel.Controls)
      {
        CreateMenuItem(menuItemList, f);
      }
      foreach (Control f in myToolStripContainer.RightToolStripPanel.Controls)
      {
        CreateMenuItem(menuItemList, f);
      }
      foreach (Control f in myToolStripContainer.LeftToolStripPanel.Controls)
      {
        CreateMenuItem(menuItemList, f);
      }
      return menuItemList.ToArray();
    }

    #region private
    private ToolStripContainer myToolStripContainer;
    private void CreateMenuItem(List<ToolStripMenuItem> menuItemList, Control f)
    {
      if (f is ToolStrip)
      {
        ToolStripMenuItem item = new ToolStripMenuItem(f.Text);
        item.Click += new EventHandler(menuItem_Click);
        item.Tag = f;
        item.CheckOnClick = true;
        item.Checked = f.Visible;
        item.Paint += new PaintEventHandler(menuItem_Paint);
        menuItemList.Add(item);
      }
    }
    private void menuItem_Paint(object sender, PaintEventArgs e)
    {
      ToolStripMenuItem item = sender as ToolStripMenuItem;
      ToolStrip toolStrip = item.Tag as ToolStrip;
      if (toolStrip == null || item == null)
        return;
      item.Checked = toolStrip.Visible;
    }
    private void menuItem_Click(object sender, EventArgs e)
    {
      ToolStripItem item = sender as ToolStripItem;
      ToolStrip toolStrip = item.Tag as ToolStrip;
      if (toolStrip == null || item == null)
        return;
      if (toolStrip.Visible)
        toolStrip.Hide();
      else
        toolStrip.Show();
    }
    #endregion private

  }
}
