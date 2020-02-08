//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Drawing;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// Interface that allow to draw the object
  /// </summary>
  interface IDraw
  {
    /// <summary>
    /// Draws the object on the specified dc.
    /// </summary>
    /// <param name="dc">The DeviceContext.</param>
    /// <param name="MyGraphicsSettings">The graphics settings.</param>
    void Draw(Graphics dc, GraphicsSettings MyGraphicsSettings);
  }
}
