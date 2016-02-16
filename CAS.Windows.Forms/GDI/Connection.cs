//<summary>
//  Title   : Connection class - class that displays connection between shapes
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//  History :
//    20080307 - mzbrzezny: created
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Drawing;

namespace CAS.Lib.ControlLibrary.GDI
{
  /// <summary>
  /// Connection class - class that displays connection between shapes
  /// </summary>
  public class Connection: IDraw, IIsSelected
  {
    #region PRIVATE
    const int MaxNodeCount = 7;
 		const int PrecisionSize = 2;
    private bool mIsSelected;
    private int nodeCount;
    private Point[] nodes=new Point[MaxNodeCount];
    private HotPoint myStartHotpoint;
    private HotPoint myEndHotpoint;
    private void CalculateNodes()
    {
      if ( myStartHotpoint.IsHorizontal == myStartHotpoint.IsHorizontal )
          ParallelCalculation();
        else
          PerpendicularCalculation();
    }

    private void ParallelCalculation()
    {
      if ( myStartHotpoint.ParrentShape == null || myEndHotpoint.ParrentShape == null )
        return;

      ShapeWithHotpoints startShape = myStartHotpoint.ParrentShape;
      ShapeWithHotpoints endShape = myEndHotpoint.ParrentShape;

      if ( (myStartHotpoint.IsFixed || myEndHotpoint.IsFixed) && myEndHotpoint.MyCenterPointOnParentControl.X-myStartHotpoint.MyCenterPointOnParentControl.X<0 )
      {
        nodeCount = 6;
        nodes[ 0 ].Y = nodes[ 1 ].Y = myStartHotpoint.MyCenterPointOnParentControl.Y;
        nodes[ 5 ].Y = nodes[ 4 ].Y = myEndHotpoint.MyCenterPointOnParentControl.Y;
        nodes[ 0 ].X = myStartHotpoint.MyCenterPointOnParentControl.X;
        nodes[ 5 ].X = myEndHotpoint.MyCenterPointOnParentControl.X;
        //point 0  and 5 are ready
        nodes[ 1 ].X = nodes[ 2 ].X = myStartHotpoint.MyCenterPointOnParentControl.X + MarginSize;
        //point 1 is ready
        nodes[ 3 ].X = nodes[ 4 ].X = myEndHotpoint.MyCenterPointOnParentControl.X - MarginSize;
        //point 4 is ready
        nodes[ 3 ].Y = nodes[ 2 ].Y = myStartHotpoint.MyCenterPointOnParentControl.Y + ( myEndHotpoint.MyCenterPointOnParentControl.Y - myStartHotpoint.MyCenterPointOnParentControl.Y ) / 2;
      }
      else
      {
        #region ParallerNotFixedCalculation
        nodeCount = 4;

        if ( myStartHotpoint.IsVertical )
        {
          nodes[ 0 ].X = nodes[ 1 ].X = myStartHotpoint.AbsoluteLocation;
          nodes[ 2 ].X = nodes[ 3 ].X = myEndHotpoint.AbsoluteLocation;

          if ( endShape.StableLocation.Y - startShape.StableLocation.Y + startShape.Size.Height >= 2 * MarginSize ||
            startShape.StableLocation.Y - endShape.StableLocation.Y + endShape.Size.Height >= 2 * MarginSize )
          {
            if ( startShape.StableLocation.Y < endShape.StableLocation.Y )
            {
              int semiLength = ( endShape.StableLocation.Y - startShape.StableLocation.Y - startShape.Size.Height ) / 2;

              nodes[ 0 ].Y = startShape.StableLocation.Y + startShape.Size.Height;
              nodes[ 1 ].Y = startShape.StableLocation.Y + startShape.Size.Height + semiLength;
              nodes[ 2 ].Y = startShape.StableLocation.Y + startShape.Size.Height + semiLength;
              nodes[ 3 ].Y = endShape.StableLocation.Y - 1;
            }
            else
            {
              int semiLength = ( startShape.StableLocation.Y - endShape.StableLocation.Y - endShape.Size.Height ) / 2;

              nodes[ 0 ].Y = startShape.StableLocation.Y - 1;
              nodes[ 1 ].Y = endShape.StableLocation.Y + endShape.Size.Height + semiLength;
              nodes[ 2 ].Y = endShape.StableLocation.Y + endShape.Size.Height + semiLength;
              nodes[ 3 ].Y = endShape.StableLocation.Y + endShape.Size.Height;
            }
          }
          else
          {
            ShapeWithHotpoints bottomShape = ( startShape.StableLocation.Y < endShape.StableLocation.Y ) ?
              endShape : startShape;

            nodes[ 0 ].Y = startShape.StableLocation.Y + startShape.Size.Height;
            nodes[ 1 ].Y = bottomShape.StableLocation.Y + bottomShape.Size.Height + MarginSize;
            nodes[ 2 ].Y = bottomShape.StableLocation.Y + bottomShape.Size.Height + MarginSize;
            nodes[ 3 ].Y = endShape.StableLocation.Y + endShape.Size.Height;
          }
        }
        else
        { // Horizontal
          nodes[ 0 ].Y = nodes[ 1 ].Y = myStartHotpoint.AbsoluteLocation;
          nodes[ 2 ].Y = nodes[ 3 ].Y = myEndHotpoint.AbsoluteLocation;

          if ( endShape.StableLocation.X - startShape.StableLocation.X - startShape.Size.Width >= 2 * MarginSize ||
            startShape.StableLocation.X - endShape.StableLocation.X - endShape.Size.Width >= 2 * MarginSize || myEndHotpoint.IsFixed )
          {
            if ( startShape.StableLocation.X < endShape.StableLocation.X )
            {
              int semiLength = ( endShape.StableLocation.X - startShape.StableLocation.X - startShape.Size.Width ) / 2;

              nodes[ 0 ].X = startShape.StableLocation.X + startShape.Size.Width;
              nodes[ 1 ].X = startShape.StableLocation.X + startShape.Size.Width + semiLength;
              nodes[ 2 ].X = startShape.StableLocation.X + startShape.Size.Width + semiLength;
              nodes[ 3 ].X = endShape.StableLocation.X - 1;
            }
            else
            {
              int semiLength = ( startShape.StableLocation.X - endShape.StableLocation.X - endShape.Size.Width ) / 2;

              nodes[ 0 ].X = startShape.StableLocation.X - 1;
              nodes[ 1 ].X = endShape.StableLocation.X + endShape.Size.Width + semiLength;
              nodes[ 2 ].X = endShape.StableLocation.X + endShape.Size.Width + semiLength;
              nodes[ 3 ].X = endShape.StableLocation.X + endShape.Size.Width;
            }
          }
          else
          {
            ShapeWithHotpoints rightShape = ( startShape.StableLocation.X < endShape.StableLocation.X ) ?
              endShape : startShape;

            nodes[ 0 ].X = startShape.StableLocation.X + startShape.Size.Width;
            nodes[ 1 ].X = rightShape.StableLocation.X + rightShape.Size.Width + MarginSize;
            nodes[ 2 ].X = rightShape.StableLocation.X + rightShape.Size.Width + MarginSize;
            nodes[ 3 ].X = endShape.StableLocation.X + endShape.Size.Width;
          }
        }
        #endregion ParallerNotFixedCalculation
      }
    }

