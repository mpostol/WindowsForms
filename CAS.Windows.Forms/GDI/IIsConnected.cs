//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace UAOOI.Windows.Forms.GDI
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
