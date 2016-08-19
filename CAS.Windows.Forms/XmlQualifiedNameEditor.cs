﻿//<summary>
//  Title   : XmlQualifiedName Editor
//  System  : Microsoft Visual C# .NET 2008
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C)2008, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//</summary>

using CAS.Windows.Forms.Properties;
using System;
using System.ComponentModel;
using System.Xml;

namespace CAS.Lib.ControlLibrary
{
  /// <summary>
  /// XmlQualifiedName Editor
  /// </summary>
  public class XmlQualifiedNameEditor
  {
    #region private
    private static uint m_Counter = 0;
    private static string DefaultName { get { return String.Format( Settings.Default.XmlDefaultName, m_Counter++ ); } }
    private string Normalize( string value )
    {
      return XmlConvert.EncodeLocalName( value.Trim() ).Replace("_x", "X");
    }
    private string m_Name;
    private string m_NameSpace;
    private void RaiseXmlQualifiedNameHasChanged()
    {
      if ( XmlQualifiedNameHasChanged != null )
        XmlQualifiedNameHasChanged( this, EventArgs.Empty );
    }
    #endregion
    #region public properties
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    [
    DisplayName( "Name" ),
    BrowsableAttribute( true ),
    DescriptionAttribute( "The name" ),
    NotifyParentPropertyAttribute( true )
    ]
    public string Name
    {
      get { return m_Name; }
      set
      {
        m_Name = Normalize(value);
        NameIsBasedOnDefault = false;
        RaiseXmlQualifiedNameHasChanged();
      }
    }
    /// <summary>
    /// Gets or sets the name space.
    /// </summary>
    /// <value>The name space.</value>
    [
    DisplayName( "Name Space" ),
    TypeConverter( typeof( NamespaceConverter ) ),
    BrowsableAttribute( true ),
    DescriptionAttribute( "The name space" ),
    NotifyParentPropertyAttribute( true )
    ]
    public string NameSpace
    {
      get
      {
        if ( !IsEmpty && String.IsNullOrEmpty( m_NameSpace ) )
          return NamespaceProvider.GetTargetNamespace();
        return m_NameSpace;
      }
      set
      {
        m_NameSpace = value;
        NameIsBasedOnDefault = false;
        RaiseXmlQualifiedNameHasChanged();
      }
    }
    /// <summary>
    /// Gets or sets a value indicating whether this instance is empty.
    /// </summary>
    /// <value><c>true</c> if this instance is empty; otherwise, <c>false</c>.</value>
    [
    DisplayName( "Is Empty" ),
    BrowsableAttribute( true ),
    DescriptionAttribute( "The value indicating whether this instance is empty." ),
    NotifyParentPropertyAttribute( true )
    ]
    public bool IsEmpty { get { return String.IsNullOrEmpty( m_Name ) && String.IsNullOrEmpty( m_NameSpace ); } }
    /// <summary>
    /// Gets or sets a value indicating whether name is based on default name.
    /// </summary>
    /// <value>
    /// 	<c>true</c> if name is based on default name otherwise, <c>false</c>.
    /// </value>
    [ BrowsableAttribute( false )]
    public bool NameIsBasedOnDefault { get; private set; }
    #endregion
    #region public
    /// <summary>
    /// Updates the name and namespace based on passed value.
    /// </summary>
    /// <param name="value">The value.</param>
    public void UpdateNameAndNamespaceBasedOn( XmlQualifiedNameEditor value )
    {
      if ( value == null )
        throw new ArgumentNullException( "value" );
      this.Name = value.Name;
      this.NameSpace = value.NameSpace;
    }
    /// <summary>
    /// Updates the name and namespace and namespace provider based on passed value.
    /// </summary>
    /// <param name="value">The value.</param>
    public void UpdateNameAndNamespaceAndNamespaceProviderBasedOn( XmlQualifiedNameEditor value )
    {
      this.UpdateNameAndNamespaceBasedOn( value );
      this.NamespaceProvider = value.NamespaceProvider;
    }
    /// <summary>
    /// Determines whether the name is empty or the name is null.
    /// </summary>
    /// <returns>
    /// 	<c>true</c> if the specified name is null; otherwise <c>false</c>.
    /// </returns>
    [BrowsableAttribute( false )]
    public bool IsNull { get { return IsEmpty || String.IsNullOrEmpty( Name ); } }
    /// <summary>
    /// Occurs when [XML qualified name has changed].
    /// </summary>
    public event EventHandler XmlQualifiedNameHasChanged;
    /// <summary>
    /// Gets the XmlQualifiedName edited by this editor.
    /// </summary>
    /// <value>The XmlQualifiedName or null if XmlQualifiedName is empty</value>
    [BrowsableAttribute( false )]
    public XmlQualifiedName XmlQualifiedName
    {
      get
      {
        if ( !IsEmpty )
          return new XmlQualifiedName( Name, NameSpace );
        else
          return null; //XmlQualifiedNameEditor should not return empty XmlQualifiedName - only null is allowed
      }
    }
    /// <summary>
    /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </summary>
    /// <returns>
    /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
    /// </returns>
    public override string ToString()
    {
      if ( !IsEmpty )
        return NameSpace + ":" + Name;
      else
        return "<not set>";
    }
    /// <summary>
    /// Gets or sets the namespace provider.
    /// </summary>
    /// <value>The namespace provider.</value>
    internal IXmlQualifiedNameEditorNamespaceProvider NamespaceProvider { get; private set; }
    /// <summary>
    /// Gets the name or generate if instance is null.
    /// </summary>
    /// <param name="qualifiedName">Name property of the qualified name or autogenerated identyfier.</param>
    /// <returns></returns>
    public static string GetNameOrGenerateIfInstanceIsNull( XmlQualifiedName qualifiedName )
    {
      return qualifiedName == null ? DefaultName : qualifiedName.Name;
    }
    /// <summary>
    /// Gets the namespace or generate if instance is null.
    /// </summary>
    /// <param name="qualifiedName">Namespace of the qualified neame or autogenerated identyfier.</param>
    /// <returns></returns>
    public static string GetNamespaceOrGenerateIfInstanceIsNull( XmlQualifiedName qualifiedName )
    {
      return qualifiedName == null ? DefaultName : qualifiedName.Namespace;
    }
    /// <summary>
    /// Creates the XML qualified name editor.
    /// </summary>
    /// <param name="namespaceProvider">The namespace provider.</param>
    /// <returns></returns>
    public static XmlQualifiedNameEditor CreateXmlQualifiedNameEditor( IXmlQualifiedNameEditorNamespaceProvider namespaceProvider )
    {
      return new XmlQualifiedNameEditor( DefaultName, String.Empty, namespaceProvider );
    }
    #endregion
    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlQualifiedNameEditor"/> class. It does not create default names if <paramref name="xmlQualifiedName"/> is null.
    /// </summary>
    /// <param name="xmlQualifiedName">XmlQualifiedName to be edited.</param>
    /// <param name="namespaceProvider">The namespace provider.</param>
    public XmlQualifiedNameEditor( XmlQualifiedName xmlQualifiedName, IXmlQualifiedNameEditorNamespaceProvider namespaceProvider ) :
      this( xmlQualifiedName, namespaceProvider, false )
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlQualifiedNameEditor"/> class.
    /// </summary>
    /// <param name="xmlQualifiedName">XmlQualifiedName to be edited.</param>
    /// <param name="namespaceProvider">The namespace provider.</param>
    /// <param name="createDefault">if set to <c>true</c> assigns a default value for the <see cref="Name"/> parameter.
    /// </param>
    public XmlQualifiedNameEditor( XmlQualifiedName xmlQualifiedName, IXmlQualifiedNameEditorNamespaceProvider namespaceProvider, bool createDefault )
    {
      if ( xmlQualifiedName != null )
      {
        Name = xmlQualifiedName.Name;
        m_NameSpace = xmlQualifiedName.Namespace;
      }
      else
      {
        m_Name = createDefault ? DefaultName : String.Empty;
        m_NameSpace = String.Empty;
        NameIsBasedOnDefault = createDefault;
      }
      NamespaceProvider = namespaceProvider;
    }
    /// <summary>
    /// Initializes a new instance of the <see cref="XmlQualifiedNameEditor"/> class with
    /// the specified name and namespace..
    /// </summary>
    /// <param name="name">The local name to use as the name of the System.Xml.XmlQualifiedName object.</param>
    /// <param name="ns">The namespace for the System.Xml.XmlQualifiedName object.</param>
    /// <param name="namespaceProvider">The namespace provider.</param>
    public XmlQualifiedNameEditor( string name, string ns, IXmlQualifiedNameEditorNamespaceProvider namespaceProvider )
    {
      Name = name;
      NameSpace = ns;
      NamespaceProvider = namespaceProvider;
    }
    #endregion
  }
  #region TypeConverter class
  /// <summary>
  /// This class is used in DataTypeConverter dropdown list 
  /// </summary>
  internal class NamespaceConverter: StringConverter
  {
    /// <summary>
    /// Gets a value indicating whether this object supports a standard set of values that can be picked from a list. 
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context. </param>
    /// <returns>Always returns <b>true</b> - means show a combobox </returns>
    public override bool GetStandardValuesSupported( ITypeDescriptorContext context )
    {
      //true means show a combobox
      return true;
    }
    /// <summary>
    /// Gets a value indicating whether the list of standard values returned from the GetStandardValues method is an exclusive list. 
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context. </param>
    /// <returns>Always returns <b>true</b> - means it limits to list</returns>
    public override bool GetStandardValuesExclusive( ITypeDescriptorContext context )
    {
      //true will limit to list. false will show the list, but allow free-form entry
      return false;
    }
    /// <summary>
    /// Gets a collection of standard values for the data type this validator is designed for. 
    /// </summary>
    /// <param name="context">An <see cref="ITypeDescriptorContext"/> that provides a format context. </param>
    /// <returns>A <see cref="TypeConverter.StandardValuesCollection"/>  that holds a standard set of valid values </returns>
    public override StandardValuesCollection GetStandardValues( ITypeDescriptorContext context )
    {
      XmlQualifiedNameEditor editor = context.Instance as XmlQualifiedNameEditor;
      if ( editor != null && editor.NamespaceProvider != null )
      {
        return new StandardValuesCollection( editor.NamespaceProvider.GetAvailiableNamespaces() );
      }
      return new StandardValuesCollection( new string[ 0 ] );
    }
  }
  #endregion

  #region IXmlQualifiedNameEditorNamespaceProvider
  /// <summary>
  /// Interface responsible for creating the list of availiable namespaces
  /// </summary>
  public interface IXmlQualifiedNameEditorNamespaceProvider
  {
    /// <summary>
    /// Gets the availiable namespaces.
    /// </summary>
    /// <returns></returns>
    string[] GetAvailiableNamespaces();
    /// <summary>
    /// Gets the target namespace of the current model.
    /// </summary>
    /// <returns>The target namespace.</returns>
    string GetTargetNamespace();
  }
  #endregion IXmlQualifiedNameEditorNamespaceProvider
}
