//_______________________________________________________________
//  Title   : CSVManagement
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System;
using System.IO;

namespace CAS.Windows.Forms
{
  /// <summary>
  /// Class CSVManagement - provides functionality to manage import files contained comma separated values. 
  /// </summary>
  public class CSVManagement
  {
    /// <summary>
    /// The default filter of the open file dialog. 
    /// </summary>
    public static string Filter = "CSV Tag bits definition file (*.CSV)|*.CSV";
    /// <summary>
    /// The default extension of the comma separated files.
    /// </summary>
    public static string DefaultExt = ".CSV";
    /// <summary>
    /// Skips the <paramref name="number"/> elements, gets the current element and move to the next one.
    /// </summary>
    /// <param name="number">The number.</param>
    /// <returns>System.String.</returns>
    public string GetAndMove2NextElement(int number)
    {
      string ret = "";
      for (int i = 0; i < number; i++)
        ret = GetAndMove2NextElement();
      return ret;
    }
    /// <summary>
    /// Gets the current element and move to the next element.
    /// </summary>
    /// <returns>Current element</returns>
    public string GetAndMove2NextElement()
    {
      int _pos = m_Buffer.IndexOf(";");
      string _ret = m_Buffer.Substring(0, _pos).Trim(); 
      m_Buffer = m_Buffer.Remove(0, _pos + 1);
      return _ret;
    }
    /// <summary>
    /// Reads the text file containing comma separated values.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <returns>An instance of <see cref="CSVManagement"/> containing the content of the file.</returns>
    public static CSVManagement ReadFile(string filename)
    {
      CSVManagement _ret = new CSVManagement();
      string  _Buffer;
      using (StreamReader _stream = new StreamReader(filename)) //,System.Text.Encoding.Default);
      {
        _Buffer = _stream.ReadToEnd();
      }
      int pos = _Buffer.IndexOf("\r\n");
      _Buffer = _Buffer.Remove(0, pos + 2);
      _Buffer = _Buffer.Replace(";\r\n", ";");
      _Buffer = _Buffer.Replace("\r\n", ";");
      if (!_Buffer.EndsWith(";"))
        _Buffer = _Buffer + ";";
      _ret.m_Buffer = _Buffer;
      return _ret;
    }
    /// <summary>
    /// Returns current content of the internal buffer.
    /// </summary>
    /// <returns>A <see cref="System.String" /> from the internal buffer.</returns>
    public override string ToString()
    {
      return m_Buffer;
    }
    private string m_Buffer = String.Empty;
  }
}
