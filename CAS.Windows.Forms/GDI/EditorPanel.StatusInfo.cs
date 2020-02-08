//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System;
using System.Text;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// Editor Panel
  /// </summary>
  public partial class EditorPanel
  {
    /// <summary>
    /// Status for Editor Panel
    /// </summary>
    public class StatusInformationClass
    {

      #region private
      private bool mConnecting = false;
      private bool mShapeIsMoving = false;
      private string mAdditionalInfo = "";
      private void RaiseChangedEvent()
      {
        if ( InfoIsChanged != null )
        {
          InfoIsChanged( this, EventArgs.Empty );
        }
      }
      #endregion private

      #region internal
      /// <summary>
      /// Gets or sets a value indicating whether this <see cref="StatusInformationClass"/> is connecting.
      /// </summary>
      /// <value><c>true</c> if connecting; otherwise, <c>false</c>.</value>
      internal bool Connecting
      {
        get
        {
          return mConnecting;
        }
        set
        {
          mConnecting = value;
          RaiseChangedEvent();
        }
      }
      /// <summary>
      /// Gets or sets a value indicating whether [shape is moving].
      /// </summary>
      /// <value><c>true</c> if [shape is moving]; otherwise, <c>false</c>.</value>
      internal bool ShapeIsMoving
      {
        get
        {
          return mShapeIsMoving;
        }
        set
        {
          mShapeIsMoving = value;
          RaiseChangedEvent();
        }
      }
      /// <summary>
      /// Gets or sets the additional info.
      /// </summary>
      /// <value>The additional info.</value>
      internal string AdditionalInfo
      {
        get
        {
          return mAdditionalInfo;
        }
        set
        {
          mAdditionalInfo = value;
          RaiseChangedEvent();
        }
      }
      #endregion internal

      #region public
      /// <summary>
      /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
      /// </summary>
      /// <returns>
      /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
      /// </returns>
      public override string ToString()
      {
        StringBuilder sb = new StringBuilder();
        if (mConnecting)
          sb.Append("connecting ");
        if (mShapeIsMoving)
          sb.Append("moving shape ");
        sb.Append(mAdditionalInfo);
        return sb.ToString();
      }
      /// <summary>
      /// Occurs when information is changed.
      /// </summary>
      public event EventHandler InfoIsChanged;
      #endregion

    }
  }
}