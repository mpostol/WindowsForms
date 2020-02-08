//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using UAOOI.Windows.Forms.Diagnostics;
using UAOOI.Windows.Forms.Properties;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// Shape root graphical element
  /// </summary>
  public partial class Shape : UserControl
  {
    #region private
    private float mZoom;
    private bool isMoving = false;

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
      if (paths != null)
        foreach (GraphicsPath p in paths)
          path.AddPath(p, false);
      path.CloseAllFigures();
      Region = new Region(path);
    }
    /// <summary>
    /// Refreshes the path. this function recreate the shape depends on the control size
    /// </summary>
    protected virtual void RefreshPath() { }
    /// <summary>
    /// Recalculates the and check size of the shape. This method should be override by child class to checks any restrictions that size of the shape should preserve.
    /// </summary>
    protected virtual void RecalculateAndCheckSizeOfTheShape() { }
    /// <summary>
    /// Adds the path.
    /// </summary>
    /// <param name="path">The path.</param>
    protected void AddPath(GraphicsPath path)
    {
      if (path != null && path.PointCount > 0)
        paths.Add(path);
    }
    /// <summary>
    /// Gets my graphics settings.
    /// </summary>
    /// <value>My graphics settings.</value>
    protected GraphicsSettings MyGraphicsSettings { get; private set; }
    /// <summary>
    /// Handles the Resize event of the Shape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    private void Shape_Resize(object sender, EventArgs e)
    {
      try
      {
        RecalculateAndCheckSizeOfTheShape();
        RefreshPathRootShape();
        Invalidate();
      }
      catch (Exception ex)
      {
        string sourceName = GetType().FullName + ".Shape_Resize";
        MessageBox.Show(string.Format(Resources.ErrorMessage, sourceName), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 102, sourceName, ex.GetMessageWithExceptionNameFromExceptionIncludingInnerException());
      }
    }
    /// <summary>
    /// Handles the Paint event of the Shape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
    private void Shape_Paint(object sender, PaintEventArgs e)
    {
      try
      {
        if (paths != null)
        {
          foreach (GraphicsPath p in paths)
            if (p != null)
            {
              Graphics dc = e.Graphics;
              dc.SmoothingMode = SmoothingMode.AntiAlias;
              if (IsSelected)
                dc.DrawPath(MyGraphicsSettings.SelectionPen, p);
              else
                dc.DrawPath(MyGraphicsSettings.MainPen, p);
            }
        }
      }
      catch (Exception ex)
      {
        string sourceName = GetType().FullName + ".Shape_Paint";
        MessageBox.Show(string.Format(Resources.ErrorMessage, sourceName), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 140, sourceName, ex.GetMessageWithExceptionNameFromExceptionIncludingInnerException());
      }
    }
    private void Shape_Load(object sender, EventArgs e)
    {
      RefreshPathRootShape();
    }
    private void Shape_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
        isMoving = true;
    }
    private void Shape_MouseDown(object sender, MouseEventArgs e)
    {
      isMoving = false;
      UpdateStableLocation();
    }
    private void Shape_MouseUp(object sender, MouseEventArgs e)
    {
      isMoving = false;
      UpdateStableLocation();
    }
    private void Shape_LocationChanged(object sender, EventArgs e)
    {
      if (!isMoving)
        UpdateStableLocation();
    }
    private void Shape_Scroll(object sender, ScrollEventArgs e) { }
    #endregion private
    /// <summary>
    /// Gets or sets a value indicating whether this instance is selected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
    /// </value>
    public bool IsSelected { get; set; } = false;
    /// <summary>
    /// Initializes a new instance of the <see cref="Shape"/> class.
    /// </summary>
    public Shape()
    {
      MyGraphicsSettings = GraphicsSettings.Default;
      mZoom = 1;
      InitializeComponent();
      UpdateStableLocation();
      SetStyle(
        ControlStyles.UserPaint |
        ControlStyles.AllPaintingInWmPaint |
        ControlStyles.OptimizedDoubleBuffer, true);
    }
    /// <summary>
    /// Gets the stable location. This location is not changed while shape is moved.
    /// </summary>
    /// <value>The stable location.</value>
    public Point StableLocation { get; private set; }
    /// <summary>
    /// Updates the stable location.
    /// </summary>
    public void UpdateStableLocation()
    {
      StableLocation = new Point(Left, Top);
    }
    /// <summary>
    /// Gets or sets the zoom.
    /// </summary>
    /// <value>The zoom.</value>
    public float Zoom
    {
      get => mZoom;
      set
      {
        if (value <= 0)
          throw new ArgumentOutOfRangeException("Zoom allows only greater than 0 values");
        mZoom = value;
        MyGraphicsSettings = MyGraphicsSettings.GetGraphicsSettingsWithSpecifiedZoom(value);
        Size = new Size(0, 0);
      }
    }

  }
}
