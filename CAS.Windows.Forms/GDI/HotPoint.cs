//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Drawing;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// HotPoint - point that could be clicked/selected - this is standard point with rectangle arround to easier click on it detection
  /// </summary>
  public class HotPoint:IMatch
  {

    #region private
    private bool mIsHorizontal;
    private bool mIsFixed;
    private ShapeWithHotpoints parrentShape;
    private Size mySize;
    private Point myCenterPoint;
    private Rectangle myRectangle;
    private HotpointType myType;
    private int myNumberInParentShape;
    /// <summary>
    /// Gets the rectangle of the hotpoint.
    /// </summary>
    /// <value>The rectangle.</value>
    protected Rectangle MyRectangle
    {
      get { return myRectangle; }
    }
    #endregion
    
    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="HotPoint"/> class.
    /// </summary>
    /// <param name="parrent">The parrent shape.</param>
    /// <param name="MySize">the size of hotpoint.</param>
    /// <param name="point">The center point.</param>
    /// <param name="IsHorizontal">if set to <c>true</c> [is horizontal].</param>
    /// <param name="IsFixed">if set to <c>true</c> [is fixed].</param>
    /// <param name="Type">The type of the Hotpoint.</param>
    /// <param name="NumberInParentShape">The number in parent shape.</param>
    public HotPoint(ShapeWithHotpoints parrent, 
      Size MySize,  Point point, bool IsHorizontal, bool IsFixed,
      HotpointType Type, int NumberInParentShape )
    {
      parrentShape = parrent;
      this.mySize = MySize;
      MyCenterPoint = point;
      mIsHorizontal = IsHorizontal;
      mIsFixed = IsFixed;
      myType = Type;
      myNumberInParentShape = NumberInParentShape;
    }
    /// <summary>
    /// Gets the parrent shape.
    /// </summary>
    /// <value>The parrent shape.</value>
    public ShapeWithHotpoints ParrentShape
    {
      get
      {
        return parrentShape;
      }
    }
    /// <summary>
    /// Gets or sets the center point.
    /// </summary>
    /// <value>The center point.</value>
    public Point MyCenterPoint
    {
      get
      {
        return myCenterPoint;
      }
      set
      {
        myCenterPoint = value;
        int x = myCenterPoint.X - mySize.Width / 2;
        int y = myCenterPoint.Y - mySize.Height / 2;
        if ( x < 0 )
        {
          mySize.Width += x;
          x = 0;
        }
        if ( y < 0 )
        {
          mySize.Height += y;
          y = 0;
        }
        Point pt = new Point( x, y );
        myRectangle = new Rectangle( pt,mySize );
      }
    }
    /// <summary>
    /// Gets the relative location.
    /// </summary>
    /// <value>The relative location.</value>
    public int RelativeLocation
    {
      get
      {
        if ( !IsHorizontal )
          return myCenterPoint.X;
        else
          return myCenterPoint.Y;
      }
    }

    /// <summary>
    /// Gets the absolute location.
    /// </summary>
    /// <value>The absolute location.</value>
    public int AbsoluteLocation
    {
      get
      {
        if ( parrentShape != null )
        {
          if ( ! IsHorizontal )
            return MyCenterPointOnParentControl.X;
          else
            return MyCenterPointOnParentControl.Y;
        }
        else
        {
          return 0;
        }
      }
    }

    /// <summary>
    /// Gets the center point on parent control.
    /// </summary>
    /// <value>The center point on parent control.</value>
    public Point MyCenterPointOnParentControl
    {
      get
      {
        if ( parrentShape != null )
        {
          return new Point( myCenterPoint.X + parrentShape.StableLocation.X,
            myCenterPoint.Y + parrentShape.StableLocation.Y );
        }
        else
          return myCenterPoint;
      }
    }
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      return base.ToString()+String.Format("X={0},Y={1}",myCenterPoint.X,myCenterPoint.Y);
    }
    /// <summary>
    /// Gets a value indicating whether this instance is horizontal.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is horizontal; otherwise, <c>false</c>.
    /// </value>
    public bool IsHorizontal
    {
      get
      {
        return mIsHorizontal;
      }
    }
    /// <summary>
    /// Gets a value indicating whether this instance is vertical.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is vertical; otherwise, <c>false</c>.
    /// </value>
    public bool IsVertical
    {
      get
      {
        return !mIsHorizontal;
      }
    }
    /// <summary>
    /// Gets a value indicating whether this instance is fixed.
    /// </summary>
    /// <value><c>true</c> if this instance is fixed; otherwise, <c>false</c>.</value>
    public bool IsFixed
    {
      get
      {
        return mIsFixed;
      }
    }
    /// <summary>
    /// Gets the type.
    /// </summary>
    /// <value>The type.</value>
    public HotpointType Type
    {
      get
      {
        return myType;
      }
    }
    /// <summary>
    /// Gets the number in parent shape.
    /// </summary>
    /// <value>The number in parent shape.</value>
    public int NumberInParentShape
    {
      get
      {
        return myNumberInParentShape;
      }
    }
    #region IMatch Members
    /// <summary>
    /// tests if matches the specified point.
    /// </summary>
    /// <param name="pt">The point.</param>
    /// <returns></returns>
    public bool Match( Point pt )
    {
      return myRectangle.Contains(pt);
    }
    #endregion IMatch Members
    #endregion public

  }
}
