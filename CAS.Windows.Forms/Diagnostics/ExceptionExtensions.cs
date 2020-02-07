//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Text;

namespace CAS.Windows.Forms.Diagnostics
{
  internal static class ExceptionExtensions
  {
    /// <summary>
    /// Gets the message with exception name from exception including inner exception.
    /// </summary>
    /// <param name="ex">The ex.</param>
    /// <returns>the whole message</returns>
    public static string GetMessageWithExceptionNameFromExceptionIncludingInnerException(this Exception ex)
    {
      StringBuilder sb = new StringBuilder(ex.GetType().ToString());
      sb.Append(":");
      sb.Append(ex.Message);
      Exception InnerEx = ex.InnerException;
      while (InnerEx != null)
      {
        sb.Append("; ");
        sb.Append(InnerEx.GetType().ToString());
        sb.Append(":");
        sb.Append(InnerEx.Message);
        InnerEx = InnerEx.InnerException;
      }
      return sb.ToString();
    }

  }
}
