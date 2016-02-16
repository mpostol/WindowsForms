//<summary>
//  Title   : Interface that allow to draw the object
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20080305 - mzbrzezny - created
//    <date> - <author>: <description>
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.Drawing;

namespace CAS.Lib.ControlLibrary.GDI
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
