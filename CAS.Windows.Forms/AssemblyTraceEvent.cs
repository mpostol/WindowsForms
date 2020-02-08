//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Diagnostics;
using System.Reflection;

namespace UAOOI.Windows.Forms
{

  /// <summary>
  /// class responsible for tracing inside BaseStation - please use TraceSource( "CAS.Lib.ControlLibrary.TraceEvent" )
  /// </summary>
  internal class AssemblyTraceEvent
  {

    private static Lazy<TraceSource> m_TraceEventInternal = new Lazy<TraceSource>(() => new TraceSource(Assembly.GetCallingAssembly().GetName().Name));
    /// <summary>
    /// Gets the tracer.
    /// </summary>
    /// <value>The tracer.</value>
    public static TraceSource Tracer => m_TraceEventInternal.Value;

  }
}
