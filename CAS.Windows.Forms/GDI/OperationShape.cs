//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.Lib.RTLib.Processes;
using CAS.Windows.Forms.Properties;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary.GDI
{
  /// <summary>
  /// Shape for operation
  /// </summary>
  public class OperationShape : ShapeWithHotpointsAndLabel
  {
    private const float m_InputSpacingCoefficient = 1.3F;
    private const int ConnectorLengthInPercent = 25;
    private const int DefaultMainWidth = 40;
    private const int DefaultMainHeight = 40;
    private int MyMainWidth = DefaultMainWidth;
    private int MyMainHeight = DefaultMainHeight;
    private int MyConnectorSizeInPixels = (int)(ConnectorLengthInPercent * DefaultMainWidth / 100);
    private ToolTip toolTip_main;
    private System.ComponentModel.IContainer components;
    private int MyConnectorSizeInPixelsPrevious = 0;
    /// <summary>
    /// Refreshes the path. this function recreate the shape depends on the control size
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity")]
    protected override void RefreshPath()
    {
      lock (this)
      {
        try
        {
          AddPath(RefreshPathRectangle(MyConnectorSizeInPixels));
          AddPath(RefreshPathLeftInputs(MyConnectorSizeInPixels));
          AddPath(RefreshPathTopInputs(MyConnectorSizeInPixels));
          AddPath(RefreshPathRightInputs(MyConnectorSizeInPixels));
          AddPath(RefreshPathBottomInputs(MyConnectorSizeInPixels));
        }
        catch (Exception ex)
        {
          string sourceName = this.GetType().FullName + ".RefreshPath";
          MessageBox.Show(String.Format(Resources.ErrorMessage, sourceName), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
          AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 61, sourceName, TraceEvent.GetMessageWithExceptionNameFromExceptionIncludingInnerException(ex));
        }
        base.RefreshPath();
      }
    }
    /// <summary>
    /// Recalculates the and check size of the shape. This method should be override by child class to checks any restrictions that size of the shape should preserve.
    /// </summary>
    protected override void RecalculateAndCheckSizeOfTheShape()
    {
      try
      {
        #region main_function
        if (this.Size != null)
        {
          MyMainWidth = this.Size.Width;
          MyMainHeight = this.Size.Height;
        }
        if (MyMainWidth < (int)(DefaultMainWidth * Zoom))
          MyMainWidth = (int)(DefaultMainWidth * Zoom);
        if (MyMainHeight < (int)(DefaultMainHeight * Zoom))
          MyMainHeight = (int)(DefaultMainHeight * Zoom);
        MyConnectorSizeInPixels = (int)(ConnectorLengthInPercent * DefaultMainWidth * Zoom / 100);
        if ((MyConnectorSizeInPixelsPrevious - MyConnectorSizeInPixels) != 0)
        {
          MyConnectorSizeInPixelsPrevious = MyConnectorSizeInPixels;
          TextMarginInPixels = (int)(MyConnectorSizeInPixels * 2F);
        }
        //sprawdzamy czy nie trzeba poserzyc ze wzgledu na ilosc imputow
        float leftrightsize_base = 2;
        float topbottomsize_base = 2;
        if (HotpointsInputs != null)
        {
          if (HotpointsInputs.ContainsKey(HotpointType.Right) && HotpointsInputs[HotpointType.Right] != null)
            leftrightsize_base = Math.Max(
            HotpointsInputs[HotpointType.Right].Length + 1,//+1 - because space for one above and one under the controlis necessary
            leftrightsize_base);
          if (HotpointsInputs.ContainsKey(HotpointType.Left) && HotpointsInputs[HotpointType.Left] != null)
            leftrightsize_base = Math.Max(
            HotpointsInputs[HotpointType.Left].Length + 1,//+1 - because space for one above and one under the controlis necessary
            leftrightsize_base);
          if (HotpointsInputs.ContainsKey(HotpointType.Bottom) && HotpointsInputs[HotpointType.Bottom] != null)
            topbottomsize_base = Math.Max(
            HotpointsInputs[HotpointType.Bottom].Length + 1,//+1 - because space for one above and one under the controlis necessary
            topbottomsize_base);
          if (HotpointsInputs.ContainsKey(HotpointType.Top) && HotpointsInputs[HotpointType.Top] != null)
            topbottomsize_base = Math.Max(
            HotpointsInputs[HotpointType.Top].Length + 1,//+1 - because space for one above and one under the controlis necessary
            topbottomsize_base);
        }
        int leftrightsize = (int)(leftrightsize_base * m_InputSpacingCoefficient *
          MyConnectorSizeInPixels);
        int topbottomsize = (int)(topbottomsize_base * m_InputSpacingCoefficient *
          MyConnectorSizeInPixels);
        if (leftrightsize < DefaultMainHeight * Zoom)
          leftrightsize = (int)(DefaultMainHeight * Zoom);
        if (topbottomsize < DefaultMainWidth * Zoom)
          topbottomsize = (int)(DefaultMainWidth * Zoom);

        if (MyMainWidth < topbottomsize)
          MyMainWidth = topbottomsize;
        if (MyMainHeight < leftrightsize)
          MyMainHeight = leftrightsize;
        if (this.Size == null || this.Size.Width != MyMainWidth || this.Size.Height != MyMainHeight)
          this.Size = new System.Drawing.Size(MyMainWidth, MyMainHeight);
        #endregion main_function
      }
      catch (Exception ex)
      {
        string sourceName = this.GetType().FullName + ".RecalculateAndCheckSizeOfTheShape";
        MessageBox.Show(String.Format(Resources.ErrorMessage, sourceName), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 118, sourceName, TraceEvent.GetMessageWithExceptionNameFromExceptionIncludingInnerException(ex));
      }
      base.RecalculateAndCheckSizeOfTheShape();
    }
    private GraphicsPath RefreshPathBottomInputs(int MyConnectorSize)
    {
      if (HotpointsInputs != null && HotpointsInputs.ContainsKey(HotpointType.Bottom) && HotpointsInputs[HotpointType.Bottom] != null && HotpointsInputs[HotpointType.Bottom].Length > 0)
      {
        throw new NotImplementedException();
      }
      return null;
    }

    private GraphicsPath RefreshPathTopInputs(int MyConnectorSize)
    {
      if (HotpointsInputs != null && HotpointsInputs.ContainsKey(HotpointType.Top) && HotpointsInputs[HotpointType.Top] != null && HotpointsInputs[HotpointType.Top].Length > 0)
      {
        throw new NotImplementedException();
      }
      return null;
    }
    private GraphicsPath RefreshPathRightInputs(int MyConnectorSize)
    {
      if (HotpointsInputs != null && HotpointsInputs.ContainsKey(HotpointType.Right) && HotpointsInputs[HotpointType.Right] != null
        && HotpointsInputs[HotpointType.Right].Length > 0)
      {
        GraphicsPath p = new GraphicsPath();
        //RightInputs
        for (int i = 0; i < HotpointsInputs[HotpointType.Right].Length; i++)
        {
          Point A = new Point(this.ClientRectangle.X + this.ClientRectangle.Width - MyConnectorSize,
            this.ClientRectangle.Y + MyConnectorSize + i * MyConnectorSize);
          Point B = new Point(this.ClientRectangle.X + this.ClientRectangle.Width,
            this.ClientRectangle.Y + MyConnectorSize + MyConnectorSize / 2 + i * MyConnectorSize);
          Point C = new Point(this.ClientRectangle.X + this.ClientRectangle.Width - MyConnectorSize,
            this.ClientRectangle.Y + 2 * MyConnectorSize + i * MyConnectorSize);
          p.AddLine(A, B);
          p.AddLine(B, C);
          p.AddLine(C, A);
          HotpointsInputs[HotpointType.Right][i] = new HotPointSelectableConnectable(
            this, B, new Size(2 * MyConnectorSize, MyConnectorSize), true, true,
            HotpointType.Right, i);
        }
        return p;
      }
      return null;
    }

    private GraphicsPath RefreshPathLeftInputs(int MyConnectorSize)
    {
      if (HotpointsInputs != null && HotpointsInputs.ContainsKey(HotpointType.Left) && HotpointsInputs[HotpointType.Left] != null
        && HotpointsInputs[HotpointType.Left].Length > 0)
      {
        GraphicsPath p = new GraphicsPath();
        //LeftInputs
        for (int i = 0; i < HotpointsInputs[HotpointType.Left].Length; i++)
        {
          Point A = new Point(this.ClientRectangle.X + MyConnectorSize,
            this.ClientRectangle.Y + MyConnectorSize + i * MyConnectorSize);
          Point B = new Point(this.ClientRectangle.X,
            this.ClientRectangle.Y + MyConnectorSize + MyConnectorSize / 2 + i * MyConnectorSize);
          Point C = new Point(this.ClientRectangle.X + MyConnectorSize,
            this.ClientRectangle.Y + 2 * MyConnectorSize + i * MyConnectorSize);
          p.AddLine(A, B);
          p.AddLine(B, C);
          p.AddLine(C, A);
          HotpointsInputs[HotpointType.Left][i] = new HotPointSelectableConnectable(
            this, B, new Size(2 * MyConnectorSize, MyConnectorSize), true, true,
            HotpointType.Left, i);
        }
        return p;
      }
      return null;
    }

    private GraphicsPath RefreshPathRectangle(int MyConnectorSize)
    {
      if (this.ClientRectangle == null)
        return null;
      GraphicsPath p = new GraphicsPath();
      //rectangle:
      Point A = new Point(this.ClientRectangle.X + MyConnectorSize,
        this.ClientRectangle.Y + MyConnectorSize);
      Size size = new Size(this.ClientRectangle.Width - 2 * MyConnectorSize, this.ClientRectangle.Height - 2 * MyConnectorSize);
      Rectangle rect = new Rectangle(A, size);
      p.AddRectangle(rect);
      return p;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="OperationShape"/> class.
    /// </summary>
    /// <param name="NumberOfInputs">The number of inputs.</param>
    /// <param name="NumberOfOutputs">The number of outputs.</param>
    /// <param name="NumberOfTopInputs">The number of top inputs.</param>
    /// <param name="NumberOfBottomInputs">The number of bottom inputs.</param>
    /// <param name="MainShapeColor">the main color of the shape.</param>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2002:DoNotLockOnObjectsWithWeakIdentity")]
    public OperationShape(int NumberOfInputs, int NumberOfOutputs, int NumberOfTopInputs, int NumberOfBottomInputs, Color MainShapeColor)
      : base()
    {
      lock (this)
      {
        this.InitializeComponent();
        HotpointsInputs = new HotPointSelectableConnectableArray();
        HotpointsInputs.Add(HotpointType.Left, new HotPointSelectableConnectable[NumberOfInputs]);
        HotpointsInputs.Add(HotpointType.Right, new HotPointSelectableConnectable[NumberOfOutputs]);
        HotpointsInputs.Add(HotpointType.Top, new HotPointSelectableConnectable[NumberOfTopInputs]);
        HotpointsInputs.Add(HotpointType.Bottom, new HotPointSelectableConnectable[NumberOfBottomInputs]);
        this.BackColor = MainShapeColor;
        MyMainWidth = (int)(DefaultMainWidth * Zoom);
        MyMainHeight = (int)(DefaultMainHeight * Zoom);
        this.Size = new System.Drawing.Size(MyMainWidth, MyMainWidth);
      }
    }

    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.toolTip_main = new System.Windows.Forms.ToolTip(this.components);
      this.SuspendLayout();
      // 
      // OperationShape
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "OperationShape";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.OperationShape_Paint);
      this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OperationShape_MouseDown);
      this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OperationShape_MouseUp);
      this.ResumeLayout(false);

    }

    /// <summary>
    /// Handles the MouseDown event of the OperationShape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void OperationShape_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
    {
    }

    private void OperationShape_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
    }

    private void OperationShape_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
    {
    }

    /// <summary>
    /// Changes the number of inputs.
    /// </summary>
    /// <param name="HotpointType">Type of the hotpoint.</param>
    /// <param name="NewInputNumber">The new input number.</param>
    protected void ChangeNumberOfInputs(HotpointType HotpointType, int NewInputNumber)
    {
      if (HotpointsInputs == null)
        return;
      HotpointsInputs.Remove(HotpointType);
      HotpointsInputs.Add(HotpointType, new HotPointSelectableConnectable[NewInputNumber]);
      this.Size = new Size(0, 0);
      RefreshPathRootShape();
    }
    /// <summary>
    /// Gets or sets the tool tip text.
    /// </summary>
    /// <value>The tool tip text.</value>
    protected string ToolTipText
    {
      get
      {
        return this.toolTip_main.GetToolTip(this);
      }
      set
      {
        this.toolTip_main.SetToolTip(this, value);
      }
    }
  }
}
