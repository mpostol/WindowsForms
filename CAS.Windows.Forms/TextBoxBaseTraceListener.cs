//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// TextBoxBaseTraceListener - listener that can be used to display output from trace in any text box window
  /// </summary>
  public class TextBoxBaseTraceListener : TraceListener
  {
    #region private static
    private static Dictionary<string, TextBoxBase> m_OutputTextBoxBaseDictionary;
    static TextBoxBaseTraceListener()
    {
      m_OutputTextBoxBaseDictionary = new Dictionary<string, TextBoxBase>();
    }
    private static void CheckAndRemoveEventHAndlerFromPreviousTextBoxBase(string name)
    {
      if (m_OutputTextBoxBaseDictionary.ContainsKey(name))
      {
        if (m_OutputTextBoxBaseDictionary.TryGetValue(name, out TextBoxBase previousOutputTextBoxBase))
        {
          if (previousOutputTextBoxBase != null)
            previousOutputTextBoxBase.Disposed -= new EventHandler(OutputTextBoxBase_Disposed);
        }
      }
    }
    private static void OutputTextBoxBase_Disposed(object sender, EventArgs e)
    {
      TextBoxBase OutputTextBoxBase = null;
      if ((OutputTextBoxBase = sender as TextBoxBase) != null)
      {
        string[] keys = new string[m_OutputTextBoxBaseDictionary.Keys.Count];
        m_OutputTextBoxBaseDictionary.Keys.CopyTo(keys, 0);
        for (int idx = 0; idx < m_OutputTextBoxBaseDictionary.Count; idx++)
        {
          string key = keys[idx];
          if (m_OutputTextBoxBaseDictionary[key] == OutputTextBoxBase)
          {
            m_OutputTextBoxBaseDictionary.Remove(key);
            break;
          }
        }
      }
    }
    private delegate void InvokeTextAppendDelegate(string message, bool IncludeTimeStamp, TextBoxBase m_OutputTextBoxBase);
    private static void TextAppend(string message, bool IncludeTimeStamp, TextBoxBase m_OutputTextBoxBase)
    {
      if (m_OutputTextBoxBase.InvokeRequired)
      {
        m_OutputTextBoxBase.BeginInvoke(
          new InvokeTextAppendDelegate(TextAppend),
          new object[] { message, IncludeTimeStamp, m_OutputTextBoxBase });
      }
      else
      {
        if (IncludeTimeStamp)
          m_OutputTextBoxBase.AppendText(System.DateTime.Now.ToString() + ": ");
        m_OutputTextBoxBase.AppendText(message);
      }
    }
    #endregion privatestatic
    #region private
    private bool WriteLineIsOdd = true; // we are writing timestamp only when WriteLine operation is odd in sequence
                                        // this is because the sequence of WriteLine in TraceListener
                                        // first Write is TraceSource + space (as separator) + Level
                                        // second Write is message
    private void Write(string message, bool IncludeTimeStamp)
    {
      TextBoxBase m_OutputTextBoxBase = null;
      if (m_OutputTextBoxBaseDictionary.ContainsKey(this.Name) &&
        (m_OutputTextBoxBase = m_OutputTextBoxBaseDictionary[this.Name]) != null
        && !m_OutputTextBoxBase.IsDisposed)
      {
        TextAppend(message, IncludeTimeStamp, m_OutputTextBoxBase);
      }
    }
    #endregion private
    #region public
    /// <summary>
    /// When overridden in a derived class, writes the specified message to the listener you create in the derived class.
    /// </summary>
    /// <param name="message">A message to write.</param>
    public override void Write(string message)
    {
      Write(message, WriteLineIsOdd);
      WriteLineIsOdd = !WriteLineIsOdd;
    }
    /// <summary>
    /// When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.
    /// </summary>
    /// <param name="message">A message to write.</param>
    public override void WriteLine(string message)
    {
      Write(message, WriteLineIsOdd);
      WriteLineIsOdd = !WriteLineIsOdd;
      Write(Environment.NewLine, false);
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="TextBoxBaseTraceListener"/> class.
    /// </summary>
    public TextBoxBaseTraceListener()
      : base()
    {
    }
    #endregion public
    #region public static
    /// <summary>
    /// Registers the text box.
    /// </summary>
    /// <param name="name">The name to be registered as listener source.</param>
    /// <param name="OutputTextBoxBase">The TextBox to be registered.</param>
    public static void RegisterTextBoxBase(string name, TextBoxBase OutputTextBoxBase)
    {
      if (m_OutputTextBoxBaseDictionary.ContainsKey(name))
      {
        CheckAndRemoveEventHAndlerFromPreviousTextBoxBase(name);
        m_OutputTextBoxBaseDictionary[name] = OutputTextBoxBase;
      }
      else
      {
        m_OutputTextBoxBaseDictionary.Add(name, OutputTextBoxBase);
      }
      OutputTextBoxBase.Disposed += new EventHandler(OutputTextBoxBase_Disposed);
    }
    /// <summary>
    /// Unregisters the  text box.
    /// </summary>
    /// <param name="name">The name to be unregistered as listener source.</param>
    public static void UnRegisterTextBoxBase(string name)
    {
      if (m_OutputTextBoxBaseDictionary.ContainsKey(name))
      {
        CheckAndRemoveEventHAndlerFromPreviousTextBoxBase(name);
        m_OutputTextBoxBaseDictionary.Remove(name);
      }
    }
    #endregion public static
  }
  /// <summary>
  /// Component that can be added to any control to be used as a connection between any TextBox and coupled TextBoxBaseTraceListener
  /// </summary>
  public class TextBoxBaseWithTraceListener : Component
  {
    private TextBoxBase m_OutputTextBox;
    private TextBoxBaseTraceListener m_InternalTextBoxBaseTraceListener;
    /// <summary>
    /// Initializes a new instance of the <see cref="TextBoxBaseWithTraceListener"/> class.
    /// </summary>
    public TextBoxBaseWithTraceListener()
    {
      m_InternalTextBoxBaseTraceListener =
          new TextBoxBaseTraceListener();
    }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name of the trace listener.</value>
    public string Name
    {
      get => m_InternalTextBoxBaseTraceListener.Name;
      set
      {
        if (!string.IsNullOrEmpty(this.Name))
          TextBoxBaseTraceListener.UnRegisterTextBoxBase(this.Name);
        m_InternalTextBoxBaseTraceListener.Name = value;
        if (OutputTextBox != null)
          TextBoxBaseTraceListener.RegisterTextBoxBase(this.Name, OutputTextBox);
      }
    }
    /// <summary>
    /// Gets or sets the output text box.
    /// </summary>
    /// <value>The output text box.</value>
    public TextBoxBase OutputTextBox
    {
      get => m_OutputTextBox;
      set
      {
        if (!string.IsNullOrEmpty(this.Name))
          TextBoxBaseTraceListener.UnRegisterTextBoxBase(this.Name);
        m_OutputTextBox = value;
        if (OutputTextBox != null)
          TextBoxBaseTraceListener.RegisterTextBoxBase(this.Name, OutputTextBox);
      }
    }
  }

}
