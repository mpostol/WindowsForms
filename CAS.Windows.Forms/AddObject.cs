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
  /// The form allows editing values of the browse-able properties of the assigned object using the property grid. Returning dialog results can be used to accept or reject changes.
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