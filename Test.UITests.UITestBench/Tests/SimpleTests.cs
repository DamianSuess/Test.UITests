using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public void ReadEvailPrintLoopTest()
    {
      // _app.Repl();

      // https://docs.microsoft.com/en-us/appcenter/test-cloud/uitest/working-with-repl?tabs=vswin
      // Usage:
      //  * tree    - Prints layout from the screen 
    }

    [Test]
    public void WelcomeTextIsDisplayedTest()
    {
      // Arrange
      // Act
      AppResult[] results = _app.WaitForElement(c => c.Marked("Welcome to Xamarin.Forms!"));
      // SaveScreenshot();

      // Assert
      Assert.IsTrue(results.Any());
    }

    [Test]
    public void CanTakeAndSaveScreenShotTest()
    {
      // Act
      // _app.Screenshot("Generic screen shot");
    }


    [Test]
    public void CanInputUserAndPasswordTest()
    {
      // Arrange
      var pageTitle = "Welcome to Xamarin.Forms!";

      // Act
      AppResult[] results = _app.WaitForElement(c => c.Marked(pageTitle));
      _app.Tap(x => x.Marked("UserNameEntry"));

      _app.EnterText(x => x.Marked("UserNameEntry"), "TestUser");
      _app.PressEnter();

      // Must DismissKeyboard() or PressEnter(), otherwise it wont input text
      _app.EnterText(x => x.Marked("PasswordEntry"), "testing");
      _app.DismissKeyboard();

      _app.Tap(x => x.Marked("LoginButton"));

      // SaveScreenshot();

      // Assert
      Assert.IsTrue(results.Any());
    }

    [Test]
    public void CanRetypeUserNameTest()
    {
      // Arrange
      var badUser = "BadUserName";
      var goodUser = "MyUser";

      // Act
      _app.Tap(e => e.Marked("UserNameEntry"));
      _app.EnterText(badUser);
      _app.ClearText();

      _app.EnterText(goodUser);
      AppResult[] results = _app.WaitForElement(c => c.Marked(goodUser));

      // Assert
      Assert.IsTrue(results.Any());
    }

    private void SaveScreenshot(
      [CallerMemberName]string title = "",
      [CallerLineNumber]int lineNumber = -1)
    {
      FileInfo screenshot = _app.Screenshot(title);
      if (TestEnvironment.IsTestCloud == false)
      {
        File.Move(screenshot.FullName, Path.Combine(screenshot.DirectoryName,
          $"{title}-{lineNumber}{screenshot.Extension}"));
      }
    }
  }
}