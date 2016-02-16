//<summary>
//  Title   : Import filename with option component
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    Mzbrzezny - 20070615: created
//    <Author> - <date>:
//    <description>
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http:\\www.cas.eu
//</summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CAS.Lib.RTLib;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Controll That is responsible for selecting file to import
  /// </summary>
  public partial class ImportFileControll: UserControl
  {
    #region members
    private ImportInfo m_info;
    private ICanBeAccepted m_canbeaccepted;
    #endregion
    /// <summary>
    /// abstract class that contains main data for the form and import settings
    /// </summary>
    public abstract class ImportInfo
    {
      #region private
      string m_filename;
      #endregion
      /// <summary>
      /// the name for that import
      /// </summary>
      [BrowsableAttribute( false )]
      public abstract string ImportName
      {
        get;
      }
      /// <summary>
      /// default directory for importing file
      /// </summary>
      [BrowsableAttribute( false )]
      public abstract string InitialDirectory
      {
        get;
      }
      /// <summary>
      /// deafult browse filter for the dialog which is used for selecting a file
      /// </summary>
      [BrowsableAttribute( false )]
      public abstract string BrowseFilter
      {
        get;
      }
      /// <summary>
      /// deafult extension for the dialog which is used for selecting a file
      /// </summary>
      [BrowsableAttribute( false )]
      public abstract string DefaultExt
      {
        get;
      }
      /// <summary>
      /// text that is used to show the information about this importing function
      /// </summary>
      [BrowsableAttribute( false )]
      public abstract string InformationText
      {
        get;
      }
      /// <summary>
      /// selected filename
      /// </summary>
      [BrowsableAttribute( false )]
      public string Filename
      {
        get
        {
          return m_filename;
        }
        set
        {
          m_filename = value;
        }
      }
    }
    #region creator
    internal ImportFileControll()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Constructor for the import File Dialog
    /// </summary>
    /// <param name="_info">object <see cref="ImportInfo"/> that contains all setting for this import tool</param>
    /// <param name="_canbeaccepted">this is link ti the main window to enable ok button if settings are correct. 
    /// Pleas see <see cref="ICanBeAccepted" /></param>
    public ImportFileControll(ImportInfo _info, ICanBeAccepted _canbeaccepted):this()
     {
      m_info = _info;
      openFileDialog_for_import.InitialDirectory = m_info.InitialDirectory;
      openFileDialog_for_import.Filter = m_info.BrowseFilter;
      openFileDialog_for_import.DefaultExt = m_info.DefaultExt;
      textBox_info.Text = m_info.InformationText;
      propertyGrid_info.SelectedObject = m_info;
      m_canbeaccepted = _canbeaccepted;
      this.ActiveControl = textBox_filename;
    }
    #endregion
    #region events
    private void button1_Click( object sender, EventArgs e )
    {
      if ( openFileDialog_for_import.ShowDialog() == DialogResult.OK )
      {
        this.textBox_filename.Text = openFileDialog_for_import.FileName;
      }
    }
    #endregion

    private void textBox_filename_TextChanged( object sender, EventArgs e )
    {
      m_info.Filename = this.textBox_filename.Text;
      m_canbeaccepted.CanBeAccepted( true );
    }
  }
}
