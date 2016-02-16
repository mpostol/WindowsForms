//<summary>
//  Title   : Scrollable Message Box
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2011, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>
      

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CAS.Lib.ControlLibrary
{

  /// <summary>
  /// Message Box with scrollable content
  /// </summary>
  public partial class ScrollableMessageBox: Form
  {
    #region singleton
    private readonly static ScrollableMessageBox instance = new ScrollableMessageBox();
    /// <summary>
    /// Gets the instance.
    /// </summary>
    /// <value>The instance.</value>
    public static ScrollableMessageBox Instance { get { return instance; } }
    #endregion singleton
    /// <summary>
    /// Initializes a new instance of the <see cref="ScrollableMessageBox"/> class.
    /// </summary>
    public ScrollableMessageBox()
    {
      InitializeComponent();
    }

    /// <summary>
    /// Gets or sets the message font.
    /// </summary>
    /// <value>The message font.</value>
    public Font MessageFont
    {
      set
      {
        txtMessage.Font = value;
      }

      get
      {
        return txtMessage.Font;
      }
    }

    /// <summary>
    /// Gets or sets the foreground color of the message.
    /// </summary>
    /// <value>The foreground color of the message.</value>
    public Color MessageForeColor
    {
      get
      {
        return txtMessage.ForeColor;
      }

      set
      {
        txtMessage.ForeColor = value;
      }
    }

    /// <summary>
    /// Gets or sets the background color of the message.
    /// </summary>
    /// <value>The backgroundcolor of the message.</value>
    public Color MessageBackColor
    {
      get
      {
        return txtMessage.BackColor;
      }

      set
      {
        txtMessage.BackColor = value;
        this.BackColor = value;
      }
    }


    /// <summary>
    /// Shows the specified text.
    /// </summary>
    /// <param name="text">text inside the message box</param>
    /// <param name="caption">caption on the title bar</param>
    public DialogResult Show( string text, string caption )
    {
      //Assume OK Button, by default
      //Assume none icon , by default
      return this.Show( text, caption, MessageBoxButtons.OK, MessageBoxIcon.None );
    }
    /// <summary>
    /// Shows the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="buttonType">Type of the button.</param>
    public DialogResult Show( string text, string caption, MessageBoxButtons buttonType )
    {
      //Assume none icon , by default
      return this.Show( text, caption, buttonType, MessageBoxIcon.None );
    }

    /// <summary>
    /// Shows the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="buttonType">Type of the button.</param>
    /// <param name="iconType">Type of the icon.</param>
    public DialogResult Show( string text, string caption, MessageBoxButtons buttonType, MessageBoxIcon iconType )
    {
      // populate the text box with the message
      txtMessage.Text = text;
      // populate the caption with the passed in caption
      this.Text = caption;
      // Buttons:
      ChooseButtons( buttonType );
      //Assume none icon, by default
      ChooseIcon( iconType );
      this.ActiveControl = this.Controls[ this.Controls.Count - 1 ];
      return this.ShowDialog();
    }

    /// <summary>
    /// Shows the text from file.
    /// </summary>
    /// <param name="filename">The filename.</param>
    /// <param name="caption">The caption.</param>
    /// <param name="buttonType">Type of the button.</param>
    public DialogResult ShowFromFile( string filename, string caption, MessageBoxButtons buttonType )
    {
      // read the file into the message box
      StreamReader sr = new StreamReader( filename );
      string text = sr.ReadToEnd();
      sr.Close();
      return this.Show( text, caption, buttonType, MessageBoxIcon.None );
    }
    #region private
    private void RemoveButtons()
    {
      List<Button> buttons = new List<Button>();
      foreach ( Control c in this.Controls )
      {
        if ( c is Button )
        {
          buttons.Add( c as Button );
        }
      }

      foreach ( Button b in buttons )
      {
        this.Controls.Remove( b );
      }

    }

    private void ChooseButtons( MessageBoxButtons buttonType )
    {
      // remove existing buttons
      RemoveButtons();

      // decide which button set to add from buttonType, and add it
      switch ( buttonType )
      {
        case MessageBoxButtons.OK:
          AddOKButton();
          break;
        case MessageBoxButtons.YesNo:
          AddYesNoButtons();
          break;
        case MessageBoxButtons.OKCancel:
          AddOkCancelButtons();
          break;
        default:
          AddOKButton(); // default is an OK button
          break;
      }
    }
    private void ChooseIcon( MessageBoxIcon iconType )
    {
      // decide which button set to add from buttonType, and add it
      switch ( iconType )
      {
        case MessageBoxIcon.Stop:
          //case MessageBoxIcon.Error:
          this.Icon = SystemIcons.Error;
          break;
        //case MessageBoxIcon.Hand:
        //  this.Icon = SystemIcons.Hand;
        //  break;
        case MessageBoxIcon.Question:
          this.Icon = SystemIcons.Question;
          break;
        case MessageBoxIcon.Exclamation:
          this.Icon = SystemIcons.Exclamation;
          break;
        //case MessageBoxIcon.Warning:
        //  this.Icon = SystemIcons.Warning;
        //  break;
        case MessageBoxIcon.Information:
          this.Icon = SystemIcons.Information;
          break;
        //case MessageBoxIcon.Asterisk:
        //  this.Icon = SystemIcons.Asterisk;
        //  break;
        default:
          //remove icon
          this.Icon = null;
          break;
      }
    }
    private void AddOKButton()
    {
      Button btnOK = new Button();
      btnOK.Text = "OK";
      this.Controls.Add( btnOK );
      btnOK.Location = new Point( this.Width / 2 - 35, this.txtMessage.Bottom + 5 );
      btnOK.Anchor = AnchorStyles.Bottom;
      btnOK.Size = new Size( 70, 20 );
      btnOK.DialogResult = DialogResult.OK;
      this.AcceptButton = btnOK;
    }

    private void AddYesNoButtons()
    {
      Button btnYes = new Button();
      btnYes.Text = "Yes";
      this.Controls.Add( btnYes );

      // calculate the location of the buttons so that they are centered
      // at the bottom
      btnYes.Location = new Point( this.Width / 2 - 75, this.txtMessage.Bottom + 5 );
      btnYes.Anchor = AnchorStyles.Bottom;
      btnYes.Size = new Size( 70, 20 );
      btnYes.DialogResult = DialogResult.Yes;
      this.AcceptButton = btnYes;

      Button btnNo = new Button();
      btnNo.Text = "No";
      this.Controls.Add( btnNo );
      btnNo.Location = new Point( this.Width / 2 + 5, this.txtMessage.Bottom + 5 );
      btnNo.Anchor = AnchorStyles.Bottom;
      btnNo.Size = new Size( 70, 20 );
      btnNo.DialogResult = DialogResult.No;
      this.CancelButton = btnNo;
    }

    private void AddOkCancelButtons()
    {
      Button btnOK = new Button();
      btnOK.Text = "OK";
      this.Controls.Add( btnOK );
      btnOK.Location = new Point( this.Width / 2 - 75, this.txtMessage.Bottom + 5 );
      btnOK.Anchor = AnchorStyles.Bottom;
      btnOK.Size = new Size( 70, 20 );
      btnOK.DialogResult = DialogResult.OK;
      this.AcceptButton = btnOK;

      Button btnCancel = new Button();
      btnCancel.Text = "Cancel";
      this.Controls.Add( btnCancel );
      btnCancel.Location = new Point( this.Width / 2 + 5, this.txtMessage.Bottom + 5 );
      btnCancel.Anchor = AnchorStyles.Bottom;
      btnCancel.Size = new Size( 70, 20 );
      btnCancel.DialogResult = DialogResult.Cancel;
      this.CancelButton = btnCancel;

    }


    /// <summary>
    /// Shows the specified text.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns></returns>
    public DialogResult Show( string text )
    {
      txtMessage.Text = text;
      ChooseButtons( MessageBoxButtons.OK );
      return this.ShowDialog();
    }

    private void ScrollableMessageBox_Resize( object sender, EventArgs e )
    {
      // txtMessage.SetBounds(0, 0, this.ClientRectangle.Width - 10, this.Height - 55);
    }

    private void ScrollableMessageBox_Load( object sender, EventArgs e )
    {
    }
    #endregion
  }
}