//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Collections.Generic;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// List of the Shapes
  /// </summary>
  public class ShapeList : IEnumerable<Shape>
  {

    #region private
    private List<Shape> mList = new List<Shape>();
    private void RaiseShapeIsRemovedEvent( Shape RemovedShape )
    {
      if ( ShapeIsRemoved != null )
      {
        ShapeIsRemoved( RemovedShape, EventArgs.Empty );
      }
    }
    #endregion

    #region internal
    /// <summary>
    /// Deselects all shapes.
    /// </summary>
    internal void DeselectAllShapes()
    {
      lock ( this )
      {
        foreach ( Shape sh in this.mList )
        {
          sh.IsSelected = false;
        }
      }
    }
    /// <summary>
    /// Gets the selected shape.
    /// </summary>
    /// <returns></returns>
    internal Shape GetSelectedShape()
    {
      lock ( this )
      {
        foreach ( Shape sh in this.mList )
        {
          if ( sh.IsSelected )
            return sh;
        }
      }
      return null;
    }
    /// <summary>
    /// Moves to top selected shape and return selected shape.
    /// </summary>
    /// <returns></returns>
    internal Shape MoveToTopSelectedShapeAndReturnSelectedShape()
    {
      Shape sh;
      lock ( this )
      {
        sh = GetSelectedShape();
        if ( sh != null )
        {
          this.mList.Remove( sh );
          this.mList.Add( sh );
        }
      }
      return sh;
    }

    /// <summary>
    /// Removes the selected shape.
    /// </summary>
    internal void RemoveSelectedShape()
    {
      lock ( this )
      {
        foreach ( Shape sh in mList )
        {
          if ( sh.IsSelected )
          {
            this.mList.Remove( sh );
            RaiseShapeIsRemovedEvent( sh );
            break;
          }
        }
      }
    }

    /// <summary>
    /// Adds the specified shape.
    /// </summary>
    /// <param name="sh">The shape.</param>
    internal void Add( Shape sh )
    {
      if ( sh == null )
        throw new ArgumentNullException();
      lock ( this )
      {
        mList.Add( sh );
      }
    }

    /// <summary>
    /// Clears this instance.
    /// </summary>
    internal void Clear()
    {
      lock ( this )
      {
        mList.Clear();
      }
    }
    /// <summary>
    /// Determines whether [is any selected].
    /// </summary>
    /// <returns>
    /// 	<c>true</c> if [is any selected]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsAnySelected()
    {
      if ( this.GetSelectedShape() != null )
      {
        return true;
      }
      return false;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeList"/> class.
    /// </summary>
    internal ShapeList()
    {
    }
    #endregion internal

    #region IEnumerable<Shape> Members

    IEnumerator<Shape> IEnumerable<Shape>.GetEnumerator()
    {
      lock ( this )
      {
        return mList.GetEnumerator();
      }
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      lock ( this )
      {
        return mList.GetEnumerator();
      }
    }

    #endregion

    /// <summary>
    /// Occurs when [shape is removed].
    /// </summary>
    public event EventHandler ShapeIsRemoved;

  }
}
