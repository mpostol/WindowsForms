//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// Class ImportFunctionRootClass - base class to implement import functionality 
  /// </summary>
  /// <remarks>
  /// It opens file dialog to get file name and call the derived class to import content.
  /// </remarks>
  public abstract class ImportFunctionRootClass
  {
    #region private
    private OKCancelForm m_okcancelform;
    private ImportFileControll m_ImportFileControll;
    private ImportFileControll.ImportInfo m_importinfo = null;
    private string m_import_log = "";
    private System.Windows.Forms.Form m_parrent_form = null;
    /// <summary>
    /// Does the import functionality.
    /// </summary>
    protected abstract void DoTheImport();
    /// <summary>
    /// Sets the import information.
    /// </summary>
    /// <param name="importInfo">The import info.</param>
    protected void SetImportInfo(ImportFileControll.ImportInfo importInfo)
    {
      m_importinfo = importInfo;
    }
    /// <summary>
    /// Appends to log.
    /// </summary>
    /// <param name="text2Append">The text to be appended to the local log.</param>
    protected void AppendToLog(string text2Append)
    {
      m_import_log += " " + text2Append + "\r\n";
    }
    #endregion
    
    #region creator
    internal ImportFunctionRootClass( ImportFileControll.ImportInfo _importinfo, Form parentForm )
    {
      m_importinfo = _importinfo;
      m_parrent_form = parentForm;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ImportFunctionRootClass"/> class.
    /// </summary>
    /// <param name="parentForm">The parent form.</param>
    protected ImportFunctionRootClass( System.Windows.Forms.Form parentForm )
    {
      m_parrent_form = parentForm;
    }
    #endregion

    #region Public
    /// <summary>
    /// Imports this instance.
    /// </summary>
    /// <exception cref="System.Exception">please initialize (SetImportInfo) class: ImportFunctionRootClass first</exception>
    public void Import()
    {
      m_import_log = "";
      if (m_importinfo != null)
      {
        m_okcancelform = new OKCancelForm( m_importinfo.ImportName );
        m_ImportFileControll = new ImportFileControll(m_importinfo, m_okcancelform);
        m_okcancelform.SetUserControl = m_ImportFileControll;
        //ImportFileForm form = new ImportFileForm( m_importinfo );
        if (m_okcancelform.ShowDialog() == System.Windows.Forms.DialogResult.OK)
        {
          try
          {
            DoTheImport();
          }
          catch ( Exception ex )
          {
            AppendToLog( "problem during import: " + ex.Message );
          }
          if (m_import_log.Length > 0)
          {
            LogMessageWindow logform = new LogMessageWindow(m_import_log);
            logform.ShowDialog();
          }
        }
      }
      else
        throw new Exception("please initialize (SetImportInfo) class: ImportFunctionRootClass first");
    }
    /// <summary>
    /// Gets the import log.
    /// </summary>
    /// <returns>System.String.</returns>
    public string GetImportLog()
    {
      return m_import_log;
    }
    #endregion

  }
}
