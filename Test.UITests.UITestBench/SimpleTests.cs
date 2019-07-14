using NUnit.Framework;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Test.UITests.UITestBench
{
  [TestFixture(Platform.Android)]
  // [TestFixture(Platform.iOS)]
  public class SimpleTests
  {
    private IApp _app;
    private Platform _platform;

    public SimpleTests(Platform platform)
    {
      this._platform = platform;
    }

    [SetUp]
    public void BeforeEachTest()
    {
      _app = AppInitializer.StartApp(_platform);
    }

    [Test]
    public void WelcomeTextIsDisplayed()
    {
      AppResult[] results = _app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
      _app.Screenshot("Welcome screen.");

      Assert.IsTrue(results.Any());
    }

    [Test]
    public void InputAndClickTest()
    {
      _app.Tap(x => x.Marked("UserNameEntry"));

      _app.EnterText(x => x.Marked("UserNameEntry"), "TestUser");
      _app.EnterText(x => x.Marked("PasswordEntry"), "testing");

      _app.Tap(x => x.Marked("LoginButton"));

      _app.Screenshot("Tapped login");
    }
  }
}