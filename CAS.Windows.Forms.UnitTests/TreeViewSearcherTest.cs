//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using CAS.Lib.ControlLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace CAS.Windows.Forms.UnitTests
{

  /// <summary>
  ///This is a test class for TreeViewSearcherTest and is intended
  ///to contain all TreeViewSearcherTest Unit Tests
  ///</summary>
  [TestClass()]
  public class TreeViewSearcherTest
  {

    private TreeView m_TreeView;
    private string[] stringlist;
    private TestContext testContextInstance;

    /// <summary>
    ///Gets or sets the test context which provides
    ///information about and functionality for the current test run.
    ///</summary>
    public TestContext TestContext
    {
      get
      {
        return testContextInstance;
      }
      set
      {
        testContextInstance = value;
      }
    }

    #region Additional test attributes
    // 
    //You can use the following additional attributes as you write your tests:
    //
    //Use ClassInitialize to run code before running the first test in the class
    //[ClassInitialize()]
    //public static void MyClassInitialize( TestContext testContext )
    //{
    //}
    //
    //Use ClassCleanup to run code after all tests in a class have run
    //[ClassCleanup()]
    //public static void MyClassCleanup()
    //{
    //}
    //
    //Use TestInitialize to run code before running each test
    [TestInitialize()]
    public void MyTestInitialize()
    {
      //tree "c:\Program Files\Microsoft.NET"   /F /A:
      // +---ADOMD.NET
      //|   \---90
      //|       |---Microsoft.AnalysisServices.AdomdClient.dll
      //|       |   
      //|       \---en
      //|            \ Microsoft.AnalysisServices.AdomdClient.xml
      //|               
      //|       
      //+---Primary Interop Assemblies
      //|     |-adodb.dll
      //|     \-Microsoft.mshtml.dll
      //|       
      //\---SDK
      //    \---CompactFramework
      //        +---v2.0
      //        |   |---rootdir
      //        |   |   
      //        |   +---bin
      //        |   |    |--logviewer.exe
      //        |   |    \--MdbgNetcf.dll
      //        |   |       
      //        |   +---Debugger
      //        |   |   |---Icordbg.dll
      //        |   |   |   
      //        |   |   \---BCL
      //        |   |        |-CustomMarshalers.dll
      //        |   |        \-Microsoft.VisualBasic.dll
      stringlist = new string[ 20 ];
      m_TreeView = new TreeView();
      stringlist[ 0 ] = "ADOMD.NET";
      m_TreeView.Nodes.Add( "ADOMD.NET" );
      stringlist[ 1 ] = "90";
      m_TreeView.Nodes[ 0 ].Nodes.Add( "90" );
      stringlist[ 2 ] = "Microsoft.AnalysisServices.AdomdClient.dll";
      m_TreeView.Nodes[ 0 ].Nodes[ 0 ].Nodes.Add( "Microsoft.AnalysisServices.AdomdClient.dll" );
      stringlist[ 3 ] = "en";
      m_TreeView.Nodes[ 0 ].Nodes[ 0 ].Nodes.Add( "en" );
      stringlist[ 4 ] = "Microsoft.AnalysisServices.AdomdClient.xml";
      m_TreeView.Nodes[ 0 ].Nodes[ 0 ].Nodes[ 1 ].Nodes.Add( "Microsoft.AnalysisServices.AdomdClient.xml" );
      stringlist[ 5 ] = "Primary Interop Assemblies";
      m_TreeView.Nodes.Add( "Primary Interop Assemblies" );
      stringlist[ 6 ] = "adodb.dll";
      m_TreeView.Nodes[ 1 ].Nodes.Add( "adodb.dll" );
      stringlist[ 7 ] = "Microsoft.mshtml.dll";
      m_TreeView.Nodes[ 1 ].Nodes.Add( "Microsoft.mshtml.dll" );
      stringlist[ 8 ] = "SDK";
      m_TreeView.Nodes.Add( "SDK" );
      stringlist[ 9 ] = "CompactFramework";
      m_TreeView.Nodes[ 2 ].Nodes.Add( "CompactFramework" );
      stringlist[ 10 ] = "v2.0";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes.Add( "v2.0" );
      stringlist[ 11 ] = "rootdir";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes.Add( "rootdir" );
      stringlist[ 12 ] = "bin";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes.Add( "bin" );
      stringlist[ 13 ] = "logviewer.exe";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes[ 1 ].Nodes.Add( "logviewer.exe" );
      stringlist[ 14 ] = "MdbgNetcf.dll";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes[ 1 ].Nodes.Add( "MdbgNetcf.dll" );
      stringlist[ 15 ] = "Debugger";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes.Add( "Debugger" );
      stringlist[ 16 ] = "Icordbg.dll";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes[ 2 ].Nodes.Add( "Icordbg.dll" );
      stringlist[ 17 ] = "BCL";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes.Add( "BCL" );
      stringlist[ 18 ] = "CustomMarshalers.dll";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes[ 3 ].Nodes.Add( "CustomMarshalers.dll" );
      stringlist[ 19 ] = "Microsoft.VisualBasic.dll";
      m_TreeView.Nodes[ 2 ].Nodes[ 0 ].Nodes[ 0 ].Nodes[ 3 ].Nodes.Add( "Microsoft.VisualBasic.dll" );
    }
    //
    //Use TestCleanup to run code after each test has run
    //[TestCleanup()]
    //public void MyTestCleanup()
    //{
    //}
    //
    #endregion

    private int GetNextStringIndexFromStringList( int startingindex, string TextToBeSearched )
    {
      int ret = -1;
      startingindex++;
      while ( startingindex < stringlist.Length )
      {
        if ( stringlist[ startingindex ].Contains( TextToBeSearched ) )
        {
          ret = startingindex;
          break;
        }
        startingindex++;
      }
      return ret;
    }

    /// <summary>
    ///A test for SearchAndReturnNextNodeThatContainsText
    ///</summary>
    [TestMethod()]
    public void SearchAndReturnNextNodeThatContainsTextTest()
    {
      m_TreeView.SelectedNode = m_TreeView.Nodes[ 0 ];
      string TextToBeSearched = "Microsoft"; // TODO: Initialize to an appropriate value
      bool Forward = true; // TODO: Initialize to an appropriate value
      StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase; // TODO: Initialize to an appropriate value
      string expected;
      string actual;
      int idx = 0;
      TreeNode foundNode = m_TreeView.SelectedNode;
      while ( true )
      {
        idx = GetNextStringIndexFromStringList( idx, TextToBeSearched );
        foundNode = TreeViewSearcher.SearchAndReturnNextNodeThatContainsText( foundNode, TextToBeSearched, Forward, false, stringComparison );
        if ( idx < 0 )
          break;
        Assert.AreNotEqual( null, foundNode );
        expected = stringlist[ idx ];
        actual = foundNode.Text;
        Assert.AreEqual( expected, actual );
      }
      Assert.AreEqual( null, foundNode );
    }
    /// <summary>
    ///A test for SearchAndSelectNextNodeThatContainsText
    ///</summary>
    [TestMethod()]
    public void SearchAndSelectNextNodeThatContainsTextTest()
    {
      m_TreeView.SelectedNode = m_TreeView.Nodes[ 0 ];
      string TextToBeSearched = "Microsoft"; // TODO: Initialize to an appropriate value
      bool Forward = true; // TODO: Initialize to an appropriate value
      StringComparison stringComparison = StringComparison.InvariantCultureIgnoreCase; // TODO: Initialize to an appropriate value
      string expected = "Microsoft.AnalysisServices.AdomdClient.dll"; // TODO: Initialize to an appropriate value
      string actual;
      Assert.AreEqual( true, TreeViewSearcher.SearchAndSelectNextNodeThatContainsText( m_TreeView, TextToBeSearched, Forward, true, stringComparison ) );
      actual = m_TreeView.SelectedNode.Text;
      Assert.AreEqual( expected, actual );
    }
    /// <summary>
    ///A test for GetLastNodeOfTheTreeView
    ///</summary>
    [TestMethod()]
    public void GetLastNodeOfTheTreeViewTest()
    {
      TreeNode LastTreeNode = TreeViewSearcher.GetLastNodeOfTheTreeView( m_TreeView );
      Assert.AreEqual( stringlist[ stringlist.Length - 1 ], LastTreeNode.Text );
    }
    /// <summary>
    ///A test for GetNextNode
    ///</summary>
    [TestMethod()]
    public void GetNextNodeTest()
    {
      TreeNode CurrentTreeNode = m_TreeView.Nodes[ 0 ];
      TreeNode NextTreeNode;
      string actual;
      string expected;
      //test with jump to the beginning
      for ( int idx = 1; idx < ( stringlist.Length * 2 ); idx++ )
      {
        NextTreeNode = TreeViewSearcher.GetNextNode( CurrentTreeNode, true );
        actual = NextTreeNode.Text;
        if ( idx < stringlist.Length )
          expected = stringlist[ idx ];
        else
          expected = stringlist[ idx - stringlist.Length ];
        Assert.AreEqual( expected, actual, "test with jump to the beginning has failed" );
        CurrentTreeNode = NextTreeNode;
      }
      //test without jump to the beginning
      CurrentTreeNode = m_TreeView.Nodes[ 0 ];
      for ( int idx = 1; idx < stringlist.Length; idx++ )
      {
        NextTreeNode = TreeViewSearcher.GetNextNode( CurrentTreeNode, false );
        actual = NextTreeNode.Text;
        if ( idx < stringlist.Length )
          expected = stringlist[ idx ];
        else
          expected = stringlist[ idx - stringlist.Length ];
        Assert.AreEqual( expected, actual, "test without jump to the beginning has failed" );
        CurrentTreeNode = NextTreeNode;
      }
      NextTreeNode = TreeViewSearcher.GetNextNode( CurrentTreeNode, false );
      //we expect that we have passed the end of the tree so returned node should be null
      Assert.AreEqual( null, NextTreeNode, "node should be null at the end" );
    }
    /// <summary>
    ///A test for GetPreviousNode
    ///</summary>
    [TestMethod()]
    public void GetPreviousNodeTest()
    {
      TreeNode CurrentTreeNode = TreeViewSearcher.GetLastNodeOfTheTreeView( m_TreeView );
      TreeNode NextTreeNode;
      string actual;
      string expected;
      //test with jump to the beginning
      for ( int idx = ( stringlist.Length * 2 ) - 1; idx > 0; idx-- )
      {
        NextTreeNode = TreeViewSearcher.GetPreviousNode( CurrentTreeNode, true );
        actual = NextTreeNode.Text;
        if ( idx <= stringlist.Length )
          expected = stringlist[ idx - 1 ];
        else
          expected = stringlist[ idx - stringlist.Length - 1 ];
        Assert.AreEqual( expected, actual, "test with jump to the beginning has failed" );
        CurrentTreeNode = NextTreeNode;
      }
      //test without jump to the beginning
      CurrentTreeNode = TreeViewSearcher.GetLastNodeOfTheTreeView( m_TreeView );
      for ( int idx = stringlist.Length - 1; idx > 0; idx-- )
      {
        NextTreeNode = TreeViewSearcher.GetPreviousNode( CurrentTreeNode, false );
        actual = NextTreeNode.Text;
        if ( idx < stringlist.Length )
          expected = stringlist[ idx - 1 ];
        else
          expected = stringlist[ idx - stringlist.Length - 1 ];
        Assert.AreEqual( expected, actual, "test without jump to the beginning has failed" );
        CurrentTreeNode = NextTreeNode;
      }
      NextTreeNode = TreeViewSearcher.GetPreviousNode( CurrentTreeNode, false );
      //we expect that we have passed the end of the tree so returned node should be null
      Assert.AreEqual( null, NextTreeNode, "node should be null at the end" );
    }
  }

}
