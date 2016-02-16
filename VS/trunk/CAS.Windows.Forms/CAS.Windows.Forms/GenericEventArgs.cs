//<summary>
//  Title   : Generic EventArgs class
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  History :
//    20080516 mzbrzezny: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Generic EventArgs class
  /// </summary>
  /// <typeparam name="T">class stat is stored in this event arg</typeparam>
  public class GenericEventArgs<T>: EventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GenericEventArgs&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="tag">The tag.</param>
    public GenericEventArgs( T tag )
    {
      Tag = tag;
    }
    /// <summary>
    /// Access to stored Class
    /// </summary>
    public T Tag { get; private set; }
  }
}
