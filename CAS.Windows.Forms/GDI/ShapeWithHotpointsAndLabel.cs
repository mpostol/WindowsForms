//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using UAOOI.Windows.Forms.Diagnostics;
using UAOOI.Windows.Forms.Properties;

namespace UAOOI.Windows.Forms.GDI
{

  /// <summary>
  /// Shape with hot points and label on it
  /// </summary>
  public class ShapeWithHotpointsAndLabel : ShapeWithHotpoints
  {
    #region private
    private const float LabelSpaccingCoef = 1.1F;
    private string myLabel = "";
    private int mTextMargin = 12;
    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // ShapeWithHotpointsAndLabel
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.Name = "ShapeWithHotpointsAndLabel";
      this.Paint += new System.Windows.Forms.PaintEventHandler(this.ShapeWithHotpointsAndLabel_Paint);
      this.ResumeLayout(false);
      this.PerformLayout();

    }
    /// <summary>
    /// Refreshes the path. this function recreate the shape depends on the control size
    /// </summary>
    protected override void RefreshPath()
    {
      base.RefreshPath();
    }
    /// <summary>
    /// Recalculates the and check size of the shape. This method should be override by child class to checks any restrictions that size of the shape should preserve.
    /// </summary>
    protected override void RecalculateAndCheckSizeOfTheShape()
    {
      Size size = this.Size;
      SizeF labelsize = GetLabelSize();
      if (size != null && labelsize != null)
      {
        bool change = false;
        if (size.Width < labelsize.Width * LabelSpaccingCoef + mTextMargin)
        {
          size.Width = (int)(labelsize.Width * LabelSpaccingCoef + mTextMargin);
          change = true;
        }
        if (size.Height < labelsize.Height * LabelSpaccingCoef + mTextMargin)
        {
          size.Height = (int)(labelsize.Height * LabelSpaccingCoef + mTextMargin);
          change = true;
        }
        if (change)
          this.Size = size;
      }
      base.RecalculateAndCheckSizeOfTheShape();
    }
    /// <summary>
    /// Gets or sets the text label.
    /// </summary>
    /// <value>The text label.</value>
    protected string TextLabel
    {
      get
      {
        return myLabel;
      }
      set
      {
        myLabel = value;
        RecalculateAndCheckSizeOfTheShape();
      }
    }
    private void ShapeWithHotpointsAndLabel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {
      SizeF mylabelsize = GetLabelSize();
      if (mylabelsize != null && MyGraphicsSettings != null)
        e.Graphics.DrawString(myLabel, MyGraphicsSettings.MainFont, MyGraphicsSettings.TextBrush, new PointF(ClientRectangle.Width / 2 - mylabelsize.Width / 2, ClientRectangle.Height / 2 - mylabelsize.Height / 2));
    }
    /// <summary>
    /// Gets or sets the text margin in pixels.
    /// </summary>
    /// <value>The text margin in pixels.</value>
    protected int TextMarginInPixels
    {
      get
      {
        return mTextMargin;
      }
      set
      {
        mTextMargin = value;
        RecalculateAndCheckSizeOfTheShape();
      }
    }
    /// <summary>
    /// Gets the size of the label.
    /// </summary>
    /// <returns></returns>
    protected SizeF GetLabelSize()
    {
      if (MyGraphicsSettings == null)
        return new SizeF();
      try
      {
        Graphics g = this.CreateGraphics();
        SizeF size = g.MeasureString(myLabel, MyGraphicsSettings.MainFont);
        g.Dispose();
        return size;
      }
      catch (Exception ex)
      {
        string sourceName = this.GetType().FullName + ".GetLabelSize";
        MessageBox.Show(String.Format(Resources.ErrorMessage, sourceName), Resources.ErrorMessageCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        AssemblyTraceEvent.Tracer.TraceEvent(TraceEventType.Error, 130, sourceName, ex.GetMessageWithExceptionNameFromExceptionIncludingInnerException());
        return new SizeF();
      }
    }
    #endregion private

    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeWithHotpointsAndLabel"/> class.
    /// </summary>
    public ShapeWithHotpointsAndLabel()
    {
      InitializeComponent();
    }
    #endregion public

  }
}
