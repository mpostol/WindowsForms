using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Window to dispaly information
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
    /// <param name="message">message to be shouwn</param>
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
    /// <param name="message">message to be shouwn</param>
    public void SetLogMessage(string message)
    {
      this.textBox_log.Text = message;
    }
  }
}