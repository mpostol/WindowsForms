//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.Drawing;

namespace UAOOI.Windows.Forms.GDI
{
  /// <summary>
  /// The shape with hot-points on it
  /// </summary>
  public class ShapeWithHotpoints: Shape
  {
    private bool hotpointismatched = false;
    /// <summary>
    /// the array of hot-points inputs
    /// </summary>
    protected HotPointSelectableConnectableArray HotpointsInputs;
    /// <summary>
    /// Initializes the component.
    /// </summary>
    private void InitializeComponent()
    {
      this.SuspendLayout();
      // 
      // OperationShape
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
      this.Name = "ShapeWithHotPoints";
      this.Paint += new System.Windows.Forms.PaintEventHandler( this.OperationShape_Paint );
      this.MouseDown += new System.Windows.Forms.MouseEventHandler( this.OperationShape_MouseDown );
      this.MouseUp += new System.Windows.Forms.MouseEventHandler( this.OperationShape_MouseUp );
      this.ResumeLayout( false );
    }
    /// <summary>
    /// Handles the MouseDown event of the OperationShape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void OperationShape_MouseDown( object sender, System.Windows.Forms.MouseEventArgs e )
    {
      if ( HotpointsInputs != null )
        hotpointismatched = HotpointsInputs.MatchAndSelect( new Point( e.X, e.Y ) );
    }
    /// <summary>
    /// Handles the Paint event of the OperationShape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
    private void OperationShape_Paint( object sender, System.Windows.Forms.PaintEventArgs e )
    {
      if ( HotpointsInputs != null && MyGraphicsSettings != null )
        HotpointsInputs.Draw( e.Graphics, MyGraphicsSettings );
    }
    /// <summary>
    /// Handles the MouseUp event of the OperationShape control.
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
    private void OperationShape_MouseUp( object sender, System.Windows.Forms.MouseEventArgs e )
    {
      if ( HotpointsInputs != null )
        HotpointsInputs.DeselectAll();
    }
    /// <summary>
    /// Gets the selected hot-point.
    /// </summary>
    /// <value>The selected hot-point.</value>
    public HotPointSelectableConnectable SelectedHotpoint
    {
      get
      {
        if ( HotpointsInputs != null )
          return HotpointsInputs.SelectedHotpoint;
        else
          return null;
      }
    }
    /// <summary>
    /// Gets a value indicating whether one of the hot-point is matched.
    /// </summary>
    /// <value><c>true</c> if the hot-point is matched; otherwise, <c>false</c>.</value>
    public bool HotPointIsMatched
    {
      get
      {
        return hotpointismatched;
      }
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ShapeWithHotpoints"/> class.
    /// </summary>
    public ShapeWithHotpoints()
      : base()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Matches and selects the hot-point. 
    /// This function checks whether one of the hot-points is clicked and if yes the hot-point is selected.
    /// </summary>
    /// <param name="PointToBeChecked">The point that is clicked.</param>
    /// <returns>true if any hot point is selected</returns>
    internal bool MatchAndSelectHotpoint( Point PointToBeChecked )
    {
      if ( HotpointsInputs != null )
        return HotpointsInputs.MatchAndSelect( PointToBeChecked );
      else
        return false;
    }
    /// <summary>
    /// Gets the hot-point.
    /// </summary>
    /// <param name="Type">The type.</param>
    /// <param name="HotpointNumber">The hot-point number.</param>
    /// <returns>the particular HotPoint</returns>
    public HotPoint GetHotpoint( HotpointType Type, int HotpointNumber )
    {
      if ( HotpointsInputs != null )
        return HotpointsInputs[ Type ][ HotpointNumber ];
      else
        return null;
    }
  }
}
