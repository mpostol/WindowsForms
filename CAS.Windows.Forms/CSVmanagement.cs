//<summary>
//  Title   : CSV Management - class that helps to read data from CSV File
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    Maciej Zbrzezny: 2005-11-25
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http://www.cas.eu
//</summary>
      

namespace BaseStation
{
  using System;
  using System.Windows.Forms;
  using System.IO;
  /// <summary>
  /// Abstract class decribing interface functionality of the station pipe
  /// </summary>
  internal class CSVManagement
  {
    static private OpenFileDialog m_OpenFileDialog;
    static internal OpenFileDialog OPENFILEDIALOG
    {
      get
      {
        return m_OpenFileDialog;
      }
    }
		static internal string GetAndMoveNextElement(ref string inputstring, int number)
		{
			string ret="";
			for (int i=0; i< number ;i++)
			{
				ret=GetAndMoveNextElement(ref inputstring);
			}
			return ret;
		}
    static internal string GetAndMoveNextElement(ref string inputstring)
    {
      int pos = inputstring.IndexOf(";");
      string ret=inputstring.Substring(0,pos);
      inputstring=inputstring.Remove(0,pos+1);
      return ret;
    }
    static CSVManagement()
    {
      m_OpenFileDialog=new OpenFileDialog();
      m_OpenFileDialog.InitialDirectory=AppDomain.CurrentDomain.BaseDirectory;
      m_OpenFileDialog.Filter = "CSV Tag bits definition file (*.CSV)|*.CSV";
      m_OpenFileDialog.DefaultExt = ".CSV";
    }
    static internal string ReadFile(string filename)
    {
      StreamReader plik = new StreamReader(filename);//,System.Text.Encoding.Default);
      string ret = plik.ReadToEnd();
      plik.Close();
      return ret;
    }
    static internal string PrepareForCSVProcessing(string inputstring)
    {
      string ret;
      int pos = inputstring.IndexOf("\r\n");
      ret=inputstring.Remove(0,pos+2);
      ret=ret.Replace(";\r\n",";");
      ret=ret.Replace("\r\n",";");
      if ( !ret.EndsWith( ";" ) )
        ret = ret + ";";
      return ret;
    }
  }
}
