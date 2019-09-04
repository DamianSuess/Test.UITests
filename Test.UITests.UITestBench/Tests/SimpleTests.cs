/* Copyright Xeno Innovations, Inc. 2019
 * Author:  Damian Suess
 * Date:    2019-7-12
 * File:    SampleTests.cs
 * Description:
 *  Quick sample test of unit testing AAA principals
 *
 *  AAA: Arrange, Act, Assert
 */

using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Test.UITests.UITestBench
{
  [TestFixture(Platform.Android)]
  // [TestFixture(Platform.iOS)]
  public class SimpleTests : BaseUiTest
  {
    public SimpleTests(Platform platform)
      : base(platform)
    {
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
      System.IO.Directory.SetCurrentDirectory(@"C:\Temp");
      _app.Screenshot("Generic screen shot");
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
  }
}