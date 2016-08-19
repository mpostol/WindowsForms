
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace CAS.Windows.FormsUnitTests
{
  [TestClass]
  public class ResourcesUnitTest
  {
    [TestMethod]
    public void ImagesTestMethod()
    {
      Bitmap _startBitmap = Forms.Properties.Resources.start;
      Assert.IsNotNull(_startBitmap);
      _startBitmap = Forms.Properties.Resources.stop;
      Assert.IsNotNull(_startBitmap);
      _startBitmap = Forms.Properties.Resources.restart;
      Assert.IsNotNull(_startBitmap);
    }
  }
}
