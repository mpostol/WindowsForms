//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________


using System;
using System.Drawing;
using System.Windows.Forms;
using UAOOI.Windows.GUIAbstractions;

namespace CAS.Lib.ControlLibrary
{
  public partial class OKCancelForm: Form, ICanBeAccepted
  {
    #region public
    /// <summary>
    /// Default creator of the object
    /// </summary>
    internal OKCancelForm()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Adds the button.
    /// </summary>
    /// <param name="name">The name of teh button.</param>
    /// <param name="dialogResult">The dialog result.</param>
    public void AddButton(string name, DialogResult dialogResult)
    {
      ToolStripButton tsb = new ToolStripButton( name );
      tsb.AutoSize = false;
      tsb.Width = 100;
      tsb.Height = 22;
      tsb.Enabled = true;
      tsb.Tag = dialogResult;
      tsb.Click += new EventHandler( tsb_Click );
      cm_ToolStrip.Items.Add( tsb );
    }

    /// <summary>
    /// constructor with new title
    /// </summary>
    /// <param name="formname">new title for the form</param>
    public OKCancelForm( string formname )
    {
      InitializeComponent();
      this.Text = formname;
    }
    /// <summary>
    /// Sets the reference of the object to be modified.
    /// </summary>
    public UserControl SetUserControl
    {
      set
      {
        this.cm_toolStripContainer.SuspendLayout();
        this.SuspendLayout();
        this.Size = value.Size;
        this.cm_toolStripContainer.ContentPanel.Controls.Clear();
        this.cm_toolStripContainer.ContentPanel.Controls.Add( value );
        value.Dock = DockStyle.Fill;
        value.Location = new Point( 0, 0 );
        this.cm_toolStripContainer.ResumeLayout( false );
        this.ResumeLayout( false );
      }
    }
      /// <summary>
      /// Can Be Accepted
      /// </summary>
      /// <param name="pOKState"></param>
    public void CanBeAccepted( bool pOKState ) 
    { 
      cm_TSButtonAccept.Enabled = pOKState;
      cm_ButtonEnter.Enabled = pOKState;
    }
    #endregion
    #region Private events handlers
    private void cm_TSButtonAccept_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.OK;
      this.Close();
    }
    private void cm_TSButtonCancel_Click( object sender, EventArgs e )
    {
      this.DialogResult = DialogResult.Cancel;
      this.Close();
    }
    private void tsb_Click( object sender, EventArgs e )
    {
      ToolStripButton tsb = sender as ToolStripButton;
      if ( ( tsb != null ) && ( tsb.Tag != null ) && ( tsb.Tag is DialogResult ) )
        this.DialogResult = (DialogResult)tsb.Tag;
      this.Close();
    }
    #endregion
  }
}