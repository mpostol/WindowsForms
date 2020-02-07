//___________________________________________________________________________________
//
//  Copyright (C) 2020, Mariusz Postol LODZ POLAND.
//
//  To be in touch join the community at GITTER: https://gitter.im/mpostol/OPC-UA-OOI
//___________________________________________________________________________________

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using UAOOI.Windows.Forms.Properties;

namespace CAS.Windows.Forms.UnitTests
{
  [TestClass]
  public class ResourcesUnitTest
  {
    [TestMethod]
    public void ImagesTestMethod()
    {
      Bitmap _startBitmap = Resources.start;
      Assert.IsNotNull(_startBitmap);
      _startBitmap = Resources.stop;
      Assert.IsNotNull(_startBitmap);
      _startBitmap = Resources.restart;
      Assert.IsNotNull(_startBitmap);
    }
  }
}
