//<summary>
//  Title   : Form allowing to modify properties of new created object.
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    MPOstol - 18-12-2006: created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http:\\www.cas.eu
//</summary>

using System;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// The form allows to edit values of the browse-able properties of the assigned object using property grid. 
  /// Returning dialog result can be used to accept or reject changes.
  /// </summary>
  public partial class AddObject<TObject>: Form
  {
    #region public
    /// <summary>
    /// Default creator of the object
    /// </summary>
    public AddObject()
    {
      InitializeComponent();
      propertyGridExpandAllExpander1.MyPropertyGrid = cm_PropertyGrid;
    }
    /// <summary>
    /// constructor
    /// </summary>
    /// <param name="pObjectToEdit">Object to be edit</param>
    public AddObject( TObject pObjectToEdit )
      : this()
    {
      Object = pObjectToEdit;
    }
    /// <summary>
    /// Sets or gets an object to be modified.
    /// </summary>
    /// <value>The object to be edited.</value>
    public TObject Object
    {
      set { cm_PropertyGrid.SelectedObject = value; }
      get { return (TObject)cm_PropertyGrid.SelectedObject; }
    }
    #endregion
    #region Private events handlers
    private void cm_TSButtonAccept_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
    private void cm_TSButtonCancel_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
    #endregion
  }
}