//<summary>
//  Title   : IsConnected is interface that indicate if particular object is Connected
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


namespace CAS.Lib.ControlLibrary.GDI
{
  /// <summary>
  /// IsConnected is interface that indicate if particular object is Connected
  /// </summary>
  internal interface IIsConnected
  {
    bool IsConnected
    {
      get;
    }
  }
}
