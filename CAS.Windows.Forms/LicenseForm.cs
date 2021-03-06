//___________________________________________________________________________________
//
//  Copyright (C) 2021, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using UAOOI.Windows.Forms.Properties;

namespace UAOOI.Windows.Forms
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
        m_TabControl.SuspendLayout();
        if (!m_TabControl.Controls.Contains(m_TB_License))
          m_TabControl.Controls.Add(m_TB_License);
        m_TB_License.Controls.Add(value);
        value.Dock = System.Windows.Forms.DockStyle.Fill;
        value.Location = new System.Drawing.Point(3, 3);
        value.Name = "m_Licences";
        value.Size = new System.Drawing.Size(904, 434);
        value.TabIndex = 0;
        m_TabControl.ResumeLayout();
      }// cn_TableLayoutPanel.
    }

    #endregion public API

    #region constructors

    /// <summary>
    /// Form shows CAS about information
    /// </summary>
    /// <param name="productImage">Icon of the product </param>
    /// <param name="assembly">Assembly the about form is for.</param>
    public LicenseForm(Image productImage, Assembly assembly) : this()
    {
      if (assembly == null)
        throw (new ArgumentException("Assembly cannot be null"));
      AssemblyName assemblyName = assembly.GetName();
      licenseInformation = string.Format($"Product: {assemblyName.FullName}/{assemblyName.Version}");
    }

    #endregion constructors

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
      strPath = string.Empty;
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
      Close();
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

    #endregion private
  }
}