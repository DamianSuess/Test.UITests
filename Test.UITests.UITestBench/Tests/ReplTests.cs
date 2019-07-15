using NUnit.Framework;
using Xamarin.UITest;

namespace Test.UITests.UITestBench
{
  [TestFixture(Platform.Android)]
  // [TestFixture(Platform.iOS)]
  public class ReplTests : BaseUiTest
  {
    public ReplTests(Platform platform)
      : base(platform)
    {
    }

    [Ignore("REPL test only for testing/development")]
    [Test]
    public void ReadEvailPrintLoopTest()
    {
      _app.Repl();

      // https://docs.microsoft.com/en-us/appcenter/test-cloud/uitest/working-with-repl?tabs=vswin
      // Usage:
      //  * tree    - Prints layout from the screen
    }
  }
}