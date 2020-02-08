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
  /// ToolStripCheckBox
  /// </summary>
  public class ToolStripCheckBox : System.Windows.Forms.ToolStripControlHost
  {

    #region public
    /// <summary>
    /// Occurs when checked state is changed.
    /// </summary>
    public event EventHandler CheckedChanged;
    /// <summary>
    /// Initializes a new instance of the <see cref="ToolStripCheckBox"/> class.
    /// </summary>
    public ToolStripCheckBox() : base(new System.Windows.Forms.CheckBox()) { }
    /// <summary>
    /// Gets the tool strip check box control.
    /// </summary>
    /// <value>The tool strip check box control.</value>
    public CheckBox ToolStripCheckBoxControl => Control as CheckBox;
    /// <summary>
    /// Gets or sets a value indicating whether [tool strip check box enabled].
    /// expose checkbox.enabled as property
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [tool strip check box enabled]; otherwise, <c>false</c>.
    /// </value>
    public bool ToolStripCheckBoxEnabled
    {
      get => ToolStripCheckBoxControl.Enabled;
      set => ToolStripCheckBoxControl.Enabled = value;
    }
    #endregion

    #region private
    /// <summary>
    /// Called when [subscribe control events].
    /// </summary>
    /// <param name="c">The c.</param>
    protected override void OnSubscribeControlEvents(Control c)
    {
      // Call the base method so the basic events are unsubscribed.
      base.OnSubscribeControlEvents(c);
      CheckBox ToolStripCheckBoxControl = (CheckBox)c;
      if (CheckedChanged != null)
      {
        // Remove the event.
        ToolStripCheckBoxControl.CheckedChanged += new EventHandler(CheckedChanged);
      }
    }
    /// <summary>
    /// Called when on unsubscribe control events.
    /// </summary>
    /// <param name="c">The c.</param>
    protected override void OnUnsubscribeControlEvents(Control c)
    {
      // Call the base method so the basic events are unsubscribed.
      base.OnUnsubscribeControlEvents(c);
      CheckBox ToolStripCheckBoxControl = (CheckBox)c;
      if (CheckedChanged != null)
      {
        // Remove the event.
        ToolStripCheckBoxControl.CheckedChanged -= new EventHandler(CheckedChanged);
      }
    }
    /// <summary>
    /// Occurs when checked is changed.
    /// </summary>
    private void OnCheckChanged(object sender, DateRangeEventArgs e)
    {
      if (CheckedChanged != null)
      {
        CheckedChanged(this, e);
      }
    }
    #endregion

  }
}