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
  /// Window to display information
  /// </summary>
  public partial class LogMessageWindow: Form
  {
    /// <summary>
    /// default constructor
    /// </summary>
    public LogMessageWindow()
    {
      InitializeComponent();
    }
    /// <summary>
    /// constructor
    /// <param name="message">message to be shown</param>
    /// </summary>
    public LogMessageWindow(string message)
    {
      InitializeComponent();
      SetLogMessage(message);
    }
    private void button_ok_Click(object sender, EventArgs e)
    {
      this.Close();
    }
    /// <summary>
    /// this function sets the log message
    /// </summary>
    /// <param name="message">message to be shown</param>
    public void SetLogMessage(string message)
    {
      this.textBox_log.Text = message;
    }
  }
}