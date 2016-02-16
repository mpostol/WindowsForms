//<summary>
//  Title   : HotPoint that can be selected and connected
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20080305 - mzbrzezny - created
//    <date> - <author>: <description>
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System.Drawing;
using System.Drawing.Drawing2D;

namespace CAS.Lib.ControlLibrary.GDI
{
  /// <summary>
  /// HotPoint that can be selected and connected
  /// </summary>
  public class HotPointSelectableConnectable: HotPoint, IIsSelected, IIsConnected,IDraw
  {
    #region Private
    private bool isselected = false;
    private bool isconnected = false;
    #endregion //Private
    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="HotPointSelectableConnectable"/> class.
    /// </summary>
    /// <param name="parrent">The parrentshape.</param>
    /// <param name="point">The point.</param>
    /// <param name="size">The size.</param>
    /// <param name="IsHorizontal">if set to <c>true</c> [is horizontal].</param>
    /// <param name="IsFixed">if set to <c>true</c> [is fixed].</param>
    /// <param name="Type">The type.</param>
    /// <param name="NumberInParentShape">The number in parent shape.</param>
    internal HotPointSelectableConnectable( ShapeWithHotpoints parrent, Point point, Size size, bool IsHorizontal, bool IsFixed,
      HotpointType Type, int NumberInParentShape )
      : base( parrent, size, point, IsHorizontal, IsFixed,Type, NumberInParentShape )
    {
    }
    #region IIsSelected Members
    /// <summary>
    /// Gets a value indicating whether this instance is selected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
    /// </value>
    public bool IsSelected
    {
      get { return isselected; }
      set { isselected = value; }
    }
    #endregion IIsSelected Members
    #region IIsConnected Members
    /// <summary>
    /// Gets a value indicating whether this instance is connected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is connected; otherwise, <c>false</c>.
    /// </value>
    public bool IsConnected
    {
      get { return isconnected; }
      set { isconnected=value; }
    }
    #endregion IIsConnected Members
    #region IDraw Members
    /// <summary>
    /// Draws the object on the specified dc.
    /// </summary>
    /// <param name="dc">The DeviceContext.</param>
    /// <param name="MyGraphicsSettings">The graphics settings.</param>
    public void Draw(Graphics dc, GraphicsSettings MyGraphicsSettings)
    {
      if (isselected)
      {
        dc.SmoothingMode = SmoothingMode.AntiAlias;
        dc.FillRectangle(MyGraphicsSettings.SelectionBrush, MyRectangle);
        dc.DrawRectangle(MyGraphicsSettings.SelectionPen, MyRectangle);
      }
    }
    #endregion IDraw Members
    #endregion public
  }
}
