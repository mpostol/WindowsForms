//<summary>
//  Title   : The collection of property grid
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
using System.Drawing;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// The Collection of property grids
  /// </summary>
  public partial class PropertyGridCollection: UserControl
  {
    
    #region private
    private object[] m_SelectedObjects = null;
    private List<PropertyGrid> m_PropertyGridCollection = null;
    private void PropertyGrid_PropertyValueChanged( object s, PropertyValueChangedEventArgs e )
    {
      if ( PropertyValueChanged != null )
      {
        PropertyValueChanged( s, e );
      }
    }
    private void PropertyGridCollection_Resize( object sender, EventArgs e )
    {
      UpdateTheLayout();
    }
    private void Cleanup()
    {
      foreach ( PropertyGrid pg in m_PropertyGridCollection )
        pg.PropertyValueChanged -= this.PropertyGrid_PropertyValueChanged;
      m_PropertyGridCollection.Clear();
      this.Controls.Clear();
    }
    private void UpdateTheLayout()
    {
      this.SuspendLayout();
      if ( m_PropertyGridCollection.Count == 0 )
        return;
      int height = this.Size.Height / m_PropertyGridCollection.Count;
      for ( int idx = 0; idx < m_PropertyGridCollection.Count; idx++ )
      {
        m_PropertyGridCollection[ idx ].Location = new Point( 0, idx * height );
        m_PropertyGridCollection[ idx ].Size = new Size( this.Size.Width, height - 10 );
      }
      this.ResumeLayout();
      this.PerformLayout();
    }
    #endregion private

    #region public
    /// <summary>
    /// Occurs when any  value of any property is changed.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly")]
    public event PropertyValueChangedEventHandler PropertyValueChanged;
    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyGridCollection"/> class.
    /// </summary>
    public PropertyGridCollection()
    {
      InitializeComponent();
      m_PropertyGridCollection = new List<PropertyGrid>();
      this.Resize += new EventHandler( PropertyGridCollection_Resize );
    }
    /// <summary>
    /// Gets or sets the selected objects.
    /// </summary>
    /// <value>The selected objects.</value>
    public object[] SelectedObjects
    {
      get
      {
        return m_SelectedObjects;
      }
      set
      {
        m_SelectedObjects = value;
        if ( value == null )
        {
          Cleanup();
        }
        else
        {
          if ( value.Length == m_PropertyGridCollection.Count )
          {
            for ( int idx = 0; idx < value.Length; idx++ )
            {
              m_PropertyGridCollection[ idx ].SelectedObject = value[ idx ];
            }
          }
          else
          {
            Cleanup();
            for ( int idx = 0; idx < value.Length; idx++ )
            {
              if ( value[ idx ] == null )
                continue;
              PropertyGrid newPropertyGrid = new PropertyGrid();
              //newPropertyGrid.Dock = DockStyle.Fill;
              newPropertyGrid.SelectedObject = value[ idx ];
              newPropertyGrid.PropertyValueChanged += this.PropertyGrid_PropertyValueChanged;
              Splitter splitter = new Splitter();
              splitter.Dock = System.Windows.Forms.DockStyle.Bottom;
              splitter.TabStop = false;
              this.Controls.Add( newPropertyGrid );
              this.Controls.Add( splitter );
              m_PropertyGridCollection.Add( newPropertyGrid );
              UpdateTheLayout();
            }
          }
        }
      }
    }
    /// <summary>
    /// Forces the control to invalidate its client area and immediately redraw itself and any child controls.
    /// </summary>
    /// <PermissionSet>
    /// 	<IPermission class="System.Security.Permissions.EnvironmentPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// 	<IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="UnmanagedCode, ControlEvidence"/>
    /// 	<IPermission class="System.Diagnostics.PerformanceCounterPermission, System, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Unrestricted="true"/>
    /// </PermissionSet>
    public override void Refresh()
    {
      base.Refresh();
      foreach ( PropertyGrid item in m_PropertyGridCollection )
      {
        item.Refresh();
      }
    }
    #endregion

  }
}
