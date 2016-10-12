//<summary>
//  Title   : Company standard About form.
//  System  : Microsoft Visual C# .NET 2005
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    MPostol - 9-03-2007: created.
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Lib.CodeProtect;
using CAS.Windows.Forms.CodeProtectControls;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Class AboutForm - company standard About form.
  /// </summary>
  /// <seealso cref="System.Windows.Forms.Form" />
  public partial class AboutForm : Form
  {
    private string licenseInformation;
    /// <summary>
    /// delegate that provide license request message
    /// </summary>
    public delegate string LicenceRequestMessageProviderDelegate();
    /// <summary>
    /// Gets or sets the license request message provider.
    /// </summary>
    /// <value>The license request message provider.</value>
    public LicenceRequestMessageProviderDelegate LicenceRequestMessageProvider { set; private get; }
    /// <summary>
    /// Form shows CAS about information
    /// </summary>
    /// <param name="productImage">Icon of the product </param>
    /// <param name="licenseOwner">Owner name of the product license.</param>
    /// <param name="assembly">Assembly the about form is for.</param>
    public AboutForm(Image productImage, string licenseOwner, Assembly assembly)
      : this()
    {
      Licenses _licenses = new Licenses();
      if (assembly == null)
        throw (new ArgumentException("Assembly cannot be null"));
      m_about.SetProductIcon = productImage;
      m_about.SetUser = licenseOwner;
      m_about.SetLicenseLabel = _licenses;
      licenseInformation = String.Format("User: {0}, Product: {1}", licenseOwner, _licenses.GetLicenseInfo());
    }
    #region private
    private AboutForm()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Taken from http://www.codeproject.com/miscctrl/hyperlink.asp
    /// </summary>
    /// <param name="strPath"></param>
    /// <returns></returns>
    private bool GetMsinfo32Path(ref string strPath)
    {
      strPath = String.Empty;
      object objTmp = null;
      RegistryKey regKey = Registry.LocalMachine;
      if (regKey != null)
      {
        regKey = regKey.OpenSubKey("Software\\Microsoft\\Shared Tools\\MSInfo");
        if (regKey != null)
          objTmp = regKey.GetValue("Path");
        if (objTmp == null)
        {
          regKey = regKey.OpenSubKey("Software\\Microsoft\\Shared Tools Location");
          if (regKey != null)
          {
            objTmp = regKey.GetValue("MSInfo");
            if (objTmp != null)
              strPath = Path.Combine(objTmp.ToString(), "MSInfo32.exe");
          }
        }
        else
          strPath = objTmp.ToString();
        try
        {
          FileInfo fi = new FileInfo(strPath);
          return fi.Exists;
        }
        catch (ArgumentException)
        {
          strPath = string.Empty;
        }
      }
      return false;
    }
    /// <summary>
    /// Taken from: http://www.codeproject.com/miscctrl/hyperlink.asp
    /// </summary>
    /// <param name="strSysInfo"></param>
    private void StartSysInfo(string strSysInfo)
    {
      try
      {
        Process.Start(strSysInfo);
      }
      catch (Win32Exception ex)
      {
        MessageBox.Show(this, ex.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
    private void m_button_OK_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    private void m_button_Sysinfo_Click(object sender, EventArgs e)
    {
      string strSysInfo = string.Empty;
      if (GetMsinfo32Path(ref strSysInfo))
        StartSysInfo(strSysInfo);
    }
    private void m_OpenLogFolder_Click(object sender, EventArgs e)
    {
      string path = InstallContextNames.ApplicationDataPath + "\\log";
      try
      {
        using (Process process = Process.Start(@path)) { }
      }
      catch (Win32Exception)
      {
        MessageBox.Show("No Log folder exists under this link: " + path + " You can create this folder yourself.", "No Log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
      catch (Exception)
      {
        MessageBox.Show("An error during opening a log folder occurs and the log folder cannot be open", "Problem with log folder !", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
      }
    }
    #endregion
  }
}