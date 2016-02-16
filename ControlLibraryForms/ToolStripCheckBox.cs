//<summary>
//  Title   : ToolStripCheckBox
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20090127: MZBRZEZNY:created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Drawing;
using System.Windows.Forms;


namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// ToolStripCheckBox
  /// </summary>
  public class ToolStripCheckBox: System.Windows.Forms.ToolStripControlHost
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ToolStripCheckBox"/> class.
    /// </summary>
    public ToolStripCheckBox() : base( new System.Windows.Forms.CheckBox() ) { }
    /// <summary>
    /// Gets the tool strip check box control.
    /// </summary>
    /// <value>The tool strip check box control.</value>
    public CheckBox ToolStripCheckBoxControl
    {
      get
      {
        return Control as CheckBox;
      }
    }
    /// <summary>
    /// Gets or sets a value indicating whether [tool strip check box enabled].
    /// expose checkbox.enabled as property
    /// </summary>
    /// <value>
    /// 	<c>true</c> if [tool strip check box enabled]; otherwise, <c>false</c>.
    /// </value>
    public bool ToolStripCheckBoxEnabled
    {
      get
      {
        return ToolStripCheckBoxControl.Enabled;
      }
      set
      {
        ToolStripCheckBoxControl.Enabled = value;
      }
    }
    /// <summary>
    /// Called when [subscribe control events].
    /// </summary>
    /// <param name="c">The c.</param>
    protected override void OnSubscribeControlEvents( Control c )
    {
      // Call the base method so the basic events are unsubscribed.
      base.OnSubscribeControlEvents( c );
      CheckBox ToolStripCheckBoxControl = (CheckBox)c;
      if ( CheckedChanged != null )
      {
        // Remove the event.
        ToolStripCheckBoxControl.CheckedChanged += new EventHandler( CheckedChanged );
      }
    }
    /// <summary>
    /// Called when [unsubscribe control events].
    /// </summary>
    /// <param name="c">The c.</param>
    protected override void OnUnsubscribeControlEvents( Control c )
    {
      // Call the base method so the basic events are unsubscribed.
      base.OnUnsubscribeControlEvents( c );
      CheckBox ToolStripCheckBoxControl = (CheckBox)c;
      if ( CheckedChanged != null )
      {
        // Remove the event.
        ToolStripCheckBoxControl.CheckedChanged -= new EventHandler( CheckedChanged );
      }
    }

    /// <summary>
    /// Occurs when checked is changed.
    /// </summary>
    public event EventHandler CheckedChanged;

    private void OnCheckChanged( object sender, DateRangeEventArgs e )
    {
      if ( CheckedChanged != null )
      {
        CheckedChanged( this, e );
      }
    }
  }
}