    private void PerpendicularCalculation()
    {
      if ( myStartHotpoint.ParrentShape == null || myEndHotpoint.ParrentShape == null )
        return;

      ShapeWithHotpoints startShape = myStartHotpoint.ParrentShape;
      ShapeWithHotpoints endShape = myEndHotpoint.ParrentShape;
      if ( myStartHotpoint.IsFixed || myEndHotpoint.IsFixed )
      {
        throw new NotImplementedException( "This calculation is not yet implemented" );
      }
      else
      {
        #region PerpendicularCalculation not fixed
        if ( myStartHotpoint.IsVertical )
        {
          nodes[ 0 ].X = myStartHotpoint.AbsoluteLocation;

          if ( ( myStartHotpoint.AbsoluteLocation < endShape.StableLocation.X - MarginSize ||
            myStartHotpoint.AbsoluteLocation >= endShape.StableLocation.X + endShape.Size.Width + MarginSize ) &&
            ( myEndHotpoint.AbsoluteLocation < startShape.StableLocation.Y - MarginSize ||
            myEndHotpoint.AbsoluteLocation >= startShape.StableLocation.Y + startShape.Size.Height + MarginSize ) )
          {
            nodeCount = 3;

            if ( startShape.StableLocation.Y < endShape.StableLocation.Y )
              nodes[ 0 ].Y = startShape.StableLocation.Y + startShape.Size.Height;
            else
              nodes[ 0 ].Y = startShape.StableLocation.Y - 1;

            if ( startShape.StableLocation.X < endShape.StableLocation.X )
              nodes[ 2 ].X = endShape.StableLocation.X - 1;
            else
              nodes[ 2 ].X = endShape.StableLocation.X + endShape.Size.Width;

            nodes[ 1 ] = new Point( myStartHotpoint.AbsoluteLocation, myEndHotpoint.AbsoluteLocation );
            nodes[ 2 ].Y = myEndHotpoint.AbsoluteLocation;
          }
          else
          {
            Point connector = new Point();
            bool vertical = myStartHotpoint.AbsoluteLocation >= endShape.StableLocation.X - MarginSize &&
              myStartHotpoint.AbsoluteLocation < endShape.StableLocation.X + endShape.Size.Width + MarginSize;

            nodeCount = 5;

            if ( myStartHotpoint.AbsoluteLocation < ( endShape.StableLocation.X + endShape.StableLocation.X + endShape.Size.Width ) / 2 &&
              vertical || ( !vertical && endShape.StableLocation.X > startShape.StableLocation.X ) )
            {
              connector.X = endShape.StableLocation.X - MarginSize - 1;
              nodes[ 4 ].X = endShape.StableLocation.X - 1;
            }
            else
            {
              connector.X = endShape.StableLocation.X + endShape.Size.Width + MarginSize;
              nodes[ 4 ].X = endShape.StableLocation.X + endShape.Size.Width;
            }

            if ( myEndHotpoint.AbsoluteLocation < ( startShape.StableLocation.Y + startShape.StableLocation.Y + startShape.Size.Height ) / 2 &&
              !vertical || ( vertical && startShape.StableLocation.Y >= endShape.StableLocation.Y ) )
            {
              connector.Y = startShape.StableLocation.Y - MarginSize - 1;
              nodes[ 0 ].Y = startShape.StableLocation.Y - 1;
            }
            else
            {
              connector.Y = startShape.StableLocation.Y + startShape.Size.Height + MarginSize;
              nodes[ 0 ].Y = startShape.StableLocation.Y + startShape.Size.Height;
            }

            nodes[ 1 ] = new Point( myStartHotpoint.AbsoluteLocation, connector.Y );
            nodes[ 2 ] = connector;
            nodes[ 3 ] = new Point( connector.X, myEndHotpoint.AbsoluteLocation );
            nodes[ 4 ].Y = myEndHotpoint.AbsoluteLocation;
          }
        }
        else
        { // startNode.IsHorizontal
          nodes[ 0 ].Y = myStartHotpoint.AbsoluteLocation;

          if ( ( myStartHotpoint.AbsoluteLocation < endShape.StableLocation.Y - MarginSize ||
            myStartHotpoint.AbsoluteLocation >= endShape.StableLocation.Y + endShape.Size.Height + MarginSize ) &&
            ( myEndHotpoint.AbsoluteLocation < startShape.StableLocation.X - MarginSize ||
            myEndHotpoint.AbsoluteLocation >= startShape.StableLocation.X + startShape.Size.Width + MarginSize ) )
          {
            nodeCount = 3;

            if ( startShape.StableLocation.X < endShape.StableLocation.X )
              nodes[ 0 ].X = startShape.StableLocation.X + startShape.Size.Width;
            else
              nodes[ 0 ].X = startShape.StableLocation.X - 1;

            if ( startShape.StableLocation.Y < endShape.StableLocation.Y )
              nodes[ 2 ].Y = endShape.StableLocation.Y - 1;
            else
              nodes[ 2 ].Y = endShape.StableLocation.Y + endShape.Size.Height;

            nodes[ 1 ] = new Point( myEndHotpoint.AbsoluteLocation, myStartHotpoint.AbsoluteLocation );
            nodes[ 2 ].X = myEndHotpoint.AbsoluteLocation;
          }
          else
          {
            Point connector = new Point();
            bool horizontal = myStartHotpoint.AbsoluteLocation >= endShape.StableLocation.Y - MarginSize &&
              myStartHotpoint.AbsoluteLocation < endShape.StableLocation.Y + endShape.Size.Height + MarginSize;

            nodeCount = 5;

            if ( myStartHotpoint.AbsoluteLocation < ( endShape.StableLocation.Y + endShape.StableLocation.Y + endShape.Size.Height ) / 2 &&
              horizontal || ( !horizontal && endShape.StableLocation.Y > startShape.StableLocation.Y ) )
            {
              connector.Y = endShape.StableLocation.Y - MarginSize - 1;
              nodes[ 4 ].Y = endShape.StableLocation.Y - 1;
            }
            else
            {
              connector.Y = endShape.StableLocation.Y + endShape.Size.Height + MarginSize;
              nodes[ 4 ].Y = endShape.StableLocation.Y + endShape.Size.Height;
            }

            if ( myEndHotpoint.AbsoluteLocation < ( startShape.StableLocation.X + startShape.StableLocation.X + startShape.Size.Width ) / 2 &&
              !horizontal || ( horizontal && startShape.StableLocation.X >= endShape.StableLocation.X ) )
            {
              connector.X = startShape.StableLocation.X - MarginSize - 1;
              nodes[ 0 ].X = startShape.StableLocation.X - 1;
            }
            else
            {
              connector.X = startShape.StableLocation.X + startShape.Size.Width + MarginSize;
              nodes[ 0 ].X = startShape.StableLocation.X + startShape.Size.Width;
            }

            nodes[ 1 ] = new Point( connector.X, myStartHotpoint.AbsoluteLocation );
            nodes[ 2 ] = connector;
            nodes[ 3 ] = new Point( myEndHotpoint.AbsoluteLocation, connector.Y );
            nodes[ 4 ].X = myEndHotpoint.AbsoluteLocation;
          }
        }
        #endregion not fixed
      }
    }
    private static Rectangle CreateLineRectangle(Point startPoint, Point endPoint)
		{
			if (startPoint.X == endPoint.X) { // Vertical line
				if (startPoint.Y < endPoint.Y) {
					return Rectangle.FromLTRB(startPoint.X - PrecisionSize, startPoint.Y,
						startPoint.X + PrecisionSize + 1, endPoint.Y);
				}
				else {
					return Rectangle.FromLTRB(startPoint.X - PrecisionSize, endPoint.Y,
						startPoint.X + PrecisionSize + 1, startPoint.Y);
				}
			}
			else if (startPoint.Y == endPoint.Y) { // Horizontal line
				if (startPoint.X < endPoint.X) {
					return Rectangle.FromLTRB(startPoint.X, startPoint.Y - PrecisionSize,
						endPoint.X, startPoint.Y + PrecisionSize + 1);
				}
				else {
					return Rectangle.FromLTRB(endPoint.X, startPoint.Y - PrecisionSize,
						startPoint.X, startPoint.Y + PrecisionSize + 1);
				}
			}
			else {
				return Rectangle.Empty;
			}
		}
    private void ReverseNodes()
    {
      int length = nodes.Length;

      for ( int i = 0; i < length / 2; i++ )
      {
        Point temp = nodes[ i ];
        nodes[ i ] = nodes[ length - i - 1 ];
        nodes[ length - i - 1 ] = temp;
      }
    }
    private static bool Intersects(Point point, Point startPoint, Point endPoint)
		{
			Rectangle line = CreateLineRectangle(startPoint, endPoint);
			return line.Contains(point);
		}
    #endregion PRIVATE
    #region PUBLIC
    /// <summary>
    /// Exchanges the beginning with end.
    /// </summary>
    protected void ExchangeBeginningWithEnd()
    {
      HotPoint temp = myStartHotpoint;
      myStartHotpoint = myEndHotpoint;
      myEndHotpoint = temp;
    }
    /// <summary>
    /// The size of the margin
    /// </summary>
    public const int MarginSize = 22;
    /// <summary>
    /// Validates this instance. 
    /// This fuction checks whether this connection is valid. this function should be overriden by child class
    /// to achieve the validation that depend on the child.
    /// </summary>
    /// <returns>true if the connection is valid</returns>
    public virtual bool Validate()
    {
      if (myStartHotpoint==null || myEndHotpoint==null ||
        myStartHotpoint == myEndHotpoint || 
        myStartHotpoint.ParrentShape == myEndHotpoint.ParrentShape) return false;
      return true;
    }
    /// <summary>
    /// test if the connection matches the specified point.
    /// </summary>
    /// <param name="Point">The point.</param>
    /// <returns></returns>
    public bool Match( Point Point )
    {
      for ( int i = 0; i < nodeCount - 1; i++ )
      {
        if ( Intersects( Point, nodes[ i ], nodes[ i + 1 ] ) )
          return true;
      }
      return false;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="Connection"/> class.
    /// </summary>
    /// <param name="StartHotpoint">The start hotpoint.</param>
    /// <param name="EndHotpoint">The end hotpoint.</param>
    public Connection( HotPoint StartHotpoint, HotPoint EndHotpoint )
    {
      myEndHotpoint = EndHotpoint;
      myStartHotpoint = StartHotpoint;
    }
    /// <summary>
    /// Gets the start hotpoint.
    /// </summary>
    /// <value>The start hotpoint.</value>
    public HotPoint StartHotpoint
    {
      get
      {
        return myStartHotpoint;
      }
    }
    /// <summary>
    /// Gets the end hotpoint.
    /// </summary>
    /// <value>The end hotpoint.</value>
    public HotPoint EndHotpoint
    {
      get
      {
        return myEndHotpoint;
      }
    }

    #region IDraw Members
    /// <summary>
    /// Draws the object on the specified dc.
    /// </summary>
    /// <param name="dc">The DeviceContext.</param>
    /// <param name="MyGraphicsSettings">The graphics settings.</param>
    public void Draw( Graphics dc, GraphicsSettings MyGraphicsSettings )
    {
      CalculateNodes();
      //dc.DrawLine( MyGraphicsSettings.MainPen, myStartHotpoint.MyCenterPointOnParentControl, myEndHotpoint.MyCenterPointOnParentControl );
      if ( nodeCount >= 2 )
      {
        for ( int i = nodeCount; i < nodes.Length; i++ )
          nodes[ i ] = nodes[ i - 1 ];
        ReverseNodes();
        if ( !mIsSelected )
          dc.DrawLines( MyGraphicsSettings.MainPen, nodes );
        else
        {
          dc.DrawLines( MyGraphicsSettings.BackgroundPen, nodes );
          dc.DrawLines( MyGraphicsSettings.SelectionPen, nodes );
        }
        ReverseNodes();
      }
    }
    #endregion
    #endregion PUBLIC

    #region IIsSelected Members

    /// <summary>
    /// Gets or sets a value indicating whether this instance is selected.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if this instance is selected; otherwise, <c>false</c>.
    /// </value>
    bool IIsSelected.IsSelected
    {
      get
      {
        return mIsSelected;
      }
      set
      {
        mIsSelected = value;
      }
    }

    #endregion
  }
}
