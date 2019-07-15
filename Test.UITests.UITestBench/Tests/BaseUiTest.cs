using NUnit.Framework;
using Xamarin.UITest;

namespace Test.UITests.UITestBench
{
  [TestFixture(Platform.Android)]
  // [TestFixture(Platform.iOS)]
  internal abstract class BaseUiTest
  {
    private readonly Platform _platform;

    protected IApp _app { get; private set; }

    protected BaseUiTest(Platform platform) => _platform = platform;

    [SetUp]
    virtual public void BeforeEachTest()
    {
      _app = AppInitializer.StartApp(_platform);
    }
  }
}