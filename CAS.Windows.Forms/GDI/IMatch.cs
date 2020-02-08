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
  /// IMatch - this interface is used to detect whether mouse click match object that implements this interface
  /// </summary>
  internal interface IMatch
  {
    /// <summary>
    /// tests if matches the specified point.
    /// </summary>
    /// <param name="_point">The point.</param>
    /// <returns></returns>
    bool Match( Point _point );
  }

}
