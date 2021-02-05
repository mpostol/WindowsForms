//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Drawing;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  public partial class About : UserControl
  {
    #region public

    /// <summary>
    /// Component shows CAS about information
    /// </summary>
    public About()
    {
      Cursor = Cursors.AppStarting;
      InitializeComponent();
    }

    /// <summary>
    /// Allows do show on the about window the assembly full name.
    /// </summary>
    internal string SetLicenseLabel
    {
      set => LabelProgramVer.Text = $"Product: {value}";
    }

    /// <summary>
    /// Displays the product image on the about window
    /// </summary>
    public Image SetProductIcon
    {
      set
      {
        if (value != null)
          m_pictureBox.Image = value;
      }
    }

    #endregion public

    #region private

    private static void LinkActivator(object sender)
    {
      LinkLabel ml = (LinkLabel)sender;
      string todo = ml.Text.Substring(ml.LinkArea.Start, ml.LinkArea.Length);
      System.Diagnostics.Process.Start(todo);
      ml.LinkVisited = true;
    }

    private void webBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
      Cursor = Cursors.Default;
    }

    private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      LinkActivator(sender);
    }

    private void m_linkLabel_email_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      LinkActivator(sender);
    }

    private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
    {
      System.Diagnostics.Process.Start(e.LinkText);
    }

    #endregion private
  }
}