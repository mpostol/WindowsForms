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

using CAS.Windows.Forms.CodeProtectControls;
using CAS.Windows.Forms.Properties;
using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  public partial class LicenseForm : Form
  {
    #region public API
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
    /// Adds an additional control.
    /// </summary>
    /// <value>The set additional control.</value>
    public UserControl SetAdditionalControl
    {
      set
      {
        this.m_TabControl.SuspendLayout();
        if (!m_TabControl.Controls.Contains(m_TB_License))
          m_TabControl.Controls.Add(m_TB_License);
        this.m_TB_License.Controls.Add(value);
        value.Dock = System.Windows.Forms.DockStyle.Fill;
        value.Location = new System.Drawing.Point(3, 3);
        value.Name = "m_Licences";
        value.Size = new System.Drawing.Size(904, 434);
        value.TabIndex = 0;
        this.m_TabControl.ResumeLayout();
      }// cn_TableLayoutPanel.
    }

    #endregion

    #region construtors
    /// <summary>
    /// Form shows CAS about information
    /// </summary>
    /// <param name="productImage">Icon of the product </param>
    /// <param name="cLicenseOwner">Owner name of the product license.</param>
    /// <param name="assembly">Assembly the about form is for.</param>
    public LicenseForm(Image productImage, string cLicenseOwner, Assembly assembly)
      : this()
    {
      Licenses l = new Licenses();
      if (assembly == null)
        throw (new ArgumentException("Assembly cannot be null"));
      licenseInformation = String.Format("User: {0}, Product: {1}", cLicenseOwner, l.GetLicenseInfo());
    }
    #endregion

    #region private
    private LicenseForm()
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
        MessageBox.Show(this, ex.Message, Application.ProductName,
          MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    private void toolStripButton_request_for_license_Click(object sender, EventArgs e)
    {
      string message;
      if (LicenceRequestMessageProvider != null)
      {
        message = LicenceRequestMessageProvider();
        if (string.IsNullOrEmpty(message))
        {
          if (m_TB_License != null)
            m_TabControl.SelectedTab = m_TabControl.TabPages[m_TB_License.Name];
          return;
        }
      }
      else
      {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(Resources.License_request_message);
        sb.AppendLine(licenseInformation);
        message = sb.ToString();
      }
      MessageBoxSentEmail.OpenEmailClient(Settings.Default.EmailAddress, "License Request", message);
    }
    private string licenseInformation;
    #endregion

  }
}