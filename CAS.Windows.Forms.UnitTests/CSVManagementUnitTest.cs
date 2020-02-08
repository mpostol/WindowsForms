using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UAOOI.Windows.Forms;

namespace UAOOI.Windows.Forms
{
  [TestClass]
  public class CSVManagementUnitTest
  {
    [TestMethod]
    [DeploymentItem("TestData", "TestData")]
    public void CreatorTestMethod()
    {
      Assert.IsTrue(m_testFile.Exists);
      CSVManagement _buffer = CSVManagement.ReadFile(m_testFile.FullName);
      Assert.AreEqual ("Alpha", _buffer.GetAndMove2NextElement());
      Assert.AreEqual("Kilo", _buffer.GetAndMove2NextElement(10));
    }
    [TestMethod]
    [DeploymentItem("TestData", "TestData")]
    public void BeforeNewLineTestMethod()
    {
      Assert.IsTrue(m_testFile.Exists);
      CSVManagement _buffer = CSVManagement.ReadFile(m_testFile.FullName);
      Assert.AreEqual("Juliet", _buffer.GetAndMove2NextElement(10));
    }
    [TestMethod]
    [DeploymentItem("TestData", "TestData")]
    public void AfterNewLineTestMethod()
    {
      Assert.IsTrue(m_testFile.Exists);
      CSVManagement _buffer = CSVManagement.ReadFile(m_testFile.FullName);
      Assert.AreEqual("Kilo", _buffer.GetAndMove2NextElement(11));
    }
    [TestMethod]
    [DeploymentItem("TestData", "TestData")]
    public void LastItemTestMethod()
    {
      Assert.IsTrue(m_testFile.Exists);
      CSVManagement _buffer = CSVManagement.ReadFile(m_testFile.FullName);
      Assert.AreEqual("Zulu", _buffer.GetAndMove2NextElement(26));
    }
    private readonly FileInfo m_testFile = new FileInfo(@"TestData\CSVManagementTestData.csv");
  }
}
