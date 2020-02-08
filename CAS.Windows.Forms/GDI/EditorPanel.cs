//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Drawing;
using System.Windows.Forms;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// Editor Panel - panel on which GDI+ GUI is displayed
  /// </summary>
  public partial class EditorPanel: Panel
  {

    #region members
    #region protected
    /// <summary>
    /// List of the shapes on that editor panel
    /// </summary>
    protected ShapeList shapes = new ShapeList();
    /// <summary>
    /// List of the connection on that editor panel
    /// </summary>
    protected ConnectionsList connections = new ConnectionsList();
    /// <summary>
    /// context menu of that panel
    /// </summary>
    protected ContextMenuStrip contextMenuStrip;
    #endregion protected
    #region private
    private StatusInformationClass mStatusInfo = new StatusInformationClass();
    private GraphicsSettings myGraphicsSettings;
    private System.ComponentModel.IContainer components;
    private ToolStripMenuItem toolStripMenuItem_RemoveSelectedConnection;
    private ToolStripMenuItem toolStripMenuItem_RemoveSelectedShape;
    private ToolStripSeparator toolStripSeparator1;
    private HotPointSelectableConnectable StartOfTheConnection = null;
    private ToolStripComboBox toolStripComboBox_zoom;
    private ToolStripSeparator toolStripSeparator2;
    private float mZoom = 1.0F;
    private Point mousePosition = new Point();
    #endregion private
    #endregion members

    #region private functions
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip( this.components );
      this.toolStripMenuItem_RemoveSelectedConnection = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem_RemoveSelectedShape = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.toolStripComboBox_zoom = new System.Windows.Forms.ToolStripComboBox();
      this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
      this.contextMenuStrip.SuspendLayout();
      this.SuspendLayout();
      // 
      // contextMenuStrip
      // 
      this.contextMenuStrip.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_RemoveSelectedConnection,
            this.toolStripMenuItem_RemoveSelectedShape,
            this.toolStripSeparator1,
            this.toolStripComboBox_zoom,
            this.toolStripSeparator2} );
      this.contextMenuStrip.Name = "contextMenuStrip";
      this.contextMenuStrip.Size = new System.Drawing.Size( 220, 85 );
      this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler( this.contextMenuStrip_Opening );
      // 
      // toolStripMenuItem_RemoveSelectedConnection
      // 
      this.toolStripMenuItem_RemoveSelectedConnection.Enabled = false;
      this.toolStripMenuItem_RemoveSelectedConnection.Name = "toolStripMenuItem_RemoveSelectedConnection";
      this.toolStripMenuItem_RemoveSelectedConnection.Size = new System.Drawing.Size( 219, 22 );
      this.toolStripMenuItem_RemoveSelectedConnection.Text = "RemoveSelectedConnection";
      this.toolStripMenuItem_RemoveSelectedConnection.Click += new System.EventHandler( this.toolStripMenuItem_RemoveSelectedConnection_Click );
      // 
      // toolStripMenuItem_RemoveSelectedShape
      // 
      this.toolStripMenuItem_RemoveSelectedShape.Name = "toolStripMenuItem_RemoveSelectedShape";
      this.toolStripMenuItem_RemoveSelectedShape.Size = new System.Drawing.Size( 219, 22 );
      this.toolStripMenuItem_RemoveSelectedShape.Text = "Remove Selected Shape";
      this.toolStripMenuItem_RemoveSelectedShape.ToolTipText = "Removes selected shape / ";
      this.toolStripMenuItem_RemoveSelectedShape.Click += new System.EventHandler( this.toolStripMenuItem_RemoveSelectedShape_Click );
      // 
      // toolStripSeparator1
      // 
      this.toolStripSeparator1.Name = "toolStripSeparator1";
      this.toolStripSeparator1.Size = new System.Drawing.Size( 216, 6 );
      // 
      // toolStripComboBox_zoom
      // 
      this.toolStripComboBox_zoom.Items.AddRange( new object[] {
            "Zoom:  10%",
            "Zoom:  20%",
            "Zoom:  30%",
            "Zoom:  40%",
            "Zoom:  50%",
            "Zoom:  60%",
            "Zoom:  70%",
            "Zoom:  80%",
            "Zoom:  90%",
            "Zoom: 100%",
            "Zoom: 110%",
            "Zoom: 120%",
            "Zoom: 130%",
            "Zoom: 140%",
            "Zoom: 150%",
            "Zoom: 160%",
            "Zoom: 170%",
            "Zoom: 180%",
            "Zoom: 190%",
            "Zoom: 200%"
            } );
      this.toolStripComboBox_zoom.Name = "toolStripComboBox_zoom";
      this.toolStripComboBox_zoom.Text = "Zoom: 100%";
      this.toolStripComboBox_zoom.Size = new System.Drawing.Size( 121, 21 );
      this.toolStripComboBox_zoom.ToolTipText = "Select Zoom";
      this.toolStripComboBox_zoom.SelectedIndexChanged += toolStripComboBox_zoom_change;
      // 
      // toolStripSeparator2
      // 
      this.toolStripSeparator2.Name = "toolStripSeparator2";
      this.toolStripSeparator2.Size = new System.Drawing.Size( 216, 6 );
      // 
      // EditorPanel
      // 
      this.AutoScroll = true;
      this.BackColor = System.Drawing.Color.White;
      this.ContextMenuStrip = this.contextMenuStrip;
      this.Paint += new System.Windows.Forms.PaintEventHandler( this.EditorPanel_Paint );
      this.Scroll += new System.Windows.Forms.ScrollEventHandler( this.EditorPanel_Scroll );
      this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.EditorPanel_MouseDown );
      this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.EditorPanel_MouseUp );
      this.MouseMove += new MouseEventHandler( EditorPanel_MouseMove );
      this.contextMenuStrip.ResumeLayout( false );
      this.ResumeLayout( false );

    }
    private void MoveToTopSelectedShape()
    {
      Shape sh = shapes.MoveToTopSelectedShapeAndReturnSelectedShape();
      if ( sh != null )
        this.Controls.SetChildIndex( sh, 0 );
    }
    private bool CreateNewConnectionValidateAndAdd( HotPoint StartOfTheConnection, HotPoint EndOfTheConnection, bool DoNotValidate )
    {
      if ( StartOfTheConnection == null || EndOfTheConnection == null )
        return false;
      Connection cn = CreateInstanceOfNewConnection( StartOfTheConnection, EndOfTheConnection );
      bool resultofvalidating = false;
      if ( !DoNotValidate )
        resultofvalidating = cn.Validate();
      if ( resultofvalidating || DoNotValidate )
      {
        connections.Add( cn );
      }
      return resultofvalidating || DoNotValidate;
    }
    private void EditorPanel_Scroll( object sender, ScrollEventArgs e )
    {
      foreach ( Shape shape in shapes )
        shape.UpdateStableLocation();
    }
    #region MouseEvents
    #region Shape event handlers
    private void Shape_MouseDown( object sender, MouseEventArgs e )
    {
      // Get the Shape that triggered this event.
      Shape control = (Shape)sender;
      if ( e.Button == MouseButtons.Right )
      {
        UpdateSelectedShape( control );
      }
      if ( e.Button == MouseButtons.Left )
      {
        control.Tag = new Point( e.X, e.Y );
        UpdateSelectedShape( control );
        //control.BackColor = Color.FromArgb(100, control.BackColor);
        if ( sender is ShapeWithHotpoints )
        {
          ShapeWithHotpoints sh = (ShapeWithHotpoints)sender;
          if ( !mStatusInfo.Connecting )
          {
            if ( sh.HotPointIsMatched )
            {
              StartOfTheConnection = sh.SelectedHotpoint;
              mStatusInfo.Connecting = true;
            }
            mStatusInfo.ShapeIsMoving = true;
          }
          else
          {
            if ( sh.HotPointIsMatched )
            {
              HotPointSelectableConnectable EndOfTheConnection = sh.SelectedHotpoint;
              bool resultofvalidating = CreateNewConnectionValidateAndAdd( StartOfTheConnection, EndOfTheConnection, false );
              if ( resultofvalidating )
              {
                StartOfTheConnection.IsConnected = true;
                EndOfTheConnection.IsConnected = true;
              }
              StartOfTheConnection = null;
              mStatusInfo.Connecting = false;
            }
          }
        }
      }
    }

    private void UpdateSelectedShape( Shape control )
    {
      shapes.DeselectAllShapes();
      if ( control != null )
        control.IsSelected = true;
      MyControllsHaveChanged( this, EventArgs.Empty );
      MoveToTopSelectedShape();
      this.Invalidate( true );
    }
    private void Shape_MouseUp( object sender, MouseEventArgs e )
    {
      if ( e.Button == MouseButtons.Left )
      {
      }
      mStatusInfo.ShapeIsMoving = false;
      this.Invalidate( true );
    }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity")]
    private void Shape_MouseMove( object sender, MouseEventArgs e )
    {
      lock ( this )
      {
        // Get the Shape that triggered this event.
        Shape sh = (Shape)sender;

        if ( !mStatusInfo.Connecting && mStatusInfo.ShapeIsMoving && sh == shapes.GetSelectedShape() )
        {
          // Get the offset.
          Point point = (Point)sh.Tag;
          // Move the control.
          int Left = e.Location.X + sh.Left - point.X;
          if ( Left < 0 )
            Left = 0;
          int Top = e.Location.Y + sh.Top - point.Y;
          if ( Top < 0 )
            Top = 0;
          sh.Left = Left;
          sh.Top = Top;
        }
      }
    }
    #endregion
    private void EditorPanel_MouseMove( object sender, MouseEventArgs e )
    {
      this.mousePosition = e.Location;
    }
    private void EditorPanel_MouseDown( object sender, MouseEventArgs e )
    {
      if ( e.Button == MouseButtons.Left )
      {
        connections.MatchAndSelectConnection( new Point( e.X, e.Y ) );
        UpdateSelectedShape( null );
      }
    }
    private void EditorPanel_MouseUp( object sender, MouseEventArgs e )
    {
      mStatusInfo.Connecting = false;
    }
    #endregion MouseEvents
    private void EditorPanel_Paint( object sender, PaintEventArgs e )
    {
      connections.Draw( e.Graphics, myGraphicsSettings );
    }
    private void EnableDisableRemoveConnectionMenuHelper()
    {
      if ( connections.IsAnySelected() )
      {
        this.toolStripMenuItem_RemoveSelectedConnection.Enabled = true;
      }
      else
      {
        this.toolStripMenuItem_RemoveSelectedConnection.Enabled = false;
      }
    }
    private void EnableDisableRemoveShapeMenuHelper()
    {
      if ( shapes.IsAnySelected() )
      {
        this.toolStripMenuItem_RemoveSelectedShape.Enabled = true;
      }
      else
      {
        this.toolStripMenuItem_RemoveSelectedShape.Enabled = false;
      }
    }
    private void MySomethingHasChangedHandler( object sender, EventArgs e )
    {
      this.Invalidate( true );
      EnableDisableRemoveConnectionMenuHelper();
    }
    private void MyControllsHaveChanged( object sender, EventArgs e )
    {
      EnableDisableRemoveConnectionMenuHelper();
      EnableDisableRemoveShapeMenuHelper();
    }
    private void contextMenuStrip_Opening( object sender, System.ComponentModel.CancelEventArgs e )
    {

    }
    private void toolStripMenuItem_RemoveSelectedShape_Click( object sender, EventArgs e )
    {
      this.Controls.Remove( shapes.GetSelectedShape() );
      shapes.RemoveSelectedShape();
    }
    private void toolStripMenuItem_RemoveSelectedConnection_Click( object sender, EventArgs e )
    {
      connections.RemoveSelectedConnection();
    }
    private void toolStripComboBox_zoom_change( object sender, EventArgs e )
    {
      this.Zoom = System.Convert.ToSingle( ( (String)toolStripComboBox_zoom.SelectedItem ).Substring( 6, 3 ) ) / 100.0F;
    }
    private void RaiseZoomIsChangedEvent()
    {
      if ( ZoomIsChanged != null )
      {
        ZoomIsChanged( this, EventArgs.Empty );
      }
    }
    #endregion private functions

    #region public functions
    /// <summary>
    /// Initializes a new instance of the <see cref="EditorPanel"/> class.
    /// </summary>
    public EditorPanel()
    {
      InitializeComponent();

      SetStyle( ControlStyles.UserPaint |
        ControlStyles.AllPaintingInWmPaint |
        ControlStyles.OptimizedDoubleBuffer, true );
      this.DoubleBuffered = true;
      myGraphicsSettings = GraphicsSettings.Default;
      connections.ListHasChanged += MySomethingHasChangedHandler;
      this.ControlAdded += MyControllsHaveChanged;
      this.ControlRemoved += MyControllsHaveChanged;
    }

    /// <summary>
    /// Adds the connection.
    /// </summary>
    /// <param name="ChildHotpoint">The child hotpoint.</param>
    /// <param name="ParentHotpoint">The parent hotpoint.</param>
    /// <param name="DoNotValidate">if set to <c>true</c> the validation of the connection is not performed.</param>
    public void AddConnection( HotPoint ChildHotpoint, HotPoint ParentHotpoint, bool DoNotValidate )
    {
      if ( !CreateNewConnectionValidateAndAdd( ChildHotpoint, ParentHotpoint, DoNotValidate ) )
        throw new Exception( "Connection cannot be added" );
    }
    /// <summary>
    /// Adds the shape.
    /// </summary>
    /// <param name="sh">The shape</param>
    public void AddShape( Shape sh )
    {
      this.SuspendLayout();
      // Attach shape  to the same set of event handlers.
      sh.MouseDown += new MouseEventHandler( Shape_MouseDown );
      sh.MouseUp += new MouseEventHandler( Shape_MouseUp );
      sh.MouseMove += new MouseEventHandler( Shape_MouseMove );
      if ( sh.Location.X < 0 && sh.Location.Y < 0 )
        sh.Location = mousePosition;
      sh.Zoom = this.Zoom;
      //add Shape to lists
      shapes.Add( sh );
      this.Controls.Add( sh );
      this.ResumeLayout( false );
    }
    /// <summary>
    /// Clears the connection list.
    /// </summary>
    public void ClearConnectionList()
    {
      connections.Clear();
    }
    /// <summary>
    /// Clears the shapes list.
    /// </summary>
    public void ClearShapesList()
    {
      foreach ( Shape sh in shapes )
      {
        this.Controls.Remove( sh );
        // Attach shape  to the same set of event handlers.
        sh.MouseDown -= new MouseEventHandler( Shape_MouseDown );
        sh.MouseUp -= new MouseEventHandler( Shape_MouseUp );
        sh.MouseMove -= new MouseEventHandler( Shape_MouseMove );

      }
      shapes.Clear();
    }
    /// <summary>
    /// Gets the status info.
    /// </summary>
    /// <value>The status info.</value>
    public StatusInformationClass StatusInfo
    {
      get
      {
        return mStatusInfo;
      }
    }
    /// <summary>
    /// Creates the instance of new connection.
    /// </summary>
    /// <param name="StartOfTheConnection">The start of the connection.</param>
    /// <param name="EndOfTheConnection">The end of the connection.</param>
    /// <returns></returns>
    protected virtual Connection CreateInstanceOfNewConnection( HotPoint StartOfTheConnection, HotPoint EndOfTheConnection )
    {
      return new Connection( StartOfTheConnection, EndOfTheConnection );
    }
    /// <summary>
    /// Gets or sets the zoom.
    /// </summary>
    /// <value>The zoom.</value>
    public float Zoom
    {
      get
      {
        return mZoom;
      }
      set
      {
        if ( value <= 0 )
          throw new ArgumentOutOfRangeException( "Zomm alows only greater than 0 values" );
        mZoom = value;
        myGraphicsSettings = myGraphicsSettings.GetGraphicsSettingsWithSpecifiedZoom( value );
        foreach ( Shape sh in shapes )
          sh.Zoom = value;
        RaiseZoomIsChangedEvent();
        this.Invalidate( true );
      }
    }
    /// <summary>
    /// Occurs when zoom is changed.
    /// </summary>
    public event EventHandler ZoomIsChanged;
    #endregion public functions

  }

}
