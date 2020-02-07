//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.ComponentModel;
using System.Windows.Forms;
using UAOOI.Windows.GUIAbstractions;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Control That is responsible for selecting file to import
  /// </summary>
  public partial class ImportFileControll : UserControl
  {

    /// <summary>
    /// abstract class that contains main data for the form and import settings
    /// </summary>
    public abstract class ImportInfo
    {

      /// <summary>
      /// the name for that import
      /// </summary>
      [Browsable(false)]
      public abstract string ImportName
      {
        get;
      }
      /// <summary>
      /// default directory for importing file
      /// </summary>
      [BrowsableAttribute(false)]
      public abstract string InitialDirectory
      {
        get;
      }
      /// <summary>
      /// default browse filter for the dialog which is used for selecting a file
      /// </summary>
      [Browsable(false)]
      public abstract string BrowseFilter
      {
        get;
      }
      /// <summary>
      /// default extension for the dialog which is used for selecting a file
      /// </summary>
      [Browsable(false)]
      public abstract string DefaultExt
      {
        get;
      }
      /// <summary>
      /// text that is used to show the information about this importing function
      /// </summary>
      [Browsable(false)]
      public abstract string InformationText
      {
        get;
      }
      /// <summary>
      /// selected filename
      /// </summary>
      [BrowsableAttribute(false)]
      public string Filename { get; set; }
    }

    #region constructor
    internal ImportFileControll()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Constructor for the import File Dialog
    /// </summary>
    /// <param name="_info">object <see cref="ImportInfo"/> that contains all setting for this import tool</param>
    /// <param name="_canbeaccepted">this is link ti the main window to enable OK button if settings are correct. 
    /// Pleas see <see cref="ICanBeAccepted" /></param>
    public ImportFileControll(ImportInfo _info, ICanBeAccepted _canbeaccepted) : this()
    {
      m_info = _info;
      openFileDialog_for_import.InitialDirectory = m_info.InitialDirectory;
      openFileDialog_for_import.Filter = m_info.BrowseFilter;
      openFileDialog_for_import.DefaultExt = m_info.DefaultExt;
      textBox_info.Text = m_info.InformationText;
      propertyGrid_info.SelectedObject = m_info;
      m_canbeaccepted = _canbeaccepted;
      ActiveControl = textBox_filename;
    }
    #endregion

    #region private
    private ImportInfo m_info;
    private ICanBeAccepted m_canbeaccepted;

    #region handlers
    private void button1_Click(object sender, EventArgs e)
    {
      if (openFileDialog_for_import.ShowDialog() == DialogResult.OK)
        textBox_filename.Text = openFileDialog_for_import.FileName;
    }
    private void textBox_filename_TextChanged(object sender, EventArgs e)
    {
      m_info.Filename = textBox_filename.Text;
      m_canbeaccepted.CanBeAccepted(true);
    }
    #endregion

    #endregion
  }
}
