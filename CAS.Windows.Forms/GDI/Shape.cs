//<summary>
//  Title   : Root Shape controll for all other objects
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20080304 - mzbrzezny: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Windows.Forms.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary.GDI
{
  /// <summary>
  /// Shape root graphical element
  /// </summary>
  public partial class Shape: UserControl
  {
    #region private
    private float mZoom;
    private GraphicsSettings myGraphicsSettings;
    private bool isMoving = false;
    private bool isSelected = false;
    private Point mStableLocation;
    /// <summary>
    /// Path that displays this shape
    /// </summary>
    private List<GraphicsPath> paths = null;
    /// <summary>
    /// Refreshes the path of the root shape.
    /// </summary>
    protected void RefreshPathRootShape()
    {
      paths = new List<GraphicsPath>();
      RefreshPath();
      GraphicsPath path = new GraphicsPath();
      if ( paths != null )
        foreach ( GraphicsPath p in paths )
          path.AddPath( p, false );
      path.CloseAllFigures();
      this.Region = new Region( path );
    }
    /// <summary>
    /// Refreshes the path. this function recreate the shape depends on the control size
    /// </summary>
    protected virtual void RefreshPath()
    {

    }
    /// <summary>
    /// Recalculates the and check size of the shape. This method should be override by child class to checks any restrictions that size of the shape should preserve.
    /// </summary>
    protected virtual void RecalculateAndCheckSizeOfTheShape()
    {
    }
    /// <summary>
    /// Adds the path.
    /// </summary>
    /// <param name="path">The path.</param>
    protected void AddPath( GraphicsPath path )
    {
      if ( path != null && path.PointCount > 0 )
        paths.Add( path );
    }
    /// <summary>
    /// Gets my graphics settings.
    /// </summary>
    /// <value>My graphics settings.</value>
    protected GraphicsSettings MyGraphicsSettings
    {
      get
      {
        return myGraphicsSettings;
      }
    }


    /// <summary>
    /// Handles the Resize event of the Shape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void Shape_Resize( object sender, EventArgs e )
    {
      try
      {
        RecalculateAndCheckSizeOfTheShape();
        RefreshPathRootShape();
        this.Invalidate();
      }
      catch ( Exception ex )
      {
        string sourceName = this.GetType().FullName + ".Shape_Resize";
        MessageBox.Show( String.Format( Resources.ErrorMessage, sourceName ), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error );
        TraceEvent.Tracer.TraceError( 102, sourceName,
          CAS.Lib.RTLib.Processes.TraceEvent.GetMessageWithExceptionNameFromExceptionIncludingInnerException( ex ) );
      }
    }

    /// <summary>
    /// Handles the Paint event of the Shape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
    private void Shape_Paint( object sender, PaintEventArgs e )
    {
      try
      {
        if ( paths != null )
        {
          foreach ( GraphicsPath p in paths )
            if ( p != null )
            {
              Graphics dc = e.Graphics;
              dc.SmoothingMode = SmoothingMode.AntiAlias;
              if ( isSelected )
                dc.DrawPath( myGraphicsSettings.SelectionPen, p );
              else
                dc.DrawPath( myGraphicsSettings.MainPen, p );
            }
        }
      }
      catch ( Exception ex )
      {
        string sourceName = this.GetType().FullName + ".Shape_Paint";
        MessageBox.Show( String.Format( Resources.ErrorMessage, sourceName ), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error );
        TraceEvent.Tracer.TraceError( 140, sourceName,
          CAS.Lib.RTLib.Processes.TraceEvent.GetMessageWithExceptionNameFromExceptionIncludingInnerException( ex ) );
      }
    }

    private void Shape_Load( object sender, EventArgs e )
    {
      RefreshPathRootShape();
    }
    private void Shape_MouseMove( object sender, MouseEventArgs e )
    {
      if ( e.Button == MouseButtons.Left )
        isMoving = true;
    }
    private void Shape_MouseDown( object sender, MouseEventArgs e )
    {
      isMoving = false;
      UpdateStableLocation();
    }
    private void Shape_MouseUp( object sender, MouseEventArgs e )
    {
      isMoving = false;
      UpdateStableLocation();
    }
    private void Shape_LocationChanged( object sender, EventArgs e )
    {
      if ( !isMoving )
        UpdateStableLocation();
    }
    private void Shape_Scroll( object sender, ScrollEventArgs e )
    {

    }
    #endregion private
    /// <summary>
    /// Gets or sets a value indicating whether this instance is selected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
    /// </value>
    public bool IsSelected
    {
      get
      {
        return isSelected;
      }
      set
      {
        isSelected = value;
      }
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Shape"/> class.
    /// </summary>
    public Shape()
    {
      myGraphicsSettings = GraphicsSettings.Default;
      mZoom = 1;
      InitializeComponent();

      UpdateStableLocation();
      SetStyle(
        ControlStyles.UserPaint |
        ControlStyles.AllPaintingInWmPaint |
        ControlStyles.OptimizedDoubleBuffer, true );
    }
    /// <summary>
    /// Gets the stable location. This location is not changed while shape is moved.
    /// </summary>
    /// <value>The stable location.</value>
    public Point StableLocation
    {
      get
      {
        return mStableLocation;
      }
    }
    /// <summary>
    /// Updates the stable location.
    /// </summary>
    public void UpdateStableLocation()
    {
      mStableLocation = new Point( Left, Top );
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
        this.Size = new Size( 0, 0 );
      }
    }

  }
}
