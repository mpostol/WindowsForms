//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;

namespace UAOOI.Windows.Forms
{

  /// <summary>
  /// Generic EventArgs class
  /// </summary>
  /// <typeparam name="T">class stat is stored in this <see cref="EventArgs"/></typeparam>
  public class GenericEventArgs<T> : EventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="GenericEventArgs&lt;T&gt;"/> class.
    /// </summary>
    /// <param name="tag">The tag.</param>
    public GenericEventArgs(T tag)
    {
      Tag = tag;
    }
    /// <summary>
    /// Access to stored Class
    /// </summary>
    public T Tag { get; private set; }

  }
}
