//<summary>
//  Title   : CAS.Lib.CodeProtect.Controls.UlockKeyDialog: Dialog used to provide the unlock key.
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
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using CAS.Lib.CodeProtect.LicenseDsc;
using CAS.Lib.CodeProtect.Properties;
using CAS.Lib.CodeProtect.EnvironmentAccess;


namespace CAS.Windows.Forms.CodeProtectControls
{
  /// <summary>
  /// Dialog used to provide the unlock key.
  /// </summary>
  public partial class UnlockKeyDialog: Form
  {
    #region public
    /// <summary>
    /// Initializes a new instance of the <see cref="UnlockKeyDialog"/> class.
    /// </summary>
    /// <param name="container">The container of the embedded resources.</param>
    private UnlockKeyDialog( UnlockKeyAssemblyContainer container )
    {
      InitializeComponent();
      this.m_HelpText.Rtf = Resources.HowToUlock_docx;
      m_Container = container;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="UnlockKeyDialog"/> class.
    /// </summary>
    /// <param name="assembly">The assembly - container of the embedded resources.</param>
    public UnlockKeyDialog( Assembly assembly )
      : this( new UnlockKeyAssemblyContainer( assembly ) )
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="UnlockKeyDialog"/> class.
    /// </summary>
    /// <param name="assemblyName">Name of an assembly that is a container of the embedded resources.</param>
    public UnlockKeyDialog( string assemblyName )
      : this( new UnlockKeyAssemblyContainer( assemblyName ) )
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="UnlockKeyDialog"/> class. It uses a default container of the embedded resources.
    /// </summary>
    public UnlockKeyDialog()
      : this( new UnlockKeyAssemblyContainer() )
    { }
    /// <summary>
    /// Adds the <see cref="ToolStripMenuItem"/> to the <paramref name="toolStripItemCollection"/> that handles all
    /// operations to unlock the software.
    /// </summary>
    /// <param name="toolStripItemCollection">The tool strip item collection.</param>
    public static void AddMenu( ToolStripItemCollection toolStripItemCollection )
    {
      AddMenu( toolStripItemCollection, Resources.CASCommonResources );
    }
    /// <summary>
    /// Adds the <see cref="ToolStripMenuItem"/> to the <paramref name="toolStripItemCollection"/> that handles all
    /// operations to unlock the software.
    /// </summary>
    /// <param name="toolStripItemCollection">The tool strip item collection.</param>
    /// <param name="assemblyName">Name of the assembly.</param>
    public static void AddMenu( ToolStripItemCollection toolStripItemCollection, string assemblyName )
    {
      UnlockKeyAssemblyContainer container = new UnlockKeyAssemblyContainer( assemblyName );
      if ( container == null )
        return;
      Invoker inv = new Invoker( container );
      AddMenu( toolStripItemCollection, inv );
    }
    /// <summary>
    /// Adds the <see cref="ToolStripMenuItem"/> to the <paramref name="toolStripItemCollection"/>.
    /// </summary>
    /// <param name="toolStripItemCollection">The tool strip item collection.</param>
    /// <param name="resourceContainer">The resource container.</param>
    public static void AddMenu( ToolStripItemCollection toolStripItemCollection, Assembly resourceContainer )
    {
      Invoker inv = new Invoker( new UnlockKeyAssemblyContainer( resourceContainer ) );
      AddMenu( toolStripItemCollection, inv );
    }
    #endregion

    #region private
    private static void AddMenu( ToolStripItemCollection toolStripItemCollection, Invoker inv )
    {
      ToolStripMenuItem mi = new ToolStripMenuItem( Resources.MenuItemText )
      {
        ToolTipText = Resources.MenuItemToolTipText,
        ShortcutKeys = Keys.Alt | Keys.K,
        ShowShortcutKeys = true,
        Image = Bitmap.FromHicon( Resources.SecurityUnlock.ToBitmap().GetHicon() )
      };
      mi.Click += new EventHandler( inv.ClickHandler );
      toolStripItemCollection.Add( mi );
    }

    private class Invoker
    {
      /// <summary>
      /// Initializes a new instance of the <see cref="Invoker"/> class.
      /// </summary>
      /// <param name="container">The container.</param>
      internal Invoker( UnlockKeyAssemblyContainer container )
      {
        m_Container = container;
      }
      /// <summary>
      /// Handles the menu item click and shows the <see cref="UnlockKeyDialog"/> .
      /// </summary>
      /// <param name="sender">The sender.</param>
      /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
      internal void ClickHandler( object sender, EventArgs e )
      {
        if ( m_Container == null )
          return;
        using ( UnlockKeyDialog dialog = new UnlockKeyDialog( m_Container ) )
        {
          dialog.ShowDialog();
        }
      }
      private UnlockKeyAssemblyContainer m_Container;
    }
    private UnlockKeyAssemblyContainer m_Container;
    private void m_OKButton_Click( object sender, EventArgs e )
    {
      if ( String.IsNullOrEmpty( m_UnlockKey.Text ) )
        return;
      string path = String.Empty;
      try
      {
        path = m_Container.GetManifestResourcePath( m_UnlockKey.Text );
        if ( String.IsNullOrEmpty( path ) )
        {
          MessageBox.Show
             (
               Resources.UnlockFindingLicenseFailureMessage,
               Resources.UnlockInalationFailureCaption,
               MessageBoxButtons.OK,
               MessageBoxIcon.Error
              );
          return;
        }
      }
      catch ( Exception )
      {
        MessageBox.Show
          (
            Resources.UnlockFindingLicenseFailureMessage,
            Resources.UnlockInalationFailureCaption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
        return;
      }
      try
      {
        using ( Stream _stream = m_Container.GetManifestResourceStream( path ) )
          LicenseFile.UpgradeLicense( _stream );
        MessageBox.Show
          (
            Resources.UnlockSuccessMessge,
            Resources.UnlockSuccessCaption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
          );
        this.Close();
      }
      catch ( Exception ex )
      {
        MessageBox.Show
          (
            LicenseFileException.TraceInnerExceptions( ex, Resources.UnlockFailureMessge ),
            Resources.UnlockInalationFailureCaption,
            MessageBoxButtons.OK,
            MessageBoxIcon.Error
          );
      }
    }
    private void m_HelpText_LinkClicked( object sender, LinkClickedEventArgs e )
    {
      try
      {
        System.Diagnostics.Process.Start( e.LinkText );
      }
      catch ( Exception ) { }
    }
    #endregion
  }
}
