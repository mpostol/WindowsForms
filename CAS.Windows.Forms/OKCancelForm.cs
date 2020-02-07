//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________


using System;
using System.Drawing;
using System.Windows.Forms;
using UAOOI.Windows.GUIAbstractions;

namespace CAS.Lib.ControlLibrary
{
  public partial class OKCancelForm : Form, ICanBeAccepted
  {
    #region public
    /// <summary>
    /// Default creator of the object
    /// </summary>
    internal OKCancelForm()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Adds the button.
    /// </summary>
    /// <param name="name">The name of the button.</param>
    /// <param name="dialogResult">The dialog result.</param>
    public void AddButton(string name, DialogResult dialogResult)
    {
      ToolStripButton tsb = new ToolStripButton(name)
      {
        AutoSize = false,
        Width = 100,
        Height = 22,
        Enabled = true,
        Tag = dialogResult
      };
      tsb.Click += new EventHandler(tsb_Click);
      cm_ToolStrip.Items.Add(tsb);
    }

    /// <summary>
    /// constructor with new title
    /// </summary>
    /// <param name="formname">new title for the form</param>
    public OKCancelForm(string formname)
    {
      InitializeComponent();
      Text = formname;
    }
    /// <summary>
    /// Sets the reference of the object to be modified.
    /// </summary>
    public UserControl SetUserControl
    {
      set
      {
        cm_toolStripContainer.SuspendLayout();
        SuspendLayout();
        Size = value.Size;
        cm_toolStripContainer.ContentPanel.Controls.Clear();
        cm_toolStripContainer.ContentPanel.Controls.Add(value);
        value.Dock = DockStyle.Fill;
        value.Location = new Point(0, 0);
        cm_toolStripContainer.ResumeLayout(false);
        ResumeLayout(false);
      }
    }
    #endregion

    #region ICanBeAccepted
    /// <summary>
    /// Can Be Accepted
    /// </summary>
    /// <param name="pOKState"></param>
    public void CanBeAccepted(bool pOKState)
    {
      cm_TSButtonAccept.Enabled = pOKState;
      cm_ButtonEnter.Enabled = pOKState;
    } 
    #endregion

    #region Private events handlers
    private void cm_TSButtonAccept_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.OK;
      Close();
    }
    private void cm_TSButtonCancel_Click(object sender, EventArgs e)
    {
      DialogResult = DialogResult.Cancel;
      Close();
    }
    private void tsb_Click(object sender, EventArgs e)
    {
      ToolStripButton tsb = sender as ToolStripButton;
      if ((tsb != null) && (tsb.Tag != null) && (tsb.Tag is DialogResult))
        DialogResult = (DialogResult)tsb.Tag;
      Close();
    }
    #endregion

  }
}