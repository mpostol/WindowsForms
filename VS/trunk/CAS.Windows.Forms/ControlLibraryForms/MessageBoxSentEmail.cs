//<summary>
//  Title   : MessageBox SentEmail
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2009, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using System;
using System.Windows.Forms;
using System.ComponentModel;
using CAS.Lib.ControlLibrary.Properties;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// MessageBoxSentEmail class- this class can display message boxes and open emial client
  /// </summary>
  public class MessageBoxSentEmail
  {
    #region static
    /// <summary>
    /// Opens the email client.
    /// </summary>
    /// <param name="EmailAddress">The email address.</param>
    /// <param name="MessageSubject">The message subject.</param>
    /// <param name="MessageBody">The message body.</param>
    /// <remarks>syntax: http://www.ianr.unl.edu/internet/mailto.html</remarks>
    public static void OpenEmailClient( string EmailAddress, string MessageSubject, string MessageBody )
    {
      try
      {
        MessageBody = MessageBody.Replace( "\r\n", "%0A" ) + "%0A"; // we have to change new line representation
        string request = String.Format( "mailto:{0}?subject={1}&body={2}", EmailAddress, MessageSubject, MessageBody );
        System.Diagnostics.Process.Start( request );
      }
      catch ( Win32Exception )
      {
        MessageBox.Show( Resources.noDefaultMailClient, Resources.problemWithMailClient, MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
      }
    }
    /// <summary>
    /// Shows the message and open email client.
    /// </summary>
    /// <param name="MessageToBeShown">The message to be shown.</param>
    /// <param name="MessageCaption">The message caption.</param>
    /// <param name="RequestedDialogResult">The requested dialog box result.</param>
    /// <param name="RequestedMessageBoxButtons">The requested message box buttons.</param>
    /// <param name="EmailAddress">The email address.</param>
    /// <param name="MessageSubject">The message subject.</param>
    /// <param name="MessageBody">The message body.</param>
    public static void ShowMessageAndOpenEmailClient( string MessageToBeShown, string MessageCaption,
      DialogResult RequestedDialogResult, MessageBoxButtons RequestedMessageBoxButtons,
      string EmailAddress, string MessageSubject, string MessageBody )
    {
      if ( MessageBox.Show( MessageToBeShown, MessageCaption, RequestedMessageBoxButtons ) == RequestedDialogResult )
      {
        OpenEmailClient( EmailAddress, MessageSubject, MessageBody );
      }
    }
    #endregion static
    #region private
    private string emailAddress;
    private string messageSubject;
    private string messageCaption;
    #endregion private
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageBoxSentEmail"/> class.
    /// </summary>
    /// <param name="EmailAddress">The email address.</param>
    /// <param name="MessageSubject">The message subject.</param>
    /// <param name="MessageCaption">The message caption.</param>
    public MessageBoxSentEmail( string EmailAddress, string MessageSubject, string MessageCaption )
    {
      emailAddress = EmailAddress;
      messageCaption = MessageCaption;
      messageSubject = MessageSubject;
    }
    /// <summary>
    /// Shows the message and send email if OK button is pressed.
    /// </summary>
    /// <param name="MessageToBeShown">The message to be shown.</param>
    /// <param name="MessageBody">The message body.</param>
    public void ShowMessageAndSendEmailIfOK( string MessageToBeShown, string MessageBody )
    {
      MessageToBeShown = MessageToBeShown + "\n\rClick OK to send email or Cancel otherwise.";
      ShowMessageAndOpenEmailClient( MessageToBeShown, messageCaption, DialogResult.OK, MessageBoxButtons.OKCancel, emailAddress, messageSubject, MessageBody );
    }
  }
}
