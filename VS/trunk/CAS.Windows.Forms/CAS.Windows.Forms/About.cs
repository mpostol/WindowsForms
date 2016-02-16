//<summary>
//  Title   : About control to be addend to products about form
//  System  : Microsoft Visual C# .NET 
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    MPostol 08-03-2007: Created.
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Drawing;
using System.Windows.Forms;
using CAS.Lib.CodeProtect.Controls;

namespace CAS.Lib.ControlLibrary
{
  public partial class About: UserControl
  {
    #region public
    /// <summary>
    /// Component shows CAS about information
    /// </summary>
    public About()
    {
      this.Cursor = Cursors.AppStarting;
      InitializeComponent();
    }
    /// <summary>
    /// Allows do show on the about window the assembly full name.
    /// </summary>
    public Licences SetLicenseLabel
    {
      set
      {
        if ( value == null )
          LabelProgramVer.Visible = false;
        else
          LabelProgramVer.Text = "Product: " + value.GetLicenseInfo();
      }
    }
    /// <summary>
    /// Displays name of the product license owner
    /// </summary>
    public string SetUser
    {
      set
      {
        if ( String.IsNullOrEmpty( value ) )
        {
          m_label_user.Visible = false;
          m_ProductLabel.Visible = false;
          m_label_user.Text = string.Empty;
        }
        else
          m_label_user.Text = value;
      }
    }
    /// <summary>
    /// Displays the product image on the about window
    /// </summary>
    public Image SetProductIcon
    {
      set
      {
        if ( value != null )
          m_pictureBox.Image = value;
      }
    }
    #endregion
    #region private
    private static void LinkActivator( object sender )
    {
      LinkLabel ml = (LinkLabel)sender;
      string todo = ml.Text.Substring( ml.LinkArea.Start, ml.LinkArea.Length );
      System.Diagnostics.Process.Start( todo );
      ml.LinkVisited = true;
    }
    #endregion
    #region eventhandlers
    private void linkLabel1_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
    {
      LinkActivator( sender );
    }
    private void m_linkLabel_email_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
    {
      LinkActivator( sender );
    }
    private void richTextBox_LinkClicked( object sender, LinkClickedEventArgs e )
    {
      System.Diagnostics.Process.Start( e.LinkText );
    }
    #endregion

    private void webBrowser_DocumentCompleted( object sender, WebBrowserDocumentCompletedEventArgs e )
    {
      this.Cursor = Cursors.Default;
    }
  }
}