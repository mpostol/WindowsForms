//<summary>
//  Title   : DockPanelUserControl panel with label and close button that can be used for docking
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  20090513: mzbrzezny created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Lib.ControlLibrary.ControlExtenders;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// panel with label and close button that can be used for docking
  /// </summary>
  public partial class DockPanelUserControl: UserControl
  {
    /// <summary>
    /// Gets or sets the panel label.
    /// </summary>
    /// <value>The label.</value>
    public string Label
    {
      get
      {
        return this.label_title.Text;
      }
      set
      {
        this.label_title.Text = value;
      }
    }
    /// <summary>
    /// Gets or sets the main control inside the panel.
    /// </summary>
    /// <value>The main control.</value>
    public Control MainControl
    {
      get
      {
        if ( this.panel_main.Controls.Count > 0 )
          return this.panel_main.Controls[ 0 ];
        else
          return null;
      }
      set
      {
        if ( this.panel_main.Controls.Count > 0 )
          this.panel_main.Controls.Clear();
        if ( value == null )
          return;
        this.panel_main.Controls.Add( value );
        value.Dock = DockStyle.Fill;
      }
    }
    /// <summary>
    /// Gets or sets the floaty. <see cref="CAS.Lib.ControlLibrary.ControlExtenders.IFloaty"/>
    /// </summary>
    /// <value>The floaty.</value>
    public IFloaty Floaty { get; private set; }
    /// <summary>
    /// Attaches to dock extender.
    /// </summary>
    /// <param name="DockExtender">The dock extender.</param>
    /// <param name="spliter">The spliter.</param>
    public void AttachToDockExtender( DockExtender DockExtender, Splitter spliter )
    {
      if ( DockExtender != null )
      {
        dockExtender = DockExtender;
        Floaty = dockExtender.Attach( this, this.label_title, spliter );
      }
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="DockPanelUserControl"/> class.
    /// </summary>
    /// <param name="DockExtender">The dock extender.</param>
    /// <param name="spliter">The spliter.</param>
    public DockPanelUserControl( DockExtender DockExtender, Splitter spliter )
      : this()
    {
      AttachToDockExtender( DockExtender, spliter );
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="DockPanelUserControl"/> class.
    /// </summary>
    public DockPanelUserControl()
    {
      InitializeComponent();
      this.label_title.VisibleChanged += new EventHandler( label_title_VisibleChanged );
      this.Enter += new EventHandler( DockPanelUserControl_EnterExited );
      this.Leave += new EventHandler( DockPanelUserControl_EnterExited );
    }
    /// <summary>
    /// Gets a value indicating whether the control has input focus.
    /// </summary>
    /// <value></value>
    /// <returns>true if the control has focus; otherwise, false.
    /// </returns>
    public new bool Focused
    {
      get
      {
        return TestFocused( this );
      }
    }
    /// <summary>
    /// Displays the control to the user.
    /// </summary>
    /// <PermissionSet>
    /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
    /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// </PermissionSet>
    public new void Show()
    {
      this.Floaty.Show();
    }
    #region private
    private DockExtender dockExtender = null;
    private void DockPanelUserControl_EnterExited( object sender, EventArgs e )
    {
      if ( this.Focused )
      {
        label_title.BackColor = SystemColors.ActiveCaption;
        label_title.ForeColor = SystemColors.ActiveCaptionText;
        button_exit.BackColor = SystemColors.ActiveCaption;
        button_exit.ForeColor = SystemColors.ActiveCaptionText;
      }
      else
      {
        label_title.BackColor = SystemColors.InactiveCaption;
        label_title.ForeColor = SystemColors.InactiveCaptionText;
        button_exit.BackColor = SystemColors.InactiveCaption;
        button_exit.ForeColor = SystemColors.InactiveCaptionText;
      }
    }
    private void button_exit_Click( object sender, EventArgs e )
    {
      dockExtenderHide_afterCloseClick();
    }
    private void dockExtenderHide_afterCloseClick()
    {
      if ( dockExtender != null )
        dockExtender.Hide( this );
    }
    private void closeToolStripMenuItem_Click( object sender, EventArgs e )
    {
      dockExtenderHide_afterCloseClick();
    }
    private void label_title_VisibleChanged( object sender, EventArgs e )
    {
      this.button_exit.Visible = this.label_title.Visible;
    }
    private static bool TestFocused( Control cn )
    {
      if ( cn.Focused )
        return true;
      foreach ( Control intcn in cn.Controls )
        if ( TestFocused( intcn ) )
          return true;
      return false;
    }
    #endregion private
  }
}
