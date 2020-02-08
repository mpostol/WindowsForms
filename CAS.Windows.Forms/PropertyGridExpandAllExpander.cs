//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// Component that expand property grid to has two new button: Collapse/Expand
  /// </summary>
  public partial class PropertyGridExpandAllExpander : Component
  {
    private PropertyGrid myPropertyGrid;
    private void myToolStripItemCollapse_Click(object sender, EventArgs e)
    {
      if (MyPropertyGrid != null)
      {
        MyPropertyGrid.CollapseAllGridItems();
      }
    }
    private void MyToolStripItemExpand_Click(object sender, EventArgs e)
    {
      if (MyPropertyGrid != null)
      {
        MyPropertyGrid.ExpandAllGridItems();
      }
    }
    /// <summary>
    /// Gets the tool strip item expand.
    /// </summary>
    /// <value>My tool strip item expand.</value>
    public ToolStripButton MyToolStripItemExpand { get; private set; }
    /// <summary>
    /// Gets the tool strip item collapse.
    /// </summary>
    /// <value>My tool strip item collapse.</value>
    public ToolStripButton MyToolStripItemCollaps { get; private set; }
    /// <summary>
    /// Gets or sets the property grid.
    /// </summary>
    /// <value>My property grid.</value>
    public PropertyGrid MyPropertyGrid
    {
      get => myPropertyGrid;
      set
      {
        myPropertyGrid = value;
        if (myPropertyGrid != null)
          foreach (Control control in MyPropertyGrid.Controls)
          {
            ToolStrip toolStrip = control as ToolStrip;
            if (toolStrip != null)
            {
              toolStrip.Items.Add(new ToolStripSeparator());
              toolStrip.Items.Add(MyToolStripItemExpand);
              toolStrip.Items.Add(MyToolStripItemCollaps);
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
    public PropertyGridExpandAllExpander(IContainer container)
    {
      container.Add(this);
      InitializeComponent();
      CommonInitialization();
    }
    private void CommonInitialization()
    {
      MyToolStripItemExpand = new ToolStripButton("Expand all");
      MyToolStripItemExpand.Click += new EventHandler(MyToolStripItemExpand_Click);
      MyToolStripItemCollaps = new ToolStripButton("Collapse all");
      MyToolStripItemCollaps.Click += new EventHandler(myToolStripItemCollapse_Click);
    }
    #endregion initialisation

  }
}
