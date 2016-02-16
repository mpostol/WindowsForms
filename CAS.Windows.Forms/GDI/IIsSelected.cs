//<summary>
//  Title   : IsSelected is interface that indicate if particular object is selected
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

namespace CAS.Lib.ControlLibrary.GDI
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
