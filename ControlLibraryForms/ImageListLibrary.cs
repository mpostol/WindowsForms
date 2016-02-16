using System.ComponentModel;
//<summary>
//  Title   : Image List Library
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2006, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto:techsupp@cas.com.pl
//  http:\\www.cas.eu
//</summary>
using System.Windows.Forms;
namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// Image List Library
  /// </summary>
  public partial class ImageListLibrary: Component
  {
    private static ImageListLibrary m_ImageListLibrary = new ImageListLibrary();
    // global constants
    /// <summary>
    /// 
    /// </summary>
    public enum Icons: int
    {
      /// <summary>
      /// image closed yellow folder
      /// </summary>
      IMAGE_CLOSED_YELLOW_FOLDER,
      /// <summary>
      /// image open yellow folder
      /// </summary>
      IMAGE_OPEN_YELLOW_FOLDER,
      /// <summary>
      /// image subscription
      /// </summary>
      IMAGE_SUBSCRIPTION,
      /// <summary>
      /// image subscription standby
      /// </summary>
      IMAGE_SUBSCRIPTION_SB,
      /// <summary>
      /// image subscription standby
      /// </summary>
      IMAGE_SUBSCRIPTION_FAIL,
      /// <summary>
      /// image subscription worning
      /// </summary>
      IMAGE_SUBSCRIPTION_WOR,
      /// <summary>
      /// image subscription disabled
      /// </summary>
      IMAGE_SUBSCRIPTION_DISABLED,
      /// <summary>
      /// image tag
      /// </summary>
      IMAGE_TAG,
      /// <summary>
      /// image tag standby
      /// </summary>
      IMAGE_TAG_SB,
      /// <summary>
      /// image tag fail
      /// </summary>
      IMAGE_TAG_FAIL,
      /// <summary>
      /// image tag worning
      /// </summary>
      IMAGE_TAG_WOR,
      /// <summary>
      /// image property
      /// </summary>
      IMAGE_PROPERTY,
      /// <summary>
      /// image property standby
      /// </summary>
      IMAGE_PROPERTY_SB,
      /// <summary>
      /// image property fail
      /// </summary>
      IMAGE_PROPERTY_FAIL,
      /// <summary>
      /// image property worning
      /// </summary>
      IMAGE_PROPERTY_WOR,
      /// <summary>
      /// image opc server
      /// </summary>
      IMAGE_OPC_SERVER,
      /// <summary>
      /// image opc server standby
      /// </summary>
      IMAGE_OPC_SERVER_SB,
      /// <summary>
      /// image opc server fail
      /// </summary>
      IMAGE_OPC_SERVER_FAIL,
      /// <summary>
      /// image opc server worning
      /// </summary>
      IMAGE_OPC_SERVER_WOR,
      /// <summary>
      /// image network
      /// </summary>
      IMAGE_NETWORK,
      /// <summary>
      /// image mycomputer
      /// </summary>
      IMAGE_MYCOMPUTER,
      /// <summary>
      /// image dictionary
      /// </summary>
      IMAGE_DICTIONARY,
      /// <summary>
      /// image processing environment
      /// </summary>
      IMAGE_PROCESSING_ENVIRONMENT,
      /// <summary>
      /// image transaction
      /// </summary>
      IMAGE_TRANSACTION,
      /// <summary>
      /// image operation
      /// </summary>
      IMAGE_OPERATION,
      /// <summary>
      /// image network folder
      /// </summary>
      IMAGE_OPC_ENVIRONMENT
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="ImageListLibrary"/> class.
    /// </summary>
    public ImageListLibrary()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Gets the project image list.
    /// </summary>
    /// <value>The project image list.</value>
    public ImageList ProjectImageList { get { return m_ImageList; } }
    /// <summary>
    /// Gets the project static image list.
    /// </summary>
    /// <value>The project image list.</value>
    public static ImageList StaticProjectImageList { get { return m_ImageListLibrary.m_ImageList; } }
  }
}
