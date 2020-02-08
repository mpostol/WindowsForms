﻿//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

namespace UAOOI.Windows.Forms.GDI
{

  /// <summary>
  /// IsSelected is interface that indicate if particular object is selected
  /// </summary>
  internal interface IIsSelected
  {

    bool IsSelected
    {
      get;
      set;
    }

  }
}
