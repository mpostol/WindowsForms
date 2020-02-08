//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using UAOOI.Windows.Forms.Properties;

namespace UAOOI.Windows.Forms
{
  /// <summary>
  /// MessageBoxSentEmail class- this class can display message boxes and open email client
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
    public static void OpenEmailClient(string EmailAddress, string MessageSubject, string MessageBody)
    {
      try
      {
        MessageBody = MessageBody.Replace("\r\n", "%0A") + "%0A"; // we have to change new line representation
        string request = string.Format("mailto:{0}?subject={1}&body={2}", EmailAddress, MessageSubject, MessageBody);
        Process.Start(request);
      }
      catch (Win32Exception)
      {
        MessageBox.Show(Resources.noDefaultMailClient, Resources.problemWithMailClient, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
    public static void ShowMessageAndOpenEmailClient(string MessageToBeShown, string MessageCaption,
      DialogResult RequestedDialogResult, MessageBoxButtons RequestedMessageBoxButtons,
      string EmailAddress, string MessageSubject, string MessageBody)
    {
      if (MessageBox.Show(MessageToBeShown, MessageCaption, RequestedMessageBoxButtons) == RequestedDialogResult)
      {
        OpenEmailClient(EmailAddress, MessageSubject, MessageBody);
      }
    }
    #endregion static

    #region private
    private readonly string emailAddress;
    private readonly string messageSubject;
    private readonly string messageCaption;
    #endregion private

    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageBoxSentEmail"/> class.
    /// </summary>
    /// <param name="EmailAddress">The email address.</param>
    /// <param name="MessageSubject">The message subject.</param>
    /// <param name="MessageCaption">The message caption.</param>
    public MessageBoxSentEmail(string EmailAddress, string MessageSubject, string MessageCaption)
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
    public void ShowMessageAndSendEmailIfOK(string MessageToBeShown, string MessageBody)
    {
      MessageToBeShown = MessageToBeShown + "\n\rClick OK to send email or Cancel otherwise.";
      ShowMessageAndOpenEmailClient(MessageToBeShown, messageCaption, DialogResult.OK, MessageBoxButtons.OKCancel, emailAddress, messageSubject, MessageBody);
    }
    #endregion

  }
}
