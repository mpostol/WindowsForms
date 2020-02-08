//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Collections.Generic;
using System.Drawing;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// Array of HotPointSelectableConnectable
  /// </summary>
  public class HotPointSelectableConnectableArray: SortedList<HotpointType, HotPointSelectableConnectable[]>, IDraw
  {
    /// <summary>
    /// Desellects all hotpoints.
    /// </summary>
    internal void DeselectAll()
    {
      foreach ( KeyValuePair<HotpointType, HotPointSelectableConnectable[]> hp_array in this )
      {
        foreach ( HotPointSelectableConnectable hp in hp_array.Value )
        {
          if ( hp != null )
            hp.IsSelected = false;
        }
      }
    }

    #region IDraw Members

    /// <summary>
    /// Draws the object on the specified dc.
    /// </summary>
    /// <param name="dc">The DeviceContext.</param>
    /// <param name="MyGraphicsSettings">The graphics settings.</param>
    public void Draw( System.Drawing.Graphics dc, GraphicsSettings MyGraphicsSettings )
    {
      // trzeba przeszukac wszystkie hot pointy
      foreach ( KeyValuePair<HotpointType, HotPointSelectableConnectable[]> hp_array in this )
      {
        foreach ( HotPointSelectableConnectable hp in hp_array.Value )
        {
          if ( hp != null )
            hp.Draw( dc, MyGraphicsSettings );
        }
      }
    }

    #endregion

    /// <summary>
    /// Matches and selects the hotpoint. 
    /// This function checks whether one of the hotpoints is clicked and if yes the hotpoint is selected.
    /// </summary>
    /// <param name="point">The point that is clicked.</param>
    /// <returns>true if any hot point is selected</returns>
    public bool MatchAndSelect( Point point )
    {
      // trzeba przeszukac wszystkie hot pointy
      foreach ( KeyValuePair<HotpointType, HotPointSelectableConnectable[]> hp_array in this )
      {
        foreach ( HotPointSelectableConnectable hp in hp_array.Value )
        {
          if ( hp != null && hp.Match( point ) )
          {
            hp.IsSelected = true;
            return true;
          }
        }
      }
      return false;
    }
    /// <summary>
    /// Gets the selected hotpoint.
    /// </summary>
    /// <value>The selected hotpoint.</value>
    public HotPointSelectableConnectable SelectedHotpoint
    {
      get
      {
        // trzeba przeszukac wszystkie hot pointy
        foreach ( KeyValuePair<HotpointType, HotPointSelectableConnectable[]> hp_array in this )
        {
          foreach ( HotPointSelectableConnectable hp in hp_array.Value )
          {
            if ( hp != null && hp.IsSelected )
              return hp;
          }
        }
        return null;
      }
    }

  }
}
