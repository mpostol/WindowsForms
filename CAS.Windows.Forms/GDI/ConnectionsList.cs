//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________


using System;
using System.Collections.Generic;
using System.Drawing;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// List of the connections
  /// </summary>
  public class ConnectionsList: IDraw
  {
    #region private
    private List<Connection> mConnectionList=new List<Connection>();
    private void RaiseConnectionIsRemovedEvent(Connection RemovedConnection)
    {
      if (ConnectionIsRemoved != null)
      {
        ConnectionIsRemoved(RemovedConnection, EventArgs.Empty);
      }
    }
    private void RaiseConnectionIsAddedEvent(Connection ConnectionAdded)
    {
      if (ConnectionIsAdded != null)
      {
        ConnectionIsAdded(ConnectionAdded, EventArgs.Empty);
      }
    }
    private void RaiseListHasChangedEvent()
    {
      if ( ListHasChanged != null )
      {
        ListHasChanged( this, EventArgs.Empty );
      }
    }
    #endregion private

    #region IDraw Members
    /// <summary>
    /// Draws the object on the specified dc.
    /// </summary>
    /// <param name="dc">The DeviceContext.</param>
    /// <param name="MyGraphicsSettings">The graphics settings.</param>
    public void Draw( System.Drawing.Graphics dc, GraphicsSettings MyGraphicsSettings )
    {
      foreach ( Connection cn in this.mConnectionList )
      {
        cn.Draw( dc, MyGraphicsSettings );
      }
    }
    #endregion

    #region public
    /// <summary>
    /// Matches the and select connection.
    /// </summary>
    /// <param name="Point">The point.</param>
    internal void MatchAndSelectConnection( Point Point )
    {
      bool somethingchanged = false;
      lock ( this )
      {
        foreach ( Connection cn in this.mConnectionList )
        {
          if ( cn.Match( Point ) )
          {
            ( (IIsSelected)cn ).IsSelected = true;
            somethingchanged = true;
          }
          else
          {
            if ( ( (IIsSelected)cn ).IsSelected )
            {
              ( (IIsSelected)cn ).IsSelected = false;
              somethingchanged = true;
            }
          }
        }
      }
      if ( somethingchanged )
          RaiseListHasChangedEvent();
    }
    /// <summary>
    /// Determines whether any connection is selected.
    /// </summary>
    /// <returns>
    /// 	<c>true</c> if [is any selected]; otherwise, <c>false</c>.
    /// </returns>
    internal bool IsAnySelected()
    {
      lock ( this )
      {
        foreach ( Connection cn in this.mConnectionList )
        {
          if ( ( (IIsSelected)cn ).IsSelected )
            return true;
        }
      }
      return false;
    }
    /// <summary>
    /// Removes the selected connection.
    /// </summary>
    internal void RemoveSelectedConnection()
    {
      bool somethingchanged = false;
      lock ( this )
      {
        foreach ( Connection cn in this.mConnectionList )
        {
          if ( ( (IIsSelected)cn ).IsSelected )
          {
            this.mConnectionList.Remove( cn );
            RaiseConnectionIsRemovedEvent( cn );
            somethingchanged = true;
            break; // wychodzimy z przegladania listy bo nie mozna modyfikowac listy ktora przegladamy foreach'em
          }
        }
      }
      if ( somethingchanged )
        RaiseListHasChangedEvent();
    }

    /// <summary>
    /// Adds the specified cn.
    /// </summary>
    /// <param name="cn">The cn.</param>
    internal void Add(Connection cn)
    {
      lock ( this )
      {
        this.mConnectionList.Add( cn );
      }
      RaiseConnectionIsAddedEvent(cn);
    }

    /// <summary>
    /// Clears this instance.
    /// </summary>
    internal void Clear()
    {
      lock ( this )
      {
        this.mConnectionList.Clear();
      }
    }
    /// <summary>
    /// Occurs when [list has changed].
    /// </summary>
    public event EventHandler ListHasChanged;
    /// <summary>
    /// Occurs when [connection is removed].
    /// </summary>
    public event EventHandler ConnectionIsRemoved;
    /// <summary>
    /// Occurs when [connection is added].
    /// </summary>
    public event EventHandler ConnectionIsAdded;
    #endregion public

  }
}
