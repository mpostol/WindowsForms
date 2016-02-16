﻿//<summary>
//  Title   : Generic Tab Control Manager
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Generic Tab Control Manager
  /// 
  /// </summary>
  public partial class TabControlManager: Component
  {
    #region Creators and Initializations
    /// <summary>
    /// Initializes a new instance of the <see cref="TabControlManager"/> class.
    /// </summary>
    public TabControlManager()
    {
      InitializeComponent();
      CommonInitialization();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="TabControlManager"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public TabControlManager( IContainer container )
    {
      container.Add( this );

      InitializeComponent();
      CommonInitialization();
    }
    private void CommonInitialization()
    {
      mAllTabPageList = new List<TabPage>();
    }
    #endregion  Creators and Initializations
    /// <summary>
    /// Gets or sets the tab control.
    /// </summary>
    /// <value>The tab control.</value>
    public TabControl TabControl
    {
      get
      { 
        return mTabControl; 
      }
      set
      {
        mAllTabPageList.Clear();
        mTabControl = value;
      }
    }
    /// <summary>
    /// Gets the tool strip item collection(eg. for the menu).
    /// </summary>
    /// <returns>colletion of tool strip item(eg. for the menu).</returns>
    public ToolStripItem[] GetToolStripItemCollection()
    {
      CheckAndFillAllTabPageList();
      ToolStripItem[] to_be_returned = new ToolStripItem[ mAllTabPageList.Count ];
      for ( int i = 0; i < mAllTabPageList.Count; i++ )
      {
        to_be_returned[ i ] = 
          new ToolStripItemMenuItemWithTabPage( mTabControl, mAllTabPageList[ i ], 
            mTabControl.TabPages.Contains( mAllTabPageList[ i ] ) );
      }
      return to_be_returned;
    }
    #region private
    private class ToolStripItemMenuItemWithTabPage: ToolStripMenuItem
    {
      TabPage mTabPage;
      TabControl mTabControl;
      private void ToolStripItemMenuItemWithTabPage_Click( object sender, EventArgs e )
      {
        if ( this.Checked )
        {
          mTabControl.TabPages.Remove( mTabPage );
          this.Checked = false;
          this.CheckState = CheckState.Unchecked;
        }
        else
        {
          mTabControl.TabPages.Add( mTabPage );
          this.Checked = true;
          this.CheckState = CheckState.Checked;
          mTabControl.SelectedTab = mTabPage;
        }
      }
      [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
      internal ToolStripItemMenuItemWithTabPage( TabControl tc, TabPage tp, bool isVisible )
      {
        this.mTabControl=tc;
        this.mTabPage=tp;
        this.Text = tp.Text;
        this.Checked = isVisible;
        this.CheckState = isVisible ? CheckState.Checked : CheckState.Unchecked;
        this.Click += new EventHandler( ToolStripItemMenuItemWithTabPage_Click );
      }
    }
    private TabControl mTabControl;
    private List<TabPage> mAllTabPageList;
    private void CheckAndFillAllTabPageList()
    {
      if(mTabControl!=null)
      {
        foreach ( TabPage tp in mTabControl.TabPages )
        {
          if ( !mAllTabPageList.Contains( tp ) )
            mAllTabPageList.Add( tp );
        }
      }
    }
    #endregion private
  }
}
