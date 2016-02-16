//<summary>
//  Title   : Component that expand property grid to has two new button: Collapse/Expand
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
using System.ComponentModel;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Component that expand property grid to has two new button: Collapse/Expand
  /// </summary>
  public partial class PropertyGridExpandAllExpander: Component
  {
    private ToolStripButton myToolStripItemExpand;
    private ToolStripButton myToolStripItemCollapse;
    private PropertyGrid myPropertyGrid;
    private void myToolStripItemCollapse_Click( object sender, EventArgs e )
    {
      if ( MyPropertyGrid != null )
      {
        MyPropertyGrid.CollapseAllGridItems();
      }
    }
    private void MyToolStripItemExpand_Click( object sender, EventArgs e )
    {
      if ( MyPropertyGrid != null )
      {
        MyPropertyGrid.ExpandAllGridItems();
      }
    }
    /// <summary>
    /// Gets the tool strip item expand.
    /// </summary>
    /// <value>My tool strip item expand.</value>
    public ToolStripButton MyToolStripItemExpand { get { return myToolStripItemExpand; } }
    /// <summary>
    /// Gets the tool strip item collaps.
    /// </summary>
    /// <value>My tool strip item collaps.</value>
    public ToolStripButton MyToolStripItemCollaps { get { return myToolStripItemCollapse; } }
    /// <summary>
    /// Gets or sets the property grid.
    /// </summary>
    /// <value>My property grid.</value>
    public PropertyGrid MyPropertyGrid
    {
      get
      {
        return myPropertyGrid;
      }
      set
      {
        myPropertyGrid = value;
        if ( myPropertyGrid != null )
          foreach ( Control control in MyPropertyGrid.Controls )
          {
            ToolStrip toolStrip = control as ToolStrip;
            if ( toolStrip != null )
            {
              toolStrip.Items.Add( new ToolStripSeparator() );
              toolStrip.Items.Add( myToolStripItemExpand );
              toolStrip.Items.Add( myToolStripItemCollapse );
            }
          }
      }
    }
    #region initialisation
    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyGridExpandAllExpander"/> class.
    /// </summary>
    public PropertyGridExpandAllExpander()
    {
      InitializeComponent();
      CommonInitialization();
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PropertyGridExpandAllExpander"/> class.
    /// </summary>
    /// <param name="container">The container.</param>
    public PropertyGridExpandAllExpander( IContainer container )
    {
      container.Add( this );
      InitializeComponent();
      CommonInitialization();
    }
    private void CommonInitialization()
    {
      myToolStripItemExpand = new ToolStripButton( "Expand all" );
      myToolStripItemExpand.Click += new EventHandler( MyToolStripItemExpand_Click );
      myToolStripItemCollapse = new ToolStripButton( "Collapse all" );
      myToolStripItemCollapse.Click += new EventHandler( myToolStripItemCollapse_Click );
    }
    #endregion initialisation
  }
}
