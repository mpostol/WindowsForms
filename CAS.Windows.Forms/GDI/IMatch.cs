//<summary>
//  Title   : IMatch - this interface is used to detect whether mous click match object that implements this interface
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20080305 - mzbrzezny - created
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
  /// IMatch - this interface is used to detect whether mous click match object that implements this interface
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
