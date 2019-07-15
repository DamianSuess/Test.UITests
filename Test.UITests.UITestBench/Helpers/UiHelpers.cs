/* Copyright Xeno Innovations, Inc. 2019
 * Author:  Damian Suess
 * Date:    2019-7-14
 * File:    UiHelpers.cs
 * Description:
 *  Helper functions
 *
 * Note:
 *  - SaveScreenshot may fail depending on your user permission settings. This is a known issue
 *    with Xamarin.UITest; its preferred that the user has Admin rights
 */

using System.IO;
using System.Runtime.CompilerServices;
using Xamarin.UITest;
using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

namespace Test.UITests.UITestBench.Helpers
{
  public static class UIHelpers
  {
    public static IApp AppContext { get; set; }

    public static void EnterText(Query textEntryQuery, string text, IApp app)
    {
      app.ClearText(textEntryQuery);
      app.EnterText(textEntryQuery, text);
      app.DismissKeyboard();
    }

    public static void SaveScreenshot([CallerMemberName]string title = "", [CallerLineNumber]int lineNumber = -1)
    {
      // AppContext (_app) only works if the calling class inherits from, BaseUiTest
      FileInfo screenshot = AppContext.Screenshot(title);
      if (TestEnvironment.IsTestCloud == false)
      {
        File.Move(screenshot.FullName, Path.Combine(screenshot.DirectoryName,
          $"{title}-{lineNumber}{screenshot.Extension}"));
      }
    }
  }
}