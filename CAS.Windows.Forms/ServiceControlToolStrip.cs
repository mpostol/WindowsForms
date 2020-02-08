//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms
{

  #region public

  /// <summary>
  /// ToolStrip to control the service
  /// </summary>
  public partial class ServiceControlToolStrip : ToolStrip
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ServiceControlToolStrip"/> class.
    /// </summary>
    public ServiceControlToolStrip()
    {
      InitializeComponent();
      ServiceResponseTimeout = new TimeSpan(0, 0, 0, 10); //default timeout 10s
      this.MouseEnter += new EventHandler(ServiceControlToolStrip_MouseEnter);
    }
    /// <summary>
    /// Gets or sets the service response timeout.
    /// </summary>
    /// <value>The service response timeout.</value>
    public TimeSpan ServiceResponseTimeout { get; set; }
    /// <summary>
    /// Gets or sets the text associated with this control.
    /// </summary>
    /// <value></value>
    /// <returns>
    /// The text associated with this control.
    /// </returns>
    public new string Text
    {
      get
      {
        return this.toolStripLabel_main.Text;
      }
      set
      {
        this.toolStripLabel_main.Text = value;
        base.Text = value;
      }
    }
    /// <summary>
    /// Gets or sets the name of the service controlled by this ToolStrip.
    /// </summary>
    /// <value>The name of the service.</value>
    public string ServiceName
    {
      get
      {
        return serviceController.ServiceName;
      }
      set
      {
        serviceController.ServiceName = value;
        UpdateServiceStatus();
      }
    }
    #endregion

    #region event handlers
    private void toolStripButton_restart_Click( object sender, System.EventArgs e )
    {
      try
      {
        if ( serviceController.Status != ServiceControllerStatus.Stopped )
        {
          this.UpdateServiceStatus();
          serviceController.Stop();
          WaitForMyServiceStatus( ServiceControllerStatus.Stopped );
        }
        this.UpdateServiceStatus();
        if ( serviceController.Status != ServiceControllerStatus.Running )
        {
          serviceController.Start();
          WaitForMyServiceStatus( ServiceControllerStatus.Running );
        }
        this.UpdateServiceStatus();
      }
      catch ( Exception ex )
      {
        ExceptionInfo( ex );
      }
    }
    private void toolStripButton_stop_Click( object sender, System.EventArgs e )
    {
      try
      {
        this.UpdateServiceStatus();
        if ( serviceController.Status != ServiceControllerStatus.Stopped )
        {
          serviceController.Stop();
          WaitForMyServiceStatus( ServiceControllerStatus.Stopped );
        }
        this.UpdateServiceStatus();
      }
      catch ( Exception ex )
      {
        ExceptionInfo( ex );
      }
    }
    private void toolStripButton_start_Click( object sender, System.EventArgs e )
    {
      try
      {
        this.UpdateServiceStatus();
        if ( serviceController.Status != ServiceControllerStatus.Running )
        {
          serviceController.Start();
          WaitForMyServiceStatus( ServiceControllerStatus.Running );
        }
        this.UpdateServiceStatus();
      }
      catch ( Exception ex )
      {
        ExceptionInfo( ex );
      }
    }
    private void ServiceControlToolStrip_MouseEnter( object sender, EventArgs e )
    {
      UpdateServiceStatus();
    }
    private void toolStripLabel_status_MouseEnter( object sender, System.EventArgs e )
    {
      UpdateServiceStatus();
    }
    #endregion event handlers

    #region private
    private static void ExceptionInfo( Exception ex )
    {
      string info = ex.Message;
      if ( ex.InnerException != null )
        info += "\r\n" + ex.InnerException.Message;
      MessageBox.Show( info );
    }
    private void WaitForMyServiceStatus( ServiceControllerStatus status )
    {
      Cursor myCursor = this.Cursor;
      this.Cursor = Cursors.WaitCursor;
      serviceController.WaitForStatus( status,ServiceResponseTimeout );
      this.Cursor = myCursor;
    }
    private void UpdateServiceStatus()
    {
      try
      {
        this.serviceController.Refresh();
        this.toolStripLabel_status.Text = serviceController.Status.ToString();
      }
      catch
      {
        this.toolStripLabel_status.Text = "";
      }
    }
    #endregion private

  }
}
