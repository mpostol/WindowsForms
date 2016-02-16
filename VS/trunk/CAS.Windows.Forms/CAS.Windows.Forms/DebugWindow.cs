//<summary>
//  Title   : Debug window
//  System  : Microsoft Visual C# .NET 
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//  20081102: mzbrzezny: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Debug window - standard window for debugging output
  /// 
  /// 
  /// usage:
  /// <![CDATA[
  ///private DebugWindow debugWindow=null;
  ///private void debugWindowToolStripMenuItem_Click(object sender, EventArgs e)
  ///{
  ///  if (debugWindowToolStripMenuItem.Checked && debugWindow!=null)
  ///  {
  ///    debugWindow.Close();
  ///    debugWindowToolStripMenuItem.Checked = false;
  ///  }
  ///  else
  ///  {
  ///    if(debugWindow==null || debugWindow.IsDisposed)
  ///    {
  ///      debugWindow=new DebugWindow(this.Icon , 
  ///        new FormClosingEventHandler( debugWindow_FormClosing));
  ///    }
  ///    debugWindow.Show();
  ///    debugWindowToolStripMenuItem.Checked = true;
  ///  }
  ///}
  ///]]>
  /// </summary>
  public partial class DebugWindow : Form
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DebugWindow"/> class.
    /// </summary>
    public DebugWindow()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="DebugWindow"/> class.
    /// </summary>
    /// <param name="icon">The icon.</param>
    /// <param name="debugWindow_FormClosing">The debug window form closing handler.</param>
    public DebugWindow(Icon icon,FormClosingEventHandler debugWindow_FormClosing)
      : this()
    {
      if (icon!=null)
        this.Icon = icon;
      if(debugWindow_FormClosing!=null)
        this.FormClosing += debugWindow_FormClosing;
    }
    /// <summary>
    /// Appends to log.
    /// </summary>
    /// <param name="StringToBeAppended">The string to be appended.</param>
    public void AppendToLog(string StringToBeAppended)
    {
      if (this.textBox_debug.InvokeRequired)
      {
        if(!this.IsDisposed)
          this.Invoke(new AppendToLogDelegate(AppendToLog),new object[]{StringToBeAppended});
      }
      else
      {
        testAndCropAppendedLength(StringToBeAppended.Length);
        this.textBox_debug.Text += StringToBeAppended;
      }
    }

    /// <summary>
    /// Appends to log as line.
    /// </summary>
    /// <param name="StringLineToBeAppended">The string line to be appended.</param>
    public void AppendToLogLine(string StringLineToBeAppended)
    {
      AppendToLog(StringLineToBeAppended+"\r\n");
    }
    #region private
    private void toolStripButton_clear_Click(object sender, EventArgs e)
    {
      textBox_debug.Text = "";
    }
    private void toolStripButton_always_ontop_Click(object sender, EventArgs e)
    {
      if (this.TopMost)
      {
        this.TopMost = false;
        toolStripButton_alwaysontop.Checked = false;
        toolStripButton_alwaysontop.CheckState = CheckState.Unchecked;
      }
      else
      {
        this.TopMost = true;
        toolStripButton_alwaysontop.Checked = true;
        toolStripButton_alwaysontop.CheckState = CheckState.Checked;
      }
    }
    private void testAndCropAppendedLength(int lengthToBeTested)
    {
      if (textBox_debug.Text.Length + lengthToBeTested >= textBox_debug.MaxLength)
      {
        textBox_debug.Text=textBox_debug.Text.Remove(0, lengthToBeTested + 1);
      }
    }
    private delegate void AppendToLogDelegate(string AppendToLogText);
    #endregion private
  }
}
