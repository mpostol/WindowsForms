//<summary>
//  Title   : TraceEvent in CAS.Lib.ControlLibrary
//  System  : Microsoft Visual C# .NET 
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20090715: mzbrzezny: created
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Diagnostics;
using System.Reflection;

namespace CAS.Lib.ControlLibrary
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
    public static TraceSource Tracer
    {
      get
      {
        return m_TraceEventInternal.Value;
      }
    }
  }
}